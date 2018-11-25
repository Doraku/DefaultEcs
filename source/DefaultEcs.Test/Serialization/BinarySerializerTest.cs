using System.IO;
using DefaultEcs.Serialization;

namespace DefaultEcs.Test.Serialization
{
    public sealed class BinarySerializerTest : ASerializerTest
    {
        protected override void Write<T>(Stream stream, T obj) => BinarySerializer.Write(stream, obj);

        protected override T Read<T>(Stream stream) => BinarySerializer.Read<T>(stream);
    }
}
