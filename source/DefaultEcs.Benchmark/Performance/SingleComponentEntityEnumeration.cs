using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs.Internal;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultEcs.Benchmark.Performance
{
    [MemoryDiagnoser]
    public partial class SingleComponentEntityEnumeration
    {
        private struct DefaultComponent
        {
            public int Value;
        }

        private sealed class DefaultEcsSystem : AEntitySetSystem<int>
        {
            public DefaultEcsSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultComponent>().AsSet(), runner)
            { }

            public DefaultEcsSystem(World world)
                : this(world, null)
            { }

            protected override void Update(int state, ReadOnlySpan<Entity> entities)
            {
                foreach (ref readonly Entity entity in entities)
                {
                    ++entity.Get<DefaultComponent>().Value;
                }
            }
        }

        private sealed class DefaultEcsEntityComponentSystem : AEntitySetSystem<int>
        {
            private readonly World _world;

            public DefaultEcsEntityComponentSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultComponent>().AsSet(), runner)
            {
                _world = world;
            }

            public DefaultEcsEntityComponentSystem(World world)
                : this(world, null)
            { }

            protected override void Update(int state, ReadOnlySpan<Entity> entities)
            {
                Components<DefaultComponent> components = _world.GetComponents<DefaultComponent>();

                foreach (ref readonly Entity entity in entities)
                {
                    ++components[entity].Value;
                }
            }
        }

        private sealed class DefaultEcsComponentSystem : AComponentSystem<int, DefaultComponent>
        {
            public DefaultEcsComponentSystem(World world, IParallelRunner runner)
                : base(world, runner)
            { }

            public DefaultEcsComponentSystem(World world)
                : this(world, null)
            { }

            protected override void Update(int state, Span<DefaultComponent> components)
            {
                foreach (ref DefaultComponent component in components)
                {
                    ++component.Value;
                }
            }
        }

        private sealed partial class DefaultEcsGeneratorSystem : AEntitySetSystem<int>
        {
            [Update]
            private static void Update(ref DefaultComponent component)
            {
                ++component.Value;
            }
        }

        private World _defaultWorld;
        private DefaultParallelRunner _defaultRunner;
        private EntitySet _defaultEntitySet;
        private Archetype _archetype;
        private DefaultComponent[] _components;
        private DefaultEcsSystem _defaultSystem;
        private DefaultEcsSystem _defaultMultiSystem;
        private DefaultEcsEntityComponentSystem _defaultEntityComponentSystem;
        private DefaultEcsEntityComponentSystem _defaultMultiEntityComponentSystem;
        private DefaultEcsComponentSystem _defaultComponentSystem;
        private DefaultEcsComponentSystem _defaultComponentMultiSystem;
        private DefaultEcsGeneratorSystem _defaultGeneratorSystem;
        private DefaultEcsGeneratorSystem _defaultGeneratorMultiSystem;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultWorld = new World(EntityCount);
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultComponent>().AsSet();
            _defaultRunner = new DefaultParallelRunner(Environment.ProcessorCount);
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);
            _defaultEntityComponentSystem = new DefaultEcsEntityComponentSystem(_defaultWorld);
            _defaultMultiEntityComponentSystem = new DefaultEcsEntityComponentSystem(_defaultWorld, _defaultRunner);
            _defaultComponentSystem = new DefaultEcsComponentSystem(_defaultWorld);
            _defaultComponentMultiSystem = new DefaultEcsComponentSystem(_defaultWorld, _defaultRunner);
            _defaultGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld);
            _defaultGeneratorMultiSystem = new DefaultEcsGeneratorSystem(_defaultWorld, _defaultRunner);

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultComponent>();
            }

            _archetype = _defaultWorld.GetArchetype<DefaultComponent>();
            _components = _archetype.GetArray<DefaultComponent>();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _defaultRunner.Dispose();
            _defaultWorld.Dispose();
        }

        //[Benchmark]
        //public void DefaultEcs_EntitySet()
        //{
        //    foreach (ref readonly Entity entity in _defaultEntitySet.GetEntities())
        //    {
        //        ++entity.Get<DefaultComponent>().Value;
        //    }
        //}

        [Benchmark]
        public void DefaultEcs_Archetype()
        {
            foreach (ref DefaultComponent component in _archetype.GetPool<DefaultComponent>().Span)
            {
                ++component.Value;
            }
        }

        [Benchmark]
        public void DefaultEcs_System() => _defaultSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_MultiSystem() => _defaultMultiSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_EntityComponentSystem() => _defaultEntityComponentSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_MultiEntityComponentSystem() => _defaultMultiEntityComponentSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_Component()
        //{
        //    foreach (ref DefaultComponent component in _defaultWorld.GetAll<DefaultComponent>())
        //    {
        //        ++component.Value;
        //    }
        //}

        //[Benchmark]
        //public void DefaultEcs_ComponentSystem() => _defaultComponentSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_ComponentMultiSystem() => _defaultComponentMultiSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_GeneratorSystem() => _defaultGeneratorSystem.Update(42);

        //[Benchmark]
        //public void DefaultEcs_GeneratorMultiSystem() => _defaultGeneratorMultiSystem.Update(42);
    }
}
