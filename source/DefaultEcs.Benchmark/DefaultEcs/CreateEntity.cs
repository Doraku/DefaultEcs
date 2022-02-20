using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 1000000)]
    public sealed class CreateEntity : IDisposable
    {
        private World _world;

        [IterationSetup]
        public void Setup()
        {
            _world = new World();
        }

        [IterationCleanup]
        public void Dispose()
        {
            _world.Dispose();
        }

        [Benchmark]
        public void DefaultEcs_CreateEntity() => _world.CreateEntity();
    }
}
