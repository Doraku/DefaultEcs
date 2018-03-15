namespace DefaultEcs.Technical.Message
{
    internal readonly struct ComponentRemovedMessage<T>
    {
        public readonly ComponentEnum Components;
        public readonly Entity Entity;

        public ComponentRemovedMessage(in Entity entity, ComponentEnum components)
        {
            Entity = entity;
            Components = components;
        }
    }
}
