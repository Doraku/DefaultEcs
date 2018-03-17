using System;

namespace DefaultEcs.Technical
{
    internal static class Helper
    {
        public static void ResizeArray<T>(ref T[] array, int newSize)
        {
            T[] newArray = new T[newSize];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }
    }
}
