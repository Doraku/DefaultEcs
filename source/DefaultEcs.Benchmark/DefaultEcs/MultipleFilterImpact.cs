using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DefaultEcs.System;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 100)]
    public sealed class MultipleFilterImpact : IDisposable
    {
        public struct ComponentA { public int value; }
        public struct ComponentB { public int value; }
        public struct ComponentC { public int value; }
        public struct ComponentD { public int value; }
        public struct ComponentE { public int value; }
        public struct ComponentF { public int value; }
        public struct ComponentG { public int value; }
        public struct ComponentH { public int value; }
        public struct ComponentI { public int value; }
        public struct ComponentJ { public int value; }
        public struct ComponentK { public int value; }
        public struct ComponentL { public int value; }
        public struct ComponentM { public int value; }
        public struct ComponentN { public int value; }
        public struct ComponentO { public int value; }
        public struct ComponentP { public int value; }
        public struct ComponentQ { public int value; }
        public struct ComponentR { public int value; }
        public struct ComponentS { public int value; }
        public struct ComponentT { public int value; }
        public struct ComponentU { public int value; }
        public struct ComponentV { public int value; }
        public struct ComponentW { public int value; }
        public struct ComponentX { public int value; }
        public struct ComponentY { public int value; }
        public struct ComponentZ { public int value; }

        public sealed class BasicSystem : AEntitySetSystem<float>
        {
            public BasicSystem(EntitySet set) : base(set)
            { }

            protected override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                foreach (ref readonly Entity entity in entities)
                {
                    ++entity.Get<int>();
                }
            }
        }

        private World _world;
        private EntitySet _set;
        private EntitySet _set2;
        private BasicSystem _system;
        private BasicSystem _system2;

        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World();

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _world.CreateEntity();

                entity.Set(0);
                entity.Set<ComponentA>();
                entity.Set<ComponentB>();
                entity.Set<ComponentC>();
                entity.Set<ComponentD>();
                entity.Set<ComponentE>();
                entity.Set<ComponentF>();
                entity.Set<ComponentG>();
                entity.Set<ComponentH>();
                entity.Set<ComponentI>();
                entity.Set<ComponentJ>();
                entity.Set<ComponentK>();
                entity.Set<ComponentL>();
                entity.Set<ComponentM>();
                entity.Set<ComponentN>();
                entity.Set<ComponentO>();
                entity.Set<ComponentP>();
                entity.Set<ComponentQ>();
                entity.Set<ComponentR>();
                entity.Set<ComponentS>();
                entity.Set<ComponentT>();
                entity.Set<ComponentU>();
                entity.Set<ComponentV>();
                entity.Set<ComponentW>();
                entity.Set<ComponentX>();
                entity.Set<ComponentY>();
                entity.Set<ComponentZ>();
            }

            _set = _world.GetEntities().With<ComponentA>().AsSet();
            _system = new BasicSystem(_set);
            _set2 = _world.GetEntities()
                .With<ComponentA>()
                .With<ComponentB>()
                .With<ComponentC>()
                .With<ComponentD>()
                .With<ComponentE>()
                .With<ComponentF>()
                .With<ComponentG>()
                .With<ComponentH>()
                .With<ComponentI>()
                .With<ComponentJ>()
                .With<ComponentK>()
                .With<ComponentL>()
                .With<ComponentM>()
                .With<ComponentN>()
                .With<ComponentO>()
                .With<ComponentP>()
                .With<ComponentQ>()
                .With<ComponentR>()
                .With<ComponentS>()
                .With<ComponentT>()
                .With<ComponentU>()
                .With<ComponentV>()
                .With<ComponentW>()
                .With<ComponentX>()
                .With<ComponentY>()
                .With<ComponentZ>()
                .AsSet();
            _system2 = new BasicSystem(_set2);
        }

        [IterationCleanup]
        public void Dispose()
        {
            _system2.Dispose();
            _system.Dispose();
            _set2.Dispose();
            _set.Dispose();
            _world.Dispose();
        }

        [Benchmark]
        public void Set()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                ++entity.Get<int>();
            }
        }

        [Benchmark]
        public void Set2()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                ++entity.Get<int>();
            }
        }

        [Benchmark]
        public void SystemSet()
        {
            _system.Update(0);
        }

        [Benchmark]
        public void SystemSet2()
        {
            _system2.Update(0);
        }
    }
}
