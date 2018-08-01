namespace DefaultEcs.Technical.Message
{
    internal readonly struct EntityCopyMessage
    {
        public readonly int EntityId;
        public readonly Entity Copy;

        public EntityCopyMessage(int entityId, Entity copy)
        {
            EntityId = entityId;
            Copy = copy;
        }
    }
}
