using System;

namespace DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction
{
    internal delegate void WriteAction<T>(StreamWriterWrapper writer, in T value);

    internal delegate T ReadAction<out T>(StreamReaderWrapper reader);

#if NETSTANDARD1_1 || NETSTANDARD2_0
    internal delegate T Parse<T>(string value);
#else
    internal delegate T Parse<T>(ReadOnlySpan<char> input);
#endif
}
