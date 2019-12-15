using System;
using DefaultEcs.Resource;

namespace DefaultEcs.Technical.Message
{
    public readonly struct ManagedResourceRequestMessage<T>
    {
        public readonly Entity Entity;
        public readonly T ManagedResource;

        public ManagedResourceRequestMessage(in Entity entity, T managedResource)
        {
            Entity = entity;
            ManagedResource = managedResource;
        }
    }
}
