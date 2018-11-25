using System;
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

            Publisher<WorldDisposedMessage>.Subscribe(0, On);
        }

        #endregion

        #region Callbacks

        private static void On(in WorldDisposedMessage message)
        {
            lock (typeof(ComponentManager<T>))
            {
                if (message.WorldId < Pools.Length)
                {
                    Pools[message.WorldId] = null;
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> Add(int worldId, int maxEntityCount, int maxComponentCount)
        {
            lock (typeof(ComponentManager<T>))
            {
                ArrayExtension.EnsureLength(ref Pools, worldId);

                ref ComponentPool<T> pool = ref Pools[worldId];
                if (pool == null)
                {
                    pool = new ComponentPool<T>(worldId, maxEntityCount, maxComponentCount);
                }

                return pool;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(int worldId, int maxComponentCount) => Get(worldId) ?? Add(worldId, World.Infos[worldId].MaxEntityCount, maxComponentCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(int worldId) => Get(worldId) ?? Add(worldId, World.Infos[worldId].MaxEntityCount, World.Infos[worldId].MaxEntityCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> Get(int worldId) => worldId < Pools.Length ? Pools[worldId] : null;

        #endregion
    }
}
