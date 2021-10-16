using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            using World world = new(4);

            using EntitySet set = world.GetEntities().AsSet();

            Check.That(set.World).IsEqualTo(world);
        }

        [Fact]
        public void GetEntities_Should_return_previously_created_Entity()
        {
            using World world = new(4);

            List<Entity> entities = new()
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
            using World world = new(4);

            Entity entity = world.CreateEntity();

            using EntitySet set = world.GetEntities().AsSet();

            Check.That(set.Contains(entity)).IsTrue();
        }

        [Fact]
        public void Contains_Should_return_false_When_not_containing_entity()
        {
            using World world = new(4);

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
            using World world = new(4);

            List<Entity> entities = new()
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
            using World world = new(4);

            List<Entity> entities = new()
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
            using World world = new(4);

            List<Entity> entities = new()
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
        public void Dispose_Should_not_throw_When_world_already_disposed()
        {
            World world = new(4);

            using EntitySet set = world.GetEntities().AsSet();

            world.Dispose();

            Check.ThatCode(set.Dispose).DoesNotThrow();
        }

        [Fact]
        public void TrimExcess_Should_fit_storage_to_number_of_entities()
        {
            using World world = new();

            using EntitySet set = world.GetEntities().AsSet();
            world.CreateEntity();

            Check.That(((Array)typeof(EntitySet).GetField("_mapping", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(set)).Length).IsNotEqualTo(set.Count + 1);
            Check.That(((Array)typeof(EntitySet).GetField("_entities", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(set)).Length).IsNotEqualTo(set.Count);

            set.TrimExcess();

            Check.That(((Array)typeof(EntitySet).GetField("_mapping", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(set)).Length).IsEqualTo(set.Count + 1);
            Check.That(((Array)typeof(EntitySet).GetField("_entities", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(set)).Length).IsEqualTo(set.Count);
        }

        [Fact]
        public void EntityAdded_Should_be_called()
        {
            using World world = new();

            using EntitySet set = world.GetEntities().AsSet();

            Entity addedEntity = default;

            set.EntityAdded += (in Entity e) => addedEntity = e;

            Entity entity = world.CreateEntity();

            Check.That(entity).IsEqualTo(addedEntity);
        }

        [Fact]
        public void EntityRemoved_Should_be_called()
        {
            using World world = new();

            using EntitySet set = world.GetEntities().AsSet();

            Entity removedEntity = default;

            set.EntityRemoved += (in Entity e) => removedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Disable();

            Check.That(entity).IsEqualTo(removedEntity);
        }

        #endregion
    }
}
