using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        private static readonly MethodInfo _withEither;
        private static readonly MethodInfo _without;
        private static readonly MethodInfo _withoutEither;
        private static readonly MethodInfo _whenAdded;
        private static readonly MethodInfo _whenAddedEither;
        private static readonly MethodInfo _whenChanged;
        private static readonly MethodInfo _whenChangedEither;
        private static readonly MethodInfo _whenRemoved;
        private static readonly MethodInfo _whenRemovedEither;

        private readonly World _world;
        private readonly List<Func<EntitySet, World, IDisposable>> _subscriptions;
        private readonly List<Func<EntitySet, World, IDisposable>> _nonReactSubscriptions;

        private bool _addCreated;
        private ComponentEnum _withFilter;
        private ComponentEnum _withEitherFilter;
        private ComponentEnum _withoutFilter;
        private ComponentEnum _withoutEitherFilter;
        private ComponentEnum _whenAddedFilter;
        private ComponentEnum _whenChangedFilter;
        private ComponentEnum _whenRemovedFilter;
        private List<ComponentEnum> _withEitherFilters;
        private List<ComponentEnum> _withoutEitherFilters;

        #endregion

        #region Initialisation

        static EntitySetBuilder()
        {
            _with = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(With)).Single(m => m.ContainsGenericParameters);
            _withEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WithEither)).Single(m => m.ContainsGenericParameters);
            _without = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(Without)).Single(m => m.ContainsGenericParameters);
            _withoutEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WithoutEither)).Single(m => m.ContainsGenericParameters);
            _whenAdded = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WhenAdded)).Single(m => m.ContainsGenericParameters);
            _whenAddedEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WhenAddedEither)).Single(m => m.ContainsGenericParameters);
            _whenChanged = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WhenChanged)).Single(m => m.ContainsGenericParameters);
            _whenChangedEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WhenChangedEither)).Single(m => m.ContainsGenericParameters);
            _whenRemoved = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WhenRemoved)).Single(m => m.ContainsGenericParameters);
            _whenRemovedEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethods(nameof(WhenRemovedEither)).Single(m => m.ContainsGenericParameters);
        }

        internal EntitySetBuilder(World world, bool withEnabledEntities)
        {
            _world = world;

            _subscriptions = new List<Func<EntitySet, World, IDisposable>>();
            _nonReactSubscriptions = new List<Func<EntitySet, World, IDisposable>>();

            _addCreated = withEnabledEntities;
            _subscriptions.Add((s, w) => w.Subscribe<EntityDisposingMessage>(s.Remove));
            _withFilter[World.IsAliveFlag] = true;
            if (withEnabledEntities)
            {
                _withFilter[World.IsEnabledFlag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<EntityDisabledMessage>(s.Remove));
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityEnabledMessage>(s.CheckedAdd));
            }
            else
            {
                _withoutFilter[World.IsEnabledFlag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<EntityEnabledMessage>(s.Remove));
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityDisabledMessage>(s.CheckedAdd));
            }
        }

        #endregion

        #region Methods

        private void WithEither<T>(StrongBox<ComponentEnum> components)
        {
            _addCreated = false;

            ComponentFlag flag = ComponentManager<T>.Flag;
            if (!components.Value[flag])
            {
                components.Value[flag] = true;
                if (!_withEitherFilter[flag])
                {
                    _withEitherFilter[flag] = true;
                    _nonReactSubscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
                    _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedRemove));
                }
            }
        }

        private void WithoutEither<T>(StrongBox<ComponentEnum> components)
        {
            ComponentFlag flag = ComponentManager<T>.Flag;
            if (!components.Value[flag])
            {
                components.Value[flag] = true;
                if (!_withoutEitherFilter[flag])
                {
                    _withoutEitherFilter[flag] = true;
                    _nonReactSubscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
                    _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedRemove));
                }
            }
        }

        private void WhenAddedEither<T>(StrongBox<ComponentEnum> components)
        {
            WithEither<T>(components);

            if (!_whenAddedFilter[ComponentManager<T>.Flag])
            {
                _whenAddedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
            }
        }

        private void WhenChangedEither<T>(StrongBox<ComponentEnum> components)
        {
            WithEither<T>(components);

            if (!_whenChangedFilter[ComponentManager<T>.Flag])
            {
                _whenChangedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentChangedMessage<T>>(s.CheckedAdd));
            }
        }

        private void WhenRemovedEither<T>(StrongBox<ComponentEnum> components)
        {
            WithoutEither<T>(components);

            if (!_whenRemovedFilter[ComponentManager<T>.Flag])
            {
                _whenRemovedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
            }
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder With<T>()
        {
            _addCreated = false;

            if (!_withFilter[ComponentManager<T>.Flag])
            {
                _withFilter[ComponentManager<T>.Flag] = true;
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
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
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WithEither(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                if (componentTypes.Length == 1)
                {
                    return With(componentTypes);
                }

                StrongBox<ComponentEnum> components = new StrongBox<ComponentEnum>();
                object[] parameters = new[] { components };
                foreach (Type componentType in componentTypes)
                {
                    _withEither.MakeGenericMethod(componentType).Invoke(this, parameters);
                }

                if (!components.Value.IsNull
                    && (!_withEitherFilters?.Select(f => f.ToString()).Contains(components.Value.ToString()) ?? true))
                {
                    (_withEitherFilters ?? (_withEitherFilters = new List<ComponentEnum>())).Add(components.Value);
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
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.Remove));
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
        /// Makes a rule to obsverve <see cref="Entity"/> without at least one component of the given types.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WithoutEither(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                if (componentTypes.Length == 1)
                {
                    return Without(componentTypes);
                }

                StrongBox<ComponentEnum> components = new StrongBox<ComponentEnum>();
                object[] parameters = new[] { components };
                foreach (Type componentType in componentTypes)
                {
                    _withoutEither.MakeGenericMethod(componentType).Invoke(this, parameters);
                }

                if (!components.Value.IsNull
                    && (!_withoutEitherFilters?.Select(f => f.ToString()).Contains(components.Value.ToString()) ?? true))
                {
                    (_withoutEitherFilters ?? (_withoutEitherFilters = new List<ComponentEnum>())).Add(components.Value);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is added.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenAdded<T>()
        {
            With<T>();

            if (!_whenAddedFilter[ComponentManager<T>.Flag])
            {
                _whenAddedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are added.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenAdded(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                foreach (Type componentType in componentTypes)
                {
                    _whenAdded.MakeGenericMethod(componentType).Invoke(this, null);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is added.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenAddedEither(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                if (componentTypes.Length == 1)
                {
                    return WhenAdded(componentTypes);
                }

                StrongBox<ComponentEnum> components = new StrongBox<ComponentEnum>();
                object[] parameters = new[] { components };
                foreach (Type componentType in componentTypes)
                {
                    _whenAddedEither.MakeGenericMethod(componentType).Invoke(this, parameters);
                }

                if (!components.Value.IsNull)
                {
                    (_withEitherFilters ?? (_withEitherFilters = new List<ComponentEnum>())).Add(components.Value);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is changed.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenChanged<T>()
        {
            With<T>();

            if (!_whenChangedFilter[ComponentManager<T>.Flag])
            {
                _whenChangedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentChangedMessage<T>>(s.CheckedAdd));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are changed.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenChanged(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                foreach (Type componentType in componentTypes)
                {
                    _whenChanged.MakeGenericMethod(componentType).Invoke(this, null);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is changed.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenChangedEither(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                if (componentTypes.Length == 1)
                {
                    return WhenChanged(componentTypes);
                }

                StrongBox<ComponentEnum> components = new StrongBox<ComponentEnum>();
                object[] parameters = new[] { components };
                foreach (Type componentType in componentTypes)
                {
                    _whenChangedEither.MakeGenericMethod(componentType).Invoke(this, parameters);
                }

                if (!components.Value.IsNull)
                {
                    (_withEitherFilters ?? (_withEitherFilters = new List<ComponentEnum>())).Add(components.Value);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is removed.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenRemoved<T>()
        {
            Without<T>();

            if (!_whenRemovedFilter[ComponentManager<T>.Flag])
            {
                _whenRemovedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are removed.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenRemoved(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                foreach (Type componentType in componentTypes)
                {
                    _whenRemoved.MakeGenericMethod(componentType).Invoke(this, null);
                }
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is removed.
        /// </summary>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder WhenRemovedEither(params Type[] componentTypes)
        {
            if (componentTypes?.Length > 0)
            {
                if (componentTypes.Length == 1)
                {
                    return WhenRemoved(componentTypes);
                }

                StrongBox<ComponentEnum> components = new StrongBox<ComponentEnum>();
                object[] parameters = new[] { components };
                foreach (Type componentType in componentTypes)
                {
                    _whenRemovedEither.MakeGenericMethod(componentType).Invoke(this, parameters);
                }

                if (!components.Value.IsNull)
                {
                    (_withoutEitherFilters ?? (_withoutEitherFilters = new List<ComponentEnum>())).Add(components.Value);
                }
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
            bool hasWhenFilter = !_whenAddedFilter.IsNull || !_whenChangedFilter.IsNull || !_whenRemovedFilter.IsNull;
            if (!hasWhenFilter)
            {
                subscriptions.AddRange(_nonReactSubscriptions);
            }

            if (_addCreated && !hasWhenFilter)
            {
                subscriptions.Add((s, w) => w.Subscribe<EntityCreatedMessage>(s.Add));
            }

            return new EntitySet(hasWhenFilter, _world, _withFilter, _withoutFilter, _withEitherFilters, _withoutEitherFilters, subscriptions);
        }

        #endregion
    }
}
