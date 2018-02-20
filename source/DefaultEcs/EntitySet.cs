using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Message;

namespace DefaultEcs
{
    public abstract class AEntitySet : IEnumerable<Entity>, IDisposable
    {
        #region Fields

        private protected readonly HashSet<Entity> _entities;

        private protected IDisposable[] _subscriptions;

        #endregion

        #region Properties

        public int Count => _entities.Count;

        #endregion

        #region Initialisation

        public AEntitySet()
        {
            _entities = new HashSet<Entity>();
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(Span<Entity> destination)
        {
            if (destination.Length != _entities.Count)
            {
                throw new InvalidOperationException($"Incorrect destination Length: {destination.Length}, expected: {_entities.Count}");
            }

            int i = 0;
            foreach (Entity entity in _entities)
            {
                destination[i++] = entity;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Entity[] Copy() => _entities.ToArray();

        #endregion

        #region IEnumerable

        public IEnumerator<Entity> GetEnumerator() => _entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region IDisposable

        public void Dispose()
        {
            foreach (IDisposable subscription in _subscriptions)
            {
                subscription.Dispose();
            }
        }

        #endregion
    }

    public sealed class EntitySet : AEntitySet
    {
        #region Initialisation

        public EntitySet(World world)
        {
            _subscriptions = new[]
            {
                world.Subscribe((in EntityCreatedMessage m) => _entities.Add(m.Entity)),
                world.Subscribe((in EntityCleanedMessage m) => _entities.Remove(m.Entity))
            };
        }

        #endregion
    }

    public sealed class EntitySet<T> : AEntitySet
    {
        #region Initialisation

        public EntitySet(World world)
        {
            _subscriptions = new[]
            {
                world.Subscribe((in ComponentSettedMessage<T> m) => _entities.Add(m.Entity)),
                world.Subscribe((in ComponentRemovedMessage<T> m) => _entities.Remove(m.Entity))
            };
        }

        #endregion

        #region Methods

        IEnumerable<(Entity, T)> CopyWithComponents()
        {
            (Entity, T)[] items = new(Entity, T)[_entities.Count];

            int i = 0;
            foreach (Entity entity in _entities)
            {
                items[i++].Item1 = entity;
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T) item = ref items[i];
                item.Item2 = item.Item1.Get<T>();
            }

            return items;
        }

        #endregion
    }

    public sealed class EntitySet<T1, T2> : AEntitySet
    {
        #region Initialisation

        public EntitySet(World world)
        {
            _subscriptions = new[]
            {
                world.Subscribe<ComponentSettedMessage<T1>>(On),
                world.Subscribe((in ComponentRemovedMessage<T1> m) => _entities.Remove(m.Entity)),
                world.Subscribe<ComponentSettedMessage<T2>>(On),
                world.Subscribe((in ComponentRemovedMessage<T2> m) => _entities.Remove(m.Entity))
            };
        }

        #endregion

        #region Callbacks

        private void On(in ComponentSettedMessage<T1> message)
        {
            if (message.Entity.Has<T2>())
            {
                _entities.Add(message.Entity);
            }
        }

        private void On(in ComponentSettedMessage<T2> message)
        {
            if (message.Entity.Has<T1>())
            {
                _entities.Add(message.Entity);
            }
        }

        #endregion

        #region Methods

        IEnumerable<(Entity, T1, T2)> CopyWithComponents()
        {
            (Entity, T1, T2)[] items = new(Entity, T1, T2)[_entities.Count];

            int i = 0;
            foreach (Entity entity in _entities)
            {
                items[i++].Item1 = entity;
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2) item = ref items[i];
                item.Item2 = item.Item1.Get<T1>();
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2) item = ref items[i];
                item.Item3 = item.Item1.Get<T2>();
            }

            return items;
        }

        #endregion
    }

    public sealed class EntitySet<T1, T2, T3> : AEntitySet
    {
        #region Initialisation

