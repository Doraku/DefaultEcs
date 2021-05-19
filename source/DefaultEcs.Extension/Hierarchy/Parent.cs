using System;

namespace DefaultEcs.Hierarchy
{
    public readonly struct Parent : IEquatable<Parent>
    {
        public readonly Entity Value;

        public Parent(Entity value)
        {
            Value = value;
        }

        #region IEquatable

        public bool Equals(Parent other) => Value == other.Value;

        #endregion

        #region Object

        public override bool Equals(object obj) => obj is Parent other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Parent left, Parent right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Parent left, Parent right)
        {
            return !(left == right);
        }

        #endregion
    }
}
