using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Helper;

namespace DefaultEcs.Internal.Component
{
    internal sealed class ArchetypeComponentPool<T>
    {
        #region Fields

        private T[] _components;

        #endregion

        #region Initialisation

        public ArchetypeComponentPool(Archetype archetype)
        {
            _components = EmptyArray<T>.Value;

            archetype.OnCopyComponents += (index, newArchetype) => { if (newArchetype.Has<T>()) ComponentManager<T>.GetOrCreateArchetype(newArchetype.ArchetypeId).SetAt(newArchetype.Count, GetAt(index)); };
            archetype.OnRemoveComponents += (index, lastIndex) => RemoveAt(index, lastIndex);
            archetype.OnTrimExcess += lastIndex => ArrayExtension.Trim(ref _components, lastIndex);
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAt(int index, in T component)
        {
            ArrayExtension.EnsureLength(ref _components, index);
            _components[index] = component;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index, int lastIndex)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T GetAt(int index) => ref _components[index];

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<T> AsMemory(int count) => new(_components, 0, count);

        #endregion
    }
}
