using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/>.
    /// </summary>
    public abstract class EntitySet : IDisposable
    {
        #region Fields

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

        private protected EntitySet(World world)
        {
            _mapping = Enumerable.Repeat(-1, world.MaxEntityCount).ToArray();
            _entities = new Entity[world.MaxEntityCount];
            _subscriptions = Subscribe(world).ToArray();

            _lastIndex = -1;
        }

        #endregion

        #region Methods

        private protected abstract IEnumerable<IDisposable> Subscribe(World world);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private protected void Add(Entity item)
        {
            ref int index = ref _mapping[item.EntityId];
            if (index == -1)
            {
                index = ++_lastIndex;
                _entities[index] = item;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private protected void Remove(Entity item)
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

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => new ReadOnlySpan<Entity>(_entities, 0, Count);

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

    internal sealed class AllEntitySet : EntitySet
    {
        #region Initialisation

        public AllEntitySet(World world)
            : base(world)
        { }

        #endregion

        #region EntitySet

        private protected override IEnumerable<IDisposable> Subscribe(World world)
        {
            yield return world.Subscribe((in EntityCreatedMessage m) => Add(m.Entity));
            yield return world.Subscribe((in EntityDisposedMessage m) => Remove(m.Entity));
        }

        #endregion
    }

    internal sealed class EntitySet<T> : EntitySet
    {
        #region Initialisation

        public EntitySet(World world)
            : base(world)
        { }

        #endregion

        #region EntitySet

        private protected override IEnumerable<IDisposable> Subscribe(World world)
        {
            yield return world.Subscribe((in ComponentAddedMessage<T> m) => Add(m.Entity));
            yield return world.Subscribe((in ComponentRemovedMessage<T> m) => Remove(m.Entity));
        }

        #endregion
    }

    internal sealed class EntitySet<T1, T2> : EntitySet
    {
        #region Initialisation

        public EntitySet(World world)
            : base(world)
        { }

        #endregion

        #region Callbacks

        private void On(in ComponentAddedMessage<T1> message)
        {
            if (message.Entity.Has<T2>())
            {
                Add(message.Entity);
            }
        }

        private void On(in ComponentAddedMessage<T2> message)
        {
            if (message.Entity.Has<T1>())
            {
                Add(message.Entity);
            }
        }

        #endregion

        #region EntitySet

        private protected override IEnumerable<IDisposable> Subscribe(World world)
        {
            yield return world.Subscribe<ComponentAddedMessage<T1>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T1> m) => Remove(m.Entity));
            yield return world.Subscribe<ComponentAddedMessage<T2>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T2> m) => Remove(m.Entity));
        }

        #endregion
    }

    internal sealed class EntitySet<T1, T2, T3> : EntitySet
    {
        #region Initialisation

        public EntitySet(World world)
            : base(world)
        { }

        #endregion

        #region Callbacks

        private void On(in ComponentAddedMessage<T1> message)
        {
            if (message.Entity.Has<T2>()
                && message.Entity.Has<T3>())
            {
                Add(message.Entity);
            }
        }

        private void On(in ComponentAddedMessage<T2> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T3>())
            {
                Add(message.Entity);
            }
        }

        private void On(in ComponentAddedMessage<T3> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T2>())
            {
                Add(message.Entity);
            }
        }

        #endregion

        #region EntitySet

        private protected override IEnumerable<IDisposable> Subscribe(World world)
        {
            yield return world.Subscribe<ComponentAddedMessage<T1>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T1> m) => Remove(m.Entity));
            yield return world.Subscribe<ComponentAddedMessage<T2>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T2> m) => Remove(m.Entity));
            yield return world.Subscribe<ComponentAddedMessage<T3>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T3> m) => Remove(m.Entity));
        }

        #endregion
    }

    internal sealed class EntitySet<T1, T2, T3, T4> : EntitySet
    {
        #region Initialisation

        public EntitySet(World world)
            : base(world)
        { }

        #endregion

        #region Callbacks

        private void On(in ComponentAddedMessage<T1> message)
        {
            if (message.Entity.Has<T2>()
                && message.Entity.Has<T3>()
                && message.Entity.Has<T4>())
            {
                Add(message.Entity);
            }
        }

        private void On(in ComponentAddedMessage<T2> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T3>()
                && message.Entity.Has<T4>())
            {
                Add(message.Entity);
            }
        }

        private void On(in ComponentAddedMessage<T3> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T2>()
                && message.Entity.Has<T4>())
            {
                Add(message.Entity);
            }
        }

        private void On(in ComponentAddedMessage<T4> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T2>()
                && message.Entity.Has<T3>())
            {
                Add(message.Entity);
            }
        }

        #endregion

        #region EntitySet

        private protected override IEnumerable<IDisposable> Subscribe(World world)
        {
            yield return world.Subscribe<ComponentAddedMessage<T1>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T1> m) => Remove(m.Entity));
            yield return world.Subscribe<ComponentAddedMessage<T2>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T2> m) => Remove(m.Entity));
            yield return world.Subscribe<ComponentAddedMessage<T3>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T3> m) => Remove(m.Entity));
            yield return world.Subscribe<ComponentAddedMessage<T4>>(On);
            yield return world.Subscribe((in ComponentRemovedMessage<T4> m) => Remove(m.Entity));
        }

        #endregion
    }
}
