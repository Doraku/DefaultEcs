using DefaultEcs.Serialization;

namespace DefaultEcs.Test.Serialization
{
    public class BinarySerializerTest : ISerializerTest
    {
        protected override ISerializer GetSerializer() => new BinarySerializer();
    }
}
