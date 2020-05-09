using System;
using System.Diagnostics.CodeAnalysis;

namespace DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction
{
    internal static class StringConverter
    {
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        private static void Write(StreamWriterWrapper writer, in string value) => writer.Stream.WriteLine(value);

        private static string Read(StreamReaderWrapper reader) => reader.ReadLine();

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<string>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<string>(Read));
    }
}
