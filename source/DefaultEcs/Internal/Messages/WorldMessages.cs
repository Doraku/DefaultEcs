namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct WorldComponentAddedMessage<T>;

    internal readonly record struct WorldComponentChangedMessage<T>;

    internal readonly record struct WorldComponentRemovedMessage<T>;

    internal readonly record struct WorldDisposedMessage(
        int WorldId);
}
