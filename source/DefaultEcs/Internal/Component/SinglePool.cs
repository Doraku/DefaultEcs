using System;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal.Component
{
    internal sealed class SinglePool<T> : IComponentPool<T>, ISortable
    {
        #region Fields

        private readonly short _worldId;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private int[] _reverseMapping;
        private T[] _components;
        private int _lastComponentIndex;
        private int _sortedIndex;

        #endregion

        #region Initialisation

        public SinglePool(short worldId, ComponentMode mode)
        {
            _worldId = worldId;

            _mapping = EmptyArray<int>.Value;
            _reverseMapping = EmptyArray<int>.Value;
            _components = EmptyArray<T>.Value;
            _lastComponentIndex = -1;
            _sortedIndex = 0;

            _subscriptions = IDisposableExtension.Merge(
                Publisher<TrimExcessMessage>.Subscribe(_worldId, On),
                Publisher<EntityDisposedMessage>.Subscribe(_worldId, On));

            Mode = mode;

            World.Instances[_worldId].Add(this);
        }

        public SinglePool(short worldId)
            : this(worldId, ComponentMode.Single)
        {
            _subscriptions = IDisposableExtension.Merge(
                _subscriptions,
                Publisher<ComponentReadMessage>.Subscribe(_worldId, On));
        }

        #endregion

        #region Callbacks

        private void On(in EntityDisposedMessage message) => Remove(message.EntityId);

        private void On(in ComponentReadMessage message)
        {
            int componentIndex = message.EntityId < _mapping.Length ? _mapping[message.EntityId] : -1;
            if (componentIndex != -1)
            {
                message.Reader.OnRead(_components[componentIndex], new Entity(_worldId, message.EntityId));
            }
        }

        private void On(in TrimExcessMessage message) => TrimExcess();

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => new(_components, 0, Count);

        #endregion

        #region IComponentPool

        public bool IsNotEmpty => _lastComponentIndex > -1;

        public int Count => _lastComponentIndex + 1;

        public ComponentMode Mode { get; }

        public bool Has(int entityId) => entityId < _mapping.Length && _mapping[entityId] != -1;

        public bool Set(int entityId, in T component)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, int.MaxValue, -1);

            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                _components[componentIndex] = component;

                return false;
            }

            if (_sortedIndex >= _lastComponentIndex || _reverseMapping[_sortedIndex] > entityId)
            {
                _sortedIndex = 0;
            }

            componentIndex = ++_lastComponentIndex;

            ArrayExtension.EnsureLength(ref _reverseMapping, componentIndex);
            _reverseMapping[componentIndex] = entityId;

            ArrayExtension.EnsureLength(ref _components, componentIndex);
            _components[componentIndex] = component;

            return true;
        }

        public bool SetSameAs(int entityId, int referenceEntityId) => throw new NotSupportedException($"{nameof(SetSameAs)} operations are only supported in {ComponentMode.Shared} mode");

        public bool Remove(int entityId)
        {
            if (entityId >= _mapping.Length)
            {
                return false;
            }

            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex == -1)
            {
                return false;
            }

            if (componentIndex != _lastComponentIndex)
            {
                _reverseMapping[componentIndex] = _reverseMapping[_lastComponentIndex];
                _components[componentIndex] = _components[_lastComponentIndex];
            }

            _sortedIndex = Math.Min(_sortedIndex, componentIndex);

            if (ComponentManager<T>.IsReferenceType)
            {
                _components[_lastComponentIndex] = default;
            }

            --_lastComponentIndex;
            componentIndex = -1;

            return true;
        }

        public ref T Get(int entityId) => ref _components[_mapping[entityId]];

        public void TrimExcess()
        {
            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i != -1) + 1);
            ArrayExtension.Trim(ref _reverseMapping, Count);
            ArrayExtension.Trim(ref _components, Count);
        }

        public Components<T> AsComponents() => new(_mapping, _components);

        public void CopyTo(IComponentPool<T> newPool)
        {
            for (int i = 0; i <= _lastComponentIndex; ++i)
            {
                newPool.Set(_reverseMapping[i], _components[i]);
            }
        }

        public PoolEntityEnumerable GetEntities() => new(_worldId, _mapping);

        #endregion

        #region ISortable

        void ISortable.Sort(ref bool shouldContinue)
        {
            for (; _sortedIndex < _lastComponentIndex && Volatile.Read(ref shouldContinue); ++_sortedIndex)
            {
                int minIndex = _sortedIndex;
                int minEntityId = _reverseMapping[_sortedIndex];
                for (int i = _sortedIndex + 1; i <= _lastComponentIndex; ++i)
                {
                    if (_reverseMapping[i] < minEntityId)
                    {
                        minEntityId = _reverseMapping[i];
                        minIndex = i;
                    }
                }

                if (minIndex != _sortedIndex)
                {
                    T tempComponent = _components[_sortedIndex];

                    _components[_sortedIndex] = _components[minIndex];
                    _components[minIndex] = tempComponent;

                    int tempEntityId = _reverseMapping[_sortedIndex];

                    _reverseMapping[_sortedIndex] = _reverseMapping[minIndex];
                    _reverseMapping[minIndex] = tempEntityId;

                    _mapping[minEntityId] = _sortedIndex;
                    _mapping[tempEntityId] = minIndex;
                }
            }
        }

        #endregion

        #region IDisposable

        public void Dispose() => _subscriptions.Dispose();

        #endregion
    }
}
