using System;
using System.Collections.Generic;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AEntitiesSystemTest
    {
        [With(typeof(bool))]
        private sealed class System<T> : AEntitiesSystem<int, T>
        {
            public List<T> Keys = new List<T>();

            public System(EntitiesMap<T> map)
                : base(map)
            { }

            public System(World world)
                : base(world)
            { }

            public System(World world, IParallelRunner runner)
                : base(world, runner)
            { }

            public System(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
                : base(world, runner, minEntityCountByRunnerIndex)
            { }

            protected override void PreUpdate(int state) => Keys.Clear();

            protected override void PostUpdate(int state, T key) => Keys.Add(key);

            protected override void Update(int state, in T key, in Entity entity)
            {
                entity.Get<bool>() = true;
            }
        }

        [With(typeof(bool))]
        private sealed class ReverseSystem : AEntitiesSystem<int, int>, IComparer<int>
        {
            public List<int> Keys = new List<int>();

            public ReverseSystem(World world)
                : base(world)
            { }

            protected override void PreUpdate(int state)
            {
                base.PreUpdate(state);

                Keys.Clear();
            }

            protected override void PostUpdate(int state, int key)
            {
                base.PostUpdate(state, key);

                Keys.Add(key);
            }

            public int Compare(int x, int y) => x.CompareTo(y) * -1;

            protected override void Update(int state, in int key, in Entity entity)
            {
                base.Update(state, key, entity);

                entity.Get<bool>() = true;
            }
        }

        #region Tests

        [Fact]
        public void AEntitiesSystem_Should_throw_ArgumentNullException_When_EntitySet_is_null()
        {
            Check.ThatCode(() => new System<int>(default(EntitiesMap<int>))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void AEntitiesSystem_Should_throw_ArgumentNullException_When_World_is_null()
        {
            Check.ThatCode(() => new System<int>(default(World))).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Update_Should_call_update()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(4);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(3);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(1);

            using System<int> system = new System<int>(world.GetEntities().With<bool>().AsMultiMap<int>());

            system.Update(0);

            Check.That(system.Keys).ContainsExactly(1, 2, 3, 4);

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();

            entity1.Set<bool>();
            entity2.Set<bool>();
            entity3.Set<bool>();
            entity4.Set<bool>();
            entity4.Remove<int>();

            system.Update(0);

            Check.That(system.Keys).ContainsExactly(2, 3, 4);

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_Should_call_update_for_nullable_key()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set<int?>(4);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set<int?>(3);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set<int?>(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set<int?>(1);

            using System<int?> system = new System<int?>(world);

            system.Update(0);

            Check.That(system.Keys).ContainsExactly(1, 2, 3, 4);

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_call_update_for_non_comparable_key()
        {
            object key = new object();

            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(key);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(key);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(key);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(key);

            using System<object> system = new System<object>(world);

            system.Update(0);

            Check.That(system.Keys).ContainsExactly(key);

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_call_update_in_order_of_key()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(1);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(2);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(3);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(4);

            using (ReverseSystem system = new ReverseSystem(world))
            {
                system.Update(0);

                Check.That(system.Keys).ContainsExactly(4, 3, 2, 1);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_not_call_update_When_disabled()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(4);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(3);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(1);

            using (ISystem<int> system = new System<int>(world)
            {
                IsEnabled = false
            })
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsFalse();
            Check.That(entity2.Get<bool>()).IsFalse();
            Check.That(entity3.Get<bool>()).IsFalse();
            Check.That(entity4.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Update_with_runner_Should_call_update()
        {
            using DefaultParallelRunner runner = new DefaultParallelRunner(2);
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(4);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(3);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(1);

            using (ISystem<int> system = new System<int>(world, runner))
            {
                system.Update(0);
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Update_Should_not_use_runner_When_minEntityCountByRunnerIndex_not_respected()
        {
            IParallelRunner runner = Substitute.For<IParallelRunner>();
            runner.DegreeOfParallelism.Returns(4);
            runner.When(m => m.Run(Arg.Any<IParallelRunnable>())).Throw<Exception>();

            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            entity1.Set<bool>();
            entity1.Set(4);

            Entity entity2 = world.CreateEntity();
            entity2.Set<bool>();
            entity2.Set(3);

            Entity entity3 = world.CreateEntity();
            entity3.Set<bool>();
            entity3.Set(2);

            Entity entity4 = world.CreateEntity();
            entity4.Set<bool>();
            entity4.Set(1);

            using (ISystem<int> system = new System<int>(world, runner, 10))
            {
                Check.ThatCode(() => system.Update(0)).DoesNotThrow();
            }

            Check.That(entity1.Get<bool>()).IsTrue();
            Check.That(entity2.Get<bool>()).IsTrue();
            Check.That(entity3.Get<bool>()).IsTrue();
            Check.That(entity4.Get<bool>()).IsTrue();
        }

        #endregion
    }
}
