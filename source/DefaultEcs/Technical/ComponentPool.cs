using System;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal sealed class ComponentPool<T>
    {
        #region Fields

        private readonly int[] _mapping;
        private readonly ComponentLink[] _links;
        private readonly T[] _components;

        private int _lastComponentIndex;

        #endregion

        #region Initialisation

        public ComponentPool(int maxEntityCount, int maxComponentCount)
        {
            _mapping = Enumerable.Repeat(-1, maxEntityCount).ToArray();
            _links = new ComponentLink[maxComponentCount];
            _components = new T[maxComponentCount];

            _lastComponentIndex = -1;
        }

        #endregion

        #region Callbacks

        public void On(in EntityDisposedMessage message) => Remove(message.Entity.EntityId);

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int entityId) => _mapping[entityId] != -1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Set(int entityId, in T component)
        {
            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                _components[componentIndex] = component;

                return false;
            }

            if (_lastComponentIndex == _components.Length - 1)
            {
                throw new InvalidOperationException($"Max number of component of type {nameof(T)} reached");
            }

            _components[++_lastComponentIndex] = component;
            componentIndex = _lastComponentIndex;
            _links[_lastComponentIndex] = new ComponentLink(entityId);

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SetSameAs(int entityId, int referenceEntityId)
        {
            int referenceComponentIndex = _mapping[referenceEntityId];

            bool isNew = true;
            ref int componentIndex = ref _mapping[entityId];
            if (componentIndex != -1)
            {
                if (componentIndex == referenceComponentIndex)
                {
                    return false;
                }

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
        public ref T Get(int entityId)
        {
            int componentIndex = _mapping[entityId];
            if (componentIndex == -1)
            {
                throw new InvalidOperationException($"Entity does not have a component of type {nameof(T)}");
            }

            return ref _components[componentIndex];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetAll() => new Span<T>(_components, 0, _lastComponentIndex + 1);

        #endregion
    }
}
