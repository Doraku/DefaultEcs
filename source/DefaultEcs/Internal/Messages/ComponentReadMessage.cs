using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentReadMessage(
        int EntityId,
        IComponentReader Reader);
}
