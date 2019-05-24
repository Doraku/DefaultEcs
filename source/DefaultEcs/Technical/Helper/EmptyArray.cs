#if !NETSTANDARD1_1
using System;
#endif

namespace DefaultEcs.Technical.Helper
{
    internal static class EmptyArray<T>
    {
#if NETSTANDARD1_1
        public static T[] Value { get; } = new T[0];
#else
        public static T[] Value => Array.Empty<T>();
#endif
    }
}
