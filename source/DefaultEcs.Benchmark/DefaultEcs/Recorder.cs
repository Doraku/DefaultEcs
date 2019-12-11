using BenchmarkDotNet.Attributes;
using DefaultEcs.Command;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
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
            _set = _world.GetEntities().With<bool>().With<int>().AsSet();
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
