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
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/> sorted by a specific component.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component to sort <see cref="Entity"/> by.</typeparam>
    [DebuggerTypeProxy(typeof(EntitySortedSetDebugView<>))]
    [DebuggerDisplay("EntitySortedSet[{Count}]")]
    public sealed class EntitySortedSet<TComponent> : IEntityContainer, IDisposable
    {
        #region Fields

        private readonly bool _needClearing;
        private readonly short _worldId;
        private readonly int _worldMaxCapacity;
        private readonly IDisposable _subscriptions;
        private readonly IComparer<Entity> _comparer;

        private int[] _mapping;
        private Entity[] _entities;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance from which current <see cref="EntitySortedSet{T}"/> originate.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World => World.Worlds[_worldId];

        /// <summary>
        /// Gets the number of <see cref="Entity"/> in the current <see cref="EntitySortedSet{T}"/>.
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        #endregion

        #region Initialisation

        internal EntitySortedSet(
            bool needClearing,
            World world,
            Predicate<ComponentEnum> filter,
            Predicate<int> predicate,
            List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions,
            IComparer<TComponent> comparer)
        {
            _needClearing = needClearing;
            _worldId = world.WorldId;
            _worldMaxCapacity = world.MaxCapacity == int.MaxValue ? int.MaxValue : (world.MaxCapacity + 1);
            EntityContainerWatcher container = new(this, filter, predicate);
            _subscriptions = Enumerable
                .Repeat(world.Subscribe<ComponentChangedMessage<TComponent>>(On), 1)
                .Concat(subscriptions.Select(s => s(container, world)))
                .Merge();
            comparer ??= Comparer<TComponent>.Default;
            ComponentPool<TComponent> components = ComponentManager<TComponent>.GetOrCreate(_worldId);
            _comparer = Comparer<Entity>.Create((e1, e2) => comparer.Compare(components.Get(e1.EntityId), components.Get(e2.EntityId)));

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
        }

        #endregion

        #region Callbacks

        private void On(in ComponentChangedMessage<TComponent> message)
        {
            if (message.EntityId < _mapping.Length && _mapping[message.EntityId] != -1)
            {
                Array.Sort(_entities, 0, Count, _comparer);
                for (int i = 0; i < Count; ++i)
                {
                    _mapping[_entities[i].EntityId] = i;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySortedSet{T}"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySortedSet{T}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => new(_entities, 0, Count);

        /// <summary>
        /// Clears current instance of its entities if it was created with some reactive filter (<see cref="EntityQueryBuilder.WhenAdded{T}"/>, <see cref="EntityQueryBuilder.WhenChanged{T}"/> or <see cref="EntityQueryBuilder.WhenRemoved{T}"/>).
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

        /// <summary>
        /// Determines whether an <see cref="Entity"/> is in the <see cref="EntitySortedSet{T}"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to locate in the <see cref="EntitySortedSet{T}"/>.</param>
        /// <returns>true if <paramref name="entity" /> is found in the <see cref="EntitySortedSet{T}" />; otherwise, false.</returns>
        public bool Contains(in Entity entity) => entity.WorldId == _worldId && entity.EntityId < _mapping.Length && _mapping[entity.EntityId] != -1;

        #endregion

        #region IEntityContainer

        void IEntityContainer.Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _worldMaxCapacity, -1);

            ref int index = ref _mapping[entityId];
            if (index == -1)
            {
                index = Count++;

                ArrayExtension.EnsureLength(ref _entities, index, _worldMaxCapacity);

                _entities[index] = new Entity(_worldId, entityId);
                if (Count > 1 && _comparer.Compare(_entities[index], _entities[index - 1]) < 0)
                {
                    Array.Sort(_entities, 0, Count, _comparer);
                    for (int i = 0; i < Count; ++i)
                    {
                        _mapping[_entities[i].EntityId] = i;
                    }
                }
            }
        }

        void IEntityContainer.Remove(int entityId)
        {
            if (entityId < _mapping.Length)
            {
                ref int index = ref _mapping[entityId];
                if (index != -1)
                {
                    int length = Count-- - index;

                    if (length > 0)
                    {
                        Array.Copy(_entities, index + 1, _entities, index, length);

                        for (int i = index; i < Count; ++i)
                        {
                            _mapping[_entities[i].EntityId] = i;
                        }
                    }

                    index = -1;
                }
            }
        }

        /// <summary>
        /// Resizes inner storage to exactly the number of <see cref="Entity"/> this <see cref="EntitySortedSet{T}"/> contains.
        /// </summary>
        public void TrimExcess()
        {
            ArrayExtension.Trim(ref _entities, Count);
            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i != -1) + 1);
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntitySortedSet{T}"/> of its subscriptions, stopping it to get modifications on the <see cref="World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose() => _subscriptions.Dispose();

        #endregion
    }
}
