using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private static readonly MethodInfo _with;
        private static readonly MethodInfo _without;
        private static readonly MethodInfo _withAny;

        private readonly World _world;
        private readonly List<Func<EntitySet, World, IDisposable>> _subscriptions;

        private ComponentEnum _withFilter;
        private ComponentEnum _withoutFilter;
        private ComponentEnum _currentWithAnyFilter;
        private List<ComponentEnum> _withAnyFilters;

        #endregion

        #region Initialisation

        static EntitySetBuilder()
        {
            _with = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(With)).First(m => m.ContainsGenericParameters);
            _without = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(Without)).First(m => m.ContainsGenericParameters);
            _withAny = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WithAny)).First(m => m.ContainsGenericParameters);
        }

        internal EntitySetBuilder(World world)
        {
            _world = world;
            _subscriptions = new List<Func<EntitySet, World, IDisposable>>
            {
                (s, w) => w.Subscribe<EntityDisposedMessage>(s.Remove),
                (s, w) => w.Subscribe<EntityDisabledMessage>(s.Remove),
                (s, w) => w.Subscribe<EntityEnabledMessage>(s.CheckedAdd)
            };
        }

        #endregion

        #region Methods

        private void WithAny<T>()
        {
            if (!_currentWithAnyFilter[ComponentManager<T>.Flag])
            {
                _currentWithAnyFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedRemove));
            }
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder With<T>()
        {
            if (!_withFilter[ComponentManager<T>.Flag])
            {
                _withFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.Remove));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with all component of the given types.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder With(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                foreach (Type componentType in componentTypes)
                {
                    _with.MakeGenericMethod(componentType).Invoke(this, null);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder Without<T>()
        {
            if (!_withoutFilter[ComponentManager<T>.Flag])
            {
                _withoutFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.Remove));
                _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder Without(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                foreach (Type componentType in componentTypes)
                {
                    _without.MakeGenericMethod(componentType).Invoke(this, null);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WithAny(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                if (componentTypes.Length == 1)
                {
                    return With(componentTypes);
                }

                if (_withAnyFilters == null)
                {
                    _withAnyFilters = new List<ComponentEnum>();
                }

                _currentWithAnyFilter = new ComponentEnum();
                foreach (Type componentType in componentTypes)
                {
                    _withAny.MakeGenericMethod(componentType).Invoke(this, null);
                }

                _withAnyFilters.Add(_currentWithAnyFilter);
            }

            return this;
        }

        /// <summary>
        /// Returns an <see cref="EntitySet"/> with the specified rules.
        /// </summary>
        /// <returns>The <see cref="EntitySet"/>.</returns>
        public EntitySet Build()
        {
            List<Func<EntitySet, World, IDisposable>> subscriptions = _subscriptions.ToList();

            if (subscriptions.Count == 3 || (_withFilter.IsNull && _withAnyFilters == null))
            {
                subscriptions.Add((s, w) => w.Subscribe<EntityCreatedMessage>(s.Add));
            }

            return new EntitySet(_world, _withFilter, _withoutFilter, _withAnyFilters, subscriptions);
        }

        #endregion
    }
}
