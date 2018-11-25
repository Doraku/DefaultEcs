using System;
using DefaultEcs.System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AEntitySystemTest
    {
        [With(typeof(bool))]
        [Without(typeof(int))]
        private sealed class System : AEntitySystem<int>
        {
            public System(EntitySet set)
                : base(set)
            { }

            public System(World world)
                : base(world)
            { }

            public System(EntitySet set, SystemRunner<int> runner)
                : base(set, runner)
            { }

            public System(World world, SystemRunner<int> runner)
                : base(world, runner)
            { }

            protected override void Update(int state, in Entity entity)
            {
                entity.Get<bool>() = true;
            }
        }

        #region Tests

        [Fact]
        public void New_Should_throw_ArgumentNullException_When_EntitySet_is_null()
        {
            Check.ThatCode(() => new System(default(EntitySet))).Throws<ArgumentNullException>();

            Check.ThatCode(() => new System(default(World))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Update_Should_call_update()
        {
            using (World world = new World(3))
            {
                Entity entity1 = world.CreateEntity();
                entity1.Set<bool>();

                Entity entity2 = world.CreateEntity();
                entity2.Set<bool>();

                Entity entity3 = world.CreateEntity();
                entity3.Set<bool>();

                using (ISystem<int> system = new System(world.GetEntities().With<bool>().Build()))
                {
                    system.Update(0);
                }

                Check.That(entity1.Get<bool>()).IsTrue();
                Check.That(entity2.Get<bool>()).IsTrue();
                Check.That(entity3.Get<bool>()).IsTrue();

                entity1.Set<bool>();
                entity2.Set<bool>();
                entity3.Set<bool>();
                entity3.Set<int>();

                using (ISystem<int> system = new System(world))
                {
                    system.Update(0);
                }

                Check.That(entity1.Get<bool>()).IsTrue();
                Check.That(entity2.Get<bool>()).IsTrue();
                Check.That(entity3.Get<bool>()).IsFalse();

            }
        }

        [Fact]
        public void Update_with_runner_Should_call_update()
        {
            using (SystemRunner<int> runner = new SystemRunner<int>(2))
            using (World world = new World(3))
            {
                Entity entity1 = world.CreateEntity();
                entity1.Set<bool>();

                Entity entity2 = world.CreateEntity();
                entity2.Set<bool>();

                Entity entity3 = world.CreateEntity();
                entity3.Set<bool>();

                using (ISystem<int> system = new System(world.GetEntities().With<bool>().Build(), runner))
                {
                    system.Update(0);
                }

                Check.That(entity1.Get<bool>()).IsTrue();
                Check.That(entity2.Get<bool>()).IsTrue();
                Check.That(entity3.Get<bool>()).IsTrue();

                entity1.Set<bool>();
                entity2.Set<bool>();
                entity3.Set<bool>();
                entity3.Set<int>();

                using (ISystem<int> system = new System(world))
                {
                    system.Update(0);
                }

                Check.That(entity1.Get<bool>()).IsTrue();
                Check.That(entity2.Get<bool>()).IsTrue();
                Check.That(entity3.Get<bool>()).IsFalse();
            }
        }

        #endregion
    }
}
