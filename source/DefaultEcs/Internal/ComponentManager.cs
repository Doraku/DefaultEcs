using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Messages;

namespace DefaultEcs.Internal
{
    internal static class ComponentManager<T>
    {
        #region Fields

        private static readonly object _lockObject;

        private static ComponentPool<T>[] _previousPools;

        public static readonly ComponentFlag Flag;

        public static ComponentPool<T>[] Pools;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            _lockObject = new object();

            _previousPools = EmptyArray<ComponentPool<T>>.Value;

            Flag = ComponentFlag.GetNextFlag();

            Pools = EmptyArray<ComponentPool<T>>.Value;

            Publisher<WorldDisposedMessage>.Subscribe(0, On);
        }

        #endregion

        #region Callbacks

        private static void On(in WorldDisposedMessage message)
        {
            lock (_lockObject)
            {
                if (message.WorldId < Pools.Length)
                {
                    Pools[message.WorldId] = null;
                }
                if (message.WorldId < _previousPools.Length)
                {
                    _previousPools[message.WorldId] = null;
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> Add(short worldId, int worldMaxCapacity, int maxCapacity)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Pools, worldId);

                ref ComponentPool<T> pool = ref Pools[worldId];
                pool ??= new ComponentPool<T>(worldId, worldMaxCapacity, maxCapacity, false);

                return pool;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> AddPrevious(short worldId, int worldMaxCapacity)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref _previousPools, worldId);

                ref ComponentPool<T> previousPool = ref _previousPools[worldId];
                previousPool ??= new ComponentPool<T>(worldId, worldMaxCapacity, worldMaxCapacity, true);

                ComponentPool<T> pool = Get(worldId);
                if (pool != null)
                {
                    if (pool.Has(0))
                    {
                        previousPool.Set(0, pool.Get(0));
                    }

                    foreach (Entity entity in pool.GetEntities())
                    {
                        previousPool.Set(entity.EntityId, pool.Get(entity.EntityId));
                    }
                }

                return previousPool;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> Get(short worldId) => worldId < Pools.Length ? Pools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(short worldId) => Get(worldId) ?? Add(worldId, World.Worlds[worldId].MaxCapacity, World.Worlds[worldId].MaxCapacity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetPrevious(short worldId) => worldId < _previousPools.Length ? _previousPools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreatePrevious(short worldId) => GetPrevious(worldId) ?? AddPrevious(worldId, World.Worlds[worldId].MaxCapacity);

        #endregion
    }
}
