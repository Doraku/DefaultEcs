using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs.EntityActionSystem;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultEcs.Benchmark.Performance
{
    [MemoryDiagnoser]
    public partial class DoubleComponentEntityEnumeration
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

        private sealed class DefaultEcsSystem : AEntitySetSystem<float>
        {
            public DefaultEcsSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().AsSet(), runner)
            { }

            public DefaultEcsSystem(World world)
                : this(world, null)
            { }

            protected unsafe override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                foreach (ref readonly Entity entity in entities)
                {
                    DefaultSpeed speed = entity.Get<DefaultSpeed>();
                    ref DefaultPosition position = ref entity.Get<DefaultPosition>();

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        private sealed class DefaultEcsComponentSystem : AEntitySetSystem<float>
        {
            private readonly World _world;

            public DefaultEcsComponentSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().AsSet(), runner)
            {
                _world = world;
            }

            protected unsafe override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                Components<DefaultSpeed> speeds = _world.GetComponents<DefaultSpeed>();
                Components<DefaultPosition> positions = _world.GetComponents<DefaultPosition>();

                foreach (ref readonly Entity entity in entities)
                {
                    DefaultSpeed speed = speeds[entity];
                    ref DefaultPosition position = ref positions[entity];

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        private sealed partial class DefaultEcsGeneratorSystem : AEntitySetSystem<float>
        {
            [Update]
            private static void Update(float state, DefaultSpeed speed, ref DefaultPosition position)
            {
                position.X += speed.X * state;
                position.Y += speed.Y * state;
            }
        }

        private World _defaultWorld;
        private EntitySet _defaultEntitySet;
        private DefaultParallelRunner _defaultRunner;
        private DefaultEcsSystem _defaultSystem;
        private DefaultEcsSystem _defaultMultiSystem;
        private DefaultEcsComponentSystem _defaultComponentSystem;
        private DefaultEcsComponentSystem _defaultMultiComponentSystem;
        private DefaultEcsGeneratorSystem _defaultGeneratorSystem;
        private DefaultEcsGeneratorSystem _defaultMultiGeneratorSystem;
        private ISystem<float> _defaultEntityActionSystem;
        private ISystem<float> _defaultComponentActionSystem;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultWorld = new World(EntityCount);
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultSpeed>().With<DefaultPosition>().AsSet();
            _defaultRunner = new DefaultParallelRunner(Environment.ProcessorCount);
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);
            _defaultComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, null);
            _defaultMultiComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, _defaultRunner);
            _defaultGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, null);
            _defaultMultiGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, _defaultRunner);
            _defaultEntityActionSystem = _defaultWorld.GetEntities().AsSystem((float state, Entity entity) =>
            {
                DefaultSpeed speed = entity.Get<DefaultSpeed>();
                ref DefaultPosition position = ref entity.Get<DefaultPosition>();

                position.X += speed.X * state;
                position.Y += speed.Y * state;
            });
            _defaultComponentActionSystem = _defaultWorld.GetEntities().AsSystem(
                (float state, ref DefaultSpeed speed, ref DefaultPosition position) =>
                {
                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                });

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultPosition>();
                defaultEntity.Set(new DefaultSpeed { X = 42, Y = 42 });
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
            foreach (ref readonly Entity entity in _defaultEntitySet.GetEntities())
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
        public void DefaultEcs_GeneratorSystem() => _defaultGeneratorSystem.Update(Time);

        [Benchmark]
        public void DefaultEcs_GeneratorMultiSystem() => _defaultMultiGeneratorSystem.Update(Time);

        [Benchmark]
        public void DefaultEcs_EntityActionSystem() => _defaultEntityActionSystem.Update(Time);

        [Benchmark]
        public void DefaultEcs_ComponentActionSystem() => _defaultComponentActionSystem.Update(Time);
    }
}
