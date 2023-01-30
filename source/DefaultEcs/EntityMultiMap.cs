using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Internal;
using DefaultEcs.Internal.Diagnostics;
using DefaultEcs.Internal.Messages;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a collection of <see cref="Entity"/> mapped to a <typeparamref name="TKey"/> component. Multiple <see cref="Entity"/> can be associated with a given <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the component used as key.</typeparam>
    [DebuggerTypeProxy(typeof(EntityMultiMapDebugView<>))]
    [DebuggerDisplay("EntityMultiMap[{_entities.Count}]")]
    public sealed class EntityMultiMap<TKey> : IEntityContainer, ISortable
    {
        #region Types

        internal sealed class Entities
        {
            private Entity[] _entities;
            private int _sortedIndex;

            public int Count { get; private set; }

            public Entities()
            {
                _entities = EmptyArray<Entity>.Value;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlySpan<Entity> GetEntities(int start, int length) => new(_entities, start, length);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ReadOnlySpan<Entity> GetEntities() => GetEntities(0, Count);

            public int Add(in Entity entity, int worldMaxCapacity)
            {
                if (_sortedIndex >= Count || _entities[_sortedIndex].EntityId > entity.EntityId)
                {
                    _sortedIndex = 0;
                }

                int index = Count++;

                ArrayExtension.EnsureLength(ref _entities, index, worldMaxCapacity);

                _entities[index] = entity;

                return index;
            }

            public int Remove(int index)
            {
                --Count;

                if (index != Count)
                {
                    _entities[index] = _entities[Count];

                    _sortedIndex = Math.Min(_sortedIndex, index);
                }

                return _entities[index].EntityId;
            }

            public void Sort(Mapping[] mappings, ref bool shouldContinue)
            {
                for (; _sortedIndex < Count - 1 && Volatile.Read(ref shouldContinue); ++_sortedIndex)
                {
                    int minIndex = _sortedIndex;
                    int minEntityId = _entities[_sortedIndex].EntityId;
                    for (int i = _sortedIndex + 1; i < Count; ++i)
                    {
                        if (_entities[i].EntityId < minEntityId)
                        {
                            minEntityId = _entities[i].EntityId;
                            minIndex = i;
                        }
                    }

                    if (minIndex != _sortedIndex)
                    {
                        int sortedEntityId = _entities[_sortedIndex].EntityId;

                        (_entities[minIndex], _entities[_sortedIndex]) = (_entities[_sortedIndex], _entities[minIndex]);

                        mappings[minEntityId].ItemIndex = _sortedIndex;
                        mappings[sortedEntityId].ItemIndex = minIndex;
                    }
                }
            }

            public void SetAsSorted() => _sortedIndex = Count;

            public void Clear()
            {
                Count = 0;
                _sortedIndex = 0;
            }

            public void TrimExcess() => ArrayExtension.Trim(ref _entities, Count);
        }

        internal struct Mapping
        {
            public Entities Entities;
            public int ItemIndex;
        }

        /// <summary>
        /// Allows to enumerate the <typeparamref name="TKey"/> of a <see cref="EntityMultiMap{TKey}" />.
        /// </summary>
        public readonly struct KeyEnumerable : IEnumerable<TKey>
        {
            private readonly EntityMultiMap<TKey> _map;

            internal KeyEnumerable(EntityMultiMap<TKey> map)
            {
                _map = map;
            }

            #region IEnumerable

            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection.</returns>
            public KeyEnumerator GetEnumerator() => new(_map);

            /// <inheritdoc cref="GetEnumerator" />
            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc cref="GetEnumerator" />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            #endregion
        }

        /// <summary>
        /// Enumerates the <typeparamref name="TKey"/> of a <see cref="EntityMultiMap{TKey}" />.
        /// </summary>
        public struct KeyEnumerator : IEnumerator<TKey>
        {
            private readonly EntityMultiMap<TKey> _map;

            private Dictionary<TKey, Entities>.Enumerator _enumerator;

            internal KeyEnumerator(EntityMultiMap<TKey> map)
            {
                _map = map;

                _enumerator = map._entities.GetEnumerator();

                Current = default;
            }

            #region IEnumerator

            /// <summary>
            /// Gets the <typeparamref name="TKey"/> at the current position of the enumerator.
            /// </summary>
            /// <returns>The <typeparamref name="TKey"/> at the current position of the enumerator.</returns>
            public TKey Current { get; private set; }

            /// <inheritdoc cref="Current" />
            object IEnumerator.Current => Current;

            /// <summary>Advances the enumerator to the next <typeparamref name="TKey"/> of the <see cref="EntityMultiMap{TKey}" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next <typeparamref name="TKey"/>; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                while (_enumerator.MoveNext())
                {
                    if (_enumerator.Current.Value.Count > 0)
                    {
                        Current = _enumerator.Current.Key;
                        return true;
                    }
                }

                return false;
            }

            /// <inheritdoc />
            void IEnumerator.Reset() => _enumerator = _map._entities.GetEnumerator();

            #endregion

            #region IDisposable

            /// <summary>
            /// Releases all resources used by the <see cref="KeyEnumerator" />.
            /// </summary>
            public void Dispose() => _enumerator.Dispose();

            #endregion
        }

        #endregion

        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _worldMaxCapacity;
        private readonly IDisposable _subscriptions;
        private readonly ComponentPool<TKey> _components;
        private readonly Dictionary<TKey, Entities> _entities;

        private Mapping[] _mapping;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the keys contained in the <see cref="EntityMultiMap{TKey}"/>.
        /// </summary>
        public KeyEnumerable Keys => new(this);

        /// <summary>
        /// Gets the <see cref="Entity"/> instances associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <see cref="Entity"/> instances to get.</param>
        /// <returns>The <see cref="Entity"/> instances associated with the specified key.</returns>
        public ReadOnlySpan<Entity> this[TKey key] => _entities[key].GetEntities();

        #endregion

        #region Initialisation

        internal EntityMultiMap(
            bool needClearing,
            World world,
            Predicate<ComponentEnum> filter,
            Predicate<int> predicate,
            List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions,
            int capacity,
            IEqualityComparer<TKey> comparer)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity == int.MaxValue ? int.MaxValue : (world.MaxCapacity + 1);
            EntityContainerWatcher container = new(this, filter, predicate);
            _subscriptions = Enumerable
                .Repeat(world.Subscribe<EntityComponentChangedMessage<TKey>>(On), 1)
                .Concat(subscriptions.Select(s => s(container, world)))
                .Merge();
            _components = ComponentManager<TKey>.GetOrCreate(_worldId);
            _entities = new Dictionary<TKey, Entities>(capacity, comparer);

            _mapping = EmptyArray<Mapping>.Value;

            if (!_needClearing)
            {
                IEntityContainer @this = this;
                foreach (Entity entity in _components.GetEntities())
                {
                    if (filter(entity.Components) && predicate(entity.EntityId))
                    {
                        @this.Add(entity.EntityId);
                    }
                }

                foreach (Entities entities in _entities.Values)
                {
                    entities.SetAsSorted();
                }
            }

            world.Add(this);
        }

        #endregion

        #region Callbacks

        private void On(in EntityComponentChangedMessage<TKey> message)
        {
            if (message.EntityId < _mapping.Length)
            {
                ref Mapping mapping = ref _mapping[message.EntityId];
                if (mapping.Entities != null)
                {
                    ref TKey newKey = ref _components.Get(message.EntityId);
                    int newId = mapping.Entities.Remove(mapping.ItemIndex);
                    if (newId != message.EntityId)
                    {
                        _mapping[newId].ItemIndex = mapping.ItemIndex;
                    }

                    if (!_entities.TryGetValue(newKey, out mapping.Entities))
                    {
                        mapping.Entities = new Entities();
                        _entities.Add(newKey, mapping.Entities);
                    }

                    mapping.ItemIndex = mapping.Entities.Add(new Entity(_worldId, message.EntityId), _worldMaxCapacity);
                }
            }
        }

        #endregion

        #region Methods

        internal bool TryGetEntities(TKey key, out Entities entities) => _entities.TryGetValue(key, out entities);

        /// <summary>
        /// Gets the number of <see cref="Entity"/> in the current <see cref="EntityMultiMap{TKey}"/> for the given <typeparamref name="TKey"/>.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="EntityMultiMap{TKey}"/>.</param>
        /// <returns>The number of <see cref="Entity"/> in the current <see cref="EntityMultiMap{TKey}"/> for the given <typeparamref name="TKey"/>.</returns>
        public int Count(TKey key) => _entities.TryGetValue(key, out Entities entities) ? entities.Count : 0;

        /// <summary>
        /// Determines whether the <see cref="EntityMultiMap{TKey}"/> contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="EntityMultiMap{TKey}"/>.</param>
        /// <returns>true if the <see cref="EntityMultiMap{TKey}"/> contains the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key) => _entities.TryGetValue(key, out Entities entities) && entities.Count > 0;

        /// <summary>
        /// Gets the <see cref="Entity"/> instances associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <see cref="Entity"/> instances to get.</param>
        /// <param name="entities">When this method returns, contains the <see cref="Entity"/> instances associated with the specified key, if the key is found; otherwise, the type default value. This parameter is passed uninitialized.</param>
        /// <returns>true if the <see cref="EntityMultiMap{TKey}"/> contains <see cref="Entity"/> instances with the specified key; otherwise, false.</returns>
        public bool TryGetEntities(TKey key, out ReadOnlySpan<Entity> entities)
        {
            entities = _entities.TryGetValue(key, out Entities e) ? e.GetEntities() : default;
            return entities.Length > 0;
        }

        #endregion

        #region IEntityContainer

        /// <inheritdoc/>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World => World.Worlds[_worldId];

        /// <inheritdoc/>
        public event EntityAddedHandler EntityAdded;

        /// <inheritdoc/>
        public event EntityRemovedHandler EntityRemoved;

        /// <inheritdoc/>
        public bool Contains(in Entity entity) => entity.EntityId < _mapping.Length && _mapping[entity.EntityId].Entities != null;

        /// <inheritdoc/>
        public void Complete()
        {
            if (_needClearing)
            {
                _mapping.Fill(default);
                foreach (Entities entities in _entities.Values)
                {
                    entities.Clear();
                }
            }
        }

        /// <inheritdoc/>
        public void TrimExcess()
        {
#if NETSTANDARD2_1
            _entities.TrimExcess();
#endif

            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i.Entities != null) + 1);

            foreach (Entities entities in _entities.Values)
            {
                entities.TrimExcess();
            }
        }

        void Internal.IEntityContainer.Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _worldMaxCapacity);

            ref Mapping mapping = ref _mapping[entityId];
            if (mapping.Entities is null)
            {
                ref TKey key = ref _components.Get(entityId);

                if (!_entities.TryGetValue(key, out mapping.Entities))
                {
                    mapping.Entities = new Entities();
                    _entities.Add(key, mapping.Entities);
                }

                mapping.ItemIndex = mapping.Entities.Add(new Entity(_worldId, entityId), _worldMaxCapacity);

                EntityAdded?.Invoke(new Entity(_worldId, entityId));
            }
        }

        void Internal.IEntityContainer.Remove(int entityId)
        {
            if (entityId < _mapping.Length)
            {
                ref Mapping mapping = ref _mapping[entityId];
                if (mapping.Entities != null)
                {
                    int newId = mapping.Entities.Remove(mapping.ItemIndex);
                    if (newId != entityId)
                    {
                        _mapping[newId].ItemIndex = mapping.ItemIndex;
                    }
                    mapping = default;

                    EntityRemoved?.Invoke(new Entity(_worldId, entityId));
                }
            }
        }

        #endregion

        #region ISortable

        void ISortable.Sort(ref bool shouldContinue)
        {
            using Dictionary<TKey, Entities>.ValueCollection.Enumerator enumerable = _entities.Values.GetEnumerator();

            while (Volatile.Read(ref shouldContinue) && enumerable.MoveNext())
            {
                enumerable.Current.Sort(_mapping, ref shouldContinue);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntitySet"/> of its subscriptions, stopping it to get modifications on the <see cref="World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose()
        {
            _subscriptions.Dispose();
            World.Worlds[_worldId]?.Remove(this);
        }

        #endregion
    }
}
