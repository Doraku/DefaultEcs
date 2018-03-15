using System;
using System.Collections.Generic;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    public class EntitySetBuilder
    {
        #region Fields

        private readonly World _world;
        private readonly List<Func<EntitySet, World, IDisposable>> _subscriptions;

        private ComponentEnum _withFilter;
        private ComponentEnum _withoutFilter;

        #endregion

        #region Initialisation

        internal EntitySetBuilder(World world)
        {
            _world = world;
            _subscriptions = new List<Func<EntitySet, World, IDisposable>>
            {
                (s, w) => w.Subscribe((in EntityDisposedMessage m) => s.Remove(m.Entity))
            };
        }

        #endregion

        #region Methods

        public EntitySet Build()
        {
            if (_subscriptions.Count == 1
                || (_withFilter.IsNull && !_withoutFilter.IsNull))
            {
                _subscriptions.Add((s, w) => w.Subscribe((in EntityCreatedMessage m) => s.Add(m.Entity)));
            }

            return new EntitySet(_world, _withFilter, _withoutFilter, _subscriptions);
        }

        public EntitySetBuilder With<T>()
        {
            ComponentPool<T> pool = World.ComponentManager<T>.Pools[_world.WorldId];

            if (pool == null)
            {
                throw new InvalidOperationException($"The type of component {nameof(T)} has not been added to the current Entity World yet");
            }

            _withFilter[pool.Flag] = true;
            _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.WithAdded));
            _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.WithRemoved));

            return this;
        }

        public EntitySetBuilder Without<T>()
        {
            ComponentPool<T> pool = World.ComponentManager<T>.Pools[_world.WorldId];

            if (pool == null)
            {
                throw new InvalidOperationException($"The type of component {nameof(T)} has not been added to the current Entity World yet");
            }

            _withoutFilter[pool.Flag] = true;
            _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.WithoutAdded));
            _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.WithoutRemoved));

            return this;
        }

        #endregion
    }
}
