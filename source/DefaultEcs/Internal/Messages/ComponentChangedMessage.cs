namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentChangedMessage<T>(
        int EntityId,
        ComponentEnum Components);
}
