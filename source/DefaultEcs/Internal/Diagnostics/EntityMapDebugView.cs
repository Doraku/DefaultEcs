using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DefaultEcs.Internal.Diagnostics
{
    internal sealed class EntityMapDebugView<TKey>
    {
        private readonly EntityMap<TKey> _map;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public KeyValuePair<TKey, Entity>[] Entities => _map.Keys.Select(k => new KeyValuePair<TKey, Entity>(k, _map[k])).ToArray();

        public EntityMapDebugView(EntityMap<TKey> map)
        {
            _map = map;
        }
    }
}
