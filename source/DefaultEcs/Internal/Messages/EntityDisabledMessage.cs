namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct EntityDisabledMessage(
        int EntityId,
        ComponentEnum Components);
}
