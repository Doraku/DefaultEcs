namespace DefaultEcs.Technical.Message
{
    internal readonly struct ComponentChangedMessage<T>
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public ComponentChangedMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
