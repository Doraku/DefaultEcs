using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 1000000)]
    public class CreateEntity
    {
        private World _world;

        [IterationSetup]
        public void Setup()
        {
            _world = new World();
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _world.Dispose();
        }

        [Benchmark]
        public void DefaultEcs_CreateEntity() => _world.CreateEntity();
    }
}
