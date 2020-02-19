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
    /// Represents a collection of <see cref="Entity"/> mapped to a <typeparamref name="TKey"/> component. Only one <see cref="Entity"/> can be associated with a given <typeparamref name="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the component used as key.</typeparam>
    public sealed class EntityMap<TKey> : IEntityContainer, IDisposable
    {
        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _worldMaxCapacity;
        private readonly EntityContainerWatcher _container;
        private readonly IDisposable _subscriptions;
        private readonly ComponentPool<TKey> _previousComponents;
        private readonly ComponentPool<TKey> _components;
        private readonly Dictionary<TKey, int> _entities;

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
        public IEnumerable<TKey> Keys => _entities.Keys;

        /// <summary>
        /// Gets the <see cref="Entity"/> associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <see cref="Entity"/> to get.</param>
        /// <returns>The <see cref="Entity"/> associated with the specified key.</returns>
        public Entity this[TKey key] => new Entity(_worldId, _entities[key]);

        #endregion

        #region Initialisation

        internal EntityMap(
            bool needClearing,
            World world,
            Predicate<ComponentEnum> filter,
            List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions,
            IEqualityComparer<TKey> comparer)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity;
            _container = new EntityContainerWatcher(this, filter);
            _subscriptions = Enumerable.Repeat(world.Subscribe<ComponentChangedMessage<TKey>>(OnChange), 1).Concat(subscriptions.Select(s => s(_container, world))).Merge();

            _previousComponents = ComponentManager<TKey>.GetOrCreatePrevious(_worldId);
            _components = ComponentManager<TKey>.GetOrCreate(_worldId);
            _entities = new Dictionary<TKey, int>(comparer);

            _entityIds = EmptyArray<bool>.Value;

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
            if (message.EntityId < _entityIds.Length && _entityIds[message.EntityId] && _entities.Remove(_previousComponents.Get(message.EntityId)))
            {
                _entities.Add(_components.Get(message.EntityId), message.EntityId);
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
        public bool TryGetEntity(TKey key, out Entity entity) => (entity = _entities.TryGetValue(key, out int id) ? new Entity(_worldId, id) : default).WorldId != 0;

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
                _entities.Add(_components.Get(entityId), entityId);
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
