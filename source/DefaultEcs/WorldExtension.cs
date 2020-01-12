using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DefaultEcs.Technical;

namespace DefaultEcs
{
    public readonly unsafe struct Component<T> : IDisposable
    {
        private readonly int[] _indices;
        private readonly GCHandle _handle;
        private readonly ComponentPool<T> _pool;
        private readonly int* _i;

        internal Component(int[] indices, GCHandle handle, ComponentPool<T> pool, int* i)
        {
            _indices = indices;
            _handle = handle;
            _pool = pool;
            _i = i;
        }

        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _pool[_i[index]];
        }

        public void Dispose()
        {
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
            ArrayPool<int>.Shared.Return(_indices);
        }
    }

    public static class WorldExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe Component<T> Prefetch<T>(this World world, Entity* entities, int count)
        {
            int[] indices = ArrayPool<int>.Shared.Rent(count);
            GCHandle handle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            int* indicesP = (int*)handle.AddrOfPinnedObject().ToPointer();

            ComponentPool<T> pool = ComponentManager<T>.Pools[world.WorldId];

            pool.FillIndices(entities, indicesP, count);

            return new Component<T>(indices, handle, pool, indicesP);
        }

        public static unsafe Component<T> Prefetch<T>(this World world, ReadOnlySpan<Entity> entities)
        {
            fixed (Entity* entity = entities)
            {
                return Prefetch<T>(world, entity, entities.Length);
            }
        }

        public static unsafe (Component<T1>, Component<T2>) Prefetch<T1, T2>(this World world, ReadOnlySpan<Entity> entities)
        {
            fixed (Entity* entity = entities)
            {
                return (
                    Prefetch<T1>(world, entity, entities.Length),
                    Prefetch<T2>(world, entity, entities.Length));
            }
        }

        public static unsafe (Component<T1>, Component<T2>, Component<T3>) Prefetch<T1, T2, T3>(this World world, ReadOnlySpan<Entity> entities)
        {
            fixed (Entity* entity = entities)
            {
                return (
                    Prefetch<T1>(world, entity, entities.Length),
                    Prefetch<T2>(world, entity, entities.Length),
                    Prefetch<T3>(world, entity, entities.Length));
            }
        }
    }
}
