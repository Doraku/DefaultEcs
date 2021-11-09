using DefaultEcs.Internal.Component;

namespace DefaultEcs.Internal.Message
{
    internal readonly struct ComponentEnabledMessage<T>
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public ComponentEnabledMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
