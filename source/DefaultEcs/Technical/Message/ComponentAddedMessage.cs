namespace DefaultEcs.Technical.Message
{
    internal readonly struct ComponentAddedMessage<T>
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public ComponentAddedMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
