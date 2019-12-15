namespace DefaultEcs.Technical.Message
{
    public readonly struct EntityEnabledMessage
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
