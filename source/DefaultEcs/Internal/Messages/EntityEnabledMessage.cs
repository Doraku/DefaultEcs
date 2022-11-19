namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct EntityEnabledMessage(
        int EntityId,
        ComponentEnum Components);
}
