﻿using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    internal static class EntitySetExtension
    {
        public delegate void EntitySetProcess(ReadOnlySpan<Entity> entities);

        public static void ProcessInParallel(this EntitySet set, EntitySetProcess action)
        {
            int entitiesPerCpu = set.Count / Environment.ProcessorCount;

            Enumerable.Range(0, Environment.ProcessorCount).AsParallel().ForAll(
                i => action(i + 1 == Environment.ProcessorCount ? set.GetEntities()[(i * entitiesPerCpu)..] : set.GetEntities().Slice(i * entitiesPerCpu, entitiesPerCpu)));
        }
    }

    [MemoryDiagnoser]
    public sealed partial class System : IDisposable
    {
        private struct Position
        {
            public float X;
            public float Y;
        }

        private struct Speed
        {
            public float X;
            public float Y;
        }

        private sealed class TestSystem : AEntitySetSystem<float>
        {
            public TestSystem(World world, IParallelRunner runner)
                : base(world.GetEntities().With<Position>().With<Speed>().AsSet(), runner)
            { }

            protected override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                foreach (ref readonly Entity entity in entities)
                {
                    Speed speed = entity.Get<Speed>();
                    ref Position position = ref entity.Get<Position>();

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        [With(typeof(Speed), typeof(Position))]
        private sealed class TestComponentSystem : AEntitySetSystem<float>
        {
            private readonly World _world;

            public TestComponentSystem(World world, IParallelRunner runner)
                : base(world, runner)
            {
                _world = world;
            }

            protected override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                Components<Speed> speeds = _world.GetComponents<Speed>();
                Components<Position> positions = _world.GetComponents<Position>();

                foreach (ref readonly Entity entity in entities)
                {
                    Speed speed = speeds[entity];
                    ref Position position = ref positions[entity];

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        [With(typeof(Speed), typeof(Position))]
        private sealed class TestBufferedSystem : AEntitySetSystem<float>
        {
            public TestBufferedSystem(World world)
                : base(world, true)
            { }

            protected override void Update(float state, ReadOnlySpan<Entity> entities)
            {
                foreach (ref readonly Entity entity in entities)
                {
                    Speed speed = entity.Get<Speed>();
                    ref Position position = ref entity.Get<Position>();

                    position.X += speed.X * state;
                    position.Y += speed.Y * state;
                }
            }
        }

        private sealed class TestSystemTPL : ISystem<float>
        {
            private readonly EntitySet _set;

            public TestSystemTPL(World world)
            {
                _set = world.GetEntities().With<Position>().With<Speed>().AsSet();
            }

            public bool IsEnabled { get; set; } = true;

            public void Update(float state)
            {
                _set.ProcessInParallel(entities =>
                {
                    foreach (ref readonly Entity entity in entities)
                    {
                        Speed speed = entity.Get<Speed>();
                        ref Position position = ref entity.Get<Position>();

                        position.X += speed.X * state;
                        position.Y += speed.Y * state;
                    }
                });
            }

            public void Dispose()
            {
                _set.Dispose();
            }
        }

        private sealed partial class GeneratorSystem : AEntitySetSystem<float>
        {
            [Update]
            private static void Update(float state, Speed speed, ref Position position)
            {
                position.X += speed.X * state;
                position.Y += speed.Y * state;
            }
        }

        private World _world;
        private DefaultParallelRunner _runner;
        private ISystem<float> _systemSingle;
        private ISystem<float> _system;
        private ISystem<float> _componentSystem;
        private ISystem<float> _bufferedSystem;
        private ISystem<float> _systemTPL;
        private ISystem<float> _generatorSystem;
        private IEnumerable<Entity> _enumerable;

        [Params(100, 1000, 10000, 100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World(EntityCount);
            _runner = new DefaultParallelRunner(Environment.ProcessorCount);
            _systemSingle = new TestSystem(_world, null);
            _system = new TestSystem(_world, _runner);
            _componentSystem = new TestComponentSystem(_world, _runner);
            _bufferedSystem = new TestBufferedSystem(_world);
            _systemTPL = new TestSystemTPL(_world);
            _generatorSystem = new GeneratorSystem(_world, _runner);
            _enumerable = _world.GetEntities().With<Position>().With<Speed>().AsEnumerable();

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _world.CreateEntity();
                entity.Set<Position>();
                entity.Set(new Speed { X = 1, Y = 1 });
            }
        }

        [IterationCleanup]
        public void Dispose()
        {
            _runner.Dispose();
            _world.Dispose();
            _systemSingle.Dispose();
            _system.Dispose();
            _componentSystem.Dispose();
            _bufferedSystem.Dispose();
            _generatorSystem.Dispose();
            _systemTPL.Dispose();
        }

        [Benchmark]
        public void DefaultEcs_UpdateSingle() => _systemSingle.Update(1f / 60f);

        [Benchmark]
        public void DefaultEcs_UpdateMulti() => _system.Update(1f / 60f);

        [Benchmark]
        public void DefaultEcs_UpdateMultiComponent() => _componentSystem.Update(1f / 60f);

        [Benchmark]
        public void DefaultEcs_UpdateBuffered() => _bufferedSystem.Update(1f / 60f);

        [Benchmark]
        public void DefaultEcs_UpdateTPL() => _systemTPL.Update(1f / 60f);

        [Benchmark]
        public void DefaultEcs_UpdateMultiGenerator() => _generatorSystem.Update(1f / 60f);

        [Benchmark]
        public void DefaultEcs_UpdateEnumerable()
        {
            const float state = 1f / 60f;

            foreach (Entity entity in _enumerable)
            {
                Speed speed = entity.Get<Speed>();
                ref Position position = ref entity.Get<Position>();

                position.X += speed.X * state;
                position.Y += speed.Y * state;
            }
        }
    }
}
