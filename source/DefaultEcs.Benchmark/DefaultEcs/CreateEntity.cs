using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 10000000)]
    public class CreateEntity
    {
        private World _world;

        [IterationSetup]
        public void Setup()
        {
            _world = new World(10000000);
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
