using System.Runtime.CompilerServices;

namespace System
{
    internal static class ObjectExtension
    {
        public static T ThrowIfNull<T>(this T instance, [CallerArgumentExpression(nameof(instance))] string paramName = default) => instance ?? throw new ArgumentNullException(paramName);
    }
}
