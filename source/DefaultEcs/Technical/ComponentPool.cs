using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal sealed class ComponentPool<T> : IOptimizable
    {
        #region Types

        public readonly struct Enumerable : IEnumerable<Entity>
        {
            private readonly ComponentPool<T> _pool;

            public Enumerable(ComponentPool<T> pool)
            {
                _pool = pool;
            }

            #region IEnumerable

            public IEnumerator<Entity> GetEnumerator() => new Enumerator(_pool);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            #endregion
        }

        public struct Enumerator : IEnumerator<Entity>
        {
            private readonly short _worldId;
            private readonly int[] _mapping;

            private int _index;

            public Enumerator(ComponentPool<T> pool)
            {
                _worldId = pool._worldId;
                _mapping = pool._mapping;

                _index = -1;
            }

            #region IEnumerator

            public Entity Current => new Entity(_worldId, _index);

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                while (++_index < _mapping.Length)
                {
                    if (_mapping[_index] >= 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            public void Reset()
            {
                _index = -1;
            }

            #endregion

            #region IDisposable

            public void Dispose()
            { }

            #endregion
        }

        #endregion

        #region Fields

        private static readonly bool _isReferenceType;
        private static readonly bool _isFlagType;

        private readonly short _worldId;
        private readonly int _worldMaxCapacity;

        private int[] _mapping;
        private ComponentLink[] _links;
        private T[] _components;
        private int _lastComponentIndex;
        private int _sortedIndex;

        #endregion

        #region Properties

        public int MaxCapacity { get; }

        public bool IsNotEmpty => _lastComponentIndex > -1;

        public int Count => _lastComponentIndex + 1;

        #endregion

        #region Initialisation

        static ComponentPool()
        {
            TypeInfo typeInfo = typeof(T).GetTypeInfo();

            _isReferenceType = !typeInfo.IsValueType;
            _isFlagType = typeInfo.IsFlagType();
        }

        public ComponentPool(short worldId, int worldMaxCapacity, int maxCapacity)
        {
            _worldId = worldId;
            _worldMaxCapacity = worldMaxCapacity;
            MaxCapacity = _isFlagType ? 1 : Math.Min(worldMaxCapacity, maxCapacity);

            _mapping = EmptyArray<int>.Value;
            _links = EmptyArray<ComponentLink>.Value;
            _components = EmptyArray<T>.Value;
            _lastComponentIndex = -1;
            _sortedIndex = 0;

            Publisher<ComponentTypeReadMessage>.Subscribe(_worldId, On);
            Publisher<EntityDisposedMessage>.Subscribe(_worldId, On);
            Publisher<EntityCopyMessage>.Subscribe(_worldId, On);
            Publisher<ComponentReadMessage>.Subscribe(_worldId, On);

            World.Worlds[_worldId].Add(this);
        }

        #endregion

        #region Callbacks

        private void On(in ComponentTypeReadMessage message) => message.Reader.OnRead<T>(MaxCapacity);

        private void On(in EntityDisposedMessage message) => Remove(message.EntityId);

        private void On(in EntityCopyMessage message)
        {
            if (Has(message.EntityId))
            {
                message.Copy.Set(Get(message.EntityId));
                if (!message.Components[ComponentManager<T>.Flag])
                {
                    message.Copy.Disable<T>();
                }
            }
        }

        private void On(in ComponentReadMessage message)
        {
            int componentIndex = message.EntityId < _mapping.Length ? _mapping[message.EntityId] : -1;
            if (componentIndex != -1)
            {
                message.Reader.OnRead(ref _components[componentIndex], new Entity(_worldId, _links[componentIndex].EntityId));
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ThrowMaxNumberOfComponentReached() => throw new InvalidOperationException($"Max number of component of type {nameof(T)} reached");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int entityId) => entityId < _mapping.Length && _mapping[entityId] != -1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Set(int entityId, in T component)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _worldMaxCapacity, -1);

            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                _components[componentIndex] = component;

                return false;
            }

            if (_lastComponentIndex == MaxCapacity - 1)
            {
                if (_isFlagType)
                {
                    return SetSameAs(entityId, _links[0].EntityId);
                }

                ThrowMaxNumberOfComponentReached();
            }

            if (_sortedIndex >= _lastComponentIndex || _links[_sortedIndex].EntityId > entityId)
            {
                _sortedIndex = 0;
            }

            componentIndex = ++_lastComponentIndex;

            ArrayExtension.EnsureLength(ref _components, _lastComponentIndex, MaxCapacity);
            ArrayExtension.EnsureLength(ref _links, _lastComponentIndex, MaxCapacity);

            _components[_lastComponentIndex] = component;
            _links[_lastComponentIndex] = new ComponentLink(entityId);

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SetSameAs(int entityId, int referenceEntityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _worldMaxCapacity, -1);

            int referenceComponentIndex = _mapping[referenceEntityId];

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

                if (_isReferenceType)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get(int entityId) => ref _components[_mapping[entityId]];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => new Span<T>(_components, 0, _lastComponentIndex + 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Components<T> AsComponents() => new Components<T>(_mapping, _components);

        public Enumerable GetEntities() => new Enumerable(this);

        #endregion

        #region IOptimizable

        void IOptimizable.Optimize(ref bool shouldContinue)
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
    }
}
