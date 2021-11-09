using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;

namespace DefaultEcs.Internal.Component
{
    internal sealed class GenericComponentPool<T>
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

        public readonly ref struct EntityEnumerable
        {
            private readonly GenericComponentPool<T> _pool;

            public EntityEnumerable(GenericComponentPool<T> pool)
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

            public EntityEnumerator(GenericComponentPool<T> pool)
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
        private ComponentLink[] _links;
        private T[] _components;
        private int _lastComponentIndex;

        #endregion

        #region Properties

        public bool IsNotEmpty => _lastComponentIndex > -1;

        public int Count => _lastComponentIndex + 1;

        #endregion

        #region Initialisation

        public GenericComponentPool(short worldId, bool isPrevious)
        {
            _worldId = worldId;

            _mapping = EmptyArray<int>.Value;
            _links = EmptyArray<ComponentLink>.Value;
            _components = EmptyArray<T>.Value;
            _lastComponentIndex = -1;

            Publisher<TrimExcessMessage>.Subscribe(_worldId, On);
            Publisher<EntityDisposedMessage>.Subscribe(_worldId, On);

            if (!isPrevious)
            {
                Publisher<ComponentReadMessage>.Subscribe(_worldId, On);
            }
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowMaxNumberOfComponentReached() => throw new InvalidOperationException($"Max number of component of type {nameof(T)} reached");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int entityId) => entityId < _mapping.Length && _mapping[entityId] != -1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

            componentIndex = ++_lastComponentIndex;

            ArrayExtension.EnsureLength(ref _components, _lastComponentIndex);
            _components[_lastComponentIndex] = component;

            ArrayExtension.EnsureLength(ref _links, _lastComponentIndex);
            _links[_lastComponentIndex] = new ComponentLink(entityId);

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SetSameAs(int entityId, int referenceEntityId)
        {
            ArrayExtension.EnsureLength(ref _mapping, entityId, int.MaxValue, -1);

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
    }
}
