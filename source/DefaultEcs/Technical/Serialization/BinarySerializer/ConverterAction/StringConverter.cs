using System;
using System.Diagnostics.CodeAnalysis;

namespace DefaultEcs.Technical.Serialization.BinarySerializer.ConverterAction
{
    internal static class StringConverter
    {
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        private static void Write(in StreamWriterWrapper writer, in string value) => writer.WriteString(value);

        private static string Read(in StreamReaderWrapper reader) => reader.ReadString();

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<string>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<string>(Read));
    }
}
