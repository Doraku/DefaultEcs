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

            Pools = new ComponentPool<T>[1];

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
                if (worldId >= Pools.Length)
                {
                    Array.Resize(ref Pools, worldId * 2);
                }

                ref ComponentPool<T> pool = ref Pools[worldId];
                if (pool == null)
                {
                    pool = new ComponentPool<T>(worldId, maxEntityCount, maxComponentCount);
                }

                return pool;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(int worldId, int maxComponentCount) => Get(worldId) ?? Add(worldId, World.EntityInfos[worldId].Length, maxComponentCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(int worldId) => Get(worldId) ?? Add(worldId, World.EntityInfos[worldId].Length, World.EntityInfos[worldId].Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> Get(int worldId) => worldId < Pools.Length ? Pools[worldId] : null;

        #endregion
    }
}
