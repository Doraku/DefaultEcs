using System;

namespace DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction
{
    internal static class StringConverter
    {
        private static void Write(StreamWriterWrapper writer, in string value)
        {
            writer.Write("\"");
            writer.Write(value.IndexOf('"') >= 0 ? value.Replace("\"", "\"\"") : value);
            writer.WriteLine("\"");
        }

        private static string Read(StreamReaderWrapper reader) => reader.ReadString();

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<string>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<string>(Read));
    }
}
