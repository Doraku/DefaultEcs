﻿using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs.EntityActionSystem;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultEcs.Benchmark.Performance
{
    [MemoryDiagnoser]
    public partial class TripleComponentEntityEnumeration
    {
        private const float Time = 1f / 60f;

        private struct DefaultA
        {
            public float Value;
        }

        private struct DefaultB
        {
            public float Value;
        }

        private struct DefaultX
        {
            public float Value;
        }

        private sealed class DefaultEcsSystem : AEntitySetSystem<float>
        {
            public DefaultEcsSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultA>().With<DefaultB>().With<DefaultX>().AsSet(), runner)
            { }

            public DefaultEcsSystem(World world)
                : this(world, null)
            { }

            protected unsafe override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                foreach (ref readonly Entity entity in entities)
                {
                    entity.Get<DefaultX>().Value += (entity.Get<DefaultA>().Value + entity.Get<DefaultB>().Value) * state;
                }
            }
        }

        private sealed class DefaultEcsComponentSystem : AEntitySetSystem<float>
        {
            private readonly World _world;

            public DefaultEcsComponentSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultA>().With<DefaultB>().With<DefaultX>().AsSet(), runner)
            {
                _world = world;
            }

            protected unsafe override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                Components<DefaultA> @as = _world.GetComponents<DefaultA>();
                Components<DefaultB> bs = _world.GetComponents<DefaultB>();
                Components<DefaultX> xs = _world.GetComponents<DefaultX>();

                foreach (ref readonly Entity entity in entities)
                {
                    xs[entity].Value += (@as[entity].Value + bs[entity].Value) * state;
                }
            }
        }

        private sealed partial class DefaultEcsGeneratorSystem : AEntitySetSystem<float>
        {
            [Update]
            private static void Update(float state, in DefaultA a, in DefaultB b, ref DefaultX x)
            {
                x.Value += (a.Value + b.Value) * state;
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
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultA>().With<DefaultX>().AsSet();
            _defaultRunner = new DefaultParallelRunner(Environment.ProcessorCount);
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);
            _defaultComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, null);
            _defaultMultiComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, _defaultRunner);
            _defaultGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, null);
            _defaultMultiGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, _defaultRunner);
            _defaultEntityActionSystem = _defaultWorld.GetEntities().AsSystem((float state, Entity entity)
                => entity.Get<DefaultX>().Value += (entity.Get<DefaultA>().Value + entity.Get<DefaultB>().Value) * state);
            _defaultComponentActionSystem = _defaultWorld.GetEntities().AsSystem(
                (float state, ref DefaultA a, ref DefaultB b, ref DefaultX x) => x.Value += (a.Value + b.Value) * state);

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultX>();
                defaultEntity.Set(new DefaultA { Value = 42 });
                defaultEntity.Set(new DefaultB { Value = 42 });
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
                entity.Get<DefaultX>().Value += (entity.Get<DefaultA>().Value + entity.Get<DefaultB>().Value) * Time;
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
