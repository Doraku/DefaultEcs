using System.Runtime.CompilerServices;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal static class ComponentManager<T>
    {
        #region Fields

        public static readonly ComponentFlag Flag;

        public static ComponentPool<T>[] Pools;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            Flag = ComponentFlag.GetNextFlag();

            Pools = new ComponentPool<T>[0];

            lock (World.Locker)
            {
                World.ClearWorld += Clear;
            }
        }

        #endregion

        #region Methods

        private static void Clear(int worldId)
        {
            lock (typeof(ComponentManager<T>))
            {
                if (worldId < Pools.Length)
                {
                    Pools[worldId] = null;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ComponentPool<T> Add(int worldId, int maxEntityCount, int maxComponentCount)
        {
            lock (typeof(ComponentManager<T>))
            {
                if (worldId >= Pools.Length)
                {
                    Helper.ResizeArray(ref Pools, (worldId + 1) * 2);
                }

                ref ComponentPool<T> pool = ref Pools[worldId];
                if (pool == null)
                {
                    pool = new ComponentPool<T>(Flag, maxEntityCount, maxComponentCount);
                    Publisher<EntityDisposedMessage>.Subscribe(worldId, pool.On);
                }

                return pool;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> Add(int worldId) => Add(worldId, World.MaxEntityCounts[worldId], World.MaxEntityCounts[worldId]);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> Add(int worldId, int maxComponentCount) => Add(worldId, World.MaxEntityCounts[worldId], maxComponentCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(int worldId, int maxComponentCount)
            => worldId < Pools.Length ? (Pools[worldId] ?? Add(worldId, maxComponentCount)) : Add(worldId, maxComponentCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(int worldId)
            => worldId < Pools.Length ? (Pools[worldId] ?? Add(worldId)) : Add(worldId);

        #endregion
    }
}
