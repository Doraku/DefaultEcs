using System.Runtime.CompilerServices;

namespace DefaultEcs
{
    /// <summary>
    /// Provides a fast access to an <see cref="Entity"/> component of type <typeparamref name="T"/> by using <see cref="Entity.Get{T}(in Components{T})"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    public readonly ref struct Components<T>
    {
        private readonly int[] _mapping;
        private readonly T[] _components;

        internal Components(int[] mapping, T[] components)
        {
            _mapping = mapping;
            _components = components;
        }

        internal ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _components[_mapping[index]];
        }
    }
}
