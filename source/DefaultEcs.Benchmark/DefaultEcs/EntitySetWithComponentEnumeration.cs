using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    public class EntitySetWithComponentEnumeration
    {
        private World _world;
        private EntitySet _set;
#pragma warning disable IDE0052 // Remove unread private members
        private int _count;
        private uint _uCount;
        private long _lCount;
#pragma warning restore IDE0052 // Remove unread private members

        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World();
            _set = _world.GetEntities().With<int>().With<uint>().AsSet();

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _world.CreateEntity();
                entity.Set(i);
                entity.Set((uint)i);
                entity.Set((long)i);
            }
        }

        [IterationCleanup]
        public void Cleanup()
        {
            _set.Dispose();
            _world.Dispose();
        }

        [Benchmark]
        public void DefaultEnumeration2()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += entity.Get<int>();
                _uCount += entity.Get<uint>();
            }
        }

        [Benchmark]
        public void ComponentEnumeration2()
        {
            using Components<int> ints = _world.GetComponents<int>();
            using Components<uint> uints = _world.GetComponents<uint>();

            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += entity.Get(ints);
                _uCount += entity.Get(uints);
            }
        }

        [Benchmark]
        public void DefaultEnumeration3()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += entity.Get<int>();
                _uCount += entity.Get<uint>();
                _lCount += entity.Get<long>();
            }
        }

        [Benchmark]
        public void ComponentEnumeration3()
        {
            using Components<int> ints = _world.GetComponents<int>();
            using Components<uint> uints = _world.GetComponents<uint>();
            using Components<long> longs = _world.GetComponents<long>();

            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += entity.Get(ints);
                _uCount += entity.Get(uints);
                _lCount += entity.Get(longs);
            }
        }
    }
}
