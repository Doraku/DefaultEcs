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

        private static GenericComponentPool<T>[] _previousPools;

        public static readonly bool IsFlagType;
        public static readonly bool IsReferenceType;
        public static readonly ComponentFlag Flag;

        public static GenericComponentPool<T>[] WorldPools;
        public static ArchetypeComponentPool<T>[] ArchetypePools;

        #endregion

        #region Initialisation

        static ComponentManager()
        {
            _lockObject = new object();

            _previousPools = EmptyArray<GenericComponentPool<T>>.Value;

            IsFlagType = typeof(T).GetTypeInfo().IsFlagType();
            IsReferenceType = !typeof(T).GetTypeInfo().IsValueType;
            Flag = ComponentFlag.GetNextFlag();

            WorldPools = EmptyArray<GenericComponentPool<T>>.Value;
            ArchetypePools = EmptyArray<ArchetypeComponentPool<T>>.Value;

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
        private static GenericComponentPool<T> AddPrevious(short worldId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref _previousPools, worldId);

                GenericComponentPool<T> previousPool = _previousPools[worldId] = new GenericComponentPool<T>(worldId, true);

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
        private static GenericComponentPool<T> AddWorld(short worldId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref WorldPools, worldId);

                return WorldPools[worldId] = new GenericComponentPool<T>(worldId, false);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ArchetypeComponentPool<T> AddArchetype(int archetypeId)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref ArchetypePools, archetypeId);

                return ArchetypePools[archetypeId] = new ArchetypeComponentPool<T>(Archetype.Instances[archetypeId]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GenericComponentPool<T> GetPrevious(short worldId) => worldId < _previousPools.Length ? _previousPools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GenericComponentPool<T> GetOrCreatePrevious(short worldId) => GetPrevious(worldId) ?? AddPrevious(worldId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GenericComponentPool<T> GetWorld(short worldId) => worldId < WorldPools.Length ? WorldPools[worldId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GenericComponentPool<T> GetOrCreateWorld(short worldId) => GetWorld(worldId) ?? AddWorld(worldId);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArchetypeComponentPool<T> GetArchetype(int archetypeId) => archetypeId < ArchetypePools.Length ? ArchetypePools[archetypeId] : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArchetypeComponentPool<T> GetOrCreateArchetype(int archetypeId) => GetArchetype(archetypeId) ?? AddArchetype(archetypeId);

        #endregion
    }
}
