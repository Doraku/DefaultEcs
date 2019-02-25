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
        public void Subscribe_Should_subscribe()
        {
            using (World world = new World(0))
            {
                bool done = false;
                world.Subscribe((in bool b) => done = b);
                world.Publish(true);

                Check.That(done).IsTrue();
            }
        }

        [Fact]
        public void Subscribe_Dispose_Should_unsubscribe()
        {
            using (World world = new World(0))
            {
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
        }

        [Fact]
        public void Publish_Should_publish()
        {
            using (World world = new World(0))
            {
                bool done = false;
                world.Subscribe((in bool b) => done = b);
                world.Publish(true);

                Check.That(done).IsTrue();
            }
        }

        [Fact]
        public void CreateEntity_Should_return_an_Entity()
        {
            using (World world = new World(1))
            {
                Check.ThatCode(() => world.CreateEntity()).DoesNotThrow();
            }
        }

        [Fact]
        public void CreateEntity_Should_return_different_Entity_each_time()
        {
            using (World world = new World(2))
            {
                Check.That(world.CreateEntity()).IsNotEqualTo(world.CreateEntity());
            }
        }

        [Fact]
        public void CreateEntity_Should_throw_When_max_number_of_Entity_is_reached()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.CreateEntity()).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void SetMaximumComponentCount_Should_return_true_When_maxComponentCount_is_setted()
        {
            using (World world = new World(0))
            {
                Check.That(world.SetMaximumComponentCount<bool>(0)).IsTrue();
            }
        }

        [Fact]
        public void SetMaximumComponentCount_Should_return_false_When_maxComponentCount_is_already_setted()
        {
            using (World world = new World(42))
            {
                Check.That(world.SetMaximumComponentCount<bool>(0)).IsTrue();
                Check.That(world.SetMaximumComponentCount<bool>(42)).IsFalse();
            }
        }

        [Fact]
        public void GetMaximumComponentCount_Should_return_maxComponentCount()
        {
            using (World world = new World(100))
            {
                world.SetMaximumComponentCount<bool>(42);
                Check.That(world.GetMaximumComponentCount<bool>()).IsEqualTo(42);
            }
        }

        [Fact]
        public void GetMaximumComponentCount_Should_return_one_for_flag_type()
        {
            using (World world = new World(100))
            {
                world.SetMaximumComponentCount<FlagType>(42);
                Check.That(world.GetMaximumComponentCount<FlagType>()).IsEqualTo(1);
            }
        }

        [Fact]
        public void SetMaximumComponentCount_Should_throw_When_maxComponentCount_is_negative()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.SetMaximumComponentCount<bool>(-1)).Throws<ArgumentException>();
            }
        }

        [Fact]
        public void SetMaximumComponentCount_Should_not_throw_When_already_added()
        {
            using (World world = new World(0))
            {
                world.SetMaximumComponentCount<bool>(0);
                Check.ThatCode(() => world.SetMaximumComponentCount<bool>(0)).DoesNotThrow();
            }
        }

        [Fact]
        public void GetAllComponents_Should_not_throw_When_not_added()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.GetAllComponents<bool>()).DoesNotThrow();
            }
        }

        [Fact]
        public void GetAllComponents_Should_return_component()
        {
            using (World world = new World(2))
            {
                world.SetMaximumComponentCount<int>(2);
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
        }

        [Fact]
        public void GetEntities_Should_return_an_EntitySetBuilder()
        {
            using (World world = new World(4))
            {
                Check.That(world.GetEntities()).IsNotNull();
            }
        }

        [Fact]
        public void GetAllEntities_Should_all_entities()
        {
            using (World world = new World(4))
            {
                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity()
                };
                Entity entity = world.CreateEntity();
                entities.Add(world.CreateEntity());
                entity.Dispose();

                Check.That(world.GetAllEntities()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetAllEntities_Should_return_disabled_entities()
        {
            using (World world = new World(4))
            {
                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity()
                };
                Entity entity = world.CreateEntity();
                entities.Add(world.CreateEntity());
                entity.Dispose();
                entities[1].Disable();

                Check.That(world.GetAllEntities()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void ReadAllComponentTypes_Should_throw_ArgumentNullException_When_reader_is_null()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.ReadAllComponentTypes(null)).Throws<ArgumentNullException>();
            }
        }

        [Fact]
        public void ReadAllComponentTypes_Should_callback_reader()
        {
            using (World world = new World(42))
            {
                bool intIsOk = false;
                bool longIsOk = false;
                bool floatIsOk = true;

                world.SetMaximumComponentCount<int>(1);
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
        }

        #endregion
    }
}
