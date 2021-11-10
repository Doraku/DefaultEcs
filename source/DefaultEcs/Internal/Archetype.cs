using System;
using System.Collections.Generic;
using DefaultEcs.Internal.Component;
using DefaultEcs.Internal.Helper;

namespace DefaultEcs.Internal
{
    internal readonly struct ChangeArchetypeMessage
    {
        public readonly int EntityId;
        public readonly int ArchetypeId;

        public ChangeArchetypeMessage(int entityId, int archetypeId)
        {
            EntityId = entityId;
            ArchetypeId = archetypeId;
        }
    }

    internal readonly struct RemoveEntityMessage
    {
        public readonly int EntityId;

        public RemoveEntityMessage(int entityId)
        {
            EntityId = entityId;
        }
    }

    internal delegate void CopyComponentHandler(int index, short worldId, Archetype newArchetype);

    internal delegate void RemoveComponentHandler(int index, int lastIndex);

    internal delegate void TrimExcessHandler(int lastIndex);

    public sealed class Archetype
    {
        private static readonly object _lockObject;
        private static readonly IntDispenser _archetypeIdDispenser;

        public static Archetype[] Instances;

        private readonly ComponentEnum _components;
        private readonly Dictionary<ComponentEnum, Archetype> _archetypesByCompositions;

        private Entity[] _entities;
        private int[] _mapping;
        private int _lastEntityIndex;

        public readonly short WorldId;
        public readonly int ArchetypeId;

        internal event CopyComponentHandler OnCopyComponents;
        internal event RemoveComponentHandler OnRemoveComponents;
        internal event TrimExcessHandler OnTrimExcess;

        static Archetype()
        {
            _lockObject = new object();
            _archetypeIdDispenser = new IntDispenser(-1);

            Instances = EmptyArray<Archetype>.Value;
        }

        internal Archetype(short worldId, ComponentEnum components)
        {
            WorldId = worldId;
            ArchetypeId = _archetypeIdDispenser.GetFreeInt();
            _components = components.Copy();
            _archetypesByCompositions = World.Instances[WorldId].Archetypes;

            _entities = EmptyArray<Entity>.Value;
            _mapping = EmptyArray<int>.Value;
            _lastEntityIndex = -1;


            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Instances, ArchetypeId);
                Instances[ArchetypeId] = this;
            }

