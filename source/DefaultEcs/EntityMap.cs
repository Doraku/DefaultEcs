using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a collection of <see cref="Entity"/> mapped to a <typeparamref name="TKey"/> component. Only one <see cref="Entity"/> can be associated with a given <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the component used as key.</typeparam>
    public sealed class EntityMap<TKey> : IEntityContainer, IDisposable
    {
        #region Types

        /// <summary>
        /// Allows to enumerate the <typeparamref name="TKey"/> of a <see cref="EntityMap{TKey}" />.
        /// </summary>
        public readonly struct KeyEnumerable : IEnumerable<TKey>
        {
            private readonly EntityMap<TKey> _map;

            internal KeyEnumerable(EntityMap<TKey> map)
            {
                _map = map;
            }

            #region IEnumerable

            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection.</returns>
            public KeyEnumerator GetEnumerator() => new KeyEnumerator(_map);

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            #endregion
        }

        /// <summary>
        /// Enumerates the <typeparamref name="TKey"/> of a <see cref="EntityMap{TKey}" />.
        /// </summary>
        public struct KeyEnumerator : IEnumerator<TKey>
        {
            private readonly EntityMap<TKey> _map;

            private Dictionary<TKey, Entity>.KeyCollection.Enumerator _enumerator;

            internal KeyEnumerator(EntityMap<TKey> map)
            {
                _map = map;

                _enumerator = map._entities.Keys.GetEnumerator();
            }

            #region IEnumerator

            /// <summary>
            /// Gets the <typeparamref name="TKey"/> at the current position of the enumerator.
            /// </summary>
            /// <returns>The <typeparamref name="TKey"/> at the current position of the enumerator.</returns>
            public TKey Current => _enumerator.Current;

            object IEnumerator.Current => Current;

            /// <summary>Advances the enumerator to the next <typeparamref name="TKey"/> of the <see cref="EntityMap{TKey}" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next <typeparamref name="TKey"/>; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext() => _enumerator.MoveNext();

            void IEnumerator.Reset() => _enumerator = _map._entities.Keys.GetEnumerator();

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
        private readonly EntityContainerWatcher _container;
        private readonly IDisposable _subscriptions;
        private readonly ComponentPool<TKey> _previousComponents;
        private readonly ComponentPool<TKey> _components;
        private readonly Dictionary<TKey, Entity> _entities;

        private bool[] _entityIds;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance from which current <see cref="EntityMap{TKey}"/> originate.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World => World.Worlds[_worldId];

        /// <summary>
        /// Gets the keys contained in the <see cref="EntityMap{TKey}"/>.
        /// </summary>
        public KeyEnumerable Keys => new KeyEnumerable(this);

        /// <summary>
        /// Gets the <see cref="Entity"/> associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <see cref="Entity"/> to get.</param>
        /// <returns>The <see cref="Entity"/> associated with the specified key.</returns>
        public Entity this[TKey key] => _entities[key];

        #endregion

        #region Initialisation

        internal EntityMap(
            bool needClearing,
            World world,
            Predicate<ComponentEnum> filter,
            Predicate<int> predicate,
            List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions,
            IEqualityComparer<TKey> comparer)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity;
            _container = new EntityContainerWatcher(this, filter, predicate);
            _subscriptions = Enumerable.Repeat(world.Subscribe<ComponentChangedMessage<TKey>>(OnChange), 1).Concat(subscriptions.Select(s => s(_container, world))).Merge();

            _previousComponents = ComponentManager<TKey>.GetOrCreatePrevious(_worldId);
            _components = ComponentManager<TKey>.GetOrCreate(_worldId);
            _entities = new Dictionary<TKey, Entity>(comparer);

            _entityIds = EmptyArray<bool>.Value;

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
            }
        }

        #endregion

        #region Callbacks

        private void OnChange(in ComponentChangedMessage<TKey> message)
        {
            if (message.EntityId < _entityIds.Length && _entityIds[message.EntityId] && _entities.Remove(_previousComponents.Get(message.EntityId)))
            {
                _entities.Add(_components.Get(message.EntityId), new Entity(_worldId, message.EntityId));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the <see cref="EntityMap{TKey}"/> contains a specific <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to locate in the <see cref="EntityMap{TKey}"/>.</param>
        /// <returns>true if the <see cref="EntityMap{TKey}"/> contains the specified <see cref="Entity"/>; otherwise, false.</returns>
        public bool ContainsEntity(Entity entity) => entity.EntityId < _entityIds.Length && _entityIds[entity.EntityId];

        /// <summary>
        /// Determines whether the <see cref="EntityMap{TKey}"/> contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="EntityMap{TKey}"/>.</param>
        /// <returns>true if the <see cref="EntityMap{TKey}"/> contains the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key) => _entities.ContainsKey(key);

        /// <summary>
        /// Gets the <see cref="Entity"/> associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <see cref="Entity"/> to get.</param>
        /// <param name="entity">When this method returns, contains the <see cref="Entity"/> associated with the specified key, if the key is found; otherwise, an invalid <see cref="Entity"/>. This parameter is passed uninitialized.</param>
        /// <returns>true if the <see cref="EntityMap{TKey}"/> contains an <see cref="Entity"/> with the specified key; otherwise, false.</returns>
        public bool TryGetEntity(TKey key, out Entity entity) => _entities.TryGetValue(key, out entity);

        /// <summary>
        /// Clears current instance of its entities if it was created with some reactive filter (<seealso cref="EntityRuleBuilder.WhenAdded{T}"/>, <see cref="EntityRuleBuilder.WhenChanged{T}"/> or <see cref="EntityRuleBuilder.WhenRemoved{T}"/>).
        /// Does nothing if it was created from a static filter.
        /// This method need to be called after current instance content has been processed in a update cycle.
        /// </summary>
        public void Complete()
        {
            if (_needClearing)
            {
                _entityIds.Fill(false);
                _entities.Clear();
            }
        }

        #endregion

        #region IEntityContainer

        void IEntityContainer.Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _entityIds, entityId, _worldMaxCapacity);

            if (!_entityIds[entityId])
            {
                _entityIds[entityId] = true;
                _entities.Add(_components.Get(entityId), new Entity(_worldId, entityId));
            }
        }

        void IEntityContainer.Remove(int entityId)
        {
            if (entityId < _entityIds.Length && _entityIds[entityId])
            {
                _entityIds[entityId] = false;
                _entities.Remove(_previousComponents.Get(entityId));
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntityMap{TKey}"/> of its subscriptions, stopping it to get modifications on the <see cref="DefaultEcs.World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose()
        {
            _subscriptions.Dispose();
        }

        #endregion
    }
}
