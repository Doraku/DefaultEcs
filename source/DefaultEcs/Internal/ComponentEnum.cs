using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DefaultEcs.Internal
{
    internal struct ComponentEnum
    {
        #region Fields

        private uint[] _bitArray;

        #endregion

        #region Properties

        public bool IsNull => _bitArray is null;

        public bool this[ComponentFlag flag]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => flag.Index < _bitArray?.Length && (_bitArray[flag.Index] & flag.Bit) != 0;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((_bitArray?.Length ?? 0) < flag.Index + 1)
                {
                    uint[] newBitArray = new uint[flag.Index + 1];
                    _bitArray?.CopyTo(newBitArray, 0);
                    _bitArray = newBitArray;
                }

                if (value)
                {
                    _bitArray[flag.Index] |= flag.Bit;
                }
                else
                {
                    _bitArray[flag.Index] &= ~flag.Bit;
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(ComponentEnum filter)
        {
            if (filter._bitArray != null)
            {
                for (int i = 0; i < filter._bitArray.Length; ++i)
                {
                    uint part = filter._bitArray[i];
                    if (part != 0u && (i >= _bitArray.Length || (_bitArray[i] & part) != part))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool DoNotContains(ComponentEnum filter)
        {
            if (filter._bitArray != null)
            {
                for (int i = 0; i < filter._bitArray.Length; ++i)
                {
                    uint part = filter._bitArray[i];
                    if (part != 0u && i < _bitArray.Length && (_bitArray[i] & part) != 0u)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ComponentEnum Copy()
        {
            ComponentEnum copy = default;
            copy._bitArray = _bitArray?.ToArray();

            return copy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear() => _bitArray.Fill(0u);

        public override unsafe string ToString()
        {
            fixed (uint* bits = _bitArray)
            {
                return new string((char*)bits, 0, (_bitArray?.Length ?? 0) * 2);
            }
        }

        #endregion
    }
}
