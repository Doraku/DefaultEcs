using System;
using System.IO;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static unsafe class UnmanagedConverter<T>
        where T : unmanaged
    {
        #region Methods

        public static void Write(in T value, Stream stream, byte[] buffer, byte* bufferP)
        {
            if (sizeof(T) <= buffer.Length)
            {
                *(T*)bufferP = value;

                stream.Write(buffer, 0, sizeof(T));
            }
            else
            {
                int count = 0;
                T valueCopy = value;
                byte* valueP = (byte*)&valueCopy;
                byte* destination = bufferP;

                for (int i = 0; i < sizeof(T); ++i)
                {
                    *destination++ = *valueP++;
                    if (++count >= buffer.Length)
                    {
                        stream.Write(buffer, 0, count);
                        count = 0;
                        destination = bufferP;
                    }
                }

                stream.Write(buffer, 0, count);
            }
        }

        public static T Read(Stream stream, byte[] buffer, byte* bufferP)
        {
            if (sizeof(T) <= buffer.Length)
            {
                if (stream.Read(buffer, 0, sizeof(T)) == sizeof(T))
                {
                    return *(T*)bufferP;
                }
            }
            else
            {
                T value = default;
                byte* valueP = (byte*)&value;

                int totalLength = sizeof(T);

                while (totalLength > 0)
                {
                    int length = stream.Read(buffer, 0, Math.Min(buffer.Length, totalLength));

                    if (length <= 0)
                    {
                        break;
                    }

                    totalLength -= length;

                    byte* destination = bufferP;
                    for (int i = 0; i < length; ++i)
                    {
                        *valueP++ = *destination++;
                    }
                }

                return value;
            }

            return default;
        }

        #endregion
    }
}
