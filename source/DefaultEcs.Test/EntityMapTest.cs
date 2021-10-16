using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntityMapTest
    {
        [Fact]
        public void World_Should_return_world()
        {
            using World world = new();

            using EntityMap<int> map = world.GetEntities().AsMap<int>();

            Check.That(map.World).IsEqualTo(world);
        }

        [Fact]
        public void ContainsEntity_Should_return_weither_an_entity_is_in_or_not()
        {
            using World world = new();

            Entity entity = world.CreateEntity();

            using EntityMap<int> map = world.GetEntities().AsMap<int>();

            Check.That(map.ContainsEntity(entity)).IsFalse();

            entity.Set(42);

            Check.That(map.ContainsEntity(entity)).IsTrue();

            entity.Disable<int>();

            Check.That(map.ContainsEntity(entity)).IsFalse();

            entity.Enable<int>();

            Check.That(map.ContainsEntity(entity)).IsTrue();

            entity.Remove<int>();

            Check.That(map.ContainsEntity(entity)).IsFalse();
        }

        [Fact]
        public void ContainsKey_Should_return_weither_a_key_is_in_or_not()
        {
            using World world = new();

            using EntityMap<int> map = world.GetEntities().AsMap<int>();

            Entity entity = world.CreateEntity();

            Check.That(map.ContainsKey(42)).IsFalse();

            entity.Set(42);

            Check.That(map.ContainsKey(42)).IsTrue();

            entity.Disable<int>();

            Check.That(map.ContainsKey(42)).IsFalse();

            entity.Enable<int>();

            Check.That(map.ContainsKey(42)).IsTrue();

            entity.Remove<int>();

            Check.That(map.ContainsKey(42)).IsFalse();
        }

        [Fact]
        public void This_Should_return_entity()
        {
            using World world = new();

            using EntityMap<int> map = world.GetEntities().AsMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map[42]).IsEqualTo(entity);
        }

        [Fact]
        public void Keys_Should_return_keys()
        {
            using World world = new(3);

            using EntityMap<int> map = world.GetEntities().WithEither<int>().AsMap<int>(null);

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map.Keys as IEnumerable).ContainsExactly(42);

            entity.Remove<int>();

            Check.That(map.Keys).IsEmpty();

            entity.Set(42);

            using IEnumerator<int> enumerator = (map.Keys as IEnumerable<int>)?.GetEnumerator();

            Check.That(enumerator.MoveNext()).IsTrue();
            Check.That(enumerator.Current).IsEqualTo(42);

            enumerator.Reset();

            Check.That(enumerator.MoveNext()).IsTrue();
            Check.That(enumerator.Current).IsEqualTo(42);
        }

        [Fact]
        public void TryGetEntity_Should_return_weither_a_key_is_in_or_not()
        {
            using World world = new();

            using EntityMap<int> map = world.GetEntities().AsMap<int>(null);

            Entity entity = world.CreateEntity();

            Check.That(map.TryGetEntity(42, out Entity result)).IsFalse();

            entity.Set(42);

            Check.That(map.TryGetEntity(42, out result)).IsTrue();
            Check.That(result).IsEqualTo(entity);

            entity.Disable<int>();

            Check.That(map.TryGetEntity(42, out result)).IsFalse();

            entity.Enable<int>();

            Check.That(map.TryGetEntity(42, out result)).IsTrue();
            Check.That(result).IsEqualTo(entity);

            entity.Remove<int>();

            Check.That(map.TryGetEntity(42, out result)).IsFalse();
        }

        [Fact]
        public void Should_behave_correctly_when_key_changed()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            using EntityMap<int> map = world.GetEntities().AsMap<int>();

            Check.That(map.TryGetEntity(42, out Entity result)).IsTrue();
            Check.That(result).IsEqualTo(entity);

            entity.Set(1337);

            Check.That(map.TryGetEntity(42, out result)).IsFalse();
            Check.That(map.TryGetEntity(1337, out result)).IsTrue();
            Check.That(result).IsEqualTo(entity);

            entity.Get<int>() = 42;
            entity.NotifyChanged<int>();

            Check.That(map.TryGetEntity(1337, out result)).IsFalse();
            Check.That(map.TryGetEntity(42, out result)).IsTrue();
            Check.That(result).IsEqualTo(entity);
        }

        [Fact]
        public void Complete_Should_empty_When_reative()
        {
            using World world = new();

            using EntityMap<int> map = world.GetEntities().WhenAddedEither<int>().AsMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map.TryGetEntity(42, out Entity result)).IsTrue();
            Check.That(result).IsEqualTo(entity);

            map.Complete();

            Check.That(map.TryGetEntity(42, out result)).IsFalse();

            entity.Set(1337);

            Check.That(map.TryGetEntity(42, out result)).IsFalse();
        }

        [Fact]
        public void TrimExcess_Should_fit_storage_to_number_of_entities()
        {
            using World world = new();

            using EntityMap<int> map = world.GetEntities().AsMap<int>();
            world.CreateEntity().Set(42);

            Check.That(((Array)typeof(EntityMap<int>).GetField("_entityIds", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(map)).Length).IsNotEqualTo(map.Keys.Count() + 1);

            map.TrimExcess();

            Check.That(((Array)typeof(EntityMap<int>).GetField("_entityIds", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(map)).Length).IsEqualTo(map.Keys.Count() + 1);
        }

        [Fact]
        public void EntityAdded_Should_be_called()
        {
            using World world = new();

            using EntityMap<int> set = world.GetEntities().AsMap<int>();

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

            using EntityMap<int> set = world.GetEntities().AsMap<int>();

            Entity removedEntity = default;

            set.EntityRemoved += (in Entity e) => removedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Set(42);
            entity.Disable();

            Check.That(entity).IsEqualTo(removedEntity);
        }
    }
}
