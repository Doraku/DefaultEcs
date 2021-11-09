using DefaultEcs.Internal.Component;

namespace DefaultEcs.Internal.Message
{
    internal readonly struct EntityEnabledMessage
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public EntityEnabledMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
