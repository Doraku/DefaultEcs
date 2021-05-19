using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.Message
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 100000000)]
    public class Publish
    {
        private int _temp;
        private World _world;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void On(in int value)
        {
            _temp = value;
        }

        [IterationSetup]
        public void Setup()
        {
            _world = new World(0);
            _world.Subscribe<int>(On);
            _temp = 0;
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _world.Dispose();
        }

        [Benchmark]
        public void DirectCall() => On(_temp);

        [Benchmark]
        public void DefaultEcs_Publish() => _world.Publish(_temp);
    }
}
