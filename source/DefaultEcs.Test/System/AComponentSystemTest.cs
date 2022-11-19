using System;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AComponentSystemTest
    {
        private sealed class System : AComponentSystem<int, bool>
        {
            public System(World world)
                : base(world)
            { }

            public System(World world, IParallelRunner runner)
                : base(world, runner)
            { }

            public System(World world, IParallelRunner runner, int minComponentCountByRunnerIndex)
                : base(world, runner, minComponentCountByRunnerIndex)
            { }

            protected override void Update(int state, ref bool component)
            {
                base.Update(state, ref component);

                component = true;
            }
        }

        #region Tests

        [Fact]
        public void AComponentSystem_Should_throw_ArgumentNullException_When_world_is_null() => Check
            .ThatCode(() => new System(null))
            .Throws<ArgumentNullException>()
            .WithProperty(e => e.ParamName, "world");

        [Fact]
        public void World_Should_return_parent_world()
        {
            using World world = new(4);

            using System system = new(world);

            Check.That(system.World).IsEqualTo(world);
        }

        [Fact]
        public void Update_Should_call_update()
        {
            using World world = new(3);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            using (ISystem<int> system = new System(world))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_not_call_update_When_disabled()
        {
            using World world = new(3);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            using (ISystem<int> system = new System(world))
            {
                system.IsEnabled = false;
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsFalse();
            Check.That(entity2.Get<bool>()).IsFalse();
            Check.That(entity3.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_with_runner_Should_call_update()
        {
            using DefaultParallelRunner runner = new(2);
            using World world = new(3);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            using (ISystem<int> system = new System(world, runner))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_not_use_runner_When_minComponentCountByRunnerIndex_not_respected()
        {
            IParallelRunner runner = Substitute.For<IParallelRunner>();
            runner.DegreeOfParallelism.Returns(4);
            runner.When(m => m.Run(Arg.Any<IParallelRunnable>())).Throw<Exception>();
            using World world = new(3);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();

            using (ISystem<int> system = new System(world, runner, 10))
            {
                Check.ThatCode(() => system.Update(0)).DoesNotThrow();
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
        }

        #endregion
    }
}
