using DefaultEcs.Serialization;

namespace DefaultEcs.Test.Serialization
{
    public class TextSerializerTest : ISerializerTest
    {
        protected override ISerializer GetSerializer() => new TextSerializer();
    }
}
