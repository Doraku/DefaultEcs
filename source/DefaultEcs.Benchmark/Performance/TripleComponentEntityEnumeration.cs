using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Entitas;
using Leopotam.Ecs;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using DefaultEntity = DefaultEcs.Entity;
using DefaultEntitySet = DefaultEcs.EntitySet;
using DefaultWorld = DefaultEcs.World;
using EntitasEntity = Entitas.Entity;
using EntitiasWorld = Entitas.IContext<Entitas.Entity>;
using LeoEntity = Leopotam.Ecs.EcsEntity;
using LeoSystems = Leopotam.Ecs.EcsSystems;
using LeoWorld = Leopotam.Ecs.EcsWorld;
using MonoEntity = MonoGame.Extended.Entities.Entity;
using MonoWorld = MonoGame.Extended.Entities.World;

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
            public DefaultEcsSystem(DefaultWorld world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultA>().With<DefaultB>().With<DefaultX>().AsSet(), runner)
            { }

            public DefaultEcsSystem(DefaultWorld world)
                : this(world, null)
            { }

            protected unsafe override void Update(float state, ReadOnlySpan<DefaultEntity> entities)
            {
                foreach (ref readonly DefaultEntity entity in entities)
                {
                    entity.Get<DefaultX>().Value += (entity.Get<DefaultA>().Value + entity.Get<DefaultB>().Value) * state;
                }
            }
        }

        private sealed class DefaultEcsComponentSystem : AEntitySetSystem<float>
        {
            private readonly DefaultWorld _world;

            public DefaultEcsComponentSystem(DefaultWorld world, IParallelRunner runner)
                : base(world.GetEntities().With<DefaultA>().With<DefaultB>().With<DefaultX>().AsSet(), runner)
            {
                _world = world;
            }

            protected unsafe override void Update(float state, ReadOnlySpan<DefaultEntity> entities)
            {
                Components<DefaultA> @as = _world.GetComponents<DefaultA>();
                Components<DefaultB> bs = _world.GetComponents<DefaultB>();
                Components<DefaultX> xs = _world.GetComponents<DefaultX>();

                foreach (ref readonly DefaultEntity entity in entities)
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

        private class EntitasA : IComponent
        {
            public float Value;
        }

        private class EntitasB : IComponent
        {
            public float Value;
        }

        private class EntitasX : IComponent
        {
            public float Value;
        }

        public class EntitasSystem : JobSystem<EntitasEntity>
        {
            public EntitasSystem(EntitiasWorld world, int threadCount) : base(world.GetGroup(Matcher<EntitasEntity>.AllOf(0, 1, 2)), threadCount)
            { }

            public EntitasSystem(EntitiasWorld world) : this(world, 1)
            { }

            protected override void Execute(EntitasEntity entity)
            {
                EntitasA a = (EntitasA)entity.GetComponent(0);
                EntitasB b = (EntitasB)entity.GetComponent(1);
                EntitasX x = (EntitasX)entity.GetComponent(2);
                x.Value += (a.Value + b.Value) * Time;
            }
        }

        private class MonoA
        {
            public float Value;
        }

        private class MonoB
        {
            public float Value;
        }

        private class MonoX
        {
            public float Value;
        }

        public class MonoSystem : EntityUpdateSystem
        {
            private ComponentMapper<MonoA> _as;
            private ComponentMapper<MonoB> _bs;
            private ComponentMapper<MonoX> _xs;

            public MonoSystem()
                : base(Aspect.All(typeof(MonoA), typeof(MonoB), typeof(MonoX)))
            { }

            public override void Initialize(IComponentMapperService mapperService)
            {
                _as = mapperService.GetMapper<MonoA>();
                _bs = mapperService.GetMapper<MonoB>();
                _xs = mapperService.GetMapper<MonoX>();
            }

            public override void Update(GameTime gameTime)
            {
                foreach (int entityId in ActiveEntities)
                {
                    _xs.Get(entityId).Value += (_as.Get(entityId).Value + _bs.Get(entityId).Value) * Time;
                }
            }
        }

        private struct LeoA
        {
            public float Value;
        }

        private struct LeoB
        {
            public float Value;
        }

        private struct LeoX
        {
            public float Value;
        }

        private sealed class LeoSystem : IEcsRunSystem
        {
            private EcsFilter<LeoA, LeoB, LeoX> _filter = null;

            public void Run()
            {
                foreach (var i in _filter)
                {
                    _filter.Get3(i).Value += (_filter.Get1(i).Value + _filter.Get2(i).Value) * Time;
                }
            }
        }

        private DefaultWorld _defaultWorld;
        private DefaultEntitySet _defaultEntitySet;
        private DefaultParallelRunner _defaultRunner;
        private DefaultEcsSystem _defaultSystem;
        private DefaultEcsSystem _defaultMultiSystem;
        private DefaultEcsComponentSystem _defaultComponentSystem;
        private DefaultEcsComponentSystem _defaultMultiComponentSystem;
        private DefaultEcsGeneratorSystem _defaultGeneratorSystem;
        private DefaultEcsGeneratorSystem _defaultMultiGeneratorSystem;

        private EntitiasWorld _entitasWorld;
        private EntitasSystem _entitasSystem;
        private EntitasSystem _entitasMultiSystem;

        private MonoWorld _monoWorld;
        private GameTime _time;

        private LeoWorld _leoWorld;
        private LeoSystems _leoSystems;
        private LeoSystem _leoSystem;

        [Params(100000)]
        public int EntityCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _defaultWorld = new DefaultWorld(EntityCount);
            _defaultEntitySet = _defaultWorld.GetEntities().With<DefaultA>().With<DefaultX>().AsSet();
            _defaultRunner = new DefaultParallelRunner(Environment.ProcessorCount);
            _defaultSystem = new DefaultEcsSystem(_defaultWorld);
            _defaultMultiSystem = new DefaultEcsSystem(_defaultWorld, _defaultRunner);
            _defaultComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, null);
            _defaultMultiComponentSystem = new DefaultEcsComponentSystem(_defaultWorld, _defaultRunner);
            _defaultGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, null);
            _defaultMultiGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, _defaultRunner);

            _entitasWorld = new Context<EntitasEntity>(3, () => new EntitasEntity());
            _entitasSystem = new EntitasSystem(_entitasWorld);
            _entitasMultiSystem = new EntitasSystem(_entitasWorld, Environment.ProcessorCount);

            _monoWorld = new WorldBuilder().AddSystem(new MonoSystem()).Build();
            _time = new GameTime();

            _leoWorld = new LeoWorld();
            _leoSystem = new LeoSystem();
            _leoSystems = new LeoSystems(_leoWorld).Add(_leoSystem);
            _leoSystems.ProcessInjects().Init();

            for (int i = 0; i < EntityCount; ++i)
            {
                DefaultEntity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultX>();
                defaultEntity.Set(new DefaultA { Value = 42 });
                defaultEntity.Set(new DefaultB { Value = 42 });

                EntitasEntity entitasEntity = _entitasWorld.CreateEntity();
                entitasEntity.AddComponent(0, new EntitasA { Value = 42 });
                entitasEntity.AddComponent(1, new EntitasB { Value = 42 });
                entitasEntity.AddComponent(2, new EntitasX());

                MonoEntity monoEntity = _monoWorld.CreateEntity();
                monoEntity.Attach(new MonoA { Value = 42 });
                monoEntity.Attach(new MonoB { Value = 42 });
                monoEntity.Attach(new MonoX());

                LeoEntity leoEntity = _leoWorld.NewEntity();
                leoEntity.Get<LeoA>() = new LeoA { Value = 42 };
                leoEntity.Get<LeoB>() = new LeoB { Value = 42 };
                leoEntity.Get<LeoX>();
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
        public void Entitas_System() => _entitasSystem.Execute();

        [Benchmark]
        public void Entitas_MultiSystem() => _entitasMultiSystem.Execute();

        [Benchmark]
        public void MonoGameExtendedEntities_System() => _monoWorld.Update(_time);

        [Benchmark]
        public void Leo_System() => _leoSystem.Run();
    }
}
