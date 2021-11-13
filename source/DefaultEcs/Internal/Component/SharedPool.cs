using System;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal.Component
{
    internal sealed class SharedPool<T> : IComponentPool<T>, ISortable
    {
        #region Types

        private struct ComponentLink
        {
            #region Fields

            public int EntityId;
            public int ReferenceCount;

            #endregion

            #region Initialisation

            public ComponentLink(int entityId)
            {
                EntityId = entityId;
                ReferenceCount = 1;
            }

            #endregion
        }

        #endregion

        #region Fields

        private readonly short _worldId;
        private readonly IDisposable _subscriptions;

        private int[] _mapping;
        private ComponentLink[] _links;
        private T[] _components;
        private int _lastComponentIndex;
        private int _sortedIndex;

        #endregion

        #region Initialisation

        public SharedPool(short worldId)
        {
            _worldId = worldId;

            _mapping = EmptyArray<int>.Value;
            _links = EmptyArray<ComponentLink>.Value;
            _components = EmptyArray<T>.Value;
            _lastComponentIndex = -1;
            _sortedIndex = 0;

            _subscriptions = IDisposableExtension.Merge(
                Publisher<TrimExcessMessage>.Subscribe(_worldId, On),
                Publisher<EntityDisposedMessage>.Subscribe(_worldId, On),
                Publisher<ComponentReadMessage>.Subscribe(_worldId, On));

            World.Instances[_worldId].Add(this);
        }

        #endregion

        #region Callbacks

        private void On(in EntityDisposedMessage message) => Remove(message.EntityId);

        private void On(in ComponentReadMessage message)
        {
            int componentIndex = message.EntityId < _mapping.Length ? _mapping[message.EntityId] : -1;
            if (componentIndex != -1)
            {
                message.Reader.OnRead(_components[componentIndex], new Entity(_worldId, _links[componentIndex].EntityId));
            }
        }

        private void On(in TrimExcessMessage message) => TrimExcess();

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => new(_components, 0, _lastComponentIndex + 1);

        #endregion

        #region IComponentPool

        public bool IsNotEmpty => _lastComponentIndex > -1;

        public int Count => _lastComponentIndex + 1;

        public ComponentMode Mode => ComponentMode.Shared;

        public bool Has(int entityId) => entityId < _mapping.Length && _mapping[entityId] != -1;

        public bool Set(int entityId, in T component)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, int.MaxValue, -1);

            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                if (_links[componentIndex].ReferenceCount == 1)
                {
                    _components[componentIndex] = component;

                    return false;
                }

                Remove(entityId);
            }

            if (_sortedIndex >= _lastComponentIndex || _links[_sortedIndex].EntityId > entityId)
            {
                _sortedIndex = 0;
            }

            componentIndex = ++_lastComponentIndex;

            ArrayExtension.EnsureLength(ref _components, _lastComponentIndex);
            _components[_lastComponentIndex] = component;

            ArrayExtension.EnsureLength(ref _links, _lastComponentIndex);
            _links[_lastComponentIndex] = new ComponentLink(entityId);

            return true;
        }

        public bool SetSameAs(int entityId, int referenceEntityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, int.MaxValue, -1);

            int referenceComponentIndex = _mapping[referenceEntityId];

            if (referenceComponentIndex == -1)
            {
                throw new InvalidOperationException($"Reference entity does not have a component of type {typeof(T)}.");
            }

            bool isNew = true;
            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                Remove(entityId);
                isNew = false;
            }

            ++_links[referenceComponentIndex].ReferenceCount;
            componentIndex = referenceComponentIndex;

            return isNew;
        }

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

            ref ComponentLink link = ref _links[componentIndex];
            if (--link.ReferenceCount == 0)
            {
                if (componentIndex != _lastComponentIndex)
                {
                    ComponentLink lastLink = _links[_lastComponentIndex];
                    _links[componentIndex] = lastLink;
                    _components[componentIndex] = _components[_lastComponentIndex];
                    if (lastLink.ReferenceCount == 1)
                    {
                        _mapping[lastLink.EntityId] = componentIndex;
                    }
                    else
                    {
                        for (int i = 0; i < _mapping.Length; ++i)
                        {
                            if (_mapping[i] == _lastComponentIndex)
                            {
                                _mapping[i] = componentIndex;
                            }
                        }
                    }

                    _sortedIndex = Math.Min(_sortedIndex, componentIndex);
                }

                if (ComponentManager<T>.IsReferenceType)
                {
                    _components[_lastComponentIndex] = default;
                }
                --_lastComponentIndex;
            }
            else if (link.EntityId == entityId)
            {
                int linkIndex = componentIndex;
                for (int i = 0; i < _mapping.Length; ++i)
                {
                    if (_mapping[i] == linkIndex && i != entityId)
                    {
                        link.EntityId = i;
                        _sortedIndex = Math.Min(_sortedIndex, linkIndex);
                        break;
                    }
                }
            }

            componentIndex = -1;

            return true;
        }

        public ref T Get(int entityId) => ref _components[_mapping[entityId]];

        public void TrimExcess()
        {
            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i != -1) + 1);
            ArrayExtension.Trim(ref _links, _lastComponentIndex + 1);
            ArrayExtension.Trim(ref _components, _lastComponentIndex + 1);
        }

        public Components<T> AsComponents() => new(_mapping, _components);

        public void CopyTo(IComponentPool<T> newPool) => throw new NotSupportedException($"Changing component mode from {Mode} to {newPool.Mode} is not supported.");

        public PoolEntityEnumerable GetEntities() => new(_worldId, _mapping);

        #endregion

        #region ISortable

        void ISortable.Sort(ref bool shouldContinue)
        {
            for (; _sortedIndex < _lastComponentIndex && Volatile.Read(ref shouldContinue); ++_sortedIndex)
            {
                int minIndex = _sortedIndex;
                int minEntityId = _links[_sortedIndex].EntityId;
                for (int i = _sortedIndex + 1; i <= _lastComponentIndex; ++i)
                {
                    if (_links[i].EntityId < minEntityId)
                    {
                        minEntityId = _links[i].EntityId;
                        minIndex = i;
                    }
                }

                if (minIndex != _sortedIndex)
                {
                    T tempComponent = _components[_sortedIndex];

                    _components[_sortedIndex] = _components[minIndex];
                    _components[minIndex] = tempComponent;

                    ComponentLink tempLink = _links[_sortedIndex];

                    _links[_sortedIndex] = _links[minIndex];
                    _links[minIndex] = tempLink;

                    if (_links[_sortedIndex].ReferenceCount > 1
                        || tempLink.ReferenceCount > 1)
                    {
                        for (int i = 0; i < _mapping.Length; ++i)
                        {
                            if (_mapping[i] == minEntityId)
                            {
                                _mapping[i] = _sortedIndex;
                            }
                            else if (_mapping[i] == tempLink.EntityId)
                            {
                                _mapping[i] = minIndex;
                            }
                        }
                    }
                    else
                    {
                        _mapping[minEntityId] = _sortedIndex;
                        _mapping[tempLink.EntityId] = minIndex;
                    }
                }
            }
        }

        #endregion

        #region IDisposable

        public void Dispose() => _subscriptions.Dispose();

        #endregion
    }
}
