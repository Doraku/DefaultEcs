using System;
using DefaultEcs.Resource;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.Resource
{
    public sealed class AResourceManagerTest
    {
        private class ResourceManagerTest : AResourceManager<string, IDisposable>
        {
            private readonly IDisposable _value;

            public ResourceManagerTest(IDisposable value)
            {
                _value = value;
            }

            protected override IDisposable Load(string info) => _value;

            protected override void OnResourceLoaded(in Entity entity, string info, IDisposable resource)
            {
                if (!entity.Has<int>())
                {
                    entity.Set(0);
                }

                ++entity.Get<int>();
            }
        }

        #region Tests

        [Fact]
        public void Should_load_resource()
        {
            IDisposable value = Substitute.For<IDisposable>();

            using (ResourceManagerTest manager = new ResourceManagerTest(value))
            using (World world = new World(1))
            {
                manager.Manage(world);
                Entity entity = world.CreateEntity();
                entity.Set(new ManagedResource<string, IDisposable>("dummy"));

                Check.That(entity.Get<int>()).IsEqualTo(1);
            }
        }

        [Fact]
        public void Should_load_multiple_resource()
        {
            IDisposable value = Substitute.For<IDisposable>();

            using (ResourceManagerTest manager = new ResourceManagerTest(value))
            using (World world = new World(1))
            {
                manager.Manage(world);
                Entity entity = world.CreateEntity();
                entity.Set(new ManagedResource<string[], IDisposable>(new[] { "dummy", "dummy2" }));

                Check.That(entity.Get<int>()).IsEqualTo(2);
            }
        }

        [Fact]
        public void Should_dispose_resource_When_holding_entities_are_disposed()
        {
            int disposedCount = 0;
            IDisposable value = Substitute.For<IDisposable>();
            value.When(d => d.Dispose()).Do(_ => ++disposedCount);

            using (ResourceManagerTest manager = new ResourceManagerTest(value))
            using (World world = new World())
            {
                manager.Manage(world);
                Entity entity = world.CreateEntity();
                entity.Set(new ManagedResource<string, IDisposable>("dummy"));

                Entity entity2 = world.CreateEntity();
                entity2.Set(new ManagedResource<string, IDisposable>("dummy"));

                entity.Dispose();

                Check.That(disposedCount).IsEqualTo(0);

                entity2.Dispose();

                Check.That(disposedCount).IsEqualTo(1);
            }
        }

        [Fact]
        public void Should_dispose_resource_When_world_is_disposed()
        {
            int disposedCount = 0;
            IDisposable value = Substitute.For<IDisposable>();
            value.When(d => d.Dispose()).Do(_ => ++disposedCount);

            using (ResourceManagerTest manager = new ResourceManagerTest(value))
            {
                using (World world = new World())
                {
                    manager.Manage(world);
                    Entity entity = world.CreateEntity();
                    entity.Set(new ManagedResource<string, IDisposable>("dummy"));

                    Entity entity2 = world.CreateEntity();
                    entity2.SetSameAs<ManagedResource<string, IDisposable>>(entity);
                }

                Check.That(disposedCount).IsEqualTo(1);
            }
        }

        #endregion
    }
}
