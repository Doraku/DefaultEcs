namespace DefaultEcs.Internal.Message
{
    internal readonly struct EntityDisposingMessage
    {
        public readonly int EntityId;

        public EntityDisposingMessage(int entityId)
        {
            EntityId = entityId;
        }
    }
}
