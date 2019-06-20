using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
//using static DefaultEcs.EntitySetExtension;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    //[HardwareCounters(HardwareCounter.LlcMisses)]
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 10000)]
    public class EntitySetWithComponentEnumeration
    {
        private World _world;
        private EntitySet _set;
#pragma warning disable IDE0052 // Remove unread private members
        private int _count;
        private uint _uCount;
        private long _lCount;
#pragma warning restore IDE0052 // Remove unread private members

        [Params(1000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World(EntityCount);
            _set = _world.GetEntities().With<int>().With<uint>().Build();

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
            foreach (Entity entity in _set.GetEntities())
            {
                _count += entity.Get<int>();
                _uCount += entity.Get<uint>();
            }
        }

        //[Benchmark]
        //public void FuckItEnumeration()
        //{
        //    foreach (Entity entity in _set.GetEntities())
        //    {
        //        _count += entity.FuckItGet<int>();
        //        _uCount += entity.FuckItGet<uint>();
        //    }
        //}

        //[Benchmark]
        //public void CopyEnumeration()
        //{
        //    foreach (Entity entity in _set.CopyEntities())
        //    {
        //        _count += entity.Get<int>();
        //        _uCount += entity.Get<uint>();
        //    }
        //}

        //[Benchmark]
        //public void StackCopyEnumeration()
        //{
        //    Span<Entity> entities = stackalloc Entity[_set.Count];
        //    _set.CopyEntitiesTo(entities);
        //    foreach (Entity entity in entities)
        //    {
        //        _count += entity.Get<int>();
        //        _uCount += entity.Get<uint>();
        //    }
        //}

        //[Benchmark]
        //public void HeapCopyEnumeration()
        //{
        //    Span<Entity> entities = new Entity[_set.Count];
        //    _set.CopyEntitiesTo(entities);
        //    foreach (Entity entity in entities)
        //    {
        //        _count += entity.Get<int>();
        //        _uCount += entity.Get<uint>();
        //    }
        //}

        //[Benchmark]
        //public void WithComponentEnumeration()
        //{
        //    foreach ((Entity Entity, int Int, uint UInt) item in _set.CopyWithComponents<int, uint>())
        //    {
        //        _count += item.Int;
        //        _uCount += item.UInt;
        //    }
        //}

        //[Benchmark]
        //public void WithFinal()
        //{
        //    Span<int> ints = stackalloc int[_set.Count];
        //    Span<uint> uints = stackalloc uint[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsTo(ints);
        //    entities.CopyComponentsTo(uints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i];
        //        _uCount += uints[i];
        //    }
        //}
        //[Benchmark]
        //public void WithFinalHeap()
        //{
        //    Span<int> ints = new int[_set.Count];
        //    Span<uint> uints = new uint[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsTo(ints);
        //    entities.CopyComponentsTo(uints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i];
        //        _uCount += uints[i];
        //    }
        //}
        //[Benchmark]
        //public void WithFinalTemp()
        //{
        //    Span<int> ints = stackalloc int[_set.Count];
        //    Span<uint> uints = stackalloc uint[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsToTemp(ints);
        //    entities.CopyComponentsToTemp(uints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i];
        //        _uCount += uints[i];
        //    }
        //}
        //[Benchmark]
        //public void WithUltimateTemp()
        //{
        //    Span<(int, uint)> ints = new(int, uint)[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsToTemp(ints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i].Item1;
        //        _uCount += ints[i].Item2;
        //    }
        //}
        //[Benchmark]
        //public void WithUltimate()
        //{
        //    Span<(int, uint)> ints = new(int, uint)[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsTo(ints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i].Item1;
        //        _uCount += ints[i].Item2;
        //    }
        //}

        [Benchmark]
        public void DefaultEnumeration3()
        {
            foreach (Entity entity in _set.GetEntities())
            {
                _count += entity.Get<int>();
                _uCount += entity.Get<uint>();
                _lCount += entity.Get<long>();
            }
        }
        //[Benchmark]
        //public void WithUltimate3()
        //{
        //    Span<(int, uint, long)> ints = new(int, uint, long)[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsTo(ints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i].Item1;
        //        _uCount += ints[i].Item2;
        //        _lCount += ints[i].Item3;
        //    }
        //}
        //[Benchmark]
        //public void WithUltimatePouet()
        //{
        //    Span<Pouet> ints = stackalloc Pouet[_set.Count];

        //    ReadOnlySpan<Entity> entities = _set.GetEntities();
        //    entities.CopyComponentsTo(ints);

        //    for (int i = 0; i < ints.Length; ++i)
        //    {
        //        _count += ints[i].Item1;
        //        _uCount += ints[i].Item2;
        //        _lCount += ints[i].Item3;
        //    }
        //}

        //[Benchmark]
        //public void WithWtfComponentEnumeration()
        //{
        //    Span<(int, uint)> span = new (int, uint)[_set.Count];

        //    _set.CopyComponentsToWtf<int>((int i, in int v) => ints[i].Int = v);
        //    //_set.CopyComponentsTo(uints);

        //    //for (int i = 0; i < ints.Length; ++i)
        //    //{
        //    //    _count += ints[i];
        //    //    _uCount += uints[i];
        //    //}
        //}
    }
}
