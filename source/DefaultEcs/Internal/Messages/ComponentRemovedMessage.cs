namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentRemovedMessage<T>(
        int EntityId,
        ComponentEnum Components);
}
