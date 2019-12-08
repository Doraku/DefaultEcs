using System;
using System.Collections.Concurrent;
using System.Reflection;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Serialization.BinarySerializer.ConverterAction;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static class Converter
    {
        #region Types

        private interface IReadActionWrapper
        {
            ReadAction<T> Get<T>();
        }

        private sealed class ClassReadActionWrapper : IReadActionWrapper
        {
            private readonly Delegate _readAction;

            public ClassReadActionWrapper(Delegate readAction)
            {
                _readAction = readAction;
            }

            public ReadAction<T> Get<T>() => (ReadAction<T>)_readAction;
        }

        private sealed class StructReadActionWrapper<TReal> : IReadActionWrapper
            where TReal : struct
        {
            private readonly ReadAction<TReal> _readAction;

            public StructReadActionWrapper(Delegate readAction)
            {
                _readAction = (ReadAction<TReal>)readAction;
            }

            public ReadAction<T> Get<T>() => typeof(TReal) == typeof(T)
                ? (ReadAction<T>)(Delegate)_readAction
                : ((in StreamReaderWrapper r) => (T)(object)_readAction(r));
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<string, WriteAction<object>> _writeActions = new ConcurrentDictionary<string, WriteAction<object>>();
        private static readonly ConcurrentDictionary<string, IReadActionWrapper> _readActions = new ConcurrentDictionary<string, IReadActionWrapper>();

        #endregion

        #region Methods

        public static WriteAction<object> GetWriteAction(string typeName)
        {
            if (!_writeActions.TryGetValue(typeName, out WriteAction<object> writeAction))
            {
                lock (_writeActions)
                {
                    if (!_writeActions.ContainsKey(typeName))
                    {
                        writeAction = (WriteAction<object>)typeof(Converter<>).MakeGenericType(Type.GetType(typeName, true)).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.WrapperWrite))
                            .CreateDelegate(typeof(WriteAction<object>));

                        _writeActions.AddOrUpdate(typeName, writeAction, (_, d) => d);
                    }
                }
            }

            return writeAction;
        }

        public static ReadAction<T> GetReadAction<T>(string typeName)
        {
            if (!_readActions.TryGetValue(typeName, out IReadActionWrapper readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(typeName))
                    {
                        Type type = Type.GetType(typeName, true);

                        Delegate action = (Delegate)typeof(Converter<>).MakeGenericType(type).GetTypeInfo()
                            .GetDeclaredField(nameof(Converter<string>.ReadAction)).GetValue(null);

                        readAction = !type.GetTypeInfo().IsValueType
                            ? new ClassReadActionWrapper(action)
                            : (IReadActionWrapper)Activator.CreateInstance(typeof(StructReadActionWrapper<>).MakeGenericType(type), action);

                        _readActions.AddOrUpdate(typeName, readAction, (_, d) => d);
                    }
                }
            }

            return readAction.Get<T>();
        }

        #endregion
    }

    internal static class Converter<T>
    {
        #region Fields

        private static readonly bool _isValue;
        private static readonly bool _isSealed;

        public static readonly WriteAction<T> WriteAction;
        public static readonly ReadAction<T> ReadAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            _isValue = typeof(T).GetTypeInfo().IsValueType;
            _isSealed = typeof(T).GetTypeInfo().IsSealed || typeof(T) == typeof(Type);

            (WriteAction, ReadAction) = typeof(T) switch
            {
                Type type when type == typeof(Type) => TypeConverter.GetActions<T>(),
                Type type when type.GetTypeInfo().IsAbstract => (null, null),
                Type type when type == typeof(string) => StringConverter.GetActions<T>(),
                Type type when type.IsUnmanaged() => UnmanagedConverter.GetActions<T>(),
                Type type when type.IsArray && type.GetElementType().IsUnmanaged() => UnmanagedConverter.GetArrayActions<T>(),
                Type type when type.IsArray => ArrayConverter.GetActions<T>(),
                _ => ManagedConverter.GetActions<T>()
            };
        }

        #endregion

        #region Methods

        public static void Write(in StreamWriterWrapper writer, in T value)
        {
            if (_isValue)
            {
                WriteAction(writer, value);
            }
            else if (value is null)
            {
                writer.WriteByte(0);
            }
            else if (_isSealed || value.GetType() == typeof(T))
            {
                writer.WriteByte(1);
                WriteAction(writer, value);
            }
            else
            {
                writer.WriteByte(2);
                string typeName = value.GetType().AssemblyQualifiedName;
                writer.WriteString(typeName);
                Converter.GetWriteAction(typeName)(writer, value);
            }
        }

        public static T Read(in StreamReaderWrapper reader) => _isValue ? ReadAction(reader) : (reader.ReadByte()) switch
        {
            0 => default,
            1 => ReadAction(reader),
            2 => Converter.GetReadAction<T>(reader.ReadString())(reader),
            _ => throw StreamReaderWrapper.GetException<T>(),
        };

        public static void WrapperWrite(in StreamWriterWrapper writer, in object value) => WriteAction(writer, (T)value);

        #endregion
    }
}
