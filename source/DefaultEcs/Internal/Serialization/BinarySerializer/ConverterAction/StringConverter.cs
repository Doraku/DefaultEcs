using System;

namespace DefaultEcs.Internal.Serialization.BinarySerializer.ConverterAction
{
    internal static class StringConverter
    {
        private static void Write(in StreamWriterWrapper writer, in string value) => writer.WriteString(value);

        private static string Read(in StreamReaderWrapper reader) => reader.ReadString();

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<string>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<string>(Read));
    }
}
