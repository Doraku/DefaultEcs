using System.IO;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    unsafe internal static class UnmanagedConverter<T>
        where T : unmanaged
    {
        #region Methods

        public static T Read(Stream stream, byte[] buffer, byte* bufferP)
        {
            if (stream.Read(buffer, 0, sizeof(T)) == sizeof(T))
            {
                return *(T*)bufferP;
            }

            return default;
        }

        public static void Write(in T value, Stream stream, byte[] buffer, byte* bufferP)
        {
            *(T*)bufferP = value;

            stream.Write(buffer, 0, sizeof(T));
        }

        #endregion
    }
}
