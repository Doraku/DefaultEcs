namespace DefaultEcs.Internal.Messages
{
    internal readonly struct EntityDisposedMessage
    {
        public readonly int EntityId;

        public EntityDisposedMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
