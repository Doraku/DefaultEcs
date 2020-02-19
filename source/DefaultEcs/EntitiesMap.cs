using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a collection of <typeparamref name="TEntities"/> mapped to a <typeparamref name="TKey"/> component. Multiple <see cref="Entity"/> can be associated with a given <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the component used as key.</typeparam>
    /// <typeparam name="TEntities">The collection used to store <see cref="Entity"/> with the same key.</typeparam>
    public sealed class EntitiesMap<TKey, TEntities> : IEntityContainer, IDisposable
        where TEntities : class, ICollection<Entity>
    {
        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _worldMaxCapacity;
        private readonly EntityContainerWatcher _container;
        private readonly IDisposable _subscriptions;
        private readonly ComponentPool<TKey> _components;
        private readonly Dictionary<TKey, TEntities> _entities;
        private readonly Func<TEntities> _factory;

        private TEntities[] _idsToEntities;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance from which current <see cref="EntitiesMap{TKey, TEntities}"/> originate. 
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World => World.Worlds[_worldId];

        /// <summary>
        /// Gets the keys contained in the <see cref="EntitiesMap{TKey, TEntities}"/>.
        /// </summary>
        public IEnumerable<TKey> Keys => _entities.Keys;

        /// <summary>
        /// Gets the <typeparamref name="TEntities"/> associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <typeparamref name="TEntities"/> to get.</param>
        /// <returns>The <typeparamref name="TEntities"/> associated with the specified key.</returns>
        public TEntities this[TKey key] => _entities[key];

        #endregion

        #region Initialisation

        internal EntitiesMap(
            bool needClearing,
            World world,
            Predicate<ComponentEnum> filter,
            List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions,
            Func<TEntities> factory,
            IEqualityComparer<TKey> comparer)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity;
            _container = new EntityContainerWatcher(this, filter);
            _subscriptions = Enumerable.Repeat(world.Subscribe<ComponentChangedMessage<TKey>>(OnChange), 1).Concat(subscriptions.Select(s => s(_container, world))).Merge();
            _factory = factory;

            _components = ComponentManager<TKey>.GetOrCreate(_worldId);
            _entities = new Dictionary<TKey, TEntities>(comparer);

            _idsToEntities = EmptyArray<TEntities>.Value;

            if (!_needClearing)
            {
                IEntityContainer @this = this as IEntityContainer;
                foreach (Entity entity in _components.GetEntities())
                {
                    if (filter(entity.Components))
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
            if (message.EntityId < _idsToEntities.Length)
            {
                ref TEntities entities = ref _idsToEntities[message.EntityId];
                if (entities != null)
                {
                    Entity entity = new Entity(_worldId, message.EntityId);

                    ref TKey newKey = ref _components.Get(message.EntityId);
                    entities.Remove(entity);

                    if (!_entities.TryGetValue(newKey, out entities))
                    {
                        entities = _factory();
                        _entities.Add(newKey, entities);
                    }

                    entities.Add(entity);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether the <see cref="EntitiesMap{TKey, TEntities}"/> contains a specific <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to locate in the <see cref="EntitiesMap{TKey, TEntities}"/>.</param>
        /// <returns>true if the <see cref="EntitiesMap{TKey, TEntities}"/> contains the specified <see cref="Entity"/>; otherwise, false.</returns>
        public bool ContainsEntity(Entity entity) => entity.EntityId < _idsToEntities.Length && _idsToEntities[entity.EntityId] != null;

        /// <summary>
        /// Determines whether the <see cref="EntitiesMap{TKey, TEntities}"/> contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="EntitiesMap{TKey, TEntities}"/>.</param>
        /// <returns>true if the <see cref="EntitiesMap{TKey, TEntities}"/> contains the specified key; otherwise, false.</returns>
        public bool ContainsKey(TKey key) => _entities.ContainsKey(key);

        /// <summary>
        /// Gets the <typeparamref name="TEntities"/> associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <typeparamref name="TEntities"/> to get.</param>
        /// <param name="entities">When this method returns, contains the <typeparamref name="TEntities"/> associated with the specified key, if the key is found; otherwise, the type default value. This parameter is passed uninitialized.</param>
        /// <returns>true if the <see cref="EntitiesMap{TKey, TEntities}"/> contains an <typeparamref name="TEntities"/> with the specified key; otherwise, false.</returns>
        public bool TryGetEntities(TKey key, out TEntities entities) => _entities.TryGetValue(key, out entities);

        /// <summary>
        /// Clears current instance of its entities if it was created with some reactive filter (<seealso cref="EntityRuleBuilder.WhenAdded{T}"/>, <see cref="EntityRuleBuilder.WhenChanged{T}"/> or <see cref="EntityRuleBuilder.WhenRemoved{T}"/>).
        /// Does nothing if it was created from a static filter.
        /// This method need to be called after current instance content has been processed in a update cycle.
        /// </summary>
        public void Complete()
        {
            if (_needClearing)
            {
                _idsToEntities.Fill(null);
                _entities.Clear();
            }
        }

        #endregion

        #region IEntityContainer

        void IEntityContainer.Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _idsToEntities, entityId, _worldMaxCapacity);

            ref TEntities entities = ref _idsToEntities[entityId];
            if (entities is null)
            {
                ref TKey key = ref _components.Get(entityId);

                if (!_entities.TryGetValue(key, out entities))
                {
                    entities = _factory();
                    _entities.Add(key, entities);
                }

                entities.Add(new Entity(_worldId, entityId));
            }
        }

        void IEntityContainer.Remove(int entityId)
        {
            if (entityId < _idsToEntities.Length)
            {
                ref TEntities entities = ref _idsToEntities[entityId];
                if (entities != null)
                {
                    entities.Remove(new Entity(_worldId, entityId));
                    entities = null;
                }
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
        }

        #endregion
    }
}
