using System;
using System.Collections.Generic;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represent an helper object to create an <see cref="EntitySet"/> to retrieve specific subset of <see cref="Entity"/>.
    /// </summary>
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

        /// <summary>
        /// Returns an <see cref="EntitySet"/> with the specified rules.
        /// </summary>
        /// <returns>The <see cref="EntitySet"/>.</returns>
        public EntitySet Build()
        {
            if (_subscriptions.Count == 1
                || (_withFilter.IsNull && !_withoutFilter.IsNull))
            {
                _subscriptions.Add((s, w) => w.Subscribe((in EntityCreatedMessage m) => s.Add(m.Entity)));
            }

            return new EntitySet(_world, _withFilter, _withoutFilter, _subscriptions);
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        /// <exception cref="InvalidOperationException">The type of component <typeparamref name="T"/> has not been added to the current <see cref="EntitySetBuilder"/> <see cref="World"/> yet.</exception>
        public EntitySetBuilder With<T>()
        {
            ComponentPool<T> pool = ComponentManager<T>.Pools[_world.WorldId];

            if (pool == null)
            {
                throw new InvalidOperationException($"The type of component {nameof(T)} has not been added to the current EntitySetBuilder World yet");
            }

            _withFilter[pool.Flag] = true;
            _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.WithAdded));
            _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.WithRemoved));

            return this;
        }

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        /// <exception cref="InvalidOperationException">The type of component <typeparamref name="T"/> has not been added to the current <see cref="EntitySetBuilder"/> <see cref="World"/> yet.</exception>
        public EntitySetBuilder Without<T>()
        {
            ComponentPool<T> pool = ComponentManager<T>.Pools[_world.WorldId];

            if (pool == null)
            {
                throw new InvalidOperationException($"The type of component {nameof(T)} has not been added to the current EntitySetBuilder World yet");
            }

            _withoutFilter[pool.Flag] = true;
            _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.WithoutAdded));
            _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.WithoutRemoved));

            return this;
        }

        #endregion
    }
}
