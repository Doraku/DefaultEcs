using System;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AEntitySortedSetSystemTest
    {
        [With(typeof(bool))]
        [WithEither(typeof(double), typeof(uint))]
        private sealed class System : AEntitySortedSetSystem<int, int>
        {
            public System(EntitySortedSet<int> sortedSet, bool useBuffer)
                : base(sortedSet, useBuffer)
            { }

            public System(EntitySortedSet<int> sortedSet)
                : base(sortedSet)
            { }

            public System(World world, Func<object, World, EntitySortedSet<int>> factory)
                : base(world, factory)
            { }

            public System(World world, Func<object, World, EntitySortedSet<int>> factory, bool useBuffer)
                : base(world, factory, useBuffer)
            { }

            public System(World world)
                : base(world)
            { }

            protected override void Update(int state, in Entity entity)
            {
                base.Update(state, entity);

                entity.Get<bool>() = true;
            }
        }

        #region Tests

        [Fact]
        public void AEntitySetSystem_Should_throw_ArgumentNullException_When_EntitySet_is_null()
        {
            Check.ThatCode(() => new System(default(EntitySortedSet<int>))).Throws<ArgumentNullException>();
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

            Check.ThatCode(() => new System(world, default)).Throws<ArgumentNullException>();
            Check.ThatCode(() => new System(world, default, true)).Throws<ArgumentNullException>();
        }

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
            using World world = new(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(0);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(1);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(3);

            using (ISystem<int> system = new System(world.GetEntities().With<bool>().AsSortedSet<int>()))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_call_update_When_using_buffer()
        {
            using World world = new(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(0);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(1);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(3);

            using (EntitySortedSet<int> sortedSet = world.GetEntities().With<bool>().AsSortedSet<int>())
            using (ISystem<int> system = new System(sortedSet, true))
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
            using World world = new(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(0);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(1);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(3);

            using (ISystem<int> system = new System(world, (_, w) => w.GetEntities().With<bool>().AsSortedSet<int>(), true)
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
