using System.Collections.Generic;
using System.Reflection;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class ArrayConverter
    {
        private const string _arrayBegin = "[";
        private const string _arrayEnd = "]";

        private static readonly MethodInfo _writeMethod = typeof(ArrayConverter).GetTypeInfo().GetDeclaredMethod(nameof(Write));
        private static readonly MethodInfo _readMethod = typeof(ArrayConverter).GetTypeInfo().GetDeclaredMethod(nameof(Read));

        private static void Write<T>(StreamWriterWrapper writer, in T[] value)
        {
            writer.WriteLine(_arrayBegin);
            writer.AddIndentation();
            for (int i = 0; i < value.Length; ++i)
            {
                writer.WriteIndentation();
                Converter<T>.Write(writer, value[i]);
            }
            writer.RemoveIndentation();
            writer.WriteIndentation();
            writer.WriteLine(_arrayEnd);
        }

        private static T[] Read<T>(StreamReaderWrapper reader)
        {
            if (!reader.TryReadUntil(_arrayBegin))
            {
                StreamReaderWrapper.Throw<T[]>();
            }

            List<T> value = new();
            while (!reader.EndOfStream && !reader.TryPeek(_arrayEnd))
            {
                value.Add(Converter<T>.Read(reader));
            }

            return value.ToArray();
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)_writeMethod.MakeGenericMethod(typeof(T).GetElementType()).CreateDelegate(typeof(WriteAction<T>)),
            (ReadAction<T>)_readMethod.MakeGenericMethod(typeof(T).GetElementType()).CreateDelegate(typeof(ReadAction<T>)));
    }
}
