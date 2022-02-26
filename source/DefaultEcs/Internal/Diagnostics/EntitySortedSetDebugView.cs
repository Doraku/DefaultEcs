using System.Diagnostics;

namespace DefaultEcs.Internal.Diagnostics
{
    internal sealed class EntitySortedSetDebugView<TComponent>
    {
        private readonly EntitySortedSet<TComponent> _sortedSet;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Entity[] Entities => _sortedSet.GetEntities().ToArray();

        public EntitySortedSetDebugView(EntitySortedSet<TComponent> sortedSet)
        {
            _sortedSet = sortedSet;
        }
    }
}
