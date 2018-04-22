using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/>.
    /// </summary>
    public sealed class EntitySet : IDisposable
    {
        #region Fields

        private readonly ComponentEnum _withFilter;
        private readonly ComponentEnum _withoutFilter;
        private readonly int[] _mapping;
        private readonly Entity[] _entities;
        private readonly IDisposable[] _subscriptions;

        private int _lastIndex;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the numbers of <see cref="Entity"/> in the current <see cref="EntitySet"/>.
        /// </summary>
        public int Count => _lastIndex + 1;

        #endregion

        #region Initialisation

        internal EntitySet(World world, ComponentEnum withFilter, ComponentEnum withoutFilter, List<Func<EntitySet, World, IDisposable>> subscriptions)
        {
            _withFilter = withFilter;
            _withoutFilter = withoutFilter;
            _mapping = Enumerable.Repeat(-1, world.MaxEntityCount).ToArray();
            _entities = new Entity[world.MaxEntityCount];
            _subscriptions = subscriptions.Select(s => s(this, world)).ToArray();

            _lastIndex = -1;

            for (int i = 0; i <= world.LastEntityId; ++i)
            {
                ref ComponentEnum components = ref World.EntityComponents[world.WorldId][i];
                if (components.Contains(_withFilter)
                    && components.DoNotContains(_withoutFilter))
                {
                    Add(new Entity(world.WorldId, i));
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Add(Entity item)
        {
            ref int index = ref _mapping[item.EntityId];
            if (index == -1)
            {
                index = ++_lastIndex;
                _entities[index] = item;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Remove(Entity item)
        {
            ref int index = ref _mapping[item.EntityId];
            if (index != -1)
            {
                if (index != _lastIndex)
                {
                    ref Entity entity = ref _entities[index];
                    entity = _entities[_lastIndex];
                    _mapping[entity.EntityId] = index;
                }

                --_lastIndex;
                index = -1;
            }
        }

        internal void Created(in EntityCreatedMessage message)
        {
            Add(message.Entity);
        }

        internal void Disposed(in EntityDisposedMessage message)
        {
            Remove(message.Entity);
        }

        internal void WithAdded<T>(in ComponentAddedMessage<T> message)
        {
            if (message.Components.Contains(_withFilter)
                && message.Components.DoNotContains(_withoutFilter))
            {
                Add(message.Entity);
            }
        }

        internal void WithRemoved<T>(in ComponentRemovedMessage<T> message) => Remove(message.Entity);

        internal void WithoutAdded<T>(in ComponentAddedMessage<T> message) => Remove(message.Entity);

        internal void WithoutRemoved<T>(in ComponentRemovedMessage<T> message)
        {
            if (message.Components.Contains(_withFilter)
                && message.Components.DoNotContains(_withoutFilter))
            {
                Add(message.Entity);
            }
        }

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => new ReadOnlySpan<Entity>(_entities, 0, Count);

        /// <summary>
        /// Copies <see cref="Entity"/> of current <see cref="EntitySet"/> to a destination <see cref="Span{Entity}"/>.
        /// Passed parameter destination should be created with the correct length.
        /// </summary>
        /// <param name="destination">The <see cref="Span{Entity}"/> on which to copy <see cref="Entity"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyEntitiesTo(Span<Entity> destination) => GetEntities().CopyTo(destination);

        /// <summary>
        /// Copies <see cref="Entity"/> of current <see cref="EntitySet"/> to an <see cref="Array"/>.
        /// </summary>
        /// <returns>The <see cref="Array"/> with all the <see cref="Entity"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Entity[] CopyEntities() => GetEntities().ToArray();

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntitySet"/> of its subscriptions, stopping it to get modifications on the <see cref="World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose()
        {
            foreach (IDisposable subscription in _subscriptions)
            {
                subscription.Dispose();
            }
        }

        #endregion
    }
}
