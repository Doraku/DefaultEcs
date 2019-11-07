using System;
using System.Collections.Concurrent;
using System.IO;
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

        private class ClassReadActionWrapper : IReadActionWrapper
        {
            private readonly Delegate _readAction;

            public ClassReadActionWrapper(Delegate readAction)
            {
                _readAction = readAction;
            }

            public ReadAction<T> Get<T>() => (ReadAction<T>)_readAction;
        }

        private class StructReadActionWrapper<TReal> : IReadActionWrapper
        {
            private readonly ReadAction<TReal> _readAction;

            public StructReadActionWrapper(Delegate readAction)
            {
                _readAction = (ReadAction<TReal>)readAction;
            }

            public ReadAction<T> Get<T>()
            {
                if (typeof(TReal) == typeof(T))
                {
                    return (ReadAction<T>)(Delegate)_readAction;
                }

                return (in StreamReaderWrapper r) => (T)(object)_readAction(r);
            }
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
                        TypeInfo typeInfo = type.GetTypeInfo();

                        Delegate action = typeof(Converter<>).MakeGenericType(type).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.Read))
                            .CreateDelegate(typeof(ReadAction<>).MakeGenericType(type));

                        if (!typeInfo.IsValueType || type == typeof(T))
                        {
                            readAction = typeInfo.IsValueType ? (IReadActionWrapper)new StructReadActionWrapper<T>(action) : new ClassReadActionWrapper(action);
                        }
                        else
                        {
                            readAction = (IReadActionWrapper)Activator.CreateInstance(typeof(StructReadActionWrapper<>).MakeGenericType(type), action);
                        }

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

        private static readonly WriteAction<T> _writeAction;
        private static readonly ReadAction<T> _readAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            (_writeAction, _readAction) = typeof(T) switch
            {
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
            if (value == default)
            {
                writer.WriteByte(0);
            }
            else if (value.GetType() == typeof(T))
            {
                writer.WriteByte(1);
                _writeAction(writer, value);
            }
            else
            {
                writer.WriteByte(2);
                string typeName = value.GetType().AssemblyQualifiedName;
                writer.WriteString(typeName);
                Converter.GetWriteAction(typeName)(writer, value);
            }
        }

        public static T Read(in StreamReaderWrapper reader)
        {
            return (reader.ReadByte()) switch
            {
                -1 => throw new EndOfStreamException($"Could not deserialize type {typeof(T).FullName}"),
                0 => default,
                1 => _readAction(reader),
                _ => Converter.GetReadAction<T>(reader.ReadString())(reader),
            };
        }

        public static void WrapperWrite(in StreamWriterWrapper writer, in object value) => Write(writer, (T)value);

        #endregion
    }
}
