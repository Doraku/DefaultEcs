using System.Collections.Generic;
using System.Reflection;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class DictionaryConverter
    {
        private const string _dictionaryBegin = "[";
        private const string _dictionaryEnd = "]";

        private static readonly MethodInfo _writeMethod = typeof(DictionaryConverter).GetTypeInfo().GetDeclaredMethod(nameof(Write));
        private static readonly MethodInfo _readMethod = typeof(DictionaryConverter).GetTypeInfo().GetDeclaredMethod(nameof(Read));

        private static void Write<TKey, TValue>(StreamWriterWrapper writer, in Dictionary<TKey, TValue> value)
        {
            writer.WriteLine(_dictionaryBegin);
            writer.AddIndentation();
            foreach (KeyValuePair<TKey, TValue> item in value)
            {
                writer.WriteIndentation();
                Converter<KeyValuePair<TKey, TValue>>.Write(writer, item);
            }
            writer.RemoveIndentation();
            writer.WriteIndentation();
            writer.WriteLine(_dictionaryEnd);
        }

        private static Dictionary<TKey, TValue> Read<TKey, TValue>(StreamReaderWrapper reader)
        {
            if (!reader.TryReadUntil(_dictionaryBegin))
            {
                StreamReaderWrapper.Throw<Dictionary<TKey, TValue>>();
            }

            Dictionary<TKey, TValue> value = new();
            while (!reader.EndOfStream && !reader.TryPeek(_dictionaryEnd))
            {
                KeyValuePair<TKey, TValue> pair = Converter<KeyValuePair<TKey, TValue>>.Read(reader);
                value.Add(pair.Key, pair.Value);
            }

            return value;
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)_writeMethod.MakeGenericMethod(typeof(T).GenericTypeArguments).CreateDelegate(typeof(WriteAction<T>)),
            (ReadAction<T>)_readMethod.MakeGenericMethod(typeof(T).GenericTypeArguments).CreateDelegate(typeof(ReadAction<T>)));
    }
}
