using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs.System;
using DefaultEcs.Technical;
using DefaultEcs.Threading;
using Entitas;
using DefaultEntity = DefaultEcs.Entity;
using DefaultEntitySet = DefaultEcs.EntitySet;
using DefaultWorld = DefaultEcs.World;
using EntitasEntity = Entitas.Entity;
using EntitiasWorld = Entitas.IContext<Entitas.Entity>;

namespace DefaultEcs.Benchmark.Performance
{
    [MemoryDiagnoser]
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
            public DefaultEcsSystem(DefaultWorld world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().AsSet(), runner)
            { }

            public DefaultEcsSystem(DefaultWorld world)
                : this(world, null)
            { }

            protected unsafe override void Update(float state, ReadOnlySpan<DefaultEntity> entities)
            {
                foreach (ref readonly DefaultEntity entity in entities)
                {
                    DefaultSpeed speed = entity.Get<DefaultSpeed>();
                    ref DefaultPosition position = ref entity.Get<DefaultPosition>();

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        private sealed class DefaultEcsComponentSystem : AEntitySystem<float>
        {
            private readonly DefaultWorld _world;

            public DefaultEcsComponentSystem(DefaultWorld world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().AsSet(), runner)
            {
                _world = world;
            }

            protected unsafe override void Update(float state, ReadOnlySpan<DefaultEntity> entities)
            {
                Components<DefaultSpeed> speeds = _world.GetComponents<DefaultSpeed>();
                Components<DefaultPosition> positions = _world.GetComponents<DefaultPosition>();

                foreach (ref readonly DefaultEntity entity in entities)
                {
                    DefaultSpeed speed = speeds[entity];
                    ref DefaultPosition position = ref positions[entity];

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
        private DefaultParallelRunner _defaultRunner;
        private DefaultEcsSystem _defaultSystem;
        private DefaultEcsSystem _defaultMultiSystem;
        private DefaultEcsComponentSystem _defaultComponentSystem;
        private DefaultEcsComponentSystem _defaultMultiComponentSystem;

        private EntitiasWorld _entitasWorld;
        private EntitasSystem _entitasSystem;
        private EntitasSystem _entitasMultiSystem;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultWorld = new DefaultWorld(EntityCount);
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().AsSet();
            _defaultRunner = new DefaultParallelRunner(Environment.ProcessorCount);
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);
            _defaultComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, null);
            _defaultMultiComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, _defaultRunner);

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
            foreach (ref readonly DefaultEntity entity in _defaultEntitySet.GetEntities())
            {
                DefaultSpeed speed = entity.Get<DefaultSpeed>();
                ref DefaultPosition position = ref entity.Get<DefaultPosition>();

                position.X += speed.X * Time;
                position.Y += speed.Y * Time;
            }
        }

        [Benchmark]
        public void DefaultEcs_System() => _defaultSystem.Update(Time);

        [Benchmark]
        public void DefaultEcs_MultiSystem() => _defaultMultiSystem.Update(Time);

        [Benchmark]
        public void DefaultEcs_ComponentSystem() => _defaultComponentSystem.Update(Time);

        [Benchmark]
        public void DefaultEcs_ComponentMultiSystem() => _defaultMultiComponentSystem.Update(Time);

        [Benchmark]
        public void Entitas_System() => _entitasSystem.Execute();

        [Benchmark]
        public void Entitas_MultiSystem() => _entitasMultiSystem.Execute();
    }
}
