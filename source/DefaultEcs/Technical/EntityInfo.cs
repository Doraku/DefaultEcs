using System;
using System.Collections.Generic;

namespace DefaultEcs.Technical
{
    internal struct EntityInfo
    {
        #region Fields

        public ComponentEnum Components;
        public HashSet<int> Children;
        public Func<int, bool> Parents;

        #endregion
    }
}
