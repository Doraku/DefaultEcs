using System.Diagnostics;

namespace DefaultEcs.Internal.Diagnostics
{
    internal sealed class EntitySetDebugView
    {
        private readonly EntitySet _set;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Entity[] Entities => _set.GetEntities().ToArray();

        public EntitySetDebugView(EntitySet set)
        {
            _set = set;
        }
    }
}
