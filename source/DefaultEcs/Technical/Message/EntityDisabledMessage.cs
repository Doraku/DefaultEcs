namespace DefaultEcs.Technical.Message
{
    internal readonly struct EntityDisabledMessage
    {
        public readonly int EntityId;

        public EntityDisabledMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
