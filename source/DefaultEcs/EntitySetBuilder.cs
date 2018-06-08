using System;
using System.Collections.Generic;
using System.Linq;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represent an helper object to create an <see cref="EntitySet"/> to retrieve specific subset of <see cref="Entity"/>.
    /// </summary>
    public sealed class EntitySetBuilder
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
                (s, w) => w.Subscribe<EntityDisposedMessage>(s.Disposed)
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
            List<Func<EntitySet, World, IDisposable>> subscriptions = _subscriptions.ToList();

            if (subscriptions.Count == 1
                || (_withFilter.IsNull && !_withoutFilter.IsNull))
            {
                subscriptions.Add((s, w) => w.Subscribe<EntityCreatedMessage>(s.Created));
            }

            return new EntitySet(_world, _withFilter.Copy(), _withoutFilter.Copy(), subscriptions);
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder With<T>()
        {
            _withFilter[ComponentManager<T>.Flag] = true;
            _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.WithAdded));
            _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.WithRemoved));

            return this;
        }

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder Without<T>()
        {
            _withoutFilter[ComponentManager<T>.Flag] = true;
            _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.WithoutAdded));
            _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.WithoutRemoved));

            return this;
        }

        #endregion
    }
}
