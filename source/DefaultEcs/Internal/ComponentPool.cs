using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Internal.Messages;

namespace DefaultEcs.Internal
{
    internal sealed class ComponentPool<T> : ISortable
    {
        #region Types

        public readonly ref struct EntityEnumerable
        {
            private readonly ComponentPool<T> _pool;

            public EntityEnumerable(ComponentPool<T> pool)
            {
                _pool = pool;
            }

            #region IEnumerable

            public EntityEnumerator GetEnumerator() => new(_pool);

            #endregion
        }

        public ref struct EntityEnumerator
        {
            private readonly short _worldId;
            private readonly int[] _mapping;

            private int _index;

            public EntityEnumerator(ComponentPool<T> pool)
            {
                _worldId = pool._worldId;
                _mapping = pool._mapping;

                _index = 0;
            }

            #region IEnumerator

            public Entity Current => new(_worldId, _index);

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

            #endregion
        }

        #endregion

        #region Fields

        private static readonly bool _isReferenceType;
        private static readonly bool _isFlagType;

        private readonly short _worldId;
        private readonly int _worldMaxCapacity;

        private int _maxCapacity;
        private int[] _mapping;
        private ComponentLink[] _links;
        private T[] _components;
        private int _lastComponentIndex;
        private int _sortedIndex;

        #endregion

        #region Properties

        public int MaxCapacity
        {
            get => _maxCapacity;
            set
            {
                value = Math.Min(_isFlagType ? 1 : _worldMaxCapacity, value);

                if (_lastComponentIndex < value)
                {
                    _maxCapacity = value;
                }
            }
        }

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

        public ComponentPool(short worldId, int worldMaxCapacity, int maxCapacity, bool isPrevious)
        {
            _worldId = worldId;
            _worldMaxCapacity = worldMaxCapacity == int.MaxValue ? int.MaxValue : (worldMaxCapacity + 1);

            _mapping = EmptyArray<int>.Value;
            _links = EmptyArray<ComponentLink>.Value;
            _components = EmptyArray<T>.Value;
            _lastComponentIndex = -1;
            _sortedIndex = 0;

            MaxCapacity = maxCapacity;

            Publisher<TrimExcessMessage>.Subscribe(_worldId, On);
            Publisher<EntityDisposedMessage>.Subscribe(_worldId, On);
            if (!isPrevious)
            {
                Publisher<ComponentTypeReadMessage>.Subscribe(_worldId, On);
                Publisher<ComponentReadMessage>.Subscribe(_worldId, On);
            }

            World.Worlds[_worldId].Add(this);
        }

        #endregion

        #region Callbacks

        private void On(in ComponentTypeReadMessage message) => message.Reader.OnRead<T>(MaxCapacity);

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

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowMaxNumberOfComponentReached() => throw new InvalidOperationException($"Max number of component of type {typeof(T)} reached");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int entityId) => entityId < _mapping.Length && _mapping[entityId] != -1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Set(int entityId, in T component)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, _worldMaxCapacity, -1);

            bool isNew = true;
            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                if (_links[componentIndex].ReferenceCount == 1)
                {
                    _components[componentIndex] = component;

                    return false;
                }

                Remove(entityId);
                isNew = false;
            }

            if (_lastComponentIndex == MaxCapacity - 1)
            {
                if (_isFlagType)
                {
                    return SetSameAs(entityId, _links[0].EntityId) && isNew;
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

            return isNew;
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
        public Span<T> AsSpan() => new(_components, 0, _lastComponentIndex + 1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Components<T> AsComponents() => new(_mapping, _components);

        public EntityEnumerable GetEntities() => new(this);

        public void TrimExcess()
        {
            ArrayExtension.Trim(ref _components, _lastComponentIndex + 1);
            ArrayExtension.Trim(ref _links, _lastComponentIndex + 1);
            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i != -1) + 1);
        }

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
                    (_components[minIndex], _components[_sortedIndex]) = (_components[_sortedIndex], _components[minIndex]);

                    int sortedEntityId = _links[_sortedIndex].EntityId;

                    (_links[minIndex], _links[_sortedIndex]) = (_links[_sortedIndex], _links[minIndex]);

                    if (_links[_sortedIndex].ReferenceCount > 1
                        || _links[minIndex].ReferenceCount > 1)
                    {
                        for (int i = 0; i < _mapping.Length; ++i)
                        {
                            if (_mapping[i] == minIndex)
                            {
                                _mapping[i] = _sortedIndex;
                            }
                            else if (_mapping[i] == _sortedIndex)
                            {
                                _mapping[i] = minIndex;
                            }
                        }
                    }
                    else
                    {
                        _mapping[minEntityId] = _sortedIndex;
                        _mapping[sortedEntityId] = minIndex;
                    }
                }
            }
        }

        #endregion
    }
}
