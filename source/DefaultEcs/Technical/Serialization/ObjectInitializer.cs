using System;
#if NETSTANDARD1_1
using System.Reflection;
using System.Runtime.CompilerServices;
#else
using System.Runtime.Serialization;
#endif

namespace DefaultEcs.Technical.Serialization
{
    internal static class ObjectInitializer
    {
#if NETSTANDARD1_1
        private static readonly Func<Type, object> _initializer;

        static ObjectInitializer()
        {
            MethodInfo method = typeof(RuntimeHelpers).GetRuntimeMethod("GetUninitializedObject", new[] { typeof(Type) })
                    ?? typeof(Activator).GetRuntimeMethod(nameof(Activator.CreateInstance), new[] { typeof(Type) });
            _initializer = (Func<Type, object>)method.CreateDelegate(typeof(Func<Type, object>));
        }
#endif

        public static object Create(Type type)
        {
#if NETSTANDARD1_1
            return _initializer(type);
#else
            return FormatterServices.GetUninitializedObject(type);
#endif
        }
    }
}
