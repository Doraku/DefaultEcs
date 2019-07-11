using System;
using System.Linq;
using System.Reflection;

namespace DefaultEcs.Technical.Helper
{
    internal static class TypeExtension
    {
        public static bool IsFlagType(this TypeInfo typeInfo) => typeInfo.IsValueType && !typeInfo.IsEnum && !typeInfo.IsPrimitive && typeInfo.DeclaredFields.All(f => f.IsStatic);

        public static bool IsUnmanaged(this TypeInfo typeInfo)
        {
            return typeInfo.IsEnum || (typeInfo.IsValueType && (typeInfo.IsPrimitive || typeInfo.DeclaredFields.Where(f => !f.IsStatic).All(f => f.FieldType.IsUnmanaged())));
        }

        public static bool IsUnmanaged(this Type type) => type.GetTypeInfo().IsUnmanaged();
    }
}
