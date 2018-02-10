using System;
using DefaultEcs.Message;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public class WorldTest
    {
        #region Tests

        [Fact]
        public void Subscribe_Should_subscribe()
        {
            using (World world = new World(0))
            {
                bool done = false;
                world.Subscribe<bool>(b => done = b);
                world.Publish(true);

                Check.That(done).IsTrue();
            }
        }

        [Fact]
        public void Publish_Should_publish()
        {
            using (World world = new World(0))
            {
                bool done = false;
                world.Subscribe<bool>(b => done = b);
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
        public void CreateEntity_Should_publish_EntityCreatedMessage()
        {
            using (World world = new World(2))
            {
                world.CreateEntity();

                Entity messageEntity = default;

                world.Subscribe<EntityCreatedMessage>(m => messageEntity = m.Entity);

                Check.That(world.CreateEntity()).IsEqualTo(messageEntity);
            }
        }

        [Fact]
        public void AddComponentType_Should_add()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.AddComponentType<bool>(0)).DoesNotThrow();
            }
        }

        [Fact]
        public void AddComponentType_Should_throw_When_maxComponentCount_is_negative()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.AddComponentType<bool>(-1)).Throws<ArgumentException>();
            }
        }

        [Fact]
        public void AddComponentType_Should_throw_When_already_added()
        {
            using (World world = new World(0))
            {
                world.AddComponentType<bool>(0);
                Check.ThatCode(() => world.AddComponentType<bool>(0)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void GetAllComponents_Should_throw_When_not_added()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.GetAllComponents<bool>()).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void GetAllComponents_Should_return_component()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<int>(2);
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

        #endregion
    }
}
