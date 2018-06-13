namespace DefaultEcs.Technical
{
    internal static class ArrayExtension
    {
        public static unsafe void Fill<T>(this T[] array, in T value)
            where T : unmanaged
        {
            fixed (T* source = array)
            {
                T* item = source;
                for (int i = 0; i < array.Length; ++i, ++item)
                {
                    *item = value;
                }
            }
        }
    }
}
