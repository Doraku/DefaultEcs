using System;
using System.Runtime.CompilerServices;
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

    internal delegate void CopyComponentHandler(int index, int newArchetypeId, int newIndex);

    internal delegate void RemoveComponentHandler(int index, int lastIndex);

    public sealed class Archetype
    {
        private readonly World _world;
        private readonly ComponentEnum _components;

        private int[] _mapping;
        private int _lastEntityIndex;

        public readonly int ArchetypeId;

        internal event CopyComponentHandler CopyComponents;
        internal event RemoveComponentHandler RemoveComponents;

        internal Archetype(World world, int archetypeId, ComponentEnum components)
        {
            _world = world;
            _components = components;

            _mapping = EmptyArray<int>.Value;
            _lastEntityIndex = -1;

            ArchetypeId = archetypeId;
        }

        private Archetype ChangeArchetype(int entityId, ComponentEnum components)
        {
            if (!_world.ArchetypesByCompositions.TryGetValue(components, out Archetype newArchetype))
            {
                newArchetype = _world.CreateArchetype(components);
            }

            newArchetype.Add(entityId);
            _world.EntityInfos[entityId].ArchetypeId = newArchetype.ArchetypeId;
            CopyComponents?.Invoke(_mapping[entityId], newArchetype.ArchetypeId, newArchetype._lastEntityIndex);
            RemoveComponents?.Invoke(_mapping[entityId], _lastEntityIndex);

            --_lastEntityIndex;

            return newArchetype;
        }

        internal bool Enable(int entityId, ref ComponentEnum entityComponents)
        {
            if (_components[World.IsEnabledFlag])
            {
                return false;
            }

            entityComponents[World.IsEnabledFlag] = true;
            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Disable(int entityId, ref ComponentEnum entityComponents)
        {
            if (!_components[World.IsEnabledFlag])
            {
                return false;
            }

            entityComponents[World.IsEnabledFlag] = false;
            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Enable<T>(int entityId, ref ComponentEnum entityComponents)
        {
            if (_components[ComponentManager<T>.Flag])
            {
                return false;
            }

            ComponentPool<T> pool = ComponentManager<T>.Get(_world.WorldId);

            if (!ComponentManager<T>.IsFlagType && pool?.Has(entityId) is not true)
            {
                return false;
            }

            entityComponents[ComponentManager<T>.Flag] = true;
            Archetype newArchetype = ChangeArchetype(entityId, entityComponents);

            if (!ComponentManager<T>.IsFlagType)
            {
                ComponentManager<T>.GetOrCreate(_world.WorldId, newArchetype.ArchetypeId).SetAt(newArchetype._lastEntityIndex, pool.Get(entityId));
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
                ComponentManager<T>.GetOrCreate(_world.WorldId).Set(entityId, ComponentManager<T>.Get(_world.WorldId, ArchetypeId).GetAt(_mapping[entityId]));
            }

            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Set<T>(int entityId, ref ComponentEnum entityComponents, in T component)
        {
            if (_components[ComponentManager<T>.Flag])
            {
                if (!ComponentManager<T>.IsFlagType)
                {
                    ComponentManager<T>.Get(_world.WorldId, ArchetypeId).Set(entityId, component);
                }

                return false;
            }

            if (!ComponentManager<T>.IsFlagType)
            {
                ComponentPool<T> pool = ComponentManager<T>.Get(_world.WorldId);
                if (pool?.Has(entityId) is true)
                {
                    return pool.Set(entityId, component);
                }
            }

            entityComponents[ComponentManager<T>.Flag] = true;
            Archetype newArchetype = ChangeArchetype(entityId, entityComponents);

            if (!ComponentManager<T>.IsFlagType)
            {
                ComponentManager<T>.GetOrCreate(_world.WorldId, newArchetype.ArchetypeId).SetAt(newArchetype._lastEntityIndex, component);
            }

            return true;
        }

        internal bool Remove<T>(int entityId, ref ComponentEnum entityComponents)
        {
            if (!_components[ComponentManager<T>.Flag] && !ComponentManager<T>.IsFlagType)
            {
                return ComponentManager<T>.Get(_world.WorldId)?.Remove(entityId) ?? false;
            }

            entityComponents[ComponentManager<T>.Flag] = false;
            ChangeArchetype(entityId, entityComponents);

            return true;
        }

        internal bool Has<T>(int entityId) => _components[ComponentManager<T>.Flag] || (!ComponentManager<T>.IsFlagType && ComponentManager<T>.Get(_world.WorldId)?.Has(entityId) is true);

        internal ref T Get<T>(int entityId)
        {
            if (_components[ComponentManager<T>.Flag])
            {
                return ref ComponentManager<T>.Get(_world.WorldId, ArchetypeId).GetAt(_mapping[entityId]);
            }

            return ref ComponentManager<T>.Get(_world.WorldId).Get(entityId);
        }

        internal void Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId);
            _mapping[entityId] = ++_lastEntityIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<T> GetPool<T>() => ComponentManager<T>.Get(_world.WorldId, ArchetypeId).AsSpan(_lastEntityIndex + 1);

        public T[] GetArray<T>() => ComponentManager<T>.Get(_world.WorldId, ArchetypeId).AsArray();

        public Memory<T> GetMemory<T>() => ComponentManager<T>.Get(_world.WorldId, ArchetypeId).AsArray().AsMemory(0, Count);

        public int Count => _lastEntityIndex + 1;
    }
}
