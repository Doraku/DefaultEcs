using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DefaultEcs.Internal.Serialization
{
    internal static class TypeNames
    {
        #region Fields

        private static readonly ConcurrentDictionary<Type, string> _typeNames;

        #endregion

        #region Initialisation

        static TypeNames()
        {
            _typeNames = new ConcurrentDictionary<Type, string>();
        }

        #endregion

        #region Methods

        private static void WriteName(StringBuilder builder, Type type, bool writeNameSpace, bool writeAssembly)
        {
            if (type.IsArray)
            {
                WriteName(builder, type.GetElementType(), writeNameSpace, false);
                builder.Append('[');
                foreach (char c in Enumerable.Repeat(',', type.GetArrayRank() - 1))
                {
                    builder.Append(c);
                }
                builder.Append(']');
            }
            else
            {
                if (writeNameSpace)
                {
                    builder.Append(type.Namespace).Append('.');
                }
                if (type.DeclaringType != null)
                {
                    WriteName(builder, type.DeclaringType, false, false);
                    builder.Append('+');
                }
                builder.Append(type.Name);

                if (type.GenericTypeArguments.Length > 0)
                {
                    builder.Append('[');
                    foreach (Type generic in type.GenericTypeArguments)
                    {
                        builder.Append('[');
                        WriteName(builder, generic, true, true);
                        builder.Append(']').Append(',');
                    }
                    --builder.Length;
                    builder.Append(']');
                }
            }

            if (writeAssembly)
            {
                builder.Append(',').Append(' ').Append(type.GetTypeInfo().Assembly.GetName().Name);
            }
        }

        private static string GetName(Type type)
        {
            StringBuilder builder = new();

            WriteName(builder, type, true, true);

            return builder.ToString();
        }

        public static string Get(Type type) => _typeNames.GetOrAdd(type, GetName);

        #endregion
    }
}
