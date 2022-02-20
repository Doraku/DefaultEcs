#if !NETSTANDARD2_1_OR_GREATER
using System.Linq;

namespace System.Collections.Generic
{
    internal static class ListExtension
    {
        [Diagnostics.CodeAnalysis.SuppressMessage("Performance", "RCS1077:Optimize LINQ method call.")]
        public static List<TOutput> ConvertAll<TInput, TOutput>(this List<TInput> list, Func<TInput, TOutput> converter) => list.Select(converter).ToList();
    }
}
#endif