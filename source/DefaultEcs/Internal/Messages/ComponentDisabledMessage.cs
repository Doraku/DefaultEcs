namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentDisabledMessage<T>(
        int EntityId,
        ComponentEnum Components);
}
