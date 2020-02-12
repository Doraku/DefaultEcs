using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Debug;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/>.
    /// </summary>
    [DebuggerTypeProxy(typeof(EntitySetDebugView))]
    [DebuggerDisplay("EntitySet[{Count}]")]
    public sealed class EntitySet : IOptimizable, IDisposable
    {
        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _worldMaxCapacity;
        private readonly Predicate<ComponentEnum> _filter;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private Entity[] _entities;
        private event ActionIn<Entity> EntityAddedEvent;
        private int _sortedIndex;

        /// <summary>
        /// Event called when an <see cref="Entity"/> is added to the <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> EntityAdded
        {
            add
            {
                if (value != null)
                {
                    foreach (ref readonly Entity entity in GetEntities())
                    {
                        value(entity);
                    }
                }
                EntityAddedEvent += value;
            }
            remove => EntityAddedEvent -= value;
        }

        /// <summary>
        /// Event called when an <see cref="Entity"/> is removed from the <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> EntityRemoved;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance from which current <see cref="EntitySet"/> originate. 
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World => World.Worlds[_worldId];

        /// <summary>
        /// Gets the numbers of <see cref="Entity"/> in the current <see cref="EntitySet"/>.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        #endregion

        #region Initialisation

        internal EntitySet(
            bool needClearing,
            World world,
            ComponentEnum withFilter,
            ComponentEnum withoutFilter,
            List<ComponentEnum> withEitherFilters,
            List<ComponentEnum> withoutEitherFilters,
            List<Func<EntitySet, World, IDisposable>> subscriptions)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity;

            _filter = EntityRuleFilterFactory.GetFilter(withFilter, withoutFilter, withEitherFilters, withoutEitherFilters);

            _subscriptions = subscriptions.Select(s => s(this, world)).Merge();

            _mapping = EmptyArray<int>.Value;
            _entities = EmptyArray<Entity>.Value;
            Count = 0;

            if (!_needClearing)
            {
                for (int i = 0; i <= Math.Min(world.EntityInfos.Length, world.LastEntityId); ++i)
                {
                    if (_filter(world.EntityInfos[i].Components))
                    {
                        Add(i);
                    }
                }
            }

            _sortedIndex = Math.Max(0, Count - 1);
            world.Add(this);
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _worldMaxCapacity, -1);

            ref int index = ref _mapping[entityId];
            if (index == -1)
            {
                if (_sortedIndex >= Count || _entities[_sortedIndex].EntityId > entityId)
                {
                    _sortedIndex = 0;
                }

                index = Count++;

                ArrayExtension.EnsureLength(ref _entities, index, _worldMaxCapacity);

                _entities[index] = new Entity(_worldId, entityId);
                EntityAddedEvent?.Invoke(_entities[index]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Remove(int entityId)
        {
            if (entityId < _mapping.Length)
            {
                ref int index = ref _mapping[entityId];
                if (index != -1)
                {
                    Entity entity = _entities[index];
                    --Count;

                    if (index != Count)
                    {
                        _entities[index] = _entities[Count];
                        _mapping[_entities[Count].EntityId] = index;

                        _sortedIndex = Math.Min(_sortedIndex, index);
                    }

                    index = -1;

                    EntityRemoved?.Invoke(entity);
                }
            }
        }

        internal void Add(in EntityCreatedMessage message) => Add(message.EntityId);

        internal void CheckedAdd(in EntityEnabledMessage message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd(in EntityDisabledMessage message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd<T>(in ComponentAddedMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd<T>(in ComponentChangedMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd<T>(in ComponentRemovedMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd<T>(in ComponentEnabledMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd<T>(in ComponentDisabledMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void Remove(in EntityDisposingMessage message) => Remove(message.EntityId);

        internal void Remove(in EntityEnabledMessage message) => Remove(message.EntityId);

        internal void Remove(in EntityDisabledMessage message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentAddedMessage<T> message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentRemovedMessage<T> message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentEnabledMessage<T> message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentDisabledMessage<T> message) => Remove(message.EntityId);

        internal void CheckedRemove<T>(in ComponentAddedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                Remove(message.EntityId);
            }
        }

        internal void CheckedRemove<T>(in ComponentRemovedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                Remove(message.EntityId);
            }
        }

        internal void CheckedRemove<T>(in ComponentEnabledMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                Remove(message.EntityId);
            }
        }

        internal void CheckedRemove<T>(in ComponentDisabledMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                Remove(message.EntityId);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ReadOnlySpan<Entity> GetEntities(int start, int length) => new ReadOnlySpan<Entity>(_entities, start, length);

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => GetEntities(0, Count);

        /// <summary>
        /// Clears current instance of its entities if it was created with some reactive filter (<seealso cref="EntityRuleBuilder.WhenAdded{T}"/>, <see cref="EntityRuleBuilder.WhenChanged{T}"/> or <see cref="EntityRuleBuilder.WhenRemoved{T}"/>).
        /// Does nothing if it was created from a static filter.
        /// This method need to be called after current instance content has been processed in a update cycle.
        /// </summary>
        public void Complete()
        {
            if (_needClearing && Count > 0)
            {
                Count = 0;
                _mapping.Fill(-1);
                _sortedIndex = 0;
            }
        }

        /// <summary>
        /// Determines whether an <see cref="Entity"/> is in the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to locate in the <see cref="EntitySet"/>.</param>
        /// <returns>true if <paramref name="entity" /> is found in the <see cref="EntitySet" />; otherwise, false.</returns>
        public bool Contains(in Entity entity) => entity.WorldId == _worldId && entity.EntityId < _mapping.Length && _mapping[entity.EntityId] != -1;

        #endregion

        #region IOptimizable

        void IOptimizable.Optimize(ref bool shouldContinue)
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
                    Entity tempEntity = _entities[_sortedIndex];

                    _entities[_sortedIndex] = _entities[minIndex];
                    _entities[minIndex] = tempEntity;

                    _mapping[minEntityId] = _sortedIndex;
                    _mapping[tempEntity.EntityId] = minIndex;
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
            World.Worlds[_worldId]?.Remove(this);
        }

        #endregion
    }
}
