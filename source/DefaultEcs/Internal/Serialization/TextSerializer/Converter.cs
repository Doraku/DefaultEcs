using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Serialization.TextSerializer
{
    internal static unsafe class Converter
    {
        #region Types

        private interface IReadActionWrapper
        {
            ReadAction<T> Get<T>(TextSerializationContext context);
        }

        private sealed class ClassReadActionWrapper<TReal> : IReadActionWrapper
        {
            private readonly ReadAction<TReal> _readAction;

            public ClassReadActionWrapper(ReadAction<TReal> readAction)
            {
                _readAction = readAction;
            }

            public ReadAction<T> Get<T>(TextSerializationContext context) => context?.GetValueRead<TReal, T>() ?? (ReadAction<T>)(Delegate)_readAction;
        }

        private sealed class StructReadActionWrapper<TReal> : IReadActionWrapper
            where TReal : struct
        {
            private readonly ReadAction<TReal> _readAction;

            public StructReadActionWrapper(Delegate readAction)
            {
                _readAction = (ReadAction<TReal>)readAction;
            }

            public ReadAction<T> Get<T>(TextSerializationContext context) => context?.GetValueRead<TReal, T>() ?? (typeof(TReal) == typeof(T)
                ? (ReadAction<T>)(Delegate)_readAction
                : ((StreamReaderWrapper r) => (T)(object)_readAction(r)));
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, WriteAction<object>> _writeActions = new();
        private static readonly ConcurrentDictionary<Type, IReadActionWrapper> _readActions = new();

        #endregion

        #region Methods

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

        public static ReadAction<T> GetReadAction<T>(Type type, TextSerializationContext context)
        {
            if (!_readActions.TryGetValue(type, out IReadActionWrapper readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(type))
                    {
                        TypeInfo typeInfo = type.GetTypeInfo();

                        readAction = (IReadActionWrapper)Activator.CreateInstance(
                            (type.GetTypeInfo().IsValueType ? typeof(StructReadActionWrapper<>) : typeof(ClassReadActionWrapper<>)).MakeGenericType(type),
                            typeof(Converter<>)
                                .MakeGenericType(type).GetTypeInfo()
                                .GetDeclaredMethod(nameof(Converter<string>.Read))
                                .CreateDelegate(typeof(ReadAction<>).MakeGenericType(type)));

                        _readActions.AddOrUpdate(type, readAction, (_, d) => d);
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
                Type type when type.IsArray => ArrayConverter.GetActions<T>(),
                Type type when type.IsList() => ListConverter.GetActions<T>(),
                Type type when type.IsDictionary() => DictionaryConverter.GetActions<T>(),
                Type type when type.IsEnum() => EnumConverter.GetActions<T>(),
                Type type when type == typeof(char) => GetActions((StreamWriterWrapper w, in char v) => w.Stream.WriteLine(v), s => s[0]),
                Type type when type == typeof(bool) => GetActions((StreamWriterWrapper w, in bool v) => w.Stream.WriteLine(v), bool.Parse),
                Type type when type == typeof(sbyte) => GetActions((StreamWriterWrapper w, in sbyte v) => w.Stream.WriteLine(v), i => sbyte.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(byte) => GetActions((StreamWriterWrapper w, in byte v) => w.Stream.WriteLine(v), i => byte.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(short) => GetActions((StreamWriterWrapper w, in short v) => w.Stream.WriteLine(v), i => short.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(ushort) => GetActions((StreamWriterWrapper w, in ushort v) => w.Stream.WriteLine(v), i => ushort.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(int) => GetActions((StreamWriterWrapper w, in int v) => w.Stream.WriteLine(v), i => int.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(uint) => GetActions((StreamWriterWrapper w, in uint v) => w.Stream.WriteLine(v), i => uint.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(long) => GetActions((StreamWriterWrapper w, in long v) => w.Stream.WriteLine(v), i => long.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(ulong) => GetActions((StreamWriterWrapper w, in ulong v) => w.Stream.WriteLine(v), i => ulong.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(decimal) => GetActions((StreamWriterWrapper w, in decimal v) => w.Stream.WriteLine(v), i => decimal.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(double) => GetActions((StreamWriterWrapper w, in double v) => w.Stream.WriteLine(v), i => double.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(float) => GetActions((StreamWriterWrapper w, in float v) => w.Stream.WriteLine(v), i => float.Parse(i, provider: CultureInfo.InvariantCulture)),
                Type type when type == typeof(string) => StringConverter.GetActions<T>(),
                Type type when type == typeof(Guid) => GuidConverter.GetActions<T>(),
                _ => ObjectConverter<T>.GetActions()
            };
        }

        #endregion

        #region Methods

        private static (WriteAction<T>, ReadAction<T>) GetActions<TReal>(WriteAction<TReal> write, Parse<TReal> read) => (
            (WriteAction<T>)(Delegate)write,
            (ReadAction<T>)(Delegate)new ReadAction<TReal>(reader => read(reader.Read())));

        public static void Write(StreamWriterWrapper writer, in T value)
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

        public static T Read(StreamReaderWrapper reader)
        {
            ReadAction<T> action = reader.Context?.GetValueRead<T, T>();

            return action is null ? reader.ReadValue<T>() : action(reader);
        }

        public static void WrappedWrite(StreamWriterWrapper writer, in object value) => Write(writer, (T)value);

        #endregion
    }
}
