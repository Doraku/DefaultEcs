using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace DefaultEcs.Technical.Serialization.TextSerializer.ConverterAction
{
    internal static class ArrayConverter
    {
        private const string _arrayBegin = "[";
        private const string _arrayEnd = "]";

        private static readonly MethodInfo _writeMethod = typeof(ArrayConverter).GetTypeInfo().GetDeclaredMethod(nameof(Write));
        private static readonly MethodInfo _readMethod = typeof(ArrayConverter).GetTypeInfo().GetDeclaredMethod(nameof(Read));

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        private static void Write<T>(StreamWriterWrapper writer, in T[] value)
        {
            writer.Stream.WriteLine(_arrayBegin);
            writer.AddIndentation();
            for (int i = 0; i < value.Length; ++i)
            {
                writer.WriteIndentation();
                Converter<T>.Write(writer, value[i]);
            }
            writer.RemoveIndentation();
            writer.WriteIndentation();
            writer.Stream.WriteLine(_arrayEnd);
        }

        private static T[] Read<T>(StreamReaderWrapper reader)
        {
            if (!reader.TryReadUntil(_arrayBegin))
            {
                StreamReaderWrapper.Throw<T[]>();
            }

            List<T> value = new List<T>();
            while (!reader.EndOfStream && reader.PeekValue() != _arrayEnd)
            {
                if (string.IsNullOrEmpty(reader.PeekValue()))
                {
                    reader.ReadValue();
                    continue;
                }

                value.Add(Converter<T>.Read(reader));
            }

            return value.ToArray();
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)_writeMethod.MakeGenericMethod(typeof(T).GetElementType()).CreateDelegate(typeof(WriteAction<T>)),
            (ReadAction<T>)_readMethod.MakeGenericMethod(typeof(T).GetElementType()).CreateDelegate(typeof(ReadAction<T>)));
    }
}
