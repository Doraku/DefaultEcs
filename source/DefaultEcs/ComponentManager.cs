using System;

namespace DefaultEcs
{
    public sealed partial class World
    {
        internal static class ComponentManager<T>
        {
            #region Fields

            private static readonly object _locker;

            public static ComponentPool<T>[] Pools;

            #endregion

            #region Initialisation

            static ComponentManager()
            {
                _locker = new object();

                Pools = new ComponentPool<T>[_worldIdDispenser.LastInt + 1];

                _newWorld += Add;
                _cleanWorld += Clean;
            }

            #endregion

            #region Methods

            private static void Add(int worldId)
            {
                lock (_locker)
                {
                    if (Pools.Length < worldId + 1)
                    {
                        ComponentPool<T>[] newFactories = new ComponentPool<T>[(worldId + 1) * 2];
                        Array.Copy(Pools, newFactories, Pools.Length);
                        Pools = newFactories;
                    }
                }
            }

            private static void Clean(int worldId)
            {
                lock (_locker)
                {
                    Pools[worldId] = null;
                }
            }

            #endregion
        }
    }
}
