namespace DefaultEcs.Technical.Message
{
    public readonly struct ManagedResourceReleaseMessage<T>
    {
        public readonly T ManagedResource;

        public ManagedResourceReleaseMessage(T managedResource)
        {
            ManagedResource = managedResource;
        }
    }
}
