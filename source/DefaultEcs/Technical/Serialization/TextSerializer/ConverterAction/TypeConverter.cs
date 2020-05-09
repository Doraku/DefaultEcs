using System;
using System.Diagnostics.CodeAnalysis;

namespace DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction
{
    internal static class TypeConverter
    {
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        private static void Write(StreamWriterWrapper writer, in Type value) => writer.Stream.WriteLine(TypeNames.Get(value));

        private static Type Read(StreamReaderWrapper reader) => Type.GetType(reader.ReadLine(), true);

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<Type>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<Type>(Read));
    }
}
