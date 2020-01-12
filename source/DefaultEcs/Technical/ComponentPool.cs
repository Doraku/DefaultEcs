using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using DefaultEcs.Resource;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal sealed class ComponentPool<T>
    {
        #region Fields

        private static readonly bool _isReferenceType;
        private static readonly bool _isFlagType;
        private static readonly bool _isManagedResourceType;

        private readonly short _worldId;
        private readonly int _worldMaxCapacity;

        private int[] _mapping;
        private ComponentLink[] _links;
        private T[] _components;
        private int _lastComponentIndex;

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
            _isManagedResourceType = typeInfo.GenericTypeArguments.Length > 0 && typeInfo.GetGenericTypeDefinition() == typeof(ManagedResource<,>);
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

            Publisher<ComponentTypeReadMessage>.Subscribe(_worldId, On);
            Publisher<EntityDisposedMessage>.Subscribe(_worldId, On);
            Publisher<EntityCopyMessage>.Subscribe(_worldId, On);
            Publisher<ComponentReadMessage>.Subscribe(_worldId, On);

            if (_isManagedResourceType)
            {
                Publisher<ManagedResourceReleaseAllMessage>.Subscribe(_worldId, On);
            }
        }

        #endregion

        #region Callbacks

        private void On(in ComponentTypeReadMessage message) => message.Reader.OnRead<T>(MaxCapacity);

        private void On(in EntityDisposedMessage message) => Remove(message.EntityId);

        private void On(in EntityCopyMessage message)
        {
            if (Has(message.EntityId))
            {
                message.Copy.SetDisabled(Get(message.EntityId));
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

        private void On(in ManagedResourceReleaseAllMessage message)
        {
            for (int i = 0; i <= _lastComponentIndex; ++i)
            {
                for (int j = 0; j < _links[i].ReferenceCount; ++j)
                {
                    Publisher.Publish(_worldId, new ManagedResourceReleaseMessage<T>(_components[i]));
                }
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
                if (_isManagedResourceType)
                {
                    Publisher.Publish(_worldId, new ManagedResourceReleaseMessage<T>(_components[componentIndex]));
                }

                _components[componentIndex] = component;

                if (_isManagedResourceType)
                {
                    Publisher.Publish(_worldId, new ManagedResourceRequestMessage<T>(new Entity(_worldId, entityId), component));
                }

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

            componentIndex = ++_lastComponentIndex;

            ArrayExtension.EnsureLength(ref _components, _lastComponentIndex, MaxCapacity);
            ArrayExtension.EnsureLength(ref _links, _lastComponentIndex, MaxCapacity);

            _components[_lastComponentIndex] = component;
            _links[_lastComponentIndex] = new ComponentLink(entityId);

            if (_isManagedResourceType)
            {
                Publisher.Publish(_worldId, new ManagedResourceRequestMessage<T>(new Entity(_worldId, entityId), component));
            }

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
                if (componentIndex == referenceComponentIndex)
                {
                    return false;
                }

                Remove(entityId);
                isNew = false;
            }

            ++_links[referenceComponentIndex].ReferenceCount;
            componentIndex = referenceComponentIndex;

            if (_isManagedResourceType)
            {
                Publisher.Publish(_worldId, new ManagedResourceRequestMessage<T>(new Entity(_worldId, entityId), _components[componentIndex]));
            }

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

            if (_isManagedResourceType)
            {
                Publisher.Publish(_worldId, new ManagedResourceReleaseMessage<T>(_components[componentIndex]));
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
        public unsafe void FillIndices(Entity* entity, int* indices, int count)
        {
            fixed (int* mapping = _mapping)
            {
                while (--count >= 0)
                {
                    *indices = mapping[entity->EntityId];

                    ++indices;
                    ++entity;
                }
            }
        }

        public ref T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return ref _components[index]; }
        }

        #endregion
    }
}
