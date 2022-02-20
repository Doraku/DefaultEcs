using System;
using System.Reflection;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class EnumConverter
    {
        private static readonly MethodInfo _readMethod = typeof(EnumConverter).GetTypeInfo().GetDeclaredMethod(nameof(Read));

        private static T Read<T>(StreamReaderWrapper reader)
            where T : struct
        {
            return Enum.TryParse(
#if NETSTANDARD2_1_OR_GREATER
                new string(reader.Read()),
#else
                reader.Read(),
#endif
                out T value) ? value : throw StreamReaderWrapper.GetException<T>();
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions<T>() => (
            (StreamWriterWrapper writer, in T value) => writer.WriteLine(value.ToString()),
            (ReadAction<T>)_readMethod.MakeGenericMethod(typeof(T)).CreateDelegate(typeof(ReadAction<T>)));
    }
}
