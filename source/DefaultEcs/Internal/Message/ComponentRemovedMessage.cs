using DefaultEcs.Internal.Component;

namespace DefaultEcs.Internal.Message
{
    internal readonly struct ComponentRemovedMessage<T>
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public ComponentRemovedMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
