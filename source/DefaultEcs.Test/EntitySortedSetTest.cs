using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntitySortedSetTest
    {
        #region Tests

        [Fact]
        public void World_Should_return_parent_world()
        {
            using World world = new();

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();

            Check.That(sortedSet.World).IsEqualTo(world);
        }

        [Fact]
        public void GetEntities_Should_return_previously_created_Entity()
        {
            using World world = new();

            List<Entity> entities = new()
            {
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity()
            };

            for (int i = 0; i < entities.Count; ++i)
            {
                entities[i].Set(i);
            }

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void Contains_Should_return_true_When_containing_entity()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(0);

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();

            Check.That(sortedSet.Contains(entity)).IsTrue();
        }

        [Fact]
        public void Contains_Should_return_false_When_not_containing_entity()
        {
            using World world = new();

            world.CreateEntity().Set(0);
            world.CreateEntity().Set(0);
            world.CreateEntity().Set(0);
            Entity entity = world.CreateEntity();
            entity.Set(0);

            using EntitySortedSet<int> sortedSet = world.GetDisabledEntities().AsSortedSet<int>();

            Check.That(sortedSet.Contains(entity)).IsFalse();
        }

        [Fact]
        public void GetEntities_Should_not_return_disabled_Entity()
        {
            using World world = new();

            List<Entity> entities = new()
            {
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity()
            };

            for (int i = 0; i < entities.Count; ++i)
            {
                entities[i].Set(i);
            }

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities);

            entities[3].Disable();

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities.Take(3));

            entities[3].Enable();

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void GetEntities_Should_return_only_disabled_Entity()
        {
            using World world = new();

            List<Entity> entities = new()
            {
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity()
            };

            for (int i = 0; i < entities.Count; ++i)
            {
                entities[i].Set(i);
            }

            using EntitySortedSet<int> sortedSet = world.GetDisabledEntities().AsSortedSet<int>();

            Check.That(sortedSet.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Disable();
            }

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities);

            entities[3].Enable();

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities.Take(3));
        }

        [Fact]
        public void GetEntities_Should_not_return_Entity_with_disabled_component()
        {
            using World world = new();

            List<Entity> entities = new()
            {
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity()
            };

            for (int i = 0; i < entities.Count; ++i)
            {
                entities[i].Set(i);
            }

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();

            entities[0].Disable<int>();

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities.Skip(1));
        }

        [Fact]
        public void GetEntities_Should_return_Entity_Sorted()
        {
            using World world = new();

            List<Entity> entities = new()
            {
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity(),
                world.CreateEntity()
            };

            using EntitySortedSet<int> sortedSet = world.GetEntities().WithEither<int>().AsSortedSet<int>();

            for (int i = 0; i < entities.Count; ++i)
            {
                entities[i].Set(-i);
            }

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities.AsEnumerable().Reverse());

            for (int i = 0; i < entities.Count; ++i)
            {
                entities[i].Set(i);
            }

            Check.That(sortedSet.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void Complete_Should_empty_When_reative()
        {
            using World world = new();

            using EntitySortedSet<int> sortedSet = world.GetEntities().WhenAdded<int>().AsSortedSet<int>();

            world.CreateEntity().Set(0);
            world.CreateEntity().Set(1);
            world.CreateEntity().Set(2);

            Check.That(sortedSet.Count).IsEqualTo(3);

            sortedSet.Complete();

            Check.That(sortedSet.Count).IsZero();
        }

        [Fact]
        public void Dispose_Should_not_throw_When_world_already_disposed()
        {
            World world = new();

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();

            world.Dispose();

            Check.ThatCode(sortedSet.Dispose).DoesNotThrow();
        }

        [Fact]
        public void TrimExcess_Should_fit_storage_to_number_of_entities()
        {
            using World world = new();

            using EntitySortedSet<int> sortedSet = world.GetEntities().AsSortedSet<int>();
            world.CreateEntity().Set(0);

            Check.That(((Array)typeof(EntitySortedSet<int>).GetField("_mapping", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedSet)).Length).IsNotEqualTo(sortedSet.Count + 1);
            Check.That(((Array)typeof(EntitySortedSet<int>).GetField("_entities", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedSet)).Length).IsNotEqualTo(sortedSet.Count);

            sortedSet.TrimExcess();

            Check.That(((Array)typeof(EntitySortedSet<int>).GetField("_mapping", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedSet)).Length).IsEqualTo(sortedSet.Count + 1);
            Check.That(((Array)typeof(EntitySortedSet<int>).GetField("_entities", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(sortedSet)).Length).IsEqualTo(sortedSet.Count);
        }

        [Fact]
        public void EntityAdded_Should_be_called()
        {
            using World world = new();

            using EntitySortedSet<int> set = world.GetEntities().AsSortedSet<int>();

            Entity addedEntity = default;

            set.EntityAdded += (in Entity e) => addedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(entity).IsEqualTo(addedEntity);
        }

        [Fact]
        public void EntityRemoved_Should_be_called()
        {
            using World world = new();

            using EntitySortedSet<int> set = world.GetEntities().AsSortedSet<int>();

            Entity removedEntity = default;

            set.EntityRemoved += (in Entity e) => removedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Set(42);
            entity.Disable();

            Check.That(entity).IsEqualTo(removedEntity);
        }

        [Fact]
        public void Remove_While_Full_Should_Not_Crash()
        {
            using World world = new();

            for (int i = 0; i < 8; i++) // choose count such that _entities is completly used
            {
                world.CreateEntity().Set(i);
            }

            using EntitySortedSet<int> set = world.GetEntities().AsSortedSet<int>();

            set.GetEntities()[0].Remove<int>();
        }

        #endregion
    }
}