        public EntitySet(World world)
        {
            _subscriptions = new[]
            {
                world.Subscribe<ComponentSettedMessage<T1>>(On),
                world.Subscribe((in ComponentRemovedMessage<T1> m) => _entities.Remove(m.Entity)),
                world.Subscribe<ComponentSettedMessage<T2>>(On),
                world.Subscribe((in ComponentRemovedMessage<T2> m) => _entities.Remove(m.Entity)),
                world.Subscribe<ComponentSettedMessage<T3>>(On),
                world.Subscribe((in ComponentRemovedMessage<T3> m) => _entities.Remove(m.Entity))
            };
        }

        #endregion

        #region Callbacks

        private void On(in ComponentSettedMessage<T1> message)
        {
            if (message.Entity.Has<T2>()
                && message.Entity.Has<T3>())
            {
                _entities.Add(message.Entity);
            }
        }

        private void On(in ComponentSettedMessage<T2> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T3>())
            {
                _entities.Add(message.Entity);
            }
        }

        private void On(in ComponentSettedMessage<T3> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T2>())
            {
                _entities.Add(message.Entity);
            }
        }

        #endregion

        #region Methods

        IEnumerable<(Entity, T1, T2, T3)> CopyWithComponents()
        {
            (Entity, T1, T2, T3)[] items = new(Entity, T1, T2, T3)[_entities.Count];

            int i = 0;
            foreach (Entity entity in _entities)
            {
                items[i++].Item1 = entity;
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3) item = ref items[i];
                item.Item2 = item.Item1.Get<T1>();
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3) item = ref items[i];
                item.Item3 = item.Item1.Get<T2>();
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3) item = ref items[i];
                item.Item4 = item.Item1.Get<T3>();
            }

            return items;
        }

        #endregion
    }

    public sealed class EntitySet<T1, T2, T3, T4> : AEntitySet
    {
        #region Initialisation

        public EntitySet(World world)
        {
            _subscriptions = new[]
            {
                world.Subscribe<ComponentSettedMessage<T1>>(On),
                world.Subscribe((in ComponentRemovedMessage<T1> m) => _entities.Remove(m.Entity)),
                world.Subscribe<ComponentSettedMessage<T2>>(On),
                world.Subscribe((in ComponentRemovedMessage<T2> m) => _entities.Remove(m.Entity)),
                world.Subscribe<ComponentSettedMessage<T3>>(On),
                world.Subscribe((in ComponentRemovedMessage<T3> m) => _entities.Remove(m.Entity)),
                world.Subscribe<ComponentSettedMessage<T4>>(On),
                world.Subscribe((in ComponentRemovedMessage<T4> m) => _entities.Remove(m.Entity))
            };
        }

        #endregion

        #region Callbacks

        private void On(in ComponentSettedMessage<T1> message)
        {
            if (message.Entity.Has<T2>()
                && message.Entity.Has<T3>()
                && message.Entity.Has<T4>())
            {
                _entities.Add(message.Entity);
            }
        }

        private void On(in ComponentSettedMessage<T2> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T3>()
                && message.Entity.Has<T4>())
            {
                _entities.Add(message.Entity);
            }
        }

        private void On(in ComponentSettedMessage<T3> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T2>()
                && message.Entity.Has<T4>())
            {
                _entities.Add(message.Entity);
            }
        }

        private void On(in ComponentSettedMessage<T4> message)
        {
            if (message.Entity.Has<T1>()
                && message.Entity.Has<T2>()
                && message.Entity.Has<T3>())
            {
                _entities.Add(message.Entity);
            }
        }

        #endregion

        #region Methods

        IEnumerable<(Entity, T1, T2, T3, T4)> CopyWithComponents()
        {
            (Entity, T1, T2, T3, T4)[] items = new(Entity, T1, T2, T3, T4)[_entities.Count];

            int i = 0;
            foreach (Entity entity in _entities)
            {
                items[i++].Item1 = entity;
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3, T4) item = ref items[i];
                item.Item2 = item.Item1.Get<T1>();
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3, T4) item = ref items[i];
                item.Item3 = item.Item1.Get<T2>();
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3, T4) item = ref items[i];
                item.Item4 = item.Item1.Get<T3>();
            }
            for (i = 0; i < items.Length; ++i)
            {
                ref (Entity, T1, T2, T3, T4) item = ref items[i];
                item.Item5 = item.Item1.Get<T4>();
            }

            return items;
        }

        #endregion
    }
}
