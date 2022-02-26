using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Messages
{
    internal readonly struct ComponentTypeReadMessage
    {
        public readonly IComponentTypeReader Reader;

        public ComponentTypeReadMessage(IComponentTypeReader reader)
        {
            Reader = reader;
        }
    }
}
