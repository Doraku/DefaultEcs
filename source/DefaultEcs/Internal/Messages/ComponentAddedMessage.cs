namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentAddedMessage<T>(
        int EntityId,
        ComponentEnum Components);
}
