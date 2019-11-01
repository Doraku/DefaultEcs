using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public sealed class EntitySet : IDisposable
    {
        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _maxEntityCount;
        private readonly Predicate<ComponentEnum> _filter;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private Entity[] _entities;
        private event ActionIn<Entity> EntityAddedEvent;

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
            _maxEntityCount = world.MaxEntityCount;

            withFilter[World.IsAliveFlag] = true;
            withFilter[World.IsEnabledFlag] = true;

            _filter = EntitySetFilterFactory.GetFilter(withFilter, withoutFilter, withEitherFilters, withoutEitherFilters);

            _subscriptions = subscriptions.Select(s => s(this, world)).Merge();

            _mapping = EmptyArray<int>.Value;
            _entities = EmptyArray<Entity>.Value;
            Count = 0;

            if (!_needClearing)
            {
                for (int i = 0; i <= Math.Min(world.Info.EntityInfos.Length, world.LastEntityId); ++i)
                {
                    if (_filter(world.Info.EntityInfos[i].Components))
                    {
                        Add(i);
                    }
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _maxEntityCount, -1);

            ref int index = ref _mapping[entityId];
            if (index == -1)
            {
                index = Count++;

                ArrayExtension.EnsureLength(ref _entities, index, _maxEntityCount);

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

        internal void Remove(in EntityDisposingMessage message) => Remove(message.EntityId);

        internal void Remove(in EntityDisabledMessage message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentRemovedMessage<T> message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentAddedMessage<T> message) => Remove(message.EntityId);

        internal void CheckedRemove<T>(in ComponentRemovedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                Remove(message.EntityId);
            }
        }

        internal void CheckedRemove<T>(in ComponentAddedMessage<T> message)
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
        /// Clears current instance of its entities if it was created with some reactive filter (<seealso cref="EntitySetBuilder.WhenAdded{T}"/>, <see cref="EntitySetBuilder.WhenChanged{T}"/> or <see cref="EntitySetBuilder.WhenRemoved{T}"/>).
        /// Does nothing if it was created from a static filter.
        /// This method need to be called after current instance content has been processed in a update cycle.
        /// </summary>
        public void Complete()
        {
            if (_needClearing && Count > 0)
            {
                Count = 0;
                _mapping.Fill(-1);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntitySet"/> of its subscriptions, stopping it to get modifications on the <see cref="World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose() => _subscriptions.Dispose();

        #endregion
    }
}
