using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DefaultEcs.Technical.Helper
{
    internal static class ArrayExtension
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void InnerEnsureLength<T>(ref T[] array, int index, int maxLength)
        {
            int newLength = Math.Max(1, array.Length);
            do
            {
                newLength *= 2;
            }
            while (index >= newLength);
            Array.Resize(ref array, Math.Min(maxLength, newLength));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
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
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void EnsureLength<T>(ref T[] array, int index, int maxLength, in T defaultValue)
        {
            if (index >= array.Length)
            {
                int oldLength = array.Length;

                InnerEnsureLength(ref array, index, maxLength);
                array.Fill(defaultValue, oldLength);
            }
        }
    }
}
