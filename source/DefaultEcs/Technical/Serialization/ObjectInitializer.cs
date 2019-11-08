using System;
using System.Reflection;
using System.Runtime.CompilerServices;
#if !NETSTANDARD1_1
using System.Runtime.Serialization;
#endif

namespace DefaultEcs.Technical.Serialization
{
    internal static class ObjectInitializer<T>
    {
#if NETSTANDARD1_1
        private static readonly Func<Type, object> _initializer;

        static ObjectInitializer()
        {
            MethodInfo method = typeof(RuntimeHelpers).GetRuntimeMethod("GetUninitializedObject", new[] { typeof(Type) });

            _initializer = method != null ? (Func<Type, object>)method.CreateDelegate(typeof(Func<Type, object>)) : Activator.CreateInstance;
        }
#endif

        public static T Create()
        {
#if NETSTANDARD1_1
            return (T)_initializer(typeof(T));
#else
            return (T)FormatterServices.GetUninitializedObject(typeof(T));
#endif
        }
    }
}
