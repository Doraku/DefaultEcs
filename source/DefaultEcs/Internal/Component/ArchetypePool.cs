using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;

namespace DefaultEcs.Internal.Component
{
    internal sealed class ArchetypePool<T>
    {
        #region Fields

        private T[] _components;

        #endregion

        #region Initialisation

        public ArchetypePool(Archetype archetype)
        {
            _components = EmptyArray<T>.Value;

            archetype.OnCopyComponents += CopyComponent;
            archetype.OnRemoveComponents += RemoveAt;
            archetype.OnTrimExcess += TrimExcess;
        }

        #endregion

        #region Methods

        private void CopyComponent(int index, short worldId, Archetype newArchetype)
        {
            if (ComponentManager<T>.GetWorld(worldId)?.Mode is null or ComponentMode.Archetype && newArchetype.Has<T>())
            {
                ComponentManager<T>.GetOrCreateArchetype(newArchetype).SetAt(newArchetype.Count, GetAt(index));
            }
        }

        private void RemoveAt(int index, int lastIndex)
        {
            if (index != lastIndex)
            {
                _components[index] = _components[lastIndex];
            }

            if (ComponentManager<T>.IsReferenceType)
            {
                _components[lastIndex] = default;
            }
        }

        private void TrimExcess(int lastIndex) => ArrayExtension.Trim(ref _components, lastIndex);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAt(int index, in T component)
        {
            ArrayExtension.EnsureLength(ref _components, index);
            _components[index] = component;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T GetAt(int index) => ref _components[index];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<T> AsMemory(int count) => new(_components, 0, count);

        public void Unsubscribe(Archetype archetype)
        {
            archetype.OnCopyComponents -= CopyComponent;
            archetype.OnRemoveComponents -= RemoveAt;
            archetype.OnTrimExcess -= TrimExcess;
        }

        #endregion
    }
}
