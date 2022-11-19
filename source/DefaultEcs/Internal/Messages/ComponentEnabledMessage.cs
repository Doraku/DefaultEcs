namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentEnabledMessage<T>(
        int EntityId,
        ComponentEnum Components);
}
