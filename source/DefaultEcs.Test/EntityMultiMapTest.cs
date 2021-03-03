using System;
using System.Collections;
using System.Collections.Generic;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntityMultiMapTest
    {
        [Fact]
        public void World_Should_return_world()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

            Check.That(map.World).IsEqualTo(world);
        }

        [Fact]
        public void ContainsEntity_Should_return_weither_an_entity_is_in_or_not()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

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

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();

            Check.That(map.ContainsKey(42)).IsFalse();

            entity.Set(42);

            Check.That(map.ContainsKey(42)).IsTrue();
        }

        [Fact]
        public void This_Should_return_entities()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map[42].ToArray()).ContainsExactly(entity);
        }

        [Fact]
        public void Keys_Should_return_keys()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

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
        public void Count_Should_return_the_number_of_entities()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();

            Check.That(map.Count(42)).IsZero();

            entity.Set(42);

            Check.That(map.Count(42)).IsEqualTo(1);
        }

        [Fact]
        public void TryGetEntities_Should_return_weither_a_key_is_in_or_not()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();

            Check.That(map.TryGetEntities(42, out ReadOnlySpan<Entity> result)).IsFalse();

            entity.Set(42);

            Check.That(map.TryGetEntities(42, out result)).IsTrue();
            Check.That(result.ToArray()).ContainsExactly(entity);

            entity.Disable<int>();

            Check.That(map.TryGetEntities(42, out result)).IsFalse();

            entity.Enable<int>();

            Check.That(map.TryGetEntities(42, out result)).IsTrue();
            Check.That(result.ToArray()).ContainsExactly(entity);

            entity.Remove<int>();

            Check.That(map.TryGetEntities(42, out result)).IsFalse();
        }

        [Fact]
        public void Should_behave_correctly_when_key_changed()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map.TryGetEntities(42, out ReadOnlySpan<Entity> result)).IsTrue();
            Check.That(result.ToArray()).ContainsExactly(entity);

            entity.Set(1337);

            Check.That(map.TryGetEntities(42, out result)).IsFalse();
            Check.That(map.TryGetEntities(1337, out result)).IsTrue();
            Check.That(result.ToArray()).ContainsExactly(entity);

            entity.Get<int>() = 42;
            entity.NotifyChanged<int>();

            Check.That(map.TryGetEntities(1337, out result)).IsFalse();
            Check.That(map.TryGetEntities(42, out result)).IsTrue();
            Check.That(result.ToArray()).ContainsExactly(entity);
        }

        [Fact]
        public void Complete_Should_empty_When_reative()
        {
            using World world = new();

            using EntityMultiMap<int> map = world.GetEntities().WhenAddedEither<int>().AsMultiMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map.TryGetEntities(42, out ReadOnlySpan<Entity> result)).IsTrue();
            Check.That(result.ToArray()).ContainsExactly(entity);

            map.Complete();

            Check.That(map.TryGetEntities(42, out result)).IsFalse();

            entity.Set(1337);

            Check.That(map.TryGetEntities(42, out result)).IsFalse();
        }

        [Fact]
        public void Dispose_Should_not_throw_When_world_already_disposed()
        {
            World world = new(4);

            EntityMultiMap<int> set = world.GetEntities().AsMultiMap<int>();

            world.Dispose();

            Check.ThatCode(set.Dispose).DoesNotThrow();
        }
    }
}
