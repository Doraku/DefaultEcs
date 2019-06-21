using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using DefaultEcs.System;
using Entitas;
using DefaultEntity = DefaultEcs.Entity;
using DefaultEntitySet = DefaultEcs.EntitySet;
using DefaultWorld = DefaultEcs.World;
using EntitasEntity = Entitas.Entity;
using EntitiasWorld = Entitas.IContext<Entitas.Entity>;

namespace DefaultEcs.Benchmark.Performance
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 10, targetCount: 10, invocationCount: 10)]
    public class DoubleComponentEntityEnumeration
    {
        private const float Time = 1f / 60f;

        private struct DefaultSpeed
        {
            public float X;
            public float Y;
        }

        private struct DefaultPosition
        {
            public float X;
            public float Y;
        }

        private sealed class DefaultEcsSystem : AEntitySystem<float>
        {
            public DefaultEcsSystem(DefaultWorld world, SystemRunner<float> runner)
                : base(world.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().Build(), runner)
            { }

            public DefaultEcsSystem(DefaultWorld world)
                : this(world, null)
            { }

            protected override void Update(float state, ReadOnlySpan<DefaultEntity> entities)
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    DefaultEntity entity = entities[i];
                    DefaultSpeed speed = entity.Get<DefaultSpeed>();
                    ref DefaultPosition position = ref entity.Get<DefaultPosition>();

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        private class EntitasSpeed : IComponent
        {
            public float X;
            public float Y;
        }

        private class EntitasPosition : IComponent
        {
            public float X;
            public float Y;
        }

        public class EntitasSystem : JobSystem<EntitasEntity>
        {
            public EntitasSystem(EntitiasWorld world, int threadCount) : base(world.GetGroup(Matcher<EntitasEntity>.AllOf(0, 1)), threadCount)
            { }

            public EntitasSystem(EntitiasWorld world) : this(world, 1)
            { }

            protected override void Execute(EntitasEntity entity)
            {
                EntitasSpeed speed = (EntitasSpeed)entity.GetComponent(0);
                EntitasPosition position = (EntitasPosition)entity.GetComponent(1);
                position.X += speed.X * Time;
                position.Y += speed.Y * Time;
            }
        }

        private DefaultWorld _defaultWorld;
        private DefaultEntitySet _defaultEntitySet;
        private DefaultEcsSystem _defaultSystem;
        private SystemRunner<float> _defaultRunner;
        private DefaultEcsSystem _defaultMultiSystem;

        private EntitiasWorld _entitasWorld;
        private EntitasSystem _entitasSystem;
        private EntitasSystem _entitasMultiSystem;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultWorld = new DefaultWorld(EntityCount);
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().Build();
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultRunner = new SystemRunner<float>(Environment.ProcessorCount);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);

            _entitasWorld = new Context<EntitasEntity>(2, () => new EntitasEntity());
            _entitasSystem = new EntitasSystem(_entitasWorld);
            _entitasMultiSystem = new EntitasSystem(_entitasWorld, Environment.ProcessorCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                DefaultEntity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultPosition>();
                defaultEntity.Set(new DefaultSpeed { X = 42, Y = 42 });

                EntitasEntity entitasEntity = _entitasWorld.CreateEntity();
                entitasEntity.AddComponent(0, new EntitasSpeed { X = 42, Y = 42 });
                entitasEntity.AddComponent(1, new EntitasPosition());
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
                DefaultEntity entity = entities[i];
                DefaultSpeed speed = entity.Get<DefaultSpeed>();
                ref DefaultPosition position = ref entity.Get<DefaultPosition>();

                position.X += speed.X * Time;
                position.Y += speed.Y * Time;
            }
        }

        [Benchmark]
        public void DefaultEcs_System()
        {
            _defaultSystem.Update(Time);
        }

        [Benchmark]
        public void DefaultEcs_MultiSystem()
        {
            _defaultMultiSystem.Update(Time);
        }

        [Benchmark]
        public void Entitas_System()
        {
            _entitasSystem.Execute();
        }

        [Benchmark]
        public void Entitas_MultiSystem()
        {
            _entitasMultiSystem.Execute();
        }
    }
}
