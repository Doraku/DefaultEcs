using System.Reflection;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal.Component
{
    internal static class ComponentManager<T>
    {
        #region Fields

        private static readonly object _lockObject;

        private static SinglePool<T>[] _previousPools;

        public static readonly bool IsFlagType;
        public static readonly bool IsReferenceType;
        public static readonly ComponentFlag Flag;

        public static IComponentPool<T>[] WorldPools;
        public static ArchetypePool<T>[] ArchetypePools;

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
                }

                foreach (Archetype archetype in World.Instances[message.WorldId].Archetypes.Values)
                {
                    if (archetype.ArchetypeId < ArchetypePools.Length)
                    {
                        ArchetypePools[archetype.ArchetypeId] = null;
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

                return WorldPools[worldId] = mode switch
                {
                    ComponentMode.Shared => new SharedPool<T>(worldId),
                    _ => new SinglePool<T>(worldId, mode)
                };
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ArchetypePool<T> AddArchetype(int archetypeId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref ArchetypePools, archetypeId);

                return ArchetypePools[archetypeId] = new ArchetypePool<T>(Archetype.Instances[archetypeId]);
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
        public static IComponentPool<T> GetOrCreateWorld(short worldId) => GetOrCreateWorld(worldId, ComponentMode.Archetype);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArchetypePool<T> GetArchetype(int archetypeId) => archetypeId < ArchetypePools.Length ? ArchetypePools[archetypeId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArchetypePool<T> GetOrCreateArchetype(int archetypeId) => GetArchetype(archetypeId) ?? AddArchetype(archetypeId);

        #endregion
    }
}
