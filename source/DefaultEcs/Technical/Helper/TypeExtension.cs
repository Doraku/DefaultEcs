using System;
using System.Linq;
using System.Reflection;

namespace DefaultEcs.Technical.Helper
{
    internal static class TypeExtension
    {
        public static bool IsUnmanaged(this Type type)
        {
            TypeInfo info = type.GetTypeInfo();

            return info.IsEnum || (info.IsValueType && (info.IsPrimitive || info.DeclaredFields.Where(f => !f.IsStatic).All(f => f.FieldType.IsUnmanaged())));
        }
    }
}
