using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DefaultEcs.Internal.Diagnostics
{
    internal sealed class EntityMultiMapDebugView<TKey>
    {
        private readonly EntityMultiMap<TKey> _multiMap;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public KeyValuePair<TKey, Entity[]>[] Entities => _multiMap.Keys.Select(k => new KeyValuePair<TKey, Entity[]>(k, _multiMap[k].ToArray())).ToArray();

        public EntityMultiMapDebugView(EntityMultiMap<TKey> multiMap)
        {
            _multiMap = multiMap;
        }
    }
}
