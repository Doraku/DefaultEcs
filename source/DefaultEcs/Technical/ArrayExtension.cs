namespace DefaultEcs.Technical
{
    internal static class ArrayExtension
    {
        public static void Fill<T>(this T[] array, in T value)
            where T : unmanaged
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = value;
            }
        }
    }
}
