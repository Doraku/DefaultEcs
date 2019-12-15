﻿namespace DefaultEcs.Technical.Message
{
    public readonly struct EntityDisabledMessage
    {
        public readonly int EntityId;
        public readonly ComponentEnum Components;

        public EntityDisabledMessage(int entityId, ComponentEnum components)
        {
            EntityId = entityId;
            Components = components;
        }
    }
}
