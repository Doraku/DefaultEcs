using System;
using DefaultEcs.System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AEntityBufferedSystemTest
    {
        [With(typeof(bool))]
        [Without(typeof(int))]
        private sealed class System : AEntityBufferedSystem<int>
        {
            public System(EntitySet set)
                : base(set)
            { }

            public System(World world)
                : base(world)
            { }

            protected override void Update(int state, in Entity entity)
            {
                base.Update(state, entity);

                entity.Get<bool>() = true;
                entity.Set(42);
            }
        }

        #region Tests

        [Fact]
        public void AEntitySystem_Should_throw_ArgumentNullException_When_EntitySet_is_null()
        {
            Check.ThatCode(() => new System(default(EntitySet))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void AEntitySystem_Should_throw_ArgumentNullException_When_World_is_null()
        {
            Check.ThatCode(() => new System(default(World))).Throws<ArgumentNullException>();
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

            using (EntitySet set = world.GetEntities().With<bool>().Without<int>().AsSet())
            using (ISystem<int> system = new System(set))
            {
                system.Update(0);

                Check.That(set.Count).IsZero();
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
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

            using (ISystem<int> system = new System(world)
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
        public void Should_call_EntityAdded_When_entity_added()
        {
            using World world = new World(4);
            using System system = new System(world);

            Entity addedEntity = default;

            void callback(in Entity e) => addedEntity = e;

            system.EntityAdded += callback;

            Entity entity = world.CreateEntity();
            entity.Set<bool>();

            Check.That(addedEntity).IsEqualTo(entity);

            system.EntityAdded -= callback;
            addedEntity = default;
            entity.Remove<bool>();
            entity.Set<bool>();

            Check.That(addedEntity).IsEqualTo(default(Entity));
        }

        [Fact]
        public void Should_call_EntityAdded_When_entity_already_present()
        {
            using World world = new World(4);

            Entity entity = world.CreateEntity();
            entity.Set<bool>();

            using System system = new System(world);

            Entity addedEntity = default;

            system.EntityAdded += (in Entity e) => addedEntity = e;

            Check.That(addedEntity).IsEqualTo(entity);
        }

        [Fact]
        public void Should_call_EntityRemoved_When_entity_removed()
        {
            using World world = new World(4);
            using System system = new System(world);

            Entity removedEntity = default;

            void callback(in Entity e) => removedEntity = e;

            system.EntityRemoved += callback;

            Entity entity = world.CreateEntity();
            entity.Set<bool>();
            entity.Remove<bool>();

            Check.That(removedEntity).IsEqualTo(entity);

            system.EntityRemoved -= callback;
            removedEntity = default;
            entity.Set<bool>();
            entity.Remove<bool>();

            Check.That(removedEntity).IsEqualTo(default(Entity));
        }

        #endregion
    }
}
