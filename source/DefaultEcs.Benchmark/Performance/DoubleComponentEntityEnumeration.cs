using System;
using BenchmarkDotNet.Attributes;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Entitas;
using Leopotam.Ecs;
using Leopotam.Ecs.Threads;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
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

        private sealed class DefaultEcsComponentSystem : AEntitySetSystem<float>
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

        private sealed partial class DefaultEcsGeneratorSystem : AEntitySetSystem<float>
        {
            [Update]
            private static void Update(float state, DefaultSpeed speed, ref DefaultPosition position)
            {
                position.X += speed.X * state;
                position.Y += speed.Y * state;
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

        private class MonoSpeed
        {
            public float X;
            public float Y;
        }

        private class MonoPosition
        {
            public float X;
            public float Y;
        }

        public class MonoSystem : EntityUpdateSystem
        {
            private ComponentMapper<MonoSpeed> _speeds;
            private ComponentMapper<MonoPosition> _positions;

            public MonoSystem()
                : base(Aspect.All(typeof(MonoSpeed), typeof(MonoPosition)))
            { }

            public override void Initialize(IComponentMapperService mapperService)
            {
                _speeds = mapperService.GetMapper<MonoSpeed>();
                _positions = mapperService.GetMapper<MonoPosition>();
            }

            public override void Update(GameTime gameTime)
            {
                foreach (int entityId in ActiveEntities)
                {
                    MonoSpeed speed = _speeds.Get(entityId);
                    MonoPosition position = _positions.Get(entityId);
                    position.X += speed.X * Time;
                    position.Y += speed.Y * Time;
                }
            }
        }
        private struct LeoSpeed
        {
            public float X;
            public float Y;
        }

        private struct LeoPosition
        {
            public float X;
            public float Y;
        }

        private sealed class LeoSystem : IEcsRunSystem
        {
            private readonly EcsFilter<LeoSpeed, LeoPosition> _filter = null;

            public void Run()
            {
                for (int i = 0, iMax = _filter.GetEntitiesCount(); i < iMax; i++)
                {
                    LeoSpeed speed = _filter.Get1(i);
                    ref LeoPosition position = ref _filter.Get2(i);

                    position.X += speed.X * Time;
                    position.Y += speed.Y * Time;
                }
            }
        }

        private sealed class LeoMultiSystem : EcsMultiThreadSystem<EcsFilter<LeoSpeed, LeoPosition>>
        {
            private readonly EcsFilter<LeoSpeed, LeoPosition> _filter = null;

            protected override EcsFilter<LeoSpeed, LeoPosition> GetFilter() => _filter;

            protected override int GetMinJobSize() => 0;

            protected override int GetThreadsCount() => Environment.ProcessorCount - 1;

            protected override EcsMultiThreadWorker GetWorker() => Worker;

            private static void Worker(EcsMultiThreadWorkerDesc workerDesc)
            {
                foreach (var i in workerDesc)
                {
                    LeoSpeed speed = workerDesc.Filter.Get1(i);
                    ref LeoPosition position = ref workerDesc.Filter.Get2(i);

                    position.X += speed.X * Time;
                    position.Y += speed.Y * Time;
                }
            }
        }

        private struct SveltoSpeed : IEntityComponent
        {
            public float X;
            public float Y;
        }

        private struct SveltoPosition : IEntityComponent
        {
            public float X;
            public float Y;
        }

        private sealed class SveltoEntity : GenericEntityDescriptor<SveltoSpeed, SveltoPosition>
        { }

        private sealed class SveltoSystem : IQueryingEntitiesEngine
        {
            public EntitiesDB entitiesDB { get; set; }

            public void Ready()
            { }

            public void Update()
            {
                var (speeds, positions, count) = entitiesDB.QueryEntities<SveltoSpeed, SveltoPosition>(_sveltoGroup);

                for (var i = 0; i < count; i++)
                {
                    SveltoSpeed speed = speeds[i];
                    ref SveltoPosition position = ref positions[i];

                    position.X += speed.X * Time;
                    position.Y += speed.Y * Time;
                }
            }
        }

        private static readonly ExclusiveGroup _sveltoGroup = new ExclusiveGroup();

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
        private IEcsRunSystem _leoMultiSystem;

        private EnginesRoot _sveltoWorld;
        private SveltoSystem _sveltoSystem;

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
            _defaultGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, null);
            _defaultMultiGeneratorSystem = new DefaultEcsGeneratorSystem(_defaultWorld, _defaultRunner);

            _entitasWorld = new Context<EntitasEntity>(2, () => new EntitasEntity());
            _entitasSystem = new EntitasSystem(_entitasWorld);
            _entitasMultiSystem = new EntitasSystem(_entitasWorld, Environment.ProcessorCount);

            _monoWorld = new WorldBuilder().AddSystem(new MonoSystem()).Build();
            _time = new GameTime();

            _leoWorld = new LeoWorld();
            _leoSystem = new LeoSystem();
            _leoMultiSystem = new LeoMultiSystem();
            _leoSystems = new LeoSystems(_leoWorld).Add(_leoSystem).Add(_leoMultiSystem);
            _leoSystems.ProcessInjects().Init();

            SimpleEntitiesSubmissionScheduler sveltoScheduler = new SimpleEntitiesSubmissionScheduler();
            _sveltoWorld = new EnginesRoot(sveltoScheduler);
            _sveltoSystem = new SveltoSystem();
            _sveltoWorld.AddEngine(_sveltoSystem);
            IEntityFactory sveltoFactory = _sveltoWorld.GenerateEntityFactory();

            for (int i = 0; i < EntityCount; ++i)
            {
                DefaultEntity defaultEntity = _defaultWorld.CreateEntity();
                defaultEntity.Set<DefaultPosition>();
                defaultEntity.Set(new DefaultSpeed { X = 42, Y = 42 });

                EntitasEntity entitasEntity = _entitasWorld.CreateEntity();
                entitasEntity.AddComponent(0, new EntitasSpeed { X = 42, Y = 42 });
                entitasEntity.AddComponent(1, new EntitasPosition());

                MonoEntity monoEntity = _monoWorld.CreateEntity();
                monoEntity.Attach(new MonoSpeed { X = 42, Y = 42 });
                monoEntity.Attach(new MonoPosition());

                LeoEntity leoEntity = _leoWorld
                    .NewEntity()
                    .Replace(new LeoSpeed { X = 42, Y = 42 })
                    .Replace(new LeoPosition());

                sveltoFactory.BuildEntity<SveltoEntity>((uint)i, _sveltoGroup).GetOrCreate<SveltoSpeed>() = new SveltoSpeed { X = 42, Y = 42 };
            }

            sveltoScheduler.SubmitEntities();
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

        [Benchmark]
        public void Leo_MultiSystem() => _leoMultiSystem.Run();

        [Benchmark]
        public void Svelto_System() => _sveltoSystem.Update();
    }
}
