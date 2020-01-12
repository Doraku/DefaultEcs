using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
//using static DefaultEcs.EntitySetExtension;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    //[HardwareCounters(HardwareCounter.CacheMisses)]
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
        public void DefaultEnumeration()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += entity.Get<int>();
                _uCount += entity.Get<uint>();
            }
        }

        [Benchmark]
        public void PrefetchedEnumeration()
        {
            ReadOnlySpan<Entity> entities = _set.GetEntities();

            using Component<int> ints = _world.Prefetch<int>(entities);
            using Component<uint> uints = _world.Prefetch<uint>(entities);

            for (int i = 0; i < entities.Length; ++i)
            {
                _count += ints[i];
                _uCount += uints[i];
            }
        }

        [Benchmark]
        public void Prefetched2Enumeration()
        {
            (Component<int> ints, Component<uint> uints) = _world.Prefetch<int, uint>(_set.GetEntities());

            using (ints)
            using (uints)
            {
                for (int i = 0; i < _set.Count; ++i)
                {
                    _count += ints[i];
                    _uCount += uints[i];
                }
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
        public void BufferedEnumeration3()
        {
            (Component<int> ints, Component<uint> uints, Component<long> longs) = _world.Prefetch<int, uint, long>(_set.GetEntities());

            using (ints)
            using (uints)
            using (longs)
            {
                for (int i = 0; i < _set.Count; ++i)
                {
                    _count += ints[i];
                    _uCount += uints[i];
                    _lCount += longs[i];
                }
            }
        }
    }
}
