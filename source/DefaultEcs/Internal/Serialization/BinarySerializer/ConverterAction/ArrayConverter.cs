using System.Reflection;

namespace DefaultEcs.Internal.Serialization.BinarySerializer.ConverterAction
{
    internal static class ArrayConverter
    {
        private static readonly MethodInfo _writeMethod = typeof(ArrayConverter).GetTypeInfo().GetDeclaredMethod(nameof(Write));
        private static readonly MethodInfo _readMethod = typeof(ArrayConverter).GetTypeInfo().GetDeclaredMethod(nameof(Read));

        private static void Write<T>(in StreamWriterWrapper writer, in T[] value)
        {
            writer.Write(value.Length);
            for (int i = 0; i < value.Length; ++i)
            {
                Converter<T>.Write(writer, value[i]);
            }
        }

        private static T[] Read<T>(in StreamReaderWrapper reader)
        {
            int length = reader.Read<int>();
            if (length == 0)
            {
                return EmptyArray<T>.Value;
            }

            T[] value = new T[length];
            for (int i = 0; i < value.Length; ++i)
            {
                value[i] = Converter<T>.Read(reader);
            }

            return value;
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)_writeMethod.MakeGenericMethod(typeof(T).GetElementType()).CreateDelegate(typeof(WriteAction<T>)),
            (ReadAction<T>)_readMethod.MakeGenericMethod(typeof(T).GetElementType()).CreateDelegate(typeof(ReadAction<T>)));
    }
}
