using System;

namespace DefaultEcs.Hierarchy
{
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2231:Overload operator equals on overriding value type Equals")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1036:Override methods on comparable types")]
    [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1241:Implement non-generic counterpart.")]
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
