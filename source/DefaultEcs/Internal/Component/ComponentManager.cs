using System.Reflection;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal.Component
{
    internal static class ComponentManager<T>
    {
        public delegate ref T Getter(int entityId);

        #region Fields

        private static readonly object _lockObject;

        private static SinglePool<T>[] _previousPools;

        public static readonly bool IsFlagType;
        public static readonly bool IsReferenceType;
        public static readonly ComponentFlag Flag;

        public static IComponentPool<T>[] WorldPools;
        public static ArchetypePool<T>[] ArchetypePools;
        public static Getter[] Getters;
        public static Getter[] ArchetypeGetters;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            _lockObject = new object();

            _previousPools = EmptyArray<SinglePool<T>>.Value;

            IsFlagType = typeof(T).GetTypeInfo().IsFlagType();
            IsReferenceType = !typeof(T).GetTypeInfo().IsValueType;
            Flag = ComponentFlag.GetNextFlag();

            WorldPools = EmptyArray<IComponentPool<T>>.Value;
            ArchetypePools = EmptyArray<ArchetypePool<T>>.Value;
            Getters = EmptyArray<Getter>.Value;
            ArchetypeGetters = EmptyArray<Getter>.Value;

            Publisher<WorldDisposedMessage>.Subscribe(0, On);
        }

        #endregion

        #region Callbacks

        private static void On(in WorldDisposedMessage message)
        {
            lock (_lockObject)
            {
                if (message.WorldId < _previousPools.Length)
                {
                    _previousPools[message.WorldId] = null;
                }

                if (message.WorldId < WorldPools.Length)
                {
                    WorldPools[message.WorldId] = null;
                    Getters[message.WorldId] = null;
                }

                foreach (Archetype archetype in World.Instances[message.WorldId].Archetypes.Values)
                {
                    if (archetype.ArchetypeId < ArchetypePools.Length)
                    {
                        ArchetypePools[archetype.ArchetypeId] = null;
                        ArchetypeGetters[archetype.ArchetypeId] = null;
                    }
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static SinglePool<T> AddPrevious(short worldId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref _previousPools, worldId);

                SinglePool<T> previousPool = _previousPools[worldId] = new SinglePool<T>(worldId);

                foreach (Entity entity in World.Instances[worldId])
                {
                    if (entity.Has<T>())
                    {
                        previousPool.Set(entity.EntityId, entity.Get<T>());
                    }
                }

                return previousPool;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IComponentPool<T> AddWorld(short worldId, ComponentMode mode)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref WorldPools, worldId);
                ArrayExtension.EnsureLength(ref Getters, worldId);

                IComponentPool<T> pool;
                switch (mode)
                {
                    case ComponentMode.Single:
                        SinglePool<T> singlePool = new(worldId, mode);
                        pool = singlePool;
                        Getters[worldId] = singlePool.Get;
                        break;

                    case ComponentMode.Shared:
                        SharedPool<T> sharedPool = new(worldId);
                        pool = sharedPool;
                        Getters[worldId] = sharedPool.Get;
                        break;

                    default:
                        pool = new SinglePool<T>(worldId, mode);
                        World world = World.Instances[worldId];
                        Getters[worldId] = entityId => ref ArchetypeGetters[world.EntityInfos[entityId].Archetype.ArchetypeId](entityId);
                        break;
                }

                return WorldPools[worldId] = pool;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ArchetypePool<T> AddArchetype(Archetype archetype)
        {
            IComponentPool<T> disabledPool = GetOrCreateWorld(archetype.WorldId);

            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref ArchetypeGetters, archetype.ArchetypeId);
                ArchetypeGetters[archetype.ArchetypeId] = archetype.Has<T>() ? archetype.Get<T> : disabledPool switch
                {
                    SinglePool<T> pool => pool.Get,
                    SharedPool<T> pool => pool.Get,
                    _ => disabledPool.Get
                };

                ArrayExtension.EnsureLength(ref ArchetypePools, archetype.ArchetypeId);
                return ArchetypePools[archetype.ArchetypeId] = new ArchetypePool<T>(Archetype.Instances[archetype.ArchetypeId]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SinglePool<T> GetPrevious(short worldId) => worldId < _previousPools.Length ? _previousPools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SinglePool<T> GetOrCreatePrevious(short worldId) => GetPrevious(worldId) ?? AddPrevious(worldId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IComponentPool<T> GetWorld(short worldId) => worldId < WorldPools.Length ? WorldPools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IComponentPool<T> GetOrCreateWorld(short worldId, ComponentMode mode) => GetWorld(worldId) ?? AddWorld(worldId, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IComponentPool<T> GetOrCreateWorld(short worldId) => GetOrCreateWorld(worldId, World.Instances[worldId].DefaultComponentMode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArchetypePool<T> GetArchetype(int archetypeId) => archetypeId < ArchetypePools.Length ? ArchetypePools[archetypeId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArchetypePool<T> GetOrCreateArchetype(Archetype archetype) => GetArchetype(archetype.ArchetypeId) ?? AddArchetype(archetype);

        #endregion
    }
}
