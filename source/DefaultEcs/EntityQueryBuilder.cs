using System;
using System.Collections.Generic;
using System.Linq;
using DefaultEcs.Internal;
using DefaultEcs.Internal.Messages;

namespace DefaultEcs
{
    /// <summary>
    /// Represent an helper object to create rules to retrieve a specific subset of <see cref="Entity"/>.
    /// </summary>
    public sealed class EntityQueryBuilder
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
        /// Represents an helper object to create an either group rule to retrieve a specific subset of <see cref="Entity"/>.
        /// </summary>
        public sealed class EitherBuilder
        {
            #region Fields

            private readonly EntityQueryBuilder _builder;
            private readonly EitherType _type;

            private ComponentEnum _eitherFilter;

            #endregion

            #region Initialisation

            internal EitherBuilder(EntityQueryBuilder builder, EitherType type)
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
                        _builder._nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentAddedMessage<T>>(s.CheckedAdd));
                        _builder._nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentEnabledMessage<T>>(s.CheckedAdd));
                        _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentRemovedMessage<T>>(s.CheckedRemove));
                        _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentDisabledMessage<T>>(s.CheckedRemove));
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
                        _builder._nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentRemovedMessage<T>>(s.CheckedAdd));
                        _builder._nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentDisabledMessage<T>>(s.CheckedAdd));
                        _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentAddedMessage<T>>(s.CheckedRemove));
                        _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentEnabledMessage<T>>(s.CheckedRemove));
                    }
                }

                return this;
            }

            private EitherBuilder OrWhenAdded<T>()
            {
                if (!_builder._whenAddedFilter[ComponentManager<T>.Flag])
                {
                    _builder._whenAddedFilter[ComponentManager<T>.Flag] = true;
                    _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentAddedMessage<T>>(s.CheckedAdd));
                    _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentEnabledMessage<T>>(s.CheckedAdd));
                }

                return OrWith<T>();
            }

            private EitherBuilder OrWhenChanged<T>()
            {
                if (!_builder._whenChangedFilter[ComponentManager<T>.Flag])
                {
                    _builder._whenChangedFilter[ComponentManager<T>.Flag] = true;
                    if (!_builder._predicateFilter[ComponentManager<T>.Flag])
                    {
                        _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentChangedMessage<T>>(s.CheckedAdd));
                    }
                }

                return OrWith<T>();
            }

            private EitherBuilder OrWhenRemoved<T>()
            {
                if (!_builder._whenRemovedFilter[ComponentManager<T>.Flag])
                {
                    _builder._whenRemovedFilter[ComponentManager<T>.Flag] = true;
                    _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentRemovedMessage<T>>(s.CheckedAdd));
                    _builder._subscriptions.Add((s, w) => w.Subscribe<EntityComponentDisabledMessage<T>>(s.CheckedAdd));
                }

                return OrWithout<T>();
            }

            internal EntityQueryBuilder Commit()
            {
                if (_type is EitherType.Without or EitherType.WhenRemoved)
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
            public EitherBuilder Or<T>() => _type switch
            {
                EitherType.Without => OrWithout<T>(),
                EitherType.WhenAdded => OrWhenAdded<T>(),
                EitherType.WhenChanged => OrWhenChanged<T>(),
                EitherType.WhenRemoved => OrWhenRemoved<T>(),
                _ => OrWith<T>()
            };

            /// <inheritdoc cref="EntityQueryBuilder.With{T}()"/>
            public EntityQueryBuilder With<T>() => Commit().With<T>();

            /// <inheritdoc cref="EntityQueryBuilder.With{T}(ComponentPredicate{T})"/>
            public EntityQueryBuilder With<T>(ComponentPredicate<T> predicate) => Commit().With(predicate);

            /// <inheritdoc cref="EntityQueryBuilder.Without{T}"/>
            public EntityQueryBuilder Without<T>() => Commit().Without<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WhenAdded{T}"/>
            public EntityQueryBuilder WhenAdded<T>() => Commit().WhenAdded<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WhenChanged{T}"/>
            public EntityQueryBuilder WhenChanged<T>() => Commit().WhenChanged<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WhenRemoved{T}"/>
            public EntityQueryBuilder WhenRemoved<T>() => Commit().WhenRemoved<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WithEither{T}"/>
            public EitherBuilder WithEither<T>() => Commit().WithEither<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WithoutEither{T}"/>
            public EitherBuilder WithoutEither<T>() => Commit().WithoutEither<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WhenAddedEither{T}"/>
            public EitherBuilder WhenAddedEither<T>() => Commit().WhenAddedEither<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WhenChangedEither{T}"/>
            public EitherBuilder WhenChangedEither<T>() => Commit().WhenChangedEither<T>();

            /// <inheritdoc cref="EntityQueryBuilder.WhenRemovedEither{T}"/>
            public EitherBuilder WhenRemovedEither<T>() => Commit().WhenRemovedEither<T>();

            /// <inheritdoc cref="EntityQueryBuilder.Copy"/>
            public EntityQueryBuilder Copy() => new(Commit());

            /// <inheritdoc cref="EntityQueryBuilder.AsPredicate"/>
            public Predicate<Entity> AsPredicate() => Commit().AsPredicate();

            /// <inheritdoc cref="EntityQueryBuilder.AsEnumerable()"/>
            public IEnumerable<Entity> AsEnumerable() => Commit().AsEnumerable();

            /// <inheritdoc cref="EntityQueryBuilder.AsSet"/>
            public EntitySet AsSet() => Commit().AsSet();

            /// <inheritdoc cref="EntityQueryBuilder.AsSortedSet{T}(IComparer{T})"/>
            public EntitySortedSet<TComponent> AsSortedSet<TComponent>(IComparer<TComponent> comparer) => Commit().AsSortedSet(comparer);

            /// <inheritdoc cref="EntityQueryBuilder.AsSortedSet{T}()"/>
            public EntitySortedSet<TComponent> AsSortedSet<TComponent>() => AsSortedSet<TComponent>(default);

            /// <inheritdoc cref="EntityQueryBuilder.AsMap{TKey}(int, IEqualityComparer{TKey})"/>
            public EntityMap<TKey> AsMap<TKey>(int capacity, IEqualityComparer<TKey> comparer) => Commit().AsMap(capacity, comparer);

            /// <inheritdoc cref="EntityQueryBuilder.AsMap{TKey}(IEqualityComparer{TKey})"/>
            public EntityMap<TKey> AsMap<TKey>(IEqualityComparer<TKey> comparer) => AsMap(0, comparer);

            /// <inheritdoc cref="EntityQueryBuilder.AsMap{TKey}(int)"/>
            public EntityMap<TKey> AsMap<TKey>(int capacity) => AsMap<TKey>(capacity, default);

            /// <inheritdoc cref="EntityQueryBuilder.AsMap{TKey}()"/>
            public EntityMap<TKey> AsMap<TKey>() => AsMap<TKey>(0);

            /// <inheritdoc cref="EntityQueryBuilder.AsMultiMap{TKey}(int, IEqualityComparer{TKey})"/>
            public EntityMultiMap<TKey> AsMultiMap<TKey>(int capacity, IEqualityComparer<TKey> comparer) => Commit().AsMultiMap(capacity, comparer);

            /// <inheritdoc cref="EntityQueryBuilder.AsMultiMap{TKey}(IEqualityComparer{TKey})"/>
            public EntityMultiMap<TKey> AsMultiMap<TKey>(IEqualityComparer<TKey> comparer) => AsMultiMap(0, comparer);

            /// <inheritdoc cref="EntityQueryBuilder.AsMultiMap{TKey}(int)"/>
            public EntityMultiMap<TKey> AsMultiMap<TKey>(int capacity) => AsMultiMap<TKey>(capacity, default);

            /// <inheritdoc cref="EntityQueryBuilder.AsMultiMap{TKey}()"/>
            public EntityMultiMap<TKey> AsMultiMap<TKey>() => AsMultiMap<TKey>(0);

            #endregion
        }

        #endregion

        #region Fields

        private readonly World _world;
        private readonly List<Func<EntityContainerWatcher, World, IDisposable>> _subscriptions;
        private readonly List<Func<EntityContainerWatcher, World, IDisposable>> _nonReactSubscriptions;

        private bool _addCreated;
        private ComponentEnum _predicateFilter;
        private ComponentEnum _withFilter;
        private ComponentEnum _withEitherFilter;
        private ComponentEnum _withoutFilter;
        private ComponentEnum _withoutEitherFilter;
        private ComponentEnum _whenAddedFilter;
        private ComponentEnum _whenChangedFilter;
        private ComponentEnum _whenRemovedFilter;
        private List<Predicate<int>> _predicates;
        private List<ComponentEnum> _withEitherFilters;
        private List<ComponentEnum> _withoutEitherFilters;

        #endregion

        #region Initialisation

        private EntityQueryBuilder(EntityQueryBuilder other)
        {
            _world = other._world;
            _subscriptions = other._subscriptions.ToList();
            _nonReactSubscriptions = other._nonReactSubscriptions.ToList();

            _addCreated = other._addCreated;
            _predicateFilter = other._predicateFilter.Copy();
            _withFilter = other._withFilter.Copy();
            _withEitherFilter = other._withEitherFilter.Copy();
            _withoutFilter = other._withoutFilter.Copy();
            _withoutEitherFilter = other._withoutEitherFilter.Copy();
            _whenAddedFilter = other._whenAddedFilter.Copy();
            _whenChangedFilter = other._whenChangedFilter.Copy();
            _whenRemovedFilter = other._whenRemovedFilter.Copy();

            if (other._predicates != null)
            {
                _predicates = other._predicates.ToList();
            }

            if (other._withEitherFilters != null)
            {
                _withEitherFilters = other._withEitherFilters.ConvertAll(f => f.Copy());
            }

            if (other._withoutEitherFilters != null)
            {
                _withoutEitherFilters = other._withoutEitherFilters.ConvertAll(f => f.Copy());
            }
        }

        internal EntityQueryBuilder(World world, bool withEnabledEntities)
        {
            _world = world;

            _subscriptions = new List<Func<EntityContainerWatcher, World, IDisposable>>();
            _nonReactSubscriptions = new List<Func<EntityContainerWatcher, World, IDisposable>>();

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

        private static IEnumerable<Entity> AsEnumerable(World world, Predicate<ComponentEnum> filter, Predicate<int> predicate)
        {
            for (int i = 1; i <= Math.Min(world.EntityInfos.Length, world.LastEntityId); ++i)
            {
                if (filter(world.EntityInfos[i].Components) && predicate(i))
                {
                    yield return new Entity(world.WorldId, i);
                }
            }
        }

        private static bool All(int _) => true;

        private Predicate<ComponentEnum> GetFilter() => EntityQueryFilterFactory.GetFilter(_withFilter, _withoutFilter, _withEitherFilters, _withoutEitherFilters);

        private Predicate<int> GetPredicate() => _predicates?.Count switch
        {
            null => All,
            1 => _predicates.Single(),
            _ => i => _predicates.All(p => p(i))
        };

        private bool GetSubscriptions(out List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions)
        {
            subscriptions = _subscriptions.ToList();
            bool hasWhenFilter = !_whenAddedFilter.IsNull || !_whenChangedFilter.IsNull || !_whenRemovedFilter.IsNull;
            if (!hasWhenFilter)
            {
                subscriptions.AddRange(_nonReactSubscriptions);
            }

            if (_addCreated && !hasWhenFilter)
            {
                subscriptions.Add((s, w) => w.Subscribe<EntityCreatedMessage>(s.Add));
            }

            subscriptions.Add((s, w) => w.Subscribe<TrimExcessMessage>(s.On));

            return hasWhenFilter;
        }

        private void AddWithEitherFilter(ComponentEnum filter)
        {
            if (!_withEitherFilters?.Select(f => f.ToString()).Contains(filter.ToString()) ?? true)
            {
                (_withEitherFilters ??= new List<ComponentEnum>()).Add(filter);
            }
        }

        private void AddWithoutEitherFilter(ComponentEnum filter)
        {
            if (!_withoutEitherFilters?.Select(f => f.ToString()).Contains(filter.ToString()) ?? true)
            {
                (_withoutEitherFilters ??= new List<ComponentEnum>()).Add(filter);
            }
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder With<T>()
        {
            _addCreated = false;

            if (!_withFilter[ComponentManager<T>.Flag])
            {
                _withFilter[ComponentManager<T>.Flag] = true;
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentAddedMessage<T>>(s.CheckedAdd));
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentEnabledMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentRemovedMessage<T>>(s.Remove));
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentDisabledMessage<T>>(s.Remove));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> with a component of type <typeparamref name="T"/> validating the given <see cref="ComponentPredicate{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="predicate">The <see cref="ComponentPredicate{T}"/> which needs to be validated.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder With<T>(ComponentPredicate<T> predicate)
        {
            predicate.ThrowIfNull();

            if (!_predicateFilter[ComponentManager<T>.Flag])
            {
                _predicateFilter[ComponentManager<T>.Flag] = true;
                if (!_whenChangedFilter[ComponentManager<T>.Flag])
                {
                    _subscriptions.Add((s, w) => w.Subscribe<EntityComponentChangedMessage<T>>(s.AddOrRemove));
                }
            }

            (_predicates ??= new List<Predicate<int>>()).Add(i => predicate(ComponentManager<T>.Pools[_world.WorldId].Get(i)));

            return With<T>();
        }

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder Without<T>()
        {
            if (!_withoutFilter[ComponentManager<T>.Flag])
            {
                _withoutFilter[ComponentManager<T>.Flag] = true;
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentRemovedMessage<T>>(s.CheckedAdd));
                _nonReactSubscriptions.Add((s, w) => w.Subscribe<EntityComponentDisabledMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentAddedMessage<T>>(s.Remove));
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentEnabledMessage<T>>(s.Remove));
            }

            return this;
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is added.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder WhenAdded<T>()
        {
            if (!_whenAddedFilter[ComponentManager<T>.Flag])
            {
                _whenAddedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentAddedMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentEnabledMessage<T>>(s.CheckedAdd));
            }

            return With<T>();
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is changed.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder WhenChanged<T>()
        {
            if (!_whenChangedFilter[ComponentManager<T>.Flag])
            {
                _whenChangedFilter[ComponentManager<T>.Flag] = true;
                if (!_predicateFilter[ComponentManager<T>.Flag])
                {
                    _subscriptions.Add((s, w) => w.Subscribe<EntityComponentChangedMessage<T>>(s.CheckedAdd));
                }
            }

            return With<T>();
        }

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when a component of type <typeparamref name="T"/> is removed.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder WhenRemoved<T>()
        {
            if (!_whenRemovedFilter[ComponentManager<T>.Flag])
            {
                _whenRemovedFilter[ComponentManager<T>.Flag] = true;
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentRemovedMessage<T>>(s.CheckedAdd));
                _subscriptions.Add((s, w) => w.Subscribe<EntityComponentDisabledMessage<T>>(s.CheckedAdd));
            }

            return Without<T>();
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
        /// Copies all the rules of the current <see cref="EntityQueryBuilder"/> to a new instance.
        /// </summary>
        /// <returns>A new <see cref="EntityQueryBuilder"/> with all the same rules as the current instance.</returns>
        public EntityQueryBuilder Copy() => new(this);

        /// <summary>
        /// Returns a <see cref="Predicate{T}"/> representing the specified rules.
        /// </summary>
        /// <returns>The <see cref="Predicate{T}"/>.</returns>
        public Predicate<Entity> AsPredicate()
        {
            Predicate<ComponentEnum> filter = GetFilter();
            Predicate<int> predicate = GetPredicate();

            return e => filter(e.Components) && predicate(e.EntityId);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> of <see cref="Entity"/> with the specified rules.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{T}"/> of <see cref="Entity"/>.</returns>
        public IEnumerable<Entity> AsEnumerable() => AsEnumerable(_world, GetFilter(), GetPredicate());

        /// <summary>
        /// Returns an <see cref="EntitySet"/> with the specified rules.
        /// </summary>
        /// <returns>The <see cref="EntitySet"/>.</returns>
        public EntitySet AsSet() => new(GetSubscriptions(out List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions), _world, GetFilter(), GetPredicate(), subscriptions);

        /// <summary>
        /// Returns an <see cref="EntitySortedSet{T}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TComponent">The component type by which <see cref="Entity"/> will be sorted.</typeparam>
        /// <param name="comparer">The custom <see cref="IComparer{T}"/> to use to sort <see cref="Entity"/>.</param>
        /// <returns>The <see cref="EntitySortedSet{T}"/>.</returns>
        public EntitySortedSet<TComponent> AsSortedSet<TComponent>(IComparer<TComponent> comparer)
        {
            With<TComponent>();

            return new(GetSubscriptions(out List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions), _world, GetFilter(), GetPredicate(), subscriptions, comparer);
        }

        /// <summary>
        /// Returns an <see cref="EntitySortedSet{T}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TComponent">The component type by which <see cref="Entity"/> will be sorted.</typeparam>
        /// <returns>The <see cref="EntitySortedSet{T}"/>.</returns>
        public EntitySortedSet<TComponent> AsSortedSet<TComponent>() => AsSortedSet<TComponent>(default);

        /// <summary>
        /// Returns an <see cref="EntityMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <param name="capacity">The initial number of element the <see cref="EntityMap{TKey}"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}.Default"/> for the type of the key.</param>
        /// <returns>The <see cref="EntityMap{TKey}"/>.</returns>
        public EntityMap<TKey> AsMap<TKey>(int capacity, IEqualityComparer<TKey> comparer)
        {
            With<TKey>();

            return new EntityMap<TKey>(GetSubscriptions(out List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions), _world, GetFilter(), GetPredicate(), subscriptions, capacity, comparer);
        }

        /// <summary>
        /// Returns an <see cref="EntityMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}.Default"/> for the type of the key.</param>
        /// <returns>The <see cref="EntityMap{TKey}"/>.</returns>
        public EntityMap<TKey> AsMap<TKey>(IEqualityComparer<TKey> comparer) => AsMap(0, comparer);

        /// <summary>
        /// Returns an <see cref="EntityMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <param name="capacity">The initial number of element the <see cref="EntityMap{TKey}"/> can contain.</param>
        /// <returns>The <see cref="EntityMap{TKey}"/>.</returns>
        public EntityMap<TKey> AsMap<TKey>(int capacity) => AsMap<TKey>(capacity, default);

        /// <summary>
        /// Returns an <see cref="EntityMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <returns>The <see cref="EntityMap{TKey}"/>.</returns>
        public EntityMap<TKey> AsMap<TKey>() => AsMap<TKey>(0);

        /// <summary>
        /// Returns an <see cref="EntityMultiMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <param name="capacity">The initial number of element the <see cref="EntityMultiMap{TKey}"/> can contain.</param>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}.Default"/> for the type of the key.</param>
        /// <returns>The <see cref="EntityMultiMap{TKey}"/>.</returns>
        public EntityMultiMap<TKey> AsMultiMap<TKey>(int capacity, IEqualityComparer<TKey> comparer)
        {
            With<TKey>();

            return new EntityMultiMap<TKey>(GetSubscriptions(out List<Func<EntityContainerWatcher, World, IDisposable>> subscriptions), _world, GetFilter(), GetPredicate(), subscriptions, capacity, comparer);
        }

        /// <summary>
        /// Returns an <see cref="EntityMultiMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing keys, or null to use the default <see cref="EqualityComparer{T}.Default"/> for the type of the key.</param>
        /// <returns>The <see cref="EntityMultiMap{TKey}"/>.</returns>
        public EntityMultiMap<TKey> AsMultiMap<TKey>(IEqualityComparer<TKey> comparer) => AsMultiMap(0, comparer);

        /// <summary>
        /// Returns an <see cref="EntityMultiMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <param name="capacity">The initial number of element the <see cref="EntityMultiMap{TKey}"/> can contain.</param>
        /// <returns>The <see cref="EntityMultiMap{TKey}"/>.</returns>
        public EntityMultiMap<TKey> AsMultiMap<TKey>(int capacity) => AsMultiMap<TKey>(capacity, default);

        /// <summary>
        /// Returns an <see cref="EntityMultiMap{TKey}"/> with the specified rules.
        /// </summary>
        /// <typeparam name="TKey">The component type to use as key.</typeparam>
        /// <returns>The <see cref="EntityMultiMap{TKey}"/>.</returns>
        public EntityMultiMap<TKey> AsMultiMap<TKey>() => AsMultiMap<TKey>(0);

        #endregion
    }
}
