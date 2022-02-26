using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    public sealed class EntitySetWithComponentEnumeration : IDisposable
    {
        private World _world;
        private EntitySet _set;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052:Remove unread private members")]
        private int _count;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052:Remove unread private members")]
        private uint _uCount;
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052:Remove unread private members")]
        private long _lCount;

        [Params(100, 1000, 10000, 100000)]
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
        public void Dispose()
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
            Components<int> ints = _world.GetComponents<int>();
            Components<uint> uints = _world.GetComponents<uint>();

            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += ints[entity];
                _uCount += uints[entity];
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
            Components<int> ints = _world.GetComponents<int>();
            Components<uint> uints = _world.GetComponents<uint>();
            Components<long> longs = _world.GetComponents<long>();

            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                _count += ints[entity];
                _uCount += uints[entity];
                _lCount += longs[entity];
            }
        }
    }
}