            _archetypesByCompositions.Add(_components, this);
        }

        internal static void Release<T>(T archetypes)
            where T : IEnumerable<Archetype>
        {
            lock (_lockObject)
            {
                foreach (Archetype archetype in archetypes)
                {
                    Instances[archetype.ArchetypeId] = null;
                    _archetypeIdDispenser.ReleaseInt(archetype.ArchetypeId);
                }
            }
        }

        private Archetype ChangeArchetype(int entityId, ComponentEnum components)
        {
            if (!_archetypesByCompositions.TryGetValue(components, out Archetype newArchetype))
            {
                newArchetype = new Archetype(WorldId, components);
            }

            ref int index = ref _mapping[entityId];
            OnCopyComponents?.Invoke(index, WorldId, newArchetype);

            newArchetype.Add(entityId);
            World.Instances[WorldId].EntityInfos[entityId].Archetype = newArchetype;

            OnRemoveComponents?.Invoke(index, _lastEntityIndex);
            if (index != _lastEntityIndex)
            {
                _entities[index] = _entities[_lastEntityIndex];
            }

            --_lastEntityIndex;

            return newArchetype;
        }

        internal bool Enable(int entityId, ref ComponentEnum entityComponents)
        {
            if (_components[ComponentFlag.IsEnable])
            {
                return false;
            }

            entityComponents[ComponentFlag.IsEnable] = true;
            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Disable(int entityId, ref ComponentEnum entityComponents)
        {
            if (!_components[ComponentFlag.IsEnable])
            {
                return false;
            }

            entityComponents[ComponentFlag.IsEnable] = false;
            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Enable<T>(int entityId, ref ComponentEnum entityComponents)
        {
            if (_components[ComponentManager<T>.Flag])
            {
                return false;
            }

            IComponentPool<T> pool = ComponentManager<T>.GetWorld(WorldId);

            if (!ComponentManager<T>.IsFlagType && pool?.Has(entityId) is not true)
            {
                return false;
            }

            entityComponents[ComponentManager<T>.Flag] = true;
            Archetype newArchetype = ChangeArchetype(entityId, entityComponents);

            if (!ComponentManager<T>.IsFlagType && pool.Mode is ComponentMode.Archetype)
            {
                ComponentManager<T>.GetOrCreateArchetype(newArchetype).SetAt(newArchetype._lastEntityIndex, pool.Get(entityId));
                pool.Remove(entityId);
            }

            return true;
        }

        internal bool Disable<T>(int entityId, ref ComponentEnum entityComponents)
        {
            if (!_components[ComponentManager<T>.Flag])
            {
                return false;
            }

            entityComponents[ComponentManager<T>.Flag] = false;

            if (!ComponentManager<T>.IsFlagType)
            {
                IComponentPool<T> pool = ComponentManager<T>.GetOrCreateWorld(WorldId);
                if (pool.Mode is ComponentMode.Archetype)
                {
                    pool.Set(entityId, ComponentManager<T>.ArchetypePools[ArchetypeId].GetAt(_mapping[entityId]));
                }
            }

            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Set<T>(int entityId, ref ComponentEnum entityComponents, in T component)
        {
            IComponentPool<T> pool = ComponentManager<T>.GetOrCreateWorld(WorldId);

            if (_components[ComponentManager<T>.Flag] && pool.Mode is ComponentMode.Archetype)
            {
                if (!ComponentManager<T>.IsFlagType)
                {
                    ComponentManager<T>.ArchetypePools[ArchetypeId].SetAt(_mapping[entityId], component);
                }

                return false;
            }

            if (!ComponentManager<T>.IsFlagType && pool.Mode is not ComponentMode.Archetype && !pool.Set(entityId, component))
            {
                return false;
            }

            entityComponents[ComponentManager<T>.Flag] = true;
            Archetype newArchetype = ChangeArchetype(entityId, entityComponents);

            if (!ComponentManager<T>.IsFlagType && pool.Mode is ComponentMode.Archetype)
            {
                ComponentManager<T>.GetOrCreateArchetype(newArchetype).SetAt(newArchetype._lastEntityIndex, component);
            }

            return true;
        }

        internal bool Remove<T>(int entityId, ref ComponentEnum entityComponents)
        {
            IComponentPool<T> pool = ComponentManager<T>.GetWorld(WorldId);

            if (!_components[ComponentManager<T>.Flag] && !ComponentManager<T>.IsFlagType)
            {
                return pool?.Remove(entityId) ?? false;
            }

            if (!ComponentManager<T>.IsFlagType && pool?.Mode is not null and not ComponentMode.Archetype && !pool.Remove(entityId))
            {
                return false;
            }

            entityComponents[ComponentManager<T>.Flag] = false;
            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        public bool Has<T>() => _components[ComponentManager<T>.Flag];

        public ref T Get<T>(int entityId) => ref ComponentManager<T>.ArchetypePools[ArchetypeId].GetAt(_mapping[entityId]);

        public void Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _entities, ++_lastEntityIndex);
            _entities[_lastEntityIndex] = new Entity(WorldId, entityId);

            ArrayExtension.EnsureLength(ref _mapping, entityId);
            _mapping[entityId] = _lastEntityIndex;
        }

        public Memory<T> Get<T>() => ComponentManager<T>.GetArchetype(ArchetypeId).AsMemory(Count);

        public int Count => _lastEntityIndex + 1;

        public void TrimExcess() => OnTrimExcess?.Invoke(Count);
    }
}
