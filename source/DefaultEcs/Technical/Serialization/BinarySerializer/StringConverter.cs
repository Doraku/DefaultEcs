using System;
using System.IO;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static unsafe class StringConverter
    {
        #region Methods

        public static void Write(in string value, Stream stream, byte[] buffer, byte* bufferP)
        {
            int* lengthP = (int*)bufferP;
            *lengthP++ = value.Length;
            char* valueP = (char*)lengthP;

            int count = sizeof(int);
            
            foreach (char c in value)
            {
                if (count + sizeof(char) > buffer.Length)
                {
                    stream.Write(buffer, 0, count);
                    valueP = (char*)bufferP;
                    count = 0;
                }

                *valueP++ = c;
                count += sizeof(char);
            }

            stream.Write(buffer, 0, count);
        }

        public static string Read(Stream stream, byte[] buffer, byte* bufferP)
        {
            string value = null;

            if (stream.Read(buffer, 0, sizeof(int)) == sizeof(int))
            {
                int totalLength = *(int*)bufferP * sizeof(char);

                while (totalLength > 0)
                {
                    int length = stream.Read(buffer, 0, Math.Min(buffer.Length, totalLength));

                    if (length <= 0)
                    {
                        break;
                    }

                    totalLength -= length;
                    value += new string((char*)bufferP, 0, length / sizeof(char));
                }
            }

            return value;
        }

        #endregion
    }
}
