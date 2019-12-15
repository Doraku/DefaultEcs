namespace DefaultEcs.Technical.Message
{
    public readonly struct EntityDisposingMessage
    {
        public readonly int EntityId;

        public EntityDisposingMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
