using System;

namespace DefaultEcs.Technical
{
    internal static class ComponentManager<T>
    {
        #region Fields

        public static ComponentPool<T>[] Pools;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            Pools = new ComponentPool<T>[0];

            World.ClearWorld += Clean;
        }

        #endregion

        #region Methods

        private static void Clean(int worldId)
        {
            lock (typeof(ComponentManager<T>))
            {
                if (worldId < Pools.Length)
                {
                    Pools[worldId] = null;
                }
            }
        }

        public static void Add(int worldId)
        {
            lock (typeof(ComponentManager<T>))
            {
                if (worldId >= Pools.Length)
                {
                    ComponentPool<T>[] newFactories = new ComponentPool<T>[(worldId + 1) * 2];
                    Array.Copy(Pools, newFactories, Pools.Length);
                    Pools = newFactories;
                }
            }
        }

        #endregion
    }
}
