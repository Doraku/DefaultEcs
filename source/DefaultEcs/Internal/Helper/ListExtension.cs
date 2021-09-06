#if NETSTANDARD1_1 || NETSTANDARD2_0
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DefaultEcs.Internal.Helper
{
    internal static class ListExtension
    {
        [SuppressMessage("Performance", "RCS1077:Optimize LINQ method call.")]
        public static List<TOutput> ConvertAll<TInput, TOutput>(this List<TInput> list, Func<TInput, TOutput> converter) => list.Select(converter).ToList();
    }
}
#endif