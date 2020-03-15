namespace DefaultEcs.Technical.Message
{
    internal readonly struct EntityCopyMessage
    {
        public readonly int EntityId;
        public readonly Entity Copy;
        public readonly ComponentEnum Components;

        public EntityCopyMessage(int entityId, in Entity copy, ComponentEnum components)
        {
            EntityId = entityId;
            Copy = copy;
            Components = components;
        }
    }
}
