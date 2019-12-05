using System;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
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

            public System(World world, IRunner runner)
                : base(world, runner)
            { }

            protected override void Update(int state, ref bool component)
            {
                base.Update(state, ref component);

                component = true;
            }
        }

        #region Tests

        [Fact]
        public void AComponentSystem_Should_throw_ArgumentNullException_When_world_is_null()
        {
            Check.ThatCode(() => new System(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Update_Should_call_update()
        {
            using World world = new World(3);

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
            using World world = new World(3);

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
            using DefaultRunner runner = new DefaultRunner(2);
            using World world = new World(3);

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

        #endregion
    }
}
