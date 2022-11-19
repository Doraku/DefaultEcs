namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct EntityDisposedMessage(
        int EntityId);
}
