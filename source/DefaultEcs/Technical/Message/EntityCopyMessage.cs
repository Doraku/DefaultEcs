namespace DefaultEcs.Technical.Message
{
    public readonly struct EntityCopyMessage
    {
        public readonly int EntityId;
        public readonly Entity Copy;

        public EntityCopyMessage(int entityId, in Entity copy)
        {
            EntityId = entityId;
            Copy = copy;
        }
    }
}
