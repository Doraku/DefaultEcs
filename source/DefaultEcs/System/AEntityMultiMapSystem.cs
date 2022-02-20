using System;
using System.Buffers;
using System.Collections.Generic;
using System.Reflection;
using DefaultEcs.Internal;
using DefaultEcs.Internal.System;
using DefaultEcs.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntityMultiMap{TKey}"/> instance.
    /// Only <see cref="Entity.Get{T}()"/> operations on already present component type are safe.
    /// Any other operation maybe change the inner <see cref="EntityMultiMap{TKey}"/> and should be done either by setting "useBuffer" of the available constructors to true or using an <see cref="Command.EntityCommandRecorder"/>.
    /// </summary>
    /// <typeparam name="TState">The type of the object used as state to update the system.</typeparam>
    /// <typeparam name="TKey">The type of the component used as key.</typeparam>
    public abstract class AEntityMultiMapSystem<TState, TKey> : ISystem<TState>
    {
        #region Types

        private sealed class Runnable : IParallelRunnable
        {
            private readonly AEntityMultiMapSystem<TState, TKey> _system;

            public TState CurrentState;
            public int EntitiesPerIndex;
            public TKey Key;
            public EntityMultiMap<TKey>.Entities Entities;

            public Runnable(AEntityMultiMapSystem<TState, TKey> system)
            {
                _system = system;
            }

            public void Run(int index, int maxIndex)
            {
                int start = index * EntitiesPerIndex;

                _system.Update(CurrentState, Key, Entities.GetEntities(start, index == maxIndex ? Entities.Count - start : EntitiesPerIndex));
            }
        }

        #endregion

        #region Fields

        private readonly bool _useBuffer;
        private readonly IParallelRunner _runner;
        private readonly Runnable _runnable;
        private readonly int _minEntityCountByRunnerIndex;
        private readonly IComparer<TKey> _keyComparer;

        private TKey[] _keys;
        private int _keyCount;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="EntityMultiMap{TKey}"/> instance on which this system operates.
        /// </summary>
        public EntityMultiMap<TKey> MultiMap { get; }

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance on which this system operates.
        /// </summary>
        public World World { get; }

        #endregion

        #region Initialisation

        private AEntityMultiMapSystem(Func<object, EntityMultiMap<TKey>> factory, IParallelRunner runner, int minEntityCountByRunnerIndex)
        {
            static bool IsIComparable()
            {
                TypeInfo type = typeof(TKey).GetTypeInfo();
                if (typeof(IComparable<TKey>).GetTypeInfo().IsAssignableFrom(type))
                {
                    return true;
                }
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    TypeInfo innerType = type.GenericTypeArguments[0].GetTypeInfo();
                    if (typeof(IComparable<>).MakeGenericType(innerType.AsType()).GetTypeInfo().IsAssignableFrom(innerType))
                    {
                        return true;
                    }
                }

                return false;
            }

            MultiMap = factory(this);
            World = MultiMap.World;

            _keyComparer = this as IComparer<TKey> ?? (IsIComparable() ? Comparer<TKey>.Default : null);
            _runner = runner ?? DefaultParallelRunner.Default;
            _runnable = new Runnable(this);
            _minEntityCountByRunnerIndex = _runner.DegreeOfParallelism > 1 ? minEntityCountByRunnerIndex : int.MaxValue;

            _keys = EmptyArray<TKey>.Value;
            _keyCount = 0;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityMultiMapSystem{T, TKey}"/> class with the given <see cref="EntityMultiMap{TKey}"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="map">The <see cref="EntityMultiMap{TKey}"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="map"/> is null.</exception>
        protected AEntityMultiMapSystem(EntityMultiMap<TKey> map, IParallelRunner runner, int minEntityCountByRunnerIndex = 0)
            : this(map is null ? throw new ArgumentNullException(nameof(map)) : _ => map, runner, minEntityCountByRunnerIndex)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityMultiMapSystem{T, TKey}"/> class with the given <see cref="EntityMultiMap{TKey}"/>.
        /// </summary>
        /// <param name="map">The <see cref="EntityMultiMap{TKey}"/> on which to process the update.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="map"/> is null.</exception>
        protected AEntityMultiMapSystem(EntityMultiMap<TKey> map, bool useBuffer = false)
            : this(map, null)
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityMultiMapSystem{T, TKey}"/> class with the given <see cref="DefaultEcs.World"/> and factory.
        /// The current instance will be passed as the first parameter of the factory.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="factory">The factory used to create the <see cref="EntityMultiMap{TKey}"/>.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is null.</exception>
        protected AEntityMultiMapSystem(World world, Func<object, World, EntityMultiMap<TKey>> factory, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : this(world is null ? throw new ArgumentNullException(nameof(world)) : factory is null ? throw new ArgumentNullException(nameof(factory)) : o => factory(o, world), runner, minEntityCountByRunnerIndex)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityMultiMapSystem{T, TKey}"/> class with the given <see cref="DefaultEcs.World"/>.
        /// To create the inner <see cref="EntityMultiMap{TKey}"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntityMultiMapSystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex = 0)
            : this(world, DefaultFactory, runner, minEntityCountByRunnerIndex)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityMultiMapSystem{T,TKey}"/> class with the given <see cref="DefaultEcs.World"/>.
        /// To create the inner <see cref="EntityMultiMap{TKey}"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="factory">The factory used to create the <see cref="EntitySet"/>.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is null.</exception>
        protected AEntityMultiMapSystem(World world, Func<object, World, EntityMultiMap<TKey>> factory, bool useBuffer)
            : this(world, factory, null, 0)
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityMultiMapSystem{T,TKey}"/> class with the given <see cref="DefaultEcs.World"/>.
        /// To create the inner <see cref="EntityMultiMap{TKey}"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntityMultiMapSystem(World world, bool useBuffer = false)
            : this(world, DefaultFactory, useBuffer)
        { }

        #endregion

        #region Methods

        private static EntityMultiMap<TKey> DefaultFactory(object o, World w) => EntityRuleBuilderFactory.Create(o.GetType())(o, w).AsMultiMap(o as IEqualityComparer<TKey>);

        /// <summary>
        /// Performs a pre-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PreUpdate(TState state) { }

        /// <summary>
        /// Performs a pre-update per <typeparamref name="TKey"/> treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="key">The key of the <see cref="Entity"/> instances about to be updated.</param>
        protected virtual void PreUpdate(TState state, TKey key) { }

        /// <summary>
        /// Performs a post-update per <typeparamref name="TKey"/> treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="key">The key of the <see cref="Entity"/> instances which have been updated.</param>
        protected virtual void PostUpdate(TState state, TKey key) { }

        /// <summary>
        /// Performs a post-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PostUpdate(TState state) { }

        /// <summary>
        /// Gets all the <typeparamref name="TKey"/> of the inner <see cref="EntityMultiMap{TKey}"/> which <see cref="Entity"/> instances will be updated.
        /// </summary>
        /// <returns>A <see cref="Span{T}"/> of <typeparamref name="TKey"/> in the order of update.</returns>
        protected virtual Span<TKey> GetKeys()
        {
            int newKeyCount = 0;
            foreach (TKey key in MultiMap.Keys)
            {
                ArrayExtension.EnsureLength(ref _keys, newKeyCount);
                _keys[newKeyCount++] = key;
            }

            if (newKeyCount < _keyCount)
            {
                _keys.Fill(default, newKeyCount);
            }

            _keyCount = newKeyCount;

            if (_keyComparer != null)
            {
                Array.Sort(_keys, 0, _keyCount, _keyComparer);
            }

            return new Span<TKey>(_keys, 0, _keyCount);
        }

        /// <summary>
        /// Update the given <see cref="Entity"/> instance once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="key">The key of the current <see cref="Entity"/>.</param>
        /// <param name="entity">The <see cref="Entity"/> instance to update.</param>
        protected virtual void Update(TState state, in TKey key, in Entity entity) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="key">The key of the current <see cref="Entity"/> instances.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to update.</param>
        protected virtual void Update(TState state, in TKey key, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                Update(state, key, entity);
            }
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AEntityMultiMapSystem{T, TKey}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if the inner <see cref="EntityMultiMap{TKey}"/> is empty.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(TState state)
        {
            if (IsEnabled)
            {
                Span<TKey> keys = GetKeys();

                if (keys.Length > 0)
                {
                    PreUpdate(state);

                    _runnable.CurrentState = state;

                    foreach (ref readonly TKey key in keys)
                    {
                        if (MultiMap.TryGetEntities(key, out _runnable.Entities) && _runnable.Entities.Count > 0)
                        {
                            PreUpdate(state, key);

                            if (_useBuffer)
                            {
                                Entity[] buffer = ArrayPool<Entity>.Shared.Rent(_runnable.Entities.Count);
                                _runnable.Entities.GetEntities().CopyTo(buffer);

                                Update(state, key, new ReadOnlySpan<Entity>(buffer, 0, _runnable.Entities.Count));

                                ArrayPool<Entity>.Shared.Return(buffer);
                            }
                            else
                            {
                                _runnable.EntitiesPerIndex = _runnable.Entities.Count / _runner.DegreeOfParallelism;

                                if (_runnable.EntitiesPerIndex < _minEntityCountByRunnerIndex)
                                {
                                    Update(state, key, _runnable.Entities.GetEntities());
                                }
                                else
                                {
                                    _runnable.Key = key;
                                    _runner.Run(_runnable);
                                }
                            }

                            PostUpdate(state, key);
                        }
                    }

                    MultiMap.Complete();

                    PostUpdate(state);
                }
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntityMultiMap{TKey}"/> instance.
        /// </summary>
        public virtual void Dispose()
        {
            MultiMap.Dispose();

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
