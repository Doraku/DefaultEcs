namespace DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction
{
    internal delegate void WriteAction<T>(StreamWriterWrapper writer, in T value);

    internal delegate T ReadAction<out T>(StreamReaderWrapper reader);
}
