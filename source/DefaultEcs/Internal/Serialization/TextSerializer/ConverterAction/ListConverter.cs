using System.Collections.Generic;
using System.Reflection;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class ListConverter
    {
        private const string _listBegin = "[";
        private const string _listEnd = "]";

        private static readonly MethodInfo _writeMethod = typeof(ListConverter).GetTypeInfo().GetDeclaredMethod(nameof(Write));
        private static readonly MethodInfo _readMethod = typeof(ListConverter).GetTypeInfo().GetDeclaredMethod(nameof(Read));

        private static void Write<T>(StreamWriterWrapper writer, in List<T> value)
        {
            writer.WriteLine(_listBegin);
            writer.AddIndentation();
            foreach (T item in value)
            {
                writer.WriteIndentation();
                Converter<T>.Write(writer, item);
            }
            writer.RemoveIndentation();
            writer.WriteIndentation();
            writer.WriteLine(_listEnd);
        }

        private static List<T> Read<T>(StreamReaderWrapper reader)
        {
            if (!reader.TryReadUntil(_listBegin))
            {
                StreamReaderWrapper.Throw<List<T>>();
            }

            List<T> value = new();
            while (!reader.EndOfStream && !reader.TryPeek(_listEnd))
            {
                value.Add(Converter<T>.Read(reader));
            }

            return value;
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)_writeMethod.MakeGenericMethod(typeof(T).GenericTypeArguments[0]).CreateDelegate(typeof(WriteAction<T>)),
            (ReadAction<T>)_readMethod.MakeGenericMethod(typeof(T).GenericTypeArguments[0]).CreateDelegate(typeof(ReadAction<T>)));
    }
}
