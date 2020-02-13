using System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class IComponentObserverTest
    {
        #region Types

        private sealed class ComponentObserver<T> : IComponentObserver<T>
        {
            private readonly Entity _expectedEntity;
            private readonly T _expectedOldValue;
            private readonly T _expectedNewValue;

            public bool IsOk { get; set; }

            public ComponentObserver(Entity expectedEntity, T expectedOldValue, T expectedNewValue)
            {
                _expectedEntity = expectedEntity;
                _expectedOldValue = expectedOldValue;
                _expectedNewValue = expectedNewValue;
            }

            public void OnAdded(in Entity entity, in T value)
            {
                Check.That(entity).IsEqualTo(_expectedEntity);
                Check.That(value).IsEqualTo(_expectedNewValue);

                IsOk = true;
            }

            public void OnChanged(in Entity entity, in T oldValue, in T newValue)
            {
                Check.That(entity).IsEqualTo(_expectedEntity);
                Check.That(oldValue).IsEqualTo(_expectedOldValue);
                Check.That(newValue).IsEqualTo(_expectedNewValue);

                IsOk = true;
            }

            public void OnDisabled(in Entity entity, in T value)
            {
                Check.That(entity).IsEqualTo(_expectedEntity);
                Check.That(value).IsEqualTo(_expectedNewValue);

                IsOk = true;
            }

            public void OnEnabled(in Entity entity, in T value)
            {
                Check.That(entity).IsEqualTo(_expectedEntity);
                Check.That(value).IsEqualTo(_expectedNewValue);

                IsOk = true;
            }

            public void OnRemoved(in Entity entity, in T value)
            {
                Check.That(entity).IsEqualTo(_expectedEntity);
                Check.That(value).IsEqualTo(_expectedOldValue);

                IsOk = true;
            }
        }

        #endregion

        #region Tests

        [Fact]
        public void OnAdded_Should_be_called_When_component_added()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, default, true);
            using IDisposable subscription = world.SubscribeObserver(observer);

            entity.Set(true);
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void OnEnable_Should_be_called_When_component_enabled()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            entity.Disable<bool>();
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, default, true);
            using IDisposable subscription = world.SubscribeObserver(observer);

            entity.Enable<bool>();
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void OnDisable_Should_be_called_When_component_disabled()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, default, true);
            using IDisposable subscription = world.SubscribeObserver(observer);

            entity.Disable<bool>();
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void OnRemoved_Should_be_called_When_component_removed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, true, default);
            using IDisposable subscription = world.SubscribeObserver(observer);

            entity.Remove<bool>();
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void OnRemoved_Should_be_called_When_entity_disposed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, true, default);
            using IDisposable subscription = world.SubscribeObserver(observer);

            entity.Dispose();
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void OnRemoved_Should_be_called_When_world_disposed()
        {
            World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, true, default);
            using IDisposable subscription = world.SubscribeObserver(observer);

            world.Dispose();
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void OnChanged_Should_be_called_When_component_changed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(false);
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, false, true);
            using IDisposable subscription = world.SubscribeObserver(observer);

            entity.Set(true);
            Check.That(observer.IsOk).IsTrue();
        }

        [Fact]
        public void Should_do_nothing_When_entity_disposed_without_component()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, true, default);
            using IDisposable subscription = world.SubscribeObserver(observer);

            Check.ThatCode(entity.Dispose).DoesNotThrow();
            Check.That(observer.IsOk).IsFalse();
        }

        [Fact]
        public void Should_do_nothing_When_world_disposed_without_component()
        {
            World world = new World();
            Entity entity = world.CreateEntity();
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, true, default);
            using IDisposable subscription = world.SubscribeObserver(observer);

            Check.ThatCode(world.Dispose).DoesNotThrow();
            Check.That(observer.IsOk).IsFalse();
        }

        [Fact]
        public void Should_do_nothing_When_subscription_disposed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            ComponentObserver<bool> observer = new ComponentObserver<bool>(entity, default, true);
            world.SubscribeObserver(observer).Dispose();

            entity.Set(true);
            Check.That(observer.IsOk).IsFalse();
        }

        #endregion
    }
}
