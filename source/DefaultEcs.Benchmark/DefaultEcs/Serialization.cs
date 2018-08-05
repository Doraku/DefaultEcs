using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DefaultEcs.Serialization;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 10, targetCount: 1, invocationCount: 1)]
    public class Serialization
    {
        private struct Position
        {
            public float X;
            public float Y;
        }

        private struct Speed
        {
            public float X;
            public float Y;
        }

        private World _world;
        private World _worldCopy;
        private ISerializer _serializer;
        private string _filePath;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _serializer = new TextSerializer();
            _world = new World(EntityCount);
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _world.CreateEntity();
                entity.Set(new Position { X = i, Y = i });
                entity.Set(new Speed { X = i, Y = i });
            }
            _filePath = Path.GetRandomFileName();
            Serialize();
        }

        [IterationCleanup]
        public void CopyCleanup()
        {
            _worldCopy?.Dispose();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _world.Dispose();
            Console.WriteLine($"file size {new FileInfo(_filePath).Length / 1024f / 1024f} mo");
            File.Delete(_filePath);
        }

        [Benchmark]
        public void Serialize()
        {
            using (Stream stream = File.Create(_filePath))
            {
                _serializer.Serialize(stream, _world);
            }
        }

        [Benchmark]
        public void Deserialize()
        {
            using (Stream stream = File.OpenRead(_filePath))
            {
                _worldCopy = _serializer.Deserialize(stream);
            }
        }
    }
}
