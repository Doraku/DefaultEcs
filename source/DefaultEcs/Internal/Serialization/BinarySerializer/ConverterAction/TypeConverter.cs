using System;

namespace DefaultEcs.Internal.Serialization.BinarySerializer.ConverterAction
{
    internal static class TypeConverter
    {
        private static void Write(in StreamWriterWrapper writer, in Type value) => writer.WriteString(TypeNames.Get(value));

        private static Type Read(in StreamReaderWrapper reader) => Type.GetType(reader.ReadString(), true);

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (WriteAction<T>)(Delegate)new WriteAction<Type>(Write),
            (ReadAction<T>)(Delegate)new ReadAction<Type>(Read));
    }
}
