namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct EntityCreatedMessage(
        int EntityId);

    internal readonly record struct EntityEnabledMessage(
        int EntityId,
        ComponentEnum Components);

    internal readonly record struct EntityDisabledMessage(
        int EntityId,
        ComponentEnum Components);

    internal readonly record struct EntityDisposingMessage(
        int EntityId);

    internal readonly record struct EntityDisposedMessage(
        int EntityId);

    internal readonly record struct EntityComponentAddedMessage<T>(
        int EntityId,
        ComponentEnum Components);

    internal readonly record struct EntityComponentChangedMessage<T>(
        int EntityId,
        ComponentEnum Components);

    internal readonly record struct EntityComponentRemovedMessage<T>(
        int EntityId,
        ComponentEnum Components);

    internal readonly record struct EntityComponentEnabledMessage<T>(
        int EntityId,
        ComponentEnum Components);

    internal readonly record struct EntityComponentDisabledMessage<T>(
        int EntityId,
        ComponentEnum Components);
}
