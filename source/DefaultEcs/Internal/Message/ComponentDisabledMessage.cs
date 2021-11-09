using DefaultEcs.Internal.Component;

namespace DefaultEcs.Internal.Message
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
