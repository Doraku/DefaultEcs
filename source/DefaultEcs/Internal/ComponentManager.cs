using System.Reflection;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal
{
    internal static class ComponentManager<T>
    {
        #region Fields

        private static readonly object _lockObject;

        private static ComponentPool<T>[] _previousPools;

        public static readonly bool IsFlagType;
        public static readonly ComponentFlag Flag;

        public static ComponentPool<T>[][] Pools;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            _lockObject = new object();

            _previousPools = EmptyArray<ComponentPool<T>>.Value;

            IsFlagType = typeof(T).GetTypeInfo().IsFlagType();
            Flag = ComponentFlag.GetNextFlag();

            Pools = EmptyArray<ComponentPool<T>[]>.Value;

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
                    Pools[message.WorldId] = EmptyArray<ComponentPool<T>>.Value;
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
        private static ComponentPool<T> Add(short worldId, int archetypeId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Pools, worldId, int.MaxValue, EmptyArray<ComponentPool<T>>.Value);
                ref ComponentPool<T>[] worldPools = ref Pools[worldId];

                ArrayExtension.EnsureLength(ref worldPools, archetypeId);

                return worldPools[archetypeId] = new ComponentPool<T>(worldId, archetypeId > 0 ? World.Worlds[worldId].Archetypes[archetypeId] : null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> AddPrevious(short worldId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref _previousPools, worldId);

                ref ComponentPool<T> previousPool = ref _previousPools[worldId];
                previousPool ??= new ComponentPool<T>(worldId, null);

                ComponentPool<T> pool = Get(worldId);
                if (pool != null)
                {
                    foreach (Entity entity in pool.GetEntities())
                    {
                        previousPool.Set(entity.EntityId, pool.Get(entity.EntityId));
                    }
                }

                return previousPool;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> Get(short worldId, int archetypeId) => worldId < Pools.Length ? (archetypeId < Pools[worldId].Length ? Pools[worldId][archetypeId] : null) : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> Get(short worldId) => Get(worldId, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(short worldId, int archetypeId) => Get(worldId, archetypeId) ?? Add(worldId, archetypeId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(short worldId) => GetOrCreate(worldId, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetPrevious(short worldId) => worldId < _previousPools.Length ? _previousPools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreatePrevious(short worldId) => GetPrevious(worldId) ?? AddPrevious(worldId);

        #endregion
    }
}
