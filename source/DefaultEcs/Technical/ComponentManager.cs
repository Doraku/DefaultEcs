using System.Runtime.CompilerServices;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal static class ComponentManager<T>
    {
        #region Fields

        private static readonly object _lockObject;

        public static readonly ComponentFlag Flag;

        public static ComponentPool<T>[] Pools;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            _lockObject = new object();

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
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ComponentPool<T> Add(short worldId, int maxEntityCount, int maxComponentCount)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Pools, worldId);

                ref ComponentPool<T> pool = ref Pools[worldId];
                pool ??= new ComponentPool<T>(worldId, maxEntityCount, maxComponentCount);

                return pool;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> Get(short worldId) => worldId < Pools.Length ? Pools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(short worldId, int maxComponentCount) => Get(worldId) ?? Add(worldId, World.Worlds[worldId].MaxEntityCount, maxComponentCount);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ComponentPool<T> GetOrCreate(short worldId) => Get(worldId) ?? Add(worldId, World.Worlds[worldId].MaxEntityCount, World.Worlds[worldId].MaxEntityCount);

        #endregion
    }
}
