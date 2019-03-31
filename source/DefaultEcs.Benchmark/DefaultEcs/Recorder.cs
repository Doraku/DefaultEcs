using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DefaultEcs.Command;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 10, targetCount: 20, invocationCount: 100000)]
    public class Recorder
    {
        private World _world;
        private Entity _entity;
        private EntitySet _set;
        private EntityCommandRecorder _recorder;

        [GlobalSetup]
        public void Setup()
        {
            _world = new World();
            _entity = _world.CreateEntity();
            _set = _world.GetEntities().With<bool>().With<int>().Build();
            _recorder = new EntityCommandRecorder(1024);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _set.Dispose();
            _world.Dispose();
        }

        [Benchmark]
        public void WithCode()
        {
            _entity.Set(false);
            _entity.Set(42);
            _entity.Remove<bool>();
            _entity.Remove<int>();
            _entity.Set(false);
            _entity.Set(42);
            _entity.Remove<bool>();
            _entity.Remove<int>();
        }

        [Benchmark]
        public void WithRecorder()
        {
            EntityRecord record = _recorder.Record(_entity);
            record.Set(false);
            record.Set(42);
            record.Remove<bool>();
            record.Remove<int>();
            record.Set(false);
            record.Set(42);
            record.Remove<bool>();
            record.Remove<int>();

            _recorder.Execute(_world);
        }
    }
}
