using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 1000)]
    public class EntitySetFilter
    {
        private World _world;
        private EntitySet _set;
        private EntitySet _filterSet;

        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World();
            _set = _world.GetEntities().Build();
            _filterSet = _world.GetEntities().With<int>().Without<double>().Build();

            for (int i = 0; i < EntityCount; ++i)
            {
                _world.CreateEntity().Set(i);
            }

            foreach (Entity entity in _set.GetEntities())
            {
                entity.Remove<int>();
            }
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _filterSet.Dispose();
            _set.Dispose();
            _world.Dispose();
        }

        [Benchmark]
        public void Set()
        {
            foreach (Entity entity in _set.GetEntities())
            {
                entity.Set(42);
            }
        }
    }
}
