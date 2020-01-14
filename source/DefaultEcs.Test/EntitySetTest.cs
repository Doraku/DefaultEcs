using System.Collections.Generic;
using System.Linq;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntitySetTest
    {
        #region Tests

        [Fact]
        public void World_Should_return_parent_world()
        {
            using World world = new World(4);

            using EntitySet set = world.GetEntities().AsSet();

            Check.That(set.World).IsEqualTo(world);
        }

        [Fact]
        public void GetEntities_Should_return_previously_created_Entity()
        {
            using World world = new World(4);

            List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            using EntitySet set = world.GetEntities().AsSet();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void Contains_Should_return_true_When_containing_entity()
        {
            using World world = new World(4);

            Entity entity = world.CreateEntity();

            using EntitySet set = world.GetEntities().AsSet();

            Check.That(set.Contains(entity)).IsTrue();
        }

        [Fact]
        public void Contains_Should_return_false_When_not_containing_entity()
        {
            using World world = new World(4);

            world.CreateEntity();
            world.CreateEntity();
            world.CreateEntity();
            Entity entity = world.CreateEntity();

            using EntitySet set = world.GetDisabledEntities().AsSet();

            Check.That(set.Contains(entity)).IsFalse();
        }

        [Fact]
        public void GetEntities_Should_not_return_disabled_Entity()
        {
            using World world = new World(4);

            List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            using EntitySet set = world.GetEntities().AsSet();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            entities[3].Disable();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities.Take(3));

            entities[3].Enable();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void GetEntities_Should_return_only_disabled_Entity()
        {
            using World world = new World(4);

            List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            using EntitySet set = world.GetDisabledEntities().AsSet();

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Disable();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            entities[3].Enable();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities.Take(3));
        }

        [Fact]
        public void GetEntities_Should_not_return_Entity_with_disabled_component()
        {
            using World world = new World(4);

            List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            foreach (Entity entity in entities)
            {
                entity.Set<bool>();
            }
            entities[0].Disable<bool>();

            using EntitySet set = world.GetEntities().With<bool>().AsSet();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities.Skip(1));
        }

        [Fact]
        public void Should_call_EntityAdded_When_entity_added()
        {
            using World world = new World(4);
            using EntitySet set = world.GetEntities().With<bool>().AsSet();

            Entity addedEntity = default;
            set.EntityAdded += (in Entity e) => addedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Set<bool>();

            Check.That(addedEntity).IsEqualTo(entity);
        }

        [Fact]
        public void Should_call_EntityAdded_When_entity_already_present()
        {
            using World world = new World(4);
            using EntitySet set = world.GetEntities().With<bool>().AsSet();

            Entity entity = world.CreateEntity();
            entity.Set<bool>();

            Entity addedEntity = default;
            set.EntityAdded += (in Entity e) => addedEntity = e;

            Check.That(addedEntity).IsEqualTo(entity);
        }

        [Fact]
        public void Should_call_EntityRemoved_When_entity_removed()
        {
            using World world = new World(4);
            using EntitySet set = world.GetEntities().With<bool>().AsSet();

            Entity removedEntity = default;
            set.EntityRemoved += (in Entity e) => removedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Set<bool>();
            entity.Remove<bool>();

            Check.That(removedEntity).IsEqualTo(entity);
        }

        #endregion
    }
}
