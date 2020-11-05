using System;

namespace DefaultEcs.Hierarchy
{
    public readonly struct HierarchyLevel : IComparable<HierarchyLevel>
    {
        public readonly int Value;

        public HierarchyLevel(int value)
        {
            Value = value;
        }

        #region IComparable

        public int CompareTo(HierarchyLevel other) => Value.CompareTo(other.Value);

        #endregion

        #region IEquatable

        public bool Equals(HierarchyLevel other) => Value == other.Value;

        #endregion

        #region Object

        public override bool Equals(object obj) => obj is HierarchyLevel other && Equals(other);

        public override int GetHashCode() => Value;

        #endregion
    }
}
