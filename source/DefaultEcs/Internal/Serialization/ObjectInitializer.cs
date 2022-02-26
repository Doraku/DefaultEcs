#if NETSTANDARD2_0_OR_GREATER
using System.Runtime.Serialization;
#else
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
#endif

namespace DefaultEcs.Internal.Serialization
{
    internal static class ObjectInitializer<T>
    {
#if !NETSTANDARD2_0_OR_GREATER
        private static readonly Func<Type, object> _initializer;

        static ObjectInitializer()
        {
            MethodInfo method = typeof(RuntimeHelpers).GetRuntimeMethod("GetUninitializedObject", new[] { typeof(Type) });

            _initializer = method != null ? (Func<Type, object>)method.CreateDelegate(typeof(Func<Type, object>)) : Activator.CreateInstance;
        }
#endif

        public static T Create()
        {
#if NETSTANDARD2_0_OR_GREATER
            return (T)FormatterServices.GetUninitializedObject(typeof(T));
#else
            return (T)_initializer(typeof(T));
#endif
        }
    }
}
