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
        #region Types

        internal enum EitherType
        {
            With,
            Without,
            WhenAdded,
            WhenChanged,
            WhenRemoved
        }

        /// <summary>
        /// Represents an helper object to create an either group for the construction of an <see cref="EntitySet"/> containing a specific subset of <see cref="Entity"/>.
        /// </summary>
        public sealed class EitherBuilder
        {
            #region Fields

            private readonly EntitySetBuilder _builder;
            private readonly EitherType _type;

            private ComponentEnum _eitherFilter;

            #endregion

            #region Initialisation

            internal EitherBuilder(EntitySetBuilder builder, EitherType type)
            {
                _builder = builder;
                _type = type;
            }

            #endregion

            #region Methods

            private EitherBuilder OrWith<T>()
            {
                _builder._addCreated = false;

                ComponentFlag flag = ComponentManager<T>.Flag;
                if (!_eitherFilter[flag])
                {
                    _eitherFilter[flag] = true;
                    if (!_builder._withEitherFilter[flag])
                    {
                        _builder._withEitherFilter[flag] = true;
                        _builder._nonReactSubscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
                        _builder._subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedRemove));
                    }
                }

                return this;
            }

            private EitherBuilder OrWithout<T>()
            {
                ComponentFlag flag = ComponentManager<T>.Flag;
                if (!_eitherFilter[flag])
                {
                    _eitherFilter[flag] = true;
                    if (!_builder._withoutEitherFilter[flag])
                    {
                        _builder._withoutEitherFilter[flag] = true;
                        _builder._nonReactSubscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
                        _builder._subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedRemove));
                    }
                }

                return this;
            }

            private EitherBuilder OrWhenAdded<T>()
            {
                if (!_builder._whenAddedFilter[ComponentManager<T>.Flag])
                {
                    _builder._whenAddedFilter[ComponentManager<T>.Flag] = true;
                    _builder._subscriptions.Add((s, w) => w.Subscribe<ComponentAddedMessage<T>>(s.CheckedAdd));
                }

                return OrWith<T>();
            }

            private EitherBuilder OrWhenChanged<T>()
            {
                if (!_builder._whenChangedFilter[ComponentManager<T>.Flag])
                {
                    _builder._whenChangedFilter[ComponentManager<T>.Flag] = true;
                    _builder._subscriptions.Add((s, w) => w.Subscribe<ComponentChangedMessage<T>>(s.CheckedAdd));
                }

                return OrWith<T>();
            }

            private EitherBuilder OrWhenRemoved<T>()
            {
                if (!_builder._whenRemovedFilter[ComponentManager<T>.Flag])
                {
                    _builder._whenRemovedFilter[ComponentManager<T>.Flag] = true;
                    _builder._subscriptions.Add((s, w) => w.Subscribe<ComponentRemovedMessage<T>>(s.CheckedAdd));
                }

                return OrWithout<T>();
            }

            internal EntitySetBuilder Commit()
            {
                if (_type == EitherType.Without || _type == EitherType.WhenRemoved)
                {
                    _builder.AddWithoutEitherFilter(_eitherFilter);
                }
                else
                {
                    _builder.AddWithEitherFilter(_eitherFilter);
                }

                return _builder;
            }

            /// <summary>
            /// Add the type <typeparamref name="T"/> to current either group.
            /// </summary>
            /// <typeparam name="T">The type of component to add to the either group.</typeparam>
            /// <returns>The current <see cref="EitherBuilder"/>.</returns>
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            public EitherBuilder Or<T>() => _type switch
            {
                EitherType.With => OrWith<T>(),
                EitherType.Without => OrWithout<T>(),
                EitherType.WhenAdded => OrWhenAdded<T>(),
                EitherType.WhenChanged => OrWhenChanged<T>(),
                EitherType.WhenRemoved => OrWhenRemoved<T>()
            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of component.</typeparam>
            /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
            public EntitySetBuilder With<T>() => Commit().With<T>();

            /// <summary>
            /// Makes a rule to ignore <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">The type of component.</typeparam>
            /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
            public EntitySetBuilder Without<T>() => Commit().Without<T>();

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is added.
            /// </summary>
            /// <typeparam name="T">The type of component.</typeparam>
            /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
            public EntitySetBuilder WhenAdded<T>() => Commit().WhenAdded<T>();

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is changed.
            /// </summary>
            /// <typeparam name="T">The type of component.</typeparam>
            /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
            public EntitySetBuilder WhenChanged<T>() => Commit().WhenChanged<T>();

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is removed.
            /// </summary>
            /// <typeparam name="T">The type of component.</typeparam>
            /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
            public EntitySetBuilder WhenRemoved<T>() => Commit().WhenRemoved<T>();

            /// <summary>
            /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the either group.
            /// </summary>
            /// <typeparam name="T">The type of component to add to the either group.</typeparam>
            /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
            public EitherBuilder WithEither<T>() => Commit().WithEither<T>();

            /// <summary>
            /// Makes a rule to obsverve <see cref="Entity"/> without at least one component of the either group.
            /// </summary>
            /// <typeparam name="T">The type of component to add to the either group.</typeparam>
            /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
            public EitherBuilder WithoutEither<T>() => Commit().WithoutEither<T>();

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> when one component of the either group is added.
            /// </summary>
            /// <typeparam name="T">The type of component to add to the either group.</typeparam>
            /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
            public EitherBuilder WhenAddedEither<T>() => Commit().WhenAddedEither<T>();

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> when one component of the either group is changed.
            /// </summary>
            /// <typeparam name="T">The type of component to add to the either group.</typeparam>
            /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
            public EitherBuilder WhenChangedEither<T>() => Commit().WhenChangedEither<T>();

            /// <summary>
            /// Makes a rule to observe <see cref="Entity"/> when one component of the either group is removed.
            /// </summary>
            /// <typeparam name="T">The type of component to add to the either group.</typeparam>
            /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
            public EitherBuilder WhenRemovedEither<T>() => Commit().WhenRemovedEither<T>();

            /// <summary>
            /// Returns an <see cref="EntitySet"/> with the specified rules.
            /// </summary>
            /// <returns>The <see cref="EntitySet"/>.</returns>
            public EntitySet AsSet() => Commit().AsSet();

            #endregion
        }

        #endregion

        #region Fields

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

        private void AddWithEitherFilter(ComponentEnum filter)
        {
            if (!_withEitherFilters?.Select(f => f.ToString()).Contains(filter.ToString()) ?? true)
            {
                (_withEitherFilters ?? (_withEitherFilters = new List<ComponentEnum>())).Add(filter);
            }
        }

        private void AddWithoutEitherFilter(ComponentEnum filter)
        {
            if (!_withoutEitherFilters?.Select(f => f.ToString()).Contains(filter.ToString()) ?? true)
            {
                (_withoutEitherFilters ?? (_withoutEitherFilters = new List<ComponentEnum>())).Add(filter);
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
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the either group.
        /// </summary>
        /// <typeparam name="T">The type of component to add to the either group.</typeparam>
        /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
        public EitherBuilder WithEither<T>() => new EitherBuilder(this, EitherType.With).Or<T>();

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> without at least one component of the either group.
        /// </summary>
        /// <typeparam name="T">The type of component to add to the either group.</typeparam>
        /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
        public EitherBuilder WithoutEither<T>() => new EitherBuilder(this, EitherType.Without).Or<T>();

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the either group is added.
        /// </summary>
        /// <typeparam name="T">The type of component to add to the either group.</typeparam>
        /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
        public EitherBuilder WhenAddedEither<T>() => new EitherBuilder(this, EitherType.WhenAdded).Or<T>();

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the either group is changed.
        /// </summary>
        /// <typeparam name="T">The type of component to add to the either group.</typeparam>
        /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
        public EitherBuilder WhenChangedEither<T>() => new EitherBuilder(this, EitherType.WhenChanged).Or<T>();

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the either group is removed.
        /// </summary>
        /// <typeparam name="T">The type of component to add to the either group.</typeparam>
        /// <returns>A <see cref="EitherBuilder"/> to create a either group.</returns>
        public EitherBuilder WhenRemovedEither<T>() => new EitherBuilder(this, EitherType.WhenRemoved).Or<T>();

        /// <summary>
        /// Returns an <see cref="EntitySet"/> with the specified rules.
        /// </summary>
        /// <returns>The <see cref="EntitySet"/>.</returns>
        public EntitySet AsSet()
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
