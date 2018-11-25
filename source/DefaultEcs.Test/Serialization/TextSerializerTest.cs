using System.IO;
using DefaultEcs.Serialization;

namespace DefaultEcs.Test.Serialization
{
    public sealed class TextSerializerTest : ASerializerTest
    {
        protected override void Write<T>(Stream stream, T obj) => TextSerializer.Write(stream, obj);

        protected override T Read<T>(Stream stream) => TextSerializer.Read<T>(stream);
    }
}
