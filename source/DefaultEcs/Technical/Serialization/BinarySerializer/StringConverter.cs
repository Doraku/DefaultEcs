using System.IO;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    unsafe internal static class StringConverter
    {
        #region Methods

        public static void Write(in string value, Stream stream, byte[] buffer, byte* bufferP)
        {
            int* lengthP = (int*)bufferP;
            *(lengthP++) = value.Length;
            char* valueP = (char*)lengthP;
            foreach (char c in value)
            {
                *(valueP++) = c;
            }

            stream.Write(buffer, 0, sizeof(int) + value.Length * sizeof(char));
        }

        public static string Read(Stream stream, byte[] buffer, byte* bufferP)
        {
            if (stream.Read(buffer, 0, sizeof(int)) == sizeof(int))
            {
                int length = *(int*)bufferP;

                if (stream.Read(buffer, 0, length * sizeof(char)) == length * sizeof(char))
                {
                    return new string((char*)bufferP, 0, length);
                }
            }

            return default;
        }

        #endregion
    }
}
