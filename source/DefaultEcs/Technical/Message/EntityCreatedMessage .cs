namespace DefaultEcs.Technical.Message
{
    internal readonly struct EntityCreatedMessage
    {
        public readonly Entity Entity;

        public EntityCreatedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
