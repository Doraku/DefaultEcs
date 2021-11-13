namespace DefaultEcs.Internal.Component
{
    internal readonly ref struct PoolEntityEnumerable
    {
        #region Types

        public ref struct PoolEntityEnumerator
        {
            private readonly PoolEntityEnumerable _enumerable;

            private int _index;

            public PoolEntityEnumerator(PoolEntityEnumerable enumerable)
            {
                _enumerable = enumerable;

                _index = 0;
            }

            #region IEnumerator

            public Entity Current => new(_enumerable._worldId, _index);

            public bool MoveNext()
            {
                while (++_index < _enumerable._mapping.Length)
                {
                    if (_enumerable._mapping[_index] >= 0)
                    {
                        return true;
                    }
                }

                return false;
            }

            #endregion
        }

        #endregion

        private readonly short _worldId;
        private readonly int[] _mapping;

        public PoolEntityEnumerable(short worldId, int[] mapping)
        {
            _worldId = worldId;
            _mapping = mapping;
        }

        #region IEnumerable

        public PoolEntityEnumerator GetEnumerator() => new(this);

        #endregion
    }
}
