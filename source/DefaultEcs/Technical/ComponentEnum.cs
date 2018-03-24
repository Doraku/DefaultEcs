﻿using System.Linq;
using System.Runtime.CompilerServices;

namespace DefaultEcs.Technical
{
    internal struct ComponentEnum
    {
        #region Fields

        private int[] _bitArray;

        #endregion

        #region Properties

        public bool IsNull => _bitArray == null;

        public bool this[ComponentFlag flag]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => flag.Index < _bitArray?.Length && (_bitArray[flag.Index] & (1 << flag.Bit)) != 0;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((_bitArray?.Length ?? 0) < flag.Index + 1)
                {
                    int[] newBitArray = new int[flag.Index + 1];
                    _bitArray?.CopyTo(newBitArray, 0);
                    _bitArray = newBitArray;
                }

                if (value)
                {
                    _bitArray[flag.Index] |= 1 << flag.Bit;
                }
                else
                {
                    _bitArray[flag.Index] &= ~(1 << flag.Bit);
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
                    int part = filter._bitArray[i];
                    if (part != 0
                        && (i >= _bitArray?.Length || (_bitArray[i] & part) != part))
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
                    int part = filter._bitArray[i];
                    if (part != 0
                        && i <= _bitArray?.Length
                        && (_bitArray[i] & part) != 0)
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
        public void Clear()
        {
            if (!IsNull)
            {
                for (int i = 0; i < _bitArray.Length; ++i)
                {
                    _bitArray[i] = 0;
                }
            }
        }

        #endregion
    }
}
