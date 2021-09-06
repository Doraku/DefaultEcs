using System;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class GuidConverter
    {
        private static Guid Read(StreamReaderWrapper reader) => Guid.Parse(reader.ReadString());

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            static (StreamWriterWrapper writer, in T value) => writer.WriteLine(value.ToString()),
            (ReadAction<T>)(Delegate)new ReadAction<Guid>(Read));
    }
}
