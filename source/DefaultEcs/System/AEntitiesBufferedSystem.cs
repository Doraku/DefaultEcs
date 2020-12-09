using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitiesMap{TKey}"/> instance.
    /// </summary>
    /// <typeparam name="TState">The type of the object used as state to update the system.</typeparam>
    /// <typeparam name="TKey">The type of the component used as key.</typeparam>
    public abstract class AEntitiesBufferedSystem<TState, TKey> : ISystem<TState>
    {
        #region Fields

        private readonly EntitiesMap<TKey> _map;
        private readonly IComparer<TKey> _keyComparer;

        private TKey[] _keys;
        private int _keyCount;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance on which this system operates.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World { get; }

        #endregion

        #region Initialisation

        private AEntitiesBufferedSystem()
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

            _keyComparer = this as IComparer<TKey> ?? (IsIComparable() ? Comparer<TKey>.Default : null);

            _keys = EmptyArray<TKey>.Value;
            _keyCount = 0;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitiesBufferedSystem{T, TKey}"/> class with the given <see cref="EntitiesMap{TKey}"/>.
        /// </summary>
        /// <param name="map">The <see cref="EntitiesMap{TKey}"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="map"/> is null.</exception>
        protected AEntitiesBufferedSystem(EntitiesMap<TKey> map)
            : this()
        {
            _map = map ?? throw new ArgumentNullException(nameof(map));

            World = map.World;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitiesBufferedSystem{T, TKey}"/> class with the given <see cref="World"/> and factory.
        /// The current instance will be passed as the first parameter of the factory.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="factory">The factory used to create the <see cref="EntitiesMap{TKey}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is null.</exception>
        protected AEntitiesBufferedSystem(World world, Func<object, World, EntitiesMap<TKey>> factory)
            : this()
        {
            _map = (factory ?? throw new ArgumentNullException(nameof(factory)))(this, world ?? throw new ArgumentNullException(nameof(world)));

            World = _map.World;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitiesBufferedSystem{T, TKey}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitiesMap{TKey}"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitiesBufferedSystem(World world)
            : this(world, static (s, w) => EntityRuleBuilderFactory.Create(s.GetType())(s, w).AsMultiMap(s as IEqualityComparer<TKey>))
        { }

        #endregion

        #region Methods

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
        /// Gets all the <typeparamref name="TKey"/> of the inner <see cref="EntitiesMap{TKey}"/> which <see cref="Entity"/> instances will be updated.
        /// </summary>
        /// <returns>A <see cref="Span{T}"/> of <typeparamref name="TKey"/> in the order of update.</returns>
        protected virtual Span<TKey> GetKeys()
        {
            int newKeyCount = 0;
            foreach (TKey key in _map.Keys)
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
        /// Gets or sets whether the current <see cref="AEntitiesSystem{T, TKey}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if the inner <see cref="EntitiesMap{TKey}"/> is empty.
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

                    foreach (ref readonly TKey key in keys)
                    {
                        if (_map.TryGetEntities(key, out EntitiesMap<TKey>.Entities entities) && entities.Count > 0)
                        {
                            PreUpdate(state, key);

                            Entity[] buffer = ArrayPool<Entity>.Shared.Rent(entities.Count);
                            entities.GetEntities().CopyTo(buffer);

                            Update(state, key, new ReadOnlySpan<Entity>(buffer, 0, entities.Count));

                            ArrayPool<Entity>.Shared.Return(buffer);

                            PostUpdate(state, key);
                        }
                    }
                    _map.Complete();

                    PostUpdate(state);
                }
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntitiesMap{TKey}"/> instance.
        /// </summary>
        public virtual void Dispose() => _map.Dispose();

        #endregion
    }
}
