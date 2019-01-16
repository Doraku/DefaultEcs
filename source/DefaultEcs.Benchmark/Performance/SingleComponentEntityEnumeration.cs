using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DefaultEcs.System;
//using Entitas;
using DefaultEntity = DefaultEcs.Entity;
using DefaultEntitySet = DefaultEcs.EntitySet;
using DefaultWorld = DefaultEcs.World;
//using EntitasEntity = Entitas.Entity;
//using EntitiasWorld = Entitas.IContext<Entitas.Entity>;

namespace DefaultEcs.Benchmark.Performance
{
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 10, targetCount: 10, invocationCount: 10)]
    public class SingleComponentEntityEnumeration
    {
        private struct DefaultComponent
        {
            public int Value;
        }

        private sealed class DefaultEcsSystem : AEntitySystem<int>
        {
            public DefaultEcsSystem(DefaultWorld world, SystemRunner<int> runner)
                : base(world.GetEntities().With<DefaultComponent>().Build(), runner)
            { }

            public DefaultEcsSystem(DefaultWorld world)
                : this(world, null)
            { }

            protected override void Update(int state, ReadOnlySpan<DefaultEntity> entities)
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    ++entities[i].Get<DefaultComponent>().Value;
                }
            }
        }

        private sealed class DefaultEcsComponentSystem : AComponentSystem<int, DefaultComponent>
        {
            public DefaultEcsComponentSystem(DefaultWorld world, SystemRunner<int> runner)
                : base(world, runner)
            { }

            public DefaultEcsComponentSystem(DefaultWorld world)
                : this(world, null)
            { }

            protected override void Update(int state, Span<DefaultComponent> components)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    ++components[i].Value;
                }
            }
        }

        //private class EntitasComponent : IComponent
        //{
        //    public int Value;
        //}

        //public class EntitasSystem : JobSystem<EntitasEntity>
        //{
        //    public EntitasSystem(EntitiasWorld world, int threadCount) : base(world.GetGroup(Matcher<EntitasEntity>.AllOf(0)), threadCount)
        //    { }

        //    public EntitasSystem(EntitiasWorld world) : this(world, 1)
        //    { }

        //    protected override void Execute(EntitasEntity entity)
        //    {
        //        EntitasComponent component = (EntitasComponent)entity.GetComponent(0);
        //        ++component.Value;
        //    }
        //}

        private DefaultWorld _defaultWorld;
        private DefaultEntitySet _defaultEntitySet;
        private DefaultEcsSystem _defaultSystem;
        private SystemRunner<int> _defaultRunner;
        private DefaultEcsSystem _defaultMultiSystem;
        private DefaultEcsComponentSystem _defaultComponentSystem;
        private DefaultEcsComponentSystem _defaultComponentMultiSystem;

        //private EntitiasWorld _entitasWorld;
        //private EntitasSystem _entitasSystem;
        //private EntitasSystem _entitasMultiSystem;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultWorld = new DefaultWorld(EntityCount);
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultComponent>().Build();
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultRunner = new SystemRunner<int>(Environment.ProcessorCount);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);
            _defaultComponentSystem = new DefaultEcsComponentSystem(_defaultWorld);
            _defaultComponentMultiSystem = new DefaultEcsComponentSystem(_defaultWorld, _defaultRunner);

            //_entitasWorld = new Context<EntitasEntity>(1);
            //_entitasSystem = new EntitasSystem(_entitasWorld);
            //_entitasMultiSystem = new EntitasSystem(_entitasWorld, Environment.ProcessorCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                DefaultEntity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultComponent>();

                //EntitasEntity entitasEntity = _entitasWorld.CreateEntity();
                //entitasEntity.AddComponent(0, new EntitasComponent());
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _defaultRunner.Dispose();
            _defaultWorld.Dispose();
        }

        [Benchmark]
        public void DefaultEcs_EntitySet()
        {
            ReadOnlySpan<DefaultEntity> entities = _defaultEntitySet.GetEntities();
            for (int i = 0; i < entities.Length; i++)
            {
                ++entities[i].Get<DefaultComponent>().Value;
            }
        }

        [Benchmark]
        public void DefaultEcs_System()
        {
            _defaultSystem.Update(42);
        }

        [Benchmark]
        public void DefaultEcs_MultiSystem()
        {
            _defaultMultiSystem.Update(42);
        }

        [Benchmark]
        public void DefaultEcs_Component()
        {
            Span<DefaultComponent> components = _defaultWorld.GetAllComponents<DefaultComponent>();
            for (int i = 0; i < components.Length; i++)
            {
                ++components[i].Value;
            }
        }

        [Benchmark]
        public void DefaultEcs_ComponentSystem()
        {
            _defaultComponentSystem.Update(42);
        }

        [Benchmark]
        public void DefaultEcs_ComponentMultiSystem()
        {
            _defaultComponentMultiSystem.Update(42);
        }

        //[Benchmark]
        //public void Entitas_System()
        //{
        //    _entitasSystem.Execute();
        //}

        //[Benchmark]
        //public void Entitas_MultiSystem()
        //{
        //    _entitasMultiSystem.Execute();
        //}
    }
}
