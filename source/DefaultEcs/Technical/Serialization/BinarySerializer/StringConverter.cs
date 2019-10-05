namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static class StringConverter
    {
        #region Methods

        public static void Write(in string value, in StreamWriterWrapper writer) => writer.WriteString(value);

        public static string Read(in StreamReaderWrapper reader) => reader.ReadString();

        #endregion
    }
}
