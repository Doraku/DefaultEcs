namespace DefaultEcs.Internal.Messages
{
    internal readonly struct ComponentDisabledMessage<T>
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public ComponentDisabledMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
