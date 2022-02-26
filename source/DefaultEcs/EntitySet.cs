using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Internal;
using DefaultEcs.Internal.Diagnostics;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/>.
    /// </summary>
    [DebuggerTypeProxy(typeof(EntitySetDebugView))]
    [DebuggerDisplay("EntitySet[{Count}]")]
    public sealed class EntitySet : IEntityContainer, ISortable
    {
        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _worldMaxCapacity;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private Entity[] _entities;
        private int _sortedIndex;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of <see cref="Entity"/> in the current <see cref="EntitySet"/>.
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
            Predicate<ComponentEnum> filter,
            Predicate<int> predicate,
            List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity == int.MaxValue ? int.MaxValue : (world.MaxCapacity + 1);
            EntityContainerWatcher container = new(this, filter, predicate);
            _subscriptions = subscriptions
                .Select(s => s(container, world))
                .Merge();

            _mapping = EmptyArray<int>.Value;
            _entities = EmptyArray<Entity>.Value;
            Count = 0;

            if (!_needClearing)
            {
                IEntityContainer @this = this;
                for (int i = 1; i <= Math.Min(world.EntityInfos.Length, world.LastEntityId); ++i)
                {
                    if (filter(world.EntityInfos[i].Components) && predicate(i))
                    {
                        @this.Add(i);
                    }
                }
            }

            _sortedIndex = Math.Max(0, Count - 1);
            world.Add(this);
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ReadOnlySpan<Entity> GetEntities(int start, int length) => new(_entities, start, length);

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => GetEntities(0, Count);

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
        public bool Contains(in Entity entity) => entity.WorldId == _worldId && entity.EntityId < _mapping.Length && _mapping[entity.EntityId] != -1;

        /// <inheritdoc/>
        public void Complete()
        {
            if (_needClearing && Count > 0)
            {
                Count = 0;
                _mapping.Fill(-1);
                _sortedIndex = 0;
            }
        }

        /// <inheritdoc/>
        public void TrimExcess()
        {
            ArrayExtension.Trim(ref _entities, Count);
            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i != -1) + 1);
        }

        void Internal.IEntityContainer.Add(int entityId)
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

                EntityAdded?.Invoke(new Entity(_worldId, entityId));
            }
        }

        void Internal.IEntityContainer.Remove(int entityId)
        {
            if (entityId < _mapping.Length)
            {
                ref int index = ref _mapping[entityId];
                if (index != -1)
                {
                    --Count;

                    if (index != Count)
                    {
                        _entities[index] = _entities[Count];
                        _mapping[_entities[Count].EntityId] = index;

                        _sortedIndex = Math.Min(_sortedIndex, index);
                    }

                    index = -1;

                    EntityRemoved?.Invoke(new Entity(_worldId, entityId));
                }
            }
        }

        #endregion

        #region ISortable

        void ISortable.Sort(ref bool shouldContinue)
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

                    _mapping[minEntityId] = _sortedIndex;
                    _mapping[sortedEntityId] = minIndex;
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
