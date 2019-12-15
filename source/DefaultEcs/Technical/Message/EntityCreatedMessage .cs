namespace DefaultEcs.Technical.Message
{
    public readonly struct EntityCreatedMessage
    {
        public readonly int EntityId;

        public EntityCreatedMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
