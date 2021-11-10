using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal.Component
{
    internal sealed class SinglePool<T> : IComponentPool<T>
    {
        #region Types

        public readonly ref struct EntityEnumerable
        {
            private readonly SinglePool<T> _pool;

            public EntityEnumerable(SinglePool<T> pool)
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

            public EntityEnumerator(SinglePool<T> pool)
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

        private readonly short _worldId;

        private int[] _mapping;
        private int[] _reverseMapping;
        private T[] _components;
        private int _lastComponentIndex;

        #endregion

        #region Properties

        public bool IsNotEmpty => _lastComponentIndex > -1;

        public int Count => _lastComponentIndex + 1;

        #endregion

        #region Initialisation

        public SinglePool(short worldId, ComponentMode mode)
        {
            _worldId = worldId;

            _mapping = EmptyArray<int>.Value;
            _reverseMapping = EmptyArray<int>.Value;
            _components = EmptyArray<T>.Value;
            _lastComponentIndex = -1;

            Publisher<TrimExcessMessage>.Subscribe(_worldId, On);
            Publisher<EntityDisposedMessage>.Subscribe(_worldId, On);

            Mode = mode;
        }

        public SinglePool(short worldId)
            : this(worldId, ComponentMode.Single)
        {
            Publisher<ComponentReadMessage>.Subscribe(_worldId, On);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Components<T> AsComponents() => new(_mapping, _components);

        public EntityEnumerable GetEntities() => new(this);

        public void TrimExcess()
        {
            ArrayExtension.Trim(ref _components, Count);
            ArrayExtension.Trim(ref _mapping, Array.FindLastIndex(_mapping, i => i != -1) + 1);
            ArrayExtension.Trim(ref _reverseMapping, Count);
        }

        #endregion

        #region IComponentPool

        public ComponentMode Mode { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int entityId) => entityId < _mapping.Length && _mapping[entityId] != -1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Set(int entityId, in T component)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, int.MaxValue, -1);

            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                _components[componentIndex] = component;

                return false;
            }

            componentIndex = ++_lastComponentIndex;

            ArrayExtension.EnsureLength(ref _reverseMapping, componentIndex);
            _reverseMapping[componentIndex] = entityId;

            ArrayExtension.EnsureLength(ref _components, componentIndex);
            _components[componentIndex] = component;

            return true;
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

            if (componentIndex != _lastComponentIndex)
            {
                _reverseMapping[componentIndex] = _reverseMapping[_lastComponentIndex];
                _components[componentIndex] = _components[_lastComponentIndex];
            }

            if (ComponentManager<T>.IsReferenceType)
            {
                _components[_lastComponentIndex] = default;
            }

            --_lastComponentIndex;
            componentIndex = -1;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get(int entityId) => ref _components[_mapping[entityId]];

        #endregion
    }
}
