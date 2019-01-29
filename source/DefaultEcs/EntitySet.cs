using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/>.
    /// </summary>
    public sealed class EntitySet : IDisposable
    {
        #region Fields

        private readonly int _worldId;
        private readonly int _maxEntityCount;
        private readonly ComponentEnum _withFilter;
        private readonly ComponentEnum _withoutFilter;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private Entity[] _entities;
        private int _lastIndex;

        #endregion

        #region Properties

        internal bool IsNotEmpty => _lastIndex > -1;

        /// <summary>
        /// Gets the numbers of <see cref="Entity"/> in the current <see cref="EntitySet"/>.
        /// </summary>
        public int Count => _lastIndex + 1;

        #endregion

        #region Initialisation

        internal EntitySet(World world, ComponentEnum withFilter, ComponentEnum withoutFilter, List<Func<EntitySet, World, IDisposable>> subscriptions)
        {
            _worldId = world.WorldId;
            _maxEntityCount = world.MaxEntityCount;
            _withFilter = withFilter;
            _withoutFilter = withoutFilter;
            _subscriptions = subscriptions.Select(s => s(this, world)).Merge();

            _mapping = new int[0];
            _entities = new Entity[0];
            _lastIndex = -1;

            _withFilter[World.AliveFlag] = true;

            for (int i = 0; i <= Math.Min(world.Info.EntityInfos.Length, world.LastEntityId); ++i)
            {
                ref ComponentEnum components = ref world.Info.EntityInfos[i].Components;
                if (components.Contains(_withFilter)
                    && components.DoNotContains(_withoutFilter))
                {
                    Add(i);
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
                index = ++_lastIndex;

                ArrayExtension.EnsureLength(ref _entities, _lastIndex, _maxEntityCount);

                _entities[_lastIndex] = new Entity(_worldId, entityId);
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
        }

        internal void Created(in EntityCreatedMessage message) => Add(message.EntityId);

        internal void Disposed(in EntityDisposedMessage message) => Remove(message.EntityId);

        internal void WithAdded<T>(in ComponentAddedMessage<T> message)
        {
            if (message.Components.Contains(_withFilter)
                && message.Components.DoNotContains(_withoutFilter))
            {
                Add(message.EntityId);
            }
        }

        internal void WithRemoved<T>(in ComponentRemovedMessage<T> message) => Remove(message.EntityId);

        internal void WithoutAdded<T>(in ComponentAddedMessage<T> message) => Remove(message.EntityId);

        internal void WithoutRemoved<T>(in ComponentRemovedMessage<T> message)
        {
            if (message.Components.Contains(_withFilter)
                && message.Components.DoNotContains(_withoutFilter))
            {
                Add(message.EntityId);
            }
        }

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => new ReadOnlySpan<Entity>(_entities, 0, _lastIndex + 1);

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntitySet"/> of its subscriptions, stopping it to get modifications on the <see cref="World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose() => _subscriptions.Dispose();

        #endregion
    }
}
