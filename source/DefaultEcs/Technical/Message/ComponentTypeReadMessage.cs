using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Message
{
    public readonly struct ComponentTypeReadMessage
    {
        public readonly IComponentTypeReader Reader;

        public ComponentTypeReadMessage(IComponentTypeReader reader)
        {
            Reader = reader;
        }
    }
}
