using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 1000)]
    public class EntitySetEnumeration
    {
        private World _world;
        private EntitySet _set;
        private int _count;

        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World(EntityCount);
            _set = _world.GetAllEntities();

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
            foreach (Entity entity in _set.GetEntities())
            {
                ++_count;
            }
        }

        [Benchmark]
        public void CopyEnumeration()
        {
            foreach (Entity entity in _set.CopyEntities())
            {
                ++_count;
            }
        }

        [Benchmark]
        public void StackCopyEnumeration()
        {
            Span<Entity> entities = stackalloc Entity[_set.Count];
            _set.CopyEntitiesTo(entities);
            foreach (Entity entity in entities)
            {
                ++_count;
            }
        }

        [Benchmark]
        public void HeapCopyEnumeration()
        {
            Span<Entity> entities = new Entity[_set.Count];
            _set.CopyEntitiesTo(entities);
            foreach (Entity entity in entities)
            {
                ++_count;
            }
        }
    }
}
