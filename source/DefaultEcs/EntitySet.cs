using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Debug;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a sub-selection of <see cref="Entity"/> instances from a <see cref="World"/>.
    /// </summary>
    [DebuggerTypeProxy(typeof(EntitySetDebugView))]
    [DebuggerDisplay("EntitySet[{Count}]")]
    public sealed class EntitySet : IDisposable
    {
        #region Fields

        private static readonly MethodInfo _componentsContains;
        private static readonly MethodInfo _componentsDoNotContains;
        private static readonly Dictionary<string, Predicate<ComponentEnum>> _filters;

        private readonly int _worldId;
        private readonly int _maxEntityCount;
        private readonly Predicate<ComponentEnum> _filter;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private Entity[] _entities;
        private int _lastIndex;
        private event ActionIn<Entity> _onEntityAdded;

        /// <summary>
        /// Event called when an <see cref="Entity"/> is added to the <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> OnEntityAdded
        {
            add
            {
                if (value != null)
                {
                    foreach (ref readonly Entity entity in GetEntities())
                    {
                        value(entity);
                    }
                }
                _onEntityAdded += value;
            }
            remove => _onEntityAdded -= value;
        }

        /// <summary>
        /// Event called when an <see cref="Entity"/> is removed from the <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> OnEntityRemoved;

        #endregion

        #region Properties

        internal bool IsNotEmpty => _lastIndex > -1;

        /// <summary>
        /// Gets the numbers of <see cref="Entity"/> in the current <see cref="EntitySet"/>.
        /// </summary>
        public int Count => _lastIndex + 1;

        #endregion

        #region Initialisation

        static EntitySet()
        {
            _componentsContains = typeof(ComponentEnum).GetTypeInfo().GetDeclaredMethod(nameof(ComponentEnum.Contains));
            _componentsDoNotContains = typeof(ComponentEnum).GetTypeInfo().GetDeclaredMethod(nameof(ComponentEnum.DoNotContains));
            _filters = new Dictionary<string, Predicate<ComponentEnum>>();
        }

        internal EntitySet(
            World world,
            ComponentEnum withFilter,
            ComponentEnum withoutFilter,
            List<ComponentEnum> withAnyFilters,
            List<Func<EntitySet, World, IDisposable>> subscriptions)
        {
            _worldId = world.WorldId;
            _maxEntityCount = world.MaxEntityCount;

            withFilter = withFilter.Copy();
            withFilter[World.IsAliveFlag] = true;
            withFilter[World.IsEnabledFlag] = true;

            _filter = GetFilter(withFilter, withoutFilter, withAnyFilters);

            _subscriptions = subscriptions.Select(s => s(this, world)).Merge();

            _mapping = EmptyArray<int>.Value;
            _entities = EmptyArray<Entity>.Value;
            _lastIndex = -1;

            for (int i = 0; i <= Math.Min(world.Info.EntityInfos.Length, world.LastEntityId); ++i)
            {
                if (_filter(world.Info.EntityInfos[i].Components))
                {
                    Add(i);
                }
            }
        }

        #endregion

        #region Methods

        private static Predicate<ComponentEnum> GetFilter(ComponentEnum withFilter, ComponentEnum withoutFilter, List<ComponentEnum> withAnyFilters)
        {
            string key = $"{withFilter} {withoutFilter} {string.Join(" ", withAnyFilters ?? Enumerable.Empty<ComponentEnum>())}";
            Predicate<ComponentEnum> filter;

            lock (_filters)
            {
                if (!_filters.TryGetValue(key, out filter))
                {
                    ParameterExpression components = Expression.Parameter(typeof(ComponentEnum));
                    Expression filterEx = Expression.Call(components, _componentsContains, Expression.Constant(withFilter));
                    if (!withoutFilter.IsNull)
                    {
                        filterEx = Expression.And(filterEx, Expression.Call(components, _componentsDoNotContains, Expression.Constant(withoutFilter.Copy())));
                    }
                    if (withAnyFilters != null)
                    {
                        foreach (ComponentEnum f in withAnyFilters)
                        {
                            filterEx = Expression.And(filterEx, Expression.Not(Expression.Call(components, _componentsDoNotContains, Expression.Constant(f.Copy()))));
                        }
                    }
                    filter = Expression.Lambda<Predicate<ComponentEnum>>(filterEx, components).Compile();

                    _filters.Add(key, filter);
                }
            }

            return filter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Add(int entityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _maxEntityCount, -1);

            ref int index = ref _mapping[entityId];
            if (index == -1)
            {
                index = ++_lastIndex;

                ArrayExtension.EnsureLength(ref _entities, _lastIndex, _maxEntityCount);

                _entities[_lastIndex] = new Entity(_worldId, entityId);
                _onEntityAdded?.Invoke(_entities[_lastIndex]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Remove(int entityId)
        {
            if (entityId < _mapping.Length)
            {
                ref int index = ref _mapping[entityId];
                if (index != -1)
                {
                    Entity entity = _entities[index];

                    if (index != _lastIndex)
                    {
                        _entities[index] = _entities[_lastIndex];
                        _mapping[_entities[_lastIndex].EntityId] = index;
                    }

                    --_lastIndex;
                    index = -1;

                    OnEntityRemoved?.Invoke(entity);
                }
            }
        }

        internal void Add(in EntityCreatedMessage message) => Add(message.EntityId);

        internal void CheckedAdd(in EntityEnabledMessage message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedAdd<T>(in ComponentAddedMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void Remove(in EntityDisposingMessage message) => Remove(message.EntityId);

        internal void Remove(in EntityDisabledMessage message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentRemovedMessage<T> message) => Remove(message.EntityId);

        internal void Remove<T>(in ComponentAddedMessage<T> message) => Remove(message.EntityId);

        internal void CheckedAdd<T>(in ComponentRemovedMessage<T> message)
        {
            if (_filter(message.Components))
            {
                Add(message.EntityId);
            }
        }

        internal void CheckedRemove<T>(in ComponentRemovedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                Remove(message.EntityId);
            }
        }

        /// <summary>
        /// Gets the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.
        /// </summary>
        /// <returns>A <see cref="ReadOnlySpan{T}"/> of the <see cref="Entity"/> contained in the current <see cref="EntitySet"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ReadOnlySpan<Entity> GetEntities() => new ReadOnlySpan<Entity>(_entities, 0, _lastIndex + 1);

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases current <see cref="EntitySet"/> of its subscriptions, stopping it to get modifications on the <see cref="World"/>'s <see cref="Entity"/>.
        /// </summary>
        public void Dispose() => _subscriptions.Dispose();

        #endregion
    }
}
