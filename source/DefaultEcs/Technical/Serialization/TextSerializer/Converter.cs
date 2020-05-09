using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal static unsafe class Converter
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

            public ReadAction<T> Get<T>() => typeof(TReal) == typeof(T)
                ? (ReadAction<T>)(Delegate)_readAction
                : r => (T)(object)_readAction(r);
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, WriteAction<object>> _writeActions = new ConcurrentDictionary<Type, WriteAction<object>>();
        private static readonly ConcurrentDictionary<Type, IReadActionWrapper> _readActions = new ConcurrentDictionary<Type, IReadActionWrapper>();

        #endregion

        #region Methods

        public static ReadAction<T> ConvertRead<T>(Delegate readAction) => (ReadAction<T>)readAction;

        public static WriteAction<object> GetWriteAction(Type type)
        {
            if (!_writeActions.TryGetValue(type, out WriteAction<object> writeAction))
            {
                lock (_writeActions)
                {
                    if (!_writeActions.ContainsKey(type))
                    {
                        writeAction = (WriteAction<object>)typeof(Converter<>).MakeGenericType(type).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.WrappedWrite))
                            .CreateDelegate(typeof(WriteAction<object>));

                        _writeActions.AddOrUpdate(type, writeAction, (_, d) => d);
                    }
                }
            }

            return writeAction;
        }

        public static ReadAction<T> GetReadAction<T>(Type type)
        {
            if (!_readActions.TryGetValue(type, out IReadActionWrapper readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(type))
                    {
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

                        _readActions.AddOrUpdate(type, readAction, (_, d) => d);
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

        private static readonly bool _isSealed;

        public static readonly WriteAction<T> WriteAction;
        public static readonly ReadAction<T> ReadAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            _isSealed = typeof(T).GetTypeInfo().IsSealed || typeof(T) == typeof(Type);

            (WriteAction, ReadAction) = typeof(T) switch
            {
                Type type when type.GetTypeInfo().IsEnum => EnumConverter.GetActions<T>(),
                Type type when type == typeof(Type) => TypeConverter.GetActions<T>(),
                Type type when type == typeof(string) => StringConverter.GetActions<T>(),
                Type type when type == typeof(char) => GetActions((StreamWriterWrapper w, in char v) => w.Stream.WriteLine(v), s => char.TryParse(s, out char value) ? value : throw StreamReaderWrapper.GetException<char>()),
                Type type when type.IsArray => ArrayConverter.GetActions<T>(),
                Type type when type == typeof(bool) => GetActions((StreamWriterWrapper w, in bool v) => w.Stream.WriteLine(v), bool.Parse),
                Type type when type == typeof(sbyte) => GetActions((StreamWriterWrapper w, in sbyte v) => w.Stream.WriteLine(v), sbyte.Parse),
                Type type when type == typeof(byte) => GetActions((StreamWriterWrapper w, in byte v) => w.Stream.WriteLine(v), byte.Parse),
                Type type when type == typeof(short) => GetActions((StreamWriterWrapper w, in short v) => w.Stream.WriteLine(v), short.Parse),
                Type type when type == typeof(ushort) => GetActions((StreamWriterWrapper w, in ushort v) => w.Stream.WriteLine(v), ushort.Parse),
                Type type when type == typeof(int) => GetActions((StreamWriterWrapper w, in int v) => w.Stream.WriteLine(v), int.Parse),
                Type type when type == typeof(uint) => GetActions((StreamWriterWrapper w, in uint v) => w.Stream.WriteLine(v), uint.Parse),
                Type type when type == typeof(long) => GetActions((StreamWriterWrapper w, in long v) => w.Stream.WriteLine(v), long.Parse),
                Type type when type == typeof(ulong) => GetActions((StreamWriterWrapper w, in ulong v) => w.Stream.WriteLine(v), ulong.Parse),
                Type type when type == typeof(decimal) => GetActions((StreamWriterWrapper w, in decimal v) => w.Stream.WriteLine(v), decimal.Parse),
                Type type when type == typeof(double) => GetActions((StreamWriterWrapper w, in double v) => w.Stream.WriteLine(v), double.Parse),
                Type type when type == typeof(float) => GetActions((StreamWriterWrapper w, in float v) => w.Stream.WriteLine(v), float.Parse),
                Type type when type.GetTypeInfo().IsAbstract => (null, null),
                _ => ObjectConverter<T>.GetActions()
            };
        }

        #endregion

        #region Methods

        private static (WriteAction<T>, ReadAction<T>) GetActions<TReal>(WriteAction<TReal> write, Func<string, TReal> read) => (
            (WriteAction<T>)(Delegate)write,
            (ReadAction<T>)(Delegate)new ReadAction<TReal>(reader => read(reader.ReadValue())));

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void Write(StreamWriterWrapper writer, in T value)
        {
            if (value is null)
            {
                writer.Stream.WriteLine("null");
            }
            else if (_isSealed || typeof(T) == value.GetType())
            {
                WriteAction(writer, value);
            }
            else
            {
                Type type = value.GetType();
                writer.Stream.WriteLine($"$type {TypeNames.Get(type)}");
                Converter.GetWriteAction(type)(writer, value);
            }
        }

        public static T Read(StreamReaderWrapper reader)
        {
            switch (reader.PeekValue())
            {
                case "null":
                    reader.ReadValue();
                    return default;

                case "$type":
                    reader.ReadValue();
                    return Converter.GetReadAction<T>(Type.GetType(reader.ReadLine(), true))(reader);

                default:
                    return ReadAction(reader);
            }
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void WrappedWrite(StreamWriterWrapper writer, in object value) => Write(writer, (T)value);

        #endregion
    }
}
