using System;
using System.IO;
using System.Reflection;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    unsafe internal static class Converter<T>
    {
        #region Types

        private delegate void WriteAction(in T value, Stream stream, byte[] buffer, byte* bufferP);
        private delegate T ReadAction(Stream stream, byte[] buffer, byte* bufferP);

        #endregion

        #region Fields

        private readonly static WriteAction _writeAction;
        private readonly static ReadAction _readAction;

        #endregion

        #region Initialisation

        static Converter()
        {

            if (typeof(T) == typeof(string))
            {
                _writeAction = (WriteAction)new Converter<string>.WriteAction(StringConverter.Write);
                _readAction = (ReadAction)new Converter<string>.ReadAction(StringConverter.Read);
            }
            else
            {
                try
                {
                    TypeInfo unmanagedType = typeof(UnmanagedConverter<>).MakeGenericType(typeof(T)).GetTypeInfo();

                    _writeAction = (WriteAction)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Write)).CreateDelegate(typeof(WriteAction));
                    _readAction = (ReadAction)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Read)).CreateDelegate(typeof(ReadAction));
                }
                catch
                {
                    _writeAction = (in T _, Stream __, byte[] ___, byte* ____) => throw new InvalidOperationException($"Unable to handle type {typeof(T).FullName}");
                    _readAction = (_, __, ___) => throw new InvalidOperationException($"Unable to handle type {typeof(T).FullName}");
                }
            }
        }

        #endregion

        #region Methods

        public static void Write(in T value, Stream stream, byte[] buffer, byte* bufferP) => _writeAction(value, stream, buffer, bufferP);

        public static T Read(Stream stream, byte[] buffer, byte* bufferP) => _readAction(stream, buffer, bufferP);

        #endregion
    }
}
