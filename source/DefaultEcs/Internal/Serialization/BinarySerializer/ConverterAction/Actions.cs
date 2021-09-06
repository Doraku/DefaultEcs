namespace DefaultEcs.Internal.Serialization.BinarySerializer.ConverterAction
{
    internal delegate void WriteAction<T>(in StreamWriterWrapper writer, in T value);

    internal delegate T ReadAction<out T>(in StreamReaderWrapper reader);
}
