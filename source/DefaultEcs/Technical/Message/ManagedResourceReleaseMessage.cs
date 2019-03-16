namespace DefaultEcs.Technical.Message
{
    internal readonly struct ManagedResourceReleaseMessage<T>
    {
        public readonly T ManagedResource;

        public ManagedResourceReleaseMessage(T managedResource)
        {
            ManagedResource = managedResource;
        }
    }
}
