namespace DefaultEcs.Technical.Message
{
    public readonly struct EntityDisposedMessage
    {
        public readonly int EntityId;

        public EntityDisposedMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
