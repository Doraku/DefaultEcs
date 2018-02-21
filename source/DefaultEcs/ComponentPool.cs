using System;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Message;

namespace DefaultEcs
{
    internal sealed class ComponentPool<T>
    {
        #region Fields

        private readonly int[] _mapping;
        private readonly bool[] _isRef;
        private readonly int[] _reverseMapping;
        private readonly T[] _items;

        private int _lastIndex;

        #endregion

        #region Initialisation

        public ComponentPool(int maxEntityCount, int maxComponentCount)
        {
            _mapping = Enumerable.Repeat(-1, maxEntityCount).ToArray();
            _isRef = new bool[maxEntityCount];
            _reverseMapping = new int[maxComponentCount];
            _items = new T[maxComponentCount];

            _lastIndex = -1;
        }

        #endregion

        #region Callbacks

        public static void On(in EntityCleanedMessage message) => message.Entity.Remove<T>();

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has(int entityId) => _mapping[entityId] != -1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Set(int entityId, in T item)
        {
            ref int index = ref _mapping[entityId];
            if (index != -1)
            {
                _items[index] = item;

                return false;
            }

            if (_lastIndex == _items.Length - 1)
            {
                throw new InvalidOperationException($"Max number of component of type {nameof(T)} reached");
            }

            _items[++_lastIndex] = item;
            index = _lastIndex;
            _reverseMapping[_lastIndex] = entityId;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool SetSameAs(int entityId, int refId)
        {
            ref int refIndex = ref _mapping[refId];
            if (refIndex == -1)
            {
                throw new InvalidOperationException($"Reference Entity does not have a component of type {nameof(T)}");
            }

            bool isNew = true;
            ref int index = ref _mapping[entityId];
            if (index != -1)
            {
                if (index == refIndex)
                {
                    return false;
                }

                Remove(entityId);
                isNew = false;
            }

            if (_reverseMapping[refIndex] == refId)
            {
                _isRef[refId] = true;
            }

            index = refIndex;

            return isNew;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Remove(int entityId)
        {
            ref int index = ref _mapping[entityId];
            if (index == -1)
            {
                return false;
            }

            ref int mappedEntityId = ref _reverseMapping[index];
            if (mappedEntityId == entityId)
            {
                if (index != _lastIndex)
                {
                    int lastId = _reverseMapping[_lastIndex];
                    _items[index] = _items[_lastIndex];
                    _mapping[lastId] = index;
                    mappedEntityId = lastId;
                }

                --_lastIndex;
            }

            ref bool isRef = ref _isRef[entityId];
            if (isRef)
            {
                int refIndex = index;
                for (int i = 0; i < _mapping.Length; ++i)
                {
                    if (_mapping[i] == refIndex && i != entityId)
                    {
                        _isRef[i] = true;
                        break;
                    }
                }

                isRef = false;
            }

            index = -1;

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get(int entityId) => ref _items[_mapping[entityId]];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetAll() => new Span<T>(_items, 0, _lastIndex + 1);

        #endregion
    }
}
