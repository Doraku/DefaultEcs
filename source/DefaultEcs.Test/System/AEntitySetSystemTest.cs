using System;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AEntitySetSystemTest
    {
        [With(typeof(bool))]
        [Without(typeof(int))]
        [WithEither(typeof(double), typeof(uint))]
        private sealed class System : AEntitySetSystem<int>
        {
            public System(EntitySet set, bool useBuffer)
                : base(set, useBuffer)
            { }

            public System(EntitySet set)
                : base(set)
            { }

            public System(World world, Func<object, World, EntitySet> factory)
                : base(world, factory, null, 0)
            { }

            public System(World world, bool useBuffer)
                : base(world, useBuffer)
            { }

            public System(World world)
                : base(world)
            { }

            public System(EntitySet set, IParallelRunner runner)
                : base(set, runner)
            { }

            public System(World world, IParallelRunner runner)
                : base(world, runner)
            { }

            public System(EntitySet set, IParallelRunner runner, int minEntityCountByRunnerIndex)
                : base(set, runner, minEntityCountByRunnerIndex)
            { }

            public System(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
                : base(world, runner, minEntityCountByRunnerIndex)
            { }

            protected override void Update(int state, in Entity entity)
            {
                base.Update(state, entity);

                entity.Get<bool>() = true;
            }
        }

        [Disabled, With(typeof(bool))]
        private sealed class DisabledSystem : AEntitySetSystem<int>
        {
            public DisabledSystem(World world)
                : base(world)
            { }

            protected override void Update(int state, in Entity entity)
            {
                base.Update(state, entity);

                entity.Get<bool>() = true;
            }
        }

        [Component((ComponentFilterType)42, typeof(bool))]
        private sealed class InvalidSystem : AEntitySetSystem<int>
        {
            public InvalidSystem(World world)
                : base(world)
            { }
        }

        #region Tests

        [Fact]
        public void AEntitySetSystem_Should_throw_ArgumentNullException_When_EntitySet_is_null()
        {
            Check.ThatCode(() => new System(default(EntitySet))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void AEntitySetSystem_Should_throw_ArgumentNullException_When_World_is_null()
        {
            Check.ThatCode(() => new System(default(World))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void AEntitySetSystem_Should_throw_ArgumentNullException_When_factory_is_null()
        {
            using World world = new();

            Check.ThatCode(() => new System(world, default(Func<object, World, EntitySet>))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void World_Should_return_parent_world()
        {
            using World world = new World(4);

            using System system = new System(world);

            Check.That(system.World).IsEqualTo(world);
        }

        [Fact]
        public void Update_Should_call_update()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world.GetEntities().With<bool>().AsSet()))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();

            entity1.Set<bool>();
            entity1.Set<double>();
            entity2.Set<bool>();
            entity2.Set<uint>();
            entity3.Set<bool>();
            entity3.Set<int>();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsFalse();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_Should_call_update_When_using_DisabledAttribute()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (ISystem<int> system = new DisabledSystem(world))
            {
                system.Update(0);

                Check.That(entity1.Get<bool>()).IsFalse();
                Check.That(entity2.Get<bool>()).IsFalse();
                Check.That(entity3.Get<bool>()).IsFalse();
                Check.That(entity4.Get<bool>()).IsFalse();

                entity1.Disable();
                entity2.Disable();

                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsFalse();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_Should_not_call_update_When_disabled()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world.GetEntities().With<bool>().AsSet())
            {
                IsEnabled = false
            })
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsFalse();
            Check.That(entity2.Get<bool>()).IsFalse();
            Check.That(entity3.Get<bool>()).IsFalse();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_with_runner_Should_call_update()
        {
            using DefaultParallelRunner runner = new DefaultParallelRunner(2);
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world.GetEntities().With<bool>().AsSet(), runner))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();

            entity1.Set<bool>();
            entity1.Set<double>();
            entity2.Set<bool>();
            entity2.Set<uint>();
            entity3.Set<bool>();
            entity3.Set<int>();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsFalse();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_Should_not_use_runner_When_minEntityCountByRunnerIndex_not_respected()
        {
            IParallelRunner runner = Substitute.For<IParallelRunner>();
            runner.DegreeOfParallelism.Returns(4);
            runner.When(m => m.Run(Arg.Any<IParallelRunnable>())).Throw<Exception>();

            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world.GetEntities().With<bool>().AsSet(), runner, 10))
            {
                Check.ThatCode(() => system.Update(0)).DoesNotThrow();
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();

            entity1.Set<bool>();
            entity1.Set<double>();
            entity2.Set<bool>();
            entity2.Set<double>();
            entity3.Set<bool>();
            entity3.Set<double>();
            entity4.Set<bool>();
            entity4.Set<double>();

            using (ISystem<int> system = new System(world, runner, 10))
            {
                Check.ThatCode(() => system.Update(0)).DoesNotThrow();
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Should_throw_When_invalid_component_filter_type()
        {
            using World world = new World(4);

            Check.ThatCode(() => new InvalidSystem(world)).Throws<ArgumentException>();
        }

        [Fact]
        public void Update_Should_call_update_When_using_buffer()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (EntitySet set = world.GetEntities().With<bool>().Without<int>().AsSet())
            using (ISystem<int> system = new System(set, true))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_not_call_update_When_disabled_and_using_buffer()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();

            using (ISystem<int> system = new System(world, true)
            {
                IsEnabled = false
            })
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsFalse();
            Check.That(entity2.Get<bool>()).IsFalse();
            Check.That(entity3.Get<bool>()).IsFalse();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        #endregion
    }
}
