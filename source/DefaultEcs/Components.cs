using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DefaultEcs
{
    /// <summary>
    /// Provides a fast unsafe access to an <see cref="Entity"/> component of type <typeparamref name="T"/> by using <see cref="Entity.Get{T}(in Components{T})"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    public unsafe readonly ref struct Components<T>
    {
        private readonly GCHandle _handle;
        private readonly int* _mapping;
        private readonly T[] _components;

        internal Components(GCHandle handle, int* mapping, T[] items)
        {
            _mapping = mapping;
            _components = items;
            _handle = handle;
        }

        internal ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _components[_mapping[index]];
        }

        /// <summary>
        /// Unpins the components from memory.
        /// </summary>
        public void Dispose()
        {
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
        }
    }
}
