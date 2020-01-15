using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class WorldTest
    {
        private struct FlagType { }

        #region Tests

        [Fact]
        public void World_Should_throw_When_maxCapacity_is_inferior_to_0()
        {
            Check.ThatCode(() => new World(-1)).Throws<ArgumentException>();
        }

        [Fact]
        public void Subscribe_Should_subscribe()
        {
            using World world = new World(0);

            bool done = false;
            world.Subscribe((in bool b) => done = b);
            world.Publish(true);

            Check.That(done).IsTrue();
        }

        [Fact]
        public void Subscribe_Dispose_Should_unsubscribe()
        {
            using World world = new World(0);

            bool done = false;
            using (world.Subscribe((in bool b) => done = b))
            {
                world.Publish(true);

                Check.That(done).IsTrue();
            }

            done = false;
            world.Publish(true);
            Check.That(done).IsFalse();
        }

        [Fact]
        public void Publish_Should_publish()
        {
            using World world = new World(0);

            bool done = false;
            world.Subscribe((in bool b) => done = b);
            world.Publish(true);

            Check.That(done).IsTrue();
        }

        [Fact]
        public void CreateEntity_Should_return_an_Entity()
        {
            using World world = new World(1);

            Check.ThatCode(() => world.CreateEntity()).DoesNotThrow();
        }

        [Fact]
        public void CreateEntity_Should_return_different_Entity_each_time()
        {
            using World world = new World(2);

            Check.That(world.CreateEntity()).IsNotEqualTo(world.CreateEntity());
        }

        [Fact]
        public void CreateEntity_Should_throw_When_max_number_of_Entity_is_reached()
        {
            using World world = new World(0);

            Check.ThatCode(() => world.CreateEntity()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetMaxCapacityOf_Should_return_true_When_maxCapacity_is_setted()
        {
            using World world = new World(0);

            Check.That(world.SetMaxCapacityFor<bool>(0)).IsTrue();
        }

        [Fact]
        public void SetMaxCapacityOf_Should_return_false_When_maxCapacity_is_already_setted()
        {
            using World world = new World(42);

            Check.That(world.SetMaxCapacityFor<bool>(0)).IsTrue();
            Check.That(world.SetMaxCapacityFor<bool>(42)).IsFalse();
        }

        [Fact]
        public void GetMaxCapacityFor_Should_return_component_max_capacity()
        {
            using World world = new World(100);

            world.SetMaxCapacityFor<bool>(42);
            Check.That(world.GetMaxCapacityFor<bool>()).IsEqualTo(42);
        }

        [Fact]
        public void GetMaxCapacityFor_Should_return_minus_one_when_not_handled()
        {
            using World world = new World(100);

            Check.That(world.GetMaxCapacityFor<bool>()).IsEqualTo(-1);
        }

        [Fact]
        public void GetMaxCapacityFor_Should_return_one_for_flag_type()
        {
            using World world = new World(100);

            world.SetMaxCapacityFor<FlagType>(42);
            Check.That(world.GetMaxCapacityFor<FlagType>()).IsEqualTo(1);
        }

        [Fact]
        public void SetMaxCapacityOf_Should_throw_When_maxCapacity_is_negative()
        {
            using World world = new World(0);

            Check.ThatCode(() => world.SetMaxCapacityFor<bool>(-1)).Throws<ArgumentException>();
        }

        [Fact]
        public void SetMaxCapacityOf_Should_not_throw_When_already_added()
        {
            using World world = new World(0);

            world.SetMaxCapacityFor<bool>(0);
            Check.ThatCode(() => world.SetMaxCapacityFor<bool>(0)).DoesNotThrow();
        }

        [Fact]
        public void GetAllComponents_Should_not_throw_When_not_added()
        {
            using World world = new World(0);

            Check.ThatCode(() => world.GetAllComponents<bool>()).DoesNotThrow();
        }

        [Fact]
        public void GetAllComponents_Should_return_component()
        {
            using World world = new World(2);

            world.SetMaxCapacityFor<int>(2);
            Entity entity = world.CreateEntity();
            Entity entity2 = world.CreateEntity();

            entity.Set(1);
            entity2.Set(2);

            Span<int> components = world.GetAllComponents<int>();

            Check.That(components[0]).IsEqualTo(entity.Get<int>());
            Check.That(components[1]).IsEqualTo(entity2.Get<int>());

            components[0] = 10;
            components[1] = 20;

            Check.That(components[0]).IsEqualTo(entity.Get<int>());
            Check.That(components[1]).IsEqualTo(entity2.Get<int>());
        }

        [Fact]
        public void GetEntities_Should_return_an_EntitySetBuilder()
        {
            using World world = new World(4);

            Check.That(world.GetEntities()).IsNotNull();
        }

        [Fact]
        public void GetEnumerator_Should_return_all_entities()
        {
            using World world = new World(4);

            List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity()
                };
            Entity entity = world.CreateEntity();
            entities.Add(world.CreateEntity());
            entity.Dispose();

            Check.That(world).ContainsExactly(entities);
        }

        [Fact]
        public void GetEnumerator_Should_return_disabled_entities()
        {
            using World world = new World(4);

            List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity()
                };
            Entity entity = world.CreateEntity();
            entities.Add(world.CreateEntity());
            entity.Dispose();
            entities[1].Disable();

            Check.That(world).ContainsExactly(entities);
        }

        [Fact]
        public void ReadAllComponentTypes_Should_throw_ArgumentNullException_When_reader_is_null()
        {
            using World world = new World(0);

            Check.ThatCode(() => world.ReadAllComponentTypes(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ReadAllComponentTypes_Should_callback_reader()
        {
            using World world = new World(42);

            bool intIsOk = false;
            bool longIsOk = false;
            bool floatIsOk = true;

            world.SetMaxCapacityFor<int>(1);
            world.GetAllComponents<long>();

            IComponentTypeReader reader = Substitute.For<IComponentTypeReader>();
            reader.When(m => m.OnRead<int>(1)).Do(_ => intIsOk = true);
            reader.When(m => m.OnRead<long>(42)).Do(_ => longIsOk = true);
            reader.When(m => m.OnRead<float>(Arg.Any<int>())).Do(_ => floatIsOk = false);

            world.ReadAllComponentTypes(reader);

            Check.That(intIsOk).IsTrue();
            Check.That(longIsOk).IsTrue();
            Check.That(floatIsOk).IsTrue();
        }

        [Fact]
        public void Should_call_EntityDisposed_When_entity_disposed()
        {
            using World world = new World(4);

            Entity disposedEntity = default;
            world.EntityDisposed += (in Entity e) => disposedEntity = e;

            Entity entity = world.CreateEntity();
            entity.Dispose();

            Check.That(disposedEntity).IsEqualTo(entity);
        }

        [Fact]
        public void GetComponents_Should_return_fast_access_to_component()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            Entity entity2 = world.CreateEntity();
            Entity entity3 = world.CreateEntity();
            Entity entity4 = world.CreateEntity();

            entity1.Set("1");
            entity2.Set("2");
            entity3.Set("3");
            entity4.Set("4");

            Components<string> strings = world.GetComponents<string>();

            Check.That(entity1.Get<string>()).IsEqualTo(entity1.Get(strings));
            Check.That(entity2.Get<string>()).IsEqualTo(entity2.Get(strings));
            Check.That(entity3.Get<string>()).IsEqualTo(entity3.Get(strings));
            Check.That(entity4.Get<string>()).IsEqualTo(entity4.Get(strings));
        }

        #endregion
    }
}
