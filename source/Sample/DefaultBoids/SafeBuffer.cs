using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DefaultBoids
{
    public sealed class SafeBuffer<T>
    {
        #region Types

        public ref struct Enumerator
        {
            private readonly ReadOnlySpan<T> _span;

            private int _index;

            public ref readonly T Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => ref _span[_index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Enumerator(ReadOnlySpan<T> span)
            {
                _span = span;
                _index = -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_index < _span.Length;
        }

        #endregion

        #region Fields

        private readonly T[] _items;

        private int _count;

        #endregion

        #region Initialisation

        public SafeBuffer(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size must be superior to 0", nameof(size));
            }

            _items = new T[size];
            _count = 0;
        }

        #endregion

        public void Add(in T item)
        {
            int newIndex = Interlocked.Increment(ref _count) - 1;

            while (newIndex >= _items.Length)
            {
                newIndex -= _items.Length;
            }

            _items[newIndex] = item;
        }

        public Enumerator GetEnumerator()
        {
            Enumerator enumerator = new(new ReadOnlySpan<T>(_items, 0, _count));
            _count = 0;

            return enumerator;
        }
    }
}
