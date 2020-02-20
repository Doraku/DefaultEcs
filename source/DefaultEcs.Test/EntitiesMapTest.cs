using System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntitiesMapTest
    {
        [Fact]
        public void ContainsEntity_Should_return_weither_an_entity_is_in_or_not()
        {
            using World world = new World();

            using EntitiesMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();

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
            using World world = new World();

            using EntitiesMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();

            Check.That(map.ContainsKey(42)).IsFalse();

            entity.Set(42);

            Check.That(map.ContainsKey(42)).IsTrue();
        }

        [Fact]
        public void This_Should_return_entities()
        {
            using World world = new World();

            using EntitiesMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map[42].ToArray()).ContainsExactly(entity);
        }

        [Fact]
        public void Keys_Should_return_keys()
        {
            using World world = new World();

            using EntitiesMap<int> map = world.GetEntities().AsMultiMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            Check.That(map.Keys).ContainsExactly(42);
        }

        [Fact]
        public void TryGetEntities_Should_return_weither_a_key_is_in_or_not()
        {
            using World world = new World();

            using EntitiesMap<int> map = world.GetEntities().AsMultiMap<int>();

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
            using World world = new World();

            using EntitiesMap<int> map = world.GetEntities().AsMultiMap<int>();

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
    }
}
