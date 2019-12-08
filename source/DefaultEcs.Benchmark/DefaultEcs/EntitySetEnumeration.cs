using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 1000)]
    public class EntitySetEnumeration
    {
        private World _world;
        private EntitySet _set;
#pragma warning disable IDE0052 // Remove unread private members
        private int _count;
#pragma warning restore IDE0052 // Remove unread private members

        [Params(1000, 100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World(EntityCount);
            _set = _world.GetEntities().Build();

            for (int i = 0; i < EntityCount; ++i)
            {
                _world.CreateEntity();
            }
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _set.Dispose();
            _world.Dispose();
        }

        [Benchmark]
        public void DefaultEnumeration()
        {
            foreach (ref readonly Entity _ in _set.GetEntities())
            {
                ++_count;
            }
        }

        [Benchmark]
        public void CopyEnumeration()
        {
            foreach (Entity _ in _set.GetEntities().ToArray())
            {
                ++_count;
            }
        }

        [Benchmark]
        public void StackCopyEnumeration()
        {
            Span<Entity> entities = stackalloc Entity[_set.Count];
            _set.GetEntities().CopyTo(entities);
            foreach (ref Entity _ in entities)
            {
                ++_count;
            }
        }

        [Benchmark]
        public void HeapCopyEnumeration()
        {
            Span<Entity> entities = new Entity[_set.Count];
            _set.GetEntities().CopyTo(entities);
            foreach (ref Entity _ in entities)
            {
                ++_count;
            }
        }
    }
}
