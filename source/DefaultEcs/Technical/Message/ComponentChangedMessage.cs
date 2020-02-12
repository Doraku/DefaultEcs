namespace DefaultEcs.Technical.Message
{
    internal readonly struct ComponentChangedMessage<T>
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;
        public readonly T OldValue;

        public ComponentChangedMessage(int entityId, ComponentEnum components, in T oldValue)
        {
            EntityId = entityId;
            Components = components;
            OldValue = oldValue;
        }
    }
}
