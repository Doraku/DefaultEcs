using System;
using System.Collections.Concurrent;
using System.Reflection;
using DefaultEcs.Internal.Serialization.BinarySerializer.ConverterAction;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Serialization.BinarySerializer
{
    internal static class Converter
    {
        #region Types

        private interface IReadActionWrapper
        {
            ReadAction<T> Get<T>(BinarySerializationContext context);
        }

        private sealed class ClassReadActionWrapper<TReal> : IReadActionWrapper
        {
            private readonly ReadAction<TReal> _readAction;

            public ClassReadActionWrapper(ReadAction<TReal> readAction)
            {
                _readAction = readAction;
            }

            public ReadAction<T> Get<T>(BinarySerializationContext context) => context?.GetValueRead<TReal, T>() ?? (ReadAction<T>)(Delegate)_readAction;
        }

        private sealed class StructReadActionWrapper<TReal> : IReadActionWrapper
            where TReal : struct
        {
            private readonly ReadAction<TReal> _readAction;

            public StructReadActionWrapper(Delegate readAction)
            {
                _readAction = (ReadAction<TReal>)readAction;
            }

            public ReadAction<T> Get<T>(BinarySerializationContext context) => context?.GetValueRead<TReal, T>() ?? (typeof(TReal) == typeof(T)
                ? (ReadAction<T>)(Delegate)_readAction
                : ((in StreamReaderWrapper r) => (T)(object)_readAction(r)));
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<string, WriteAction<object>> _writeActions = new();
        private static readonly ConcurrentDictionary<string, IReadActionWrapper> _readActions = new();

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
                            .GetDeclaredMethod(nameof(Converter<string>.WrappedWrite))
                            .CreateDelegate(typeof(WriteAction<object>));

                        _writeActions.AddOrUpdate(typeName, writeAction, (_, d) => d);
                    }
                }
            }

            return writeAction;
        }

        public static ReadAction<T> GetReadAction<T>(string typeName, BinarySerializationContext context)
        {
            if (!_readActions.TryGetValue(typeName, out IReadActionWrapper readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(typeName))
                    {
                        Type type = Type.GetType(typeName, true);

                        readAction = (IReadActionWrapper)Activator.CreateInstance(
                            (type.GetTypeInfo().IsValueType ? typeof(StructReadActionWrapper<>) : typeof(ClassReadActionWrapper<>)).MakeGenericType(type),
                            typeof(Converter<>)
                                .MakeGenericType(type).GetTypeInfo()
                                .GetDeclaredMethod(nameof(Converter<string>.Read))
                                .CreateDelegate(typeof(ReadAction<>).MakeGenericType(type)));

                        _readActions.AddOrUpdate(typeName, readAction, (_, d) => d);
                    }
                }
            }

            return readAction.Get<T>(context);
        }

        #endregion
    }

    internal static class Converter<T>
    {
        #region Fields

        public static readonly bool IsSealed;
        public static readonly WriteAction<T> WriteAction;
        public static readonly ReadAction<T> ReadAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            IsSealed = typeof(T).GetTypeInfo().IsSealed || typeof(T) == typeof(Type);

            (WriteAction, ReadAction) = typeof(T) switch
            {
                Type type when type == typeof(Type) => TypeConverter.GetActions<T>(),
                Type type when type.IsAbstract() => (null, null),
                Type type when type.IsArray && type.GetElementType().IsUnmanaged() => UnmanagedConverter.GetArrayActions<T>(),
                Type type when type.IsArray => ArrayConverter.GetActions<T>(),
                Type type when type.IsUnmanaged() => UnmanagedConverter.GetActions<T>(),
                Type type when type == typeof(string) => StringConverter.GetActions<T>(),
                _ => ManagedConverter.GetActions<T>()
            };
        }

        #endregion

        #region Methods

        public static void Write(in StreamWriterWrapper writer, in T value)
        {
            WriteAction<T> action = writer.Context?.GetValueWrite<T>();
            if (action is null)
            {
                writer.WriteValue(value);
            }
            else
            {
                action(writer, value);
            }
        }

        public static T Read(in StreamReaderWrapper reader)
        {
            ReadAction<T> action = reader.Context?.GetValueRead<T, T>();

            return action is null ? reader.ReadValue<T>() : action(reader);
        }

        public static void WrappedWrite(in StreamWriterWrapper writer, in object value) => Write(writer, (T)value);

        #endregion
    }
}
