using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Messages
{
    internal readonly record struct ComponentTypeReadMessage(
        IComponentTypeReader Reader);
}
