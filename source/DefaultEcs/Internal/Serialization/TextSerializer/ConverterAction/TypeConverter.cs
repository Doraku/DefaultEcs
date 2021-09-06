using System;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class TypeConverter
    {
        private static void Write(StreamWriterWrapper writer, in Type value) => writer.WriteLine(TypeNames.Get(value));

        private static Type Read(StreamReaderWrapper reader) => Type.GetType(reader.ReadString(), true);

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<Type>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<Type>(Read));
    }
}
