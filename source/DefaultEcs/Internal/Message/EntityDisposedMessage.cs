namespace DefaultEcs.Internal.Message
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
