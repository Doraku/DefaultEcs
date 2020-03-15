using System;
using System.Diagnostics.CodeAnalysis;

namespace DefaultEcs.Technical.Serialization.BinarySerializer.ConverterAction
{
    internal static class TypeConverter
    {
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        private static void Write(in StreamWriterWrapper writer, in Type value) => writer.WriteString(TypeNames.Get(value));

        private static Type Read(in StreamReaderWrapper reader) => Type.GetType(reader.ReadString(), true);

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<Type>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<Type>(Read));
    }
}
