namespace DefaultEcs.Technical.Message
{
    internal readonly struct ComponentAddedMessage<T>
    {
        public readonly ComponentEnum Components;
        public readonly Entity Entity;

        public ComponentAddedMessage(in Entity entity, ComponentEnum components)
        {
            Entity = entity;
            Components = components;
        }
    }
}
