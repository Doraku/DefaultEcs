#if NETSTANDARD2_1_OR_GREATER
using System;
#endif

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal delegate void WriteAction<T>(StreamWriterWrapper writer, in T value);

    internal delegate T ReadAction<out T>(StreamReaderWrapper reader);

#if NETSTANDARD2_1_OR_GREATER
    internal delegate T Parse<T>(ReadOnlySpan<char> input);
#else
    internal delegate T Parse<T>(string value);
#endif
}
