using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using DefaultEcs.Serialization;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    public class Serialization
    {
        private struct BigStruct
        {
            public float W;
            public float X;
            public float Y;
            public float Z;
        }

        private class BigClass
        {
            public float W;
            public float X;
            public float Y;
            public float Z;
        }

        private World _worldS;
        private World _worldSCopy;
        private World _worldC;
        private World _worldCCopy;
        private ISerializer _serializer;
        private string _filePathS;
        private string _filePathC;

        [Params(100000)]
        public int EntityCount { get; set; }

        [Params(typeof(BinarySerializer), typeof(TextSerializer))]
        public Type SerializerType { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _serializer = (ISerializer)Activator.CreateInstance(SerializerType);
            _worldS = new World(EntityCount);
            _worldC = new World(EntityCount);
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _worldS.CreateEntity();
                entity.Set(new BigStruct { W = i, X = i, Y = i, Z = i });
                entity = _worldC.CreateEntity();
                entity.Set(new BigClass { W = i, X = i, Y = i, Z = i });
            }
            _filePathS = Path.GetRandomFileName();
            _filePathC = Path.GetRandomFileName();
            Struct_Serialize();
            Class_Serialize();
        }

        [IterationCleanup]
        public void CopyCleanup()
        {
            _worldSCopy?.Dispose();
            _worldCCopy?.Dispose();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _worldS.Dispose();
            _worldC.Dispose();
            Console.WriteLine($"struct file size {new FileInfo(_filePathS).Length / 1024f / 1024f} mo");
            Console.WriteLine($"class file size {new FileInfo(_filePathC).Length / 1024f / 1024f} mo");
            File.Delete(_filePathS);
            File.Delete(_filePathC);
        }

        [Benchmark]
        public void Struct_Serialize()
        {
            using Stream stream = File.Create(_filePathS);

            _serializer.Serialize(stream, _worldS);
        }

        [Benchmark]
        public void Struct_Deserialize()
        {
            using Stream stream = File.OpenRead(_filePathS);

            _worldSCopy = _serializer.Deserialize(stream);
        }

        [Benchmark]
        public void Class_Serialize()
        {
            using Stream stream = File.Create(_filePathC);

            _serializer.Serialize(stream, _worldC);
        }

        [Benchmark]
        public void Class_Deserialize()
        {
            using Stream stream = File.OpenRead(_filePathC);

            _worldCCopy = _serializer.Deserialize(stream);
        }
    }
}
