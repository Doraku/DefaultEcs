using System.Runtime.CompilerServices;
using DefaultEcs.Internal;

namespace System
{
    internal static class ArrayExtension
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InnerEnsureLength<T>(ref T[] array, int index, int maxLength)
        {
            int newLength = Math.Max(4, array.Length);
            do
            {
                newLength *= 2;
                if (newLength < 0)
                {
                    newLength = index + 1;
                }
            }
            while (index >= newLength);
            Array.Resize(ref array, Math.Min(maxLength, newLength));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Fill<T>(this T[] array, in T value, int start = 0)
        {
            for (int i = start; i < array.Length; ++i)
            {
                array[i] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnsureLength<T>(ref T[] array, int index, int maxLength = int.MaxValue)
        {
            if (index >= array.Length)
            {
                InnerEnsureLength(ref array, index, maxLength);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void EnsureLength<T>(ref T[] array, int index, int maxLength, in T defaultValue)
        {
            if (index >= array.Length)
            {
                int oldLength = array.Length;

                InnerEnsureLength(ref array, index, maxLength);
                array.Fill(defaultValue, oldLength);
            }
        }

        public static void Trim<T>(ref T[] array, int lenght)
        {
            if (array.Length > lenght)
            {
                array = lenght is 0 ? EmptyArray<T>.Value : array.AsSpan(0, lenght).ToArray();
            }
        }
    }
}
