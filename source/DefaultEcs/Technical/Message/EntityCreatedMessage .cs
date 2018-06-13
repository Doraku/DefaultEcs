namespace DefaultEcs.Technical.Message
{
    internal readonly struct EntityCreatedMessage
    {
        public readonly int EntityId;

        public EntityCreatedMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
