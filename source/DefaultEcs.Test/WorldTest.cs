using System;
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
        public void SetComponentTypeMaximumCount_Should_return_same_World()
        {
            using (World world = new World(0))
            {
                Check.That(world.SetComponentTypeMaximumCount<bool>(0)).IsEqualTo(world);
            }
        }

        [Fact]
        public void SetComponentTypeMaximumCount_Should_add()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.SetComponentTypeMaximumCount<bool>(0)).DoesNotThrow();
            }
        }

        [Fact]
        public void SetComponentTypeMaximumCount_Should_throw_When_maxComponentCount_is_negative()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.SetComponentTypeMaximumCount<bool>(-1)).Throws<ArgumentException>();
            }
        }

        [Fact]
        public void SetComponentTypeMaximumCount_Should_not_throw_When_already_added()
        {
            using (World world = new World(0))
            {
                world.SetComponentTypeMaximumCount<bool>(0);
                Check.ThatCode(() => world.SetComponentTypeMaximumCount<bool>(0)).DoesNotThrow();
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
                world.SetComponentTypeMaximumCount<int>(2);
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

        #endregion
    }
}
