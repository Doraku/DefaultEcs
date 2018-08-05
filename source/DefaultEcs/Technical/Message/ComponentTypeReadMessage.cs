using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Message
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
