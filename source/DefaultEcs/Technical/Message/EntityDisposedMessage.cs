namespace DefaultEcs.Technical.Message
{
    internal readonly struct EntityDisposedMessage
    {
        public readonly Entity Entity;

        public EntityDisposedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
