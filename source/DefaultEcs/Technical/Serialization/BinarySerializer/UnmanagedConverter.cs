namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static class UnmanagedConverter<T>
        where T : unmanaged
    {
        #region Methods

        public static void Write(in T value, in StreamWriterWrapper writer) => writer.Write(value);

        public static T Read(in StreamReaderWrapper reader) => reader.Read<T>();

        #endregion
    }
}
