using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using DefaultEcs.Serialization;
using DefaultEcs.Threading;
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
        public void ToString_Should_return_id()
        {
            using World world = new World();

            Check.That(Regex.IsMatch(world.ToString(), "^World \\d*$")).IsTrue();
        }

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
        public void SetMaxCapacity_Should_return_true_When_maxCapacity_is_setted()
        {
            using World world = new World(0);

            Check.That(world.SetMaxCapacity<bool>(0)).IsTrue();
        }

        [Fact]
        public void SetMaxCapacity_Should_return_false_When_maxCapacity_is_already_setted()
        {
            using World world = new World(42);

            Check.That(world.SetMaxCapacity<bool>(0)).IsTrue();
            Check.That(world.SetMaxCapacity<bool>(42)).IsFalse();
        }

        [Fact]
        public void GetMaxCapacity_Should_return_component_max_capacity()
        {
            using World world = new World(100);

            world.SetMaxCapacity<bool>(42);
            Check.That(world.GetMaxCapacity<bool>()).IsEqualTo(42);
        }

        [Fact]
        public void GetMaxCapacity_Should_return_minus_one_when_not_handled()
        {
            using World world = new World(100);

            Check.That(world.GetMaxCapacity<bool>()).IsEqualTo(-1);
        }

        [Fact]
        public void GetMaxCapacity_Should_return_one_for_flag_type()
        {
            using World world = new World(100);

            world.SetMaxCapacity<FlagType>(42);
            Check.That(world.GetMaxCapacity<FlagType>()).IsEqualTo(1);
        }

        [Fact]
        public void SetMaxCapacity_Should_throw_When_maxCapacity_is_negative()
        {
            using World world = new World(0);

            Check.ThatCode(() => world.SetMaxCapacity<bool>(-1)).Throws<ArgumentException>();
        }

        [Fact]
        public void SetMaxCapacity_Should_not_throw_When_already_added()
        {
            using World world = new World(0);

            world.SetMaxCapacity<bool>(0);
            Check.ThatCode(() => world.SetMaxCapacity<bool>(0)).DoesNotThrow();
        }

        [Fact]
        public void Get_Should_not_throw_When_not_added()
        {
            using World world = new World(0);

            Check.ThatCode(() => world.Get<bool>()).DoesNotThrow();
        }

        [Fact]
        public void Get_Should_return_component()
        {
            using World world = new World(2);

            world.SetMaxCapacity<int>(2);
            Entity entity = world.CreateEntity();
            Entity entity2 = world.CreateEntity();

            entity.Set(1);
            entity2.Set(2);

            Span<int> components = world.Get<int>();

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

            world.SetMaxCapacity<int>(1);
            world.Get<long>();

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
        public void Optimize_Should_throw_When_runner_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.Optimize(null)).Throws<ArgumentNullException>();

            Check.ThatCode(() => world.Optimize(null, () => { })).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Optimize_Should_throw_When_action_is_null()
        {
            using World world = new World();
            using DefaultParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

            Check.ThatCode(() => world.Optimize(runner, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Optimize_Should_sort_inner_storages()
        {
            using World world = new World();
            using EntitySet set = world.GetEntities().With<int>().AsSet();

            Entity e1 = world.CreateEntity();
            Entity e2 = world.CreateEntity();
            Entity e3 = world.CreateEntity();
            Entity e4 = world.CreateEntity();

            e4.Set(4);
            e3.Set(3);
            e2.Set(2);
            e1.Set(1);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(e4, e3, e2, e1);
            Check.That(world.Get<int>().ToArray()).ContainsExactly(4, 3, 2, 1);

            world.Optimize();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(e1, e2, e3, e4);
            Check.That(world.Get<int>().ToArray()).ContainsExactly(1, 2, 3, 4);
        }

        [Fact]
        public void Optimize_Should_return_When_mainAction_is_done()
        {
            using World world = new World();
            using EntitySet set = world.GetEntities().With<int>().AsSet();
            using DefaultParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

            List<Entity> entities = Enumerable.Repeat(world, 100000).Select(w => w.CreateEntity()).ToList();

            int value = entities.Count;
            foreach (Entity entity in entities.AsEnumerable().Reverse())
            {
                entity.Set(value--);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities.AsEnumerable().Reverse());
            Check.That(world.Get<int>().ToArray()).ContainsExactly(Enumerable.Range(1, entities.Count).Reverse());

            world.Optimize(runner, () => Thread.Sleep(1));

            Check.That(set.GetEntities().ToArray().Select((e, i) => (i, e)).Any(t => entities[t.i] != t.e)).IsTrue();
            Check.That(world.Get<int>().ToArray().Select((v, i) => (i, v)).Any(t => t.i != t.v)).IsTrue();
        }

        [Fact]
        public void SubscribeEntityCreated_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeEntityCreated(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeEntityEnabled_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeEntityEnabled(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeEntityDisabled_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeEntityDisabled(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeEntityDisposed_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeEntityDisposed(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeEntityCreated_Should_call_handler_When_entity_created()
        {
            using World world = new World();

            Entity result = default;
            using IDisposable subscription = world.SubscribeEntityCreated((in Entity e) => result = e);

            Entity entity = world.CreateEntity();
            Check.That(result).IsEqualTo(entity);
        }

        [Fact]
        public void SubscribeEntityEnabled_Should_call_handler_When_entity_enabled()
        {
            using World world = new World();

            Entity entity = world.CreateEntity();
            Entity result = default;
            entity.Disable();
            using IDisposable subscription = world.SubscribeEntityEnabled((in Entity e) => result = e);

            entity.Enable();
            Check.That(result).IsEqualTo(entity);
        }

        [Fact]
        public void SubscribeEntityDisabled_Should_call_handler_When_entity_disabled()
        {
            using World world = new World();

            Entity entity = world.CreateEntity();
            Entity result = default;
            using IDisposable subscription = world.SubscribeEntityDisabled((in Entity e) => result = e);

            entity.Disable();
            Check.That(result).IsEqualTo(entity);
        }

        [Fact]
        public void SubscribeEntityDisposed_Should_call_handler_When_entity_disposed()
        {
            using World world = new World();

            Entity entity = world.CreateEntity();
            Entity result = default;
            using IDisposable subscription = world.SubscribeEntityDisposed((in Entity e) => result = e);

            entity.Dispose();
            Check.That(result).IsEqualTo(entity);
        }

        [Fact]
        public void SubscribeEntityDisposed_Should_call_handler_When_world_disposed()
        {
            World world = new World();

            Entity entity = world.CreateEntity();
            Entity result = default;
            using IDisposable subscription = world.SubscribeEntityDisposed((in Entity e) => result = e);

            world.Dispose();
            Check.That(result).IsEqualTo(entity);
        }

        [Fact]
        public void SubscribeComponentAdded_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeComponentAdded<bool>(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeComponentChanged_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeComponentChanged<bool>(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeComponentRemoved_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeComponentRemoved<bool>(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeComponentEnabled_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeComponentEnabled<bool>(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeComponentDisabled_Should_throw_When_action_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => world.SubscribeComponentDisabled<bool>(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void SubscribeComponentAdded_Should_call_handler_When_component_added()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentAdded((in Entity e, in bool v) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(v).IsTrue();
                called = true;
            });

            entity.Set(true);
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponentEnabled_Should_call_handler_When_component_enabled()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            entity.Disable<bool>();
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentEnabled((in Entity e, in bool v) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(v).IsTrue();
                called = true;
            });

            entity.Enable<bool>();
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponentDisabled_Should_call_handler_When_component_disabled()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentDisabled((in Entity e, in bool v) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(v).IsTrue();
                called = true;
            });

            entity.Disable<bool>();
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponentRemoved_Should_call_handler_When_component_removed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentRemoved((in Entity e, in bool v) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(v).IsTrue();
                called = true;
            });

            entity.Remove<bool>();
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponentRemoved_Should_call_handler_When_entity_disposed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentRemoved((in Entity e, in bool v) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(v).IsTrue();
                called = true;
            });

            entity.Dispose();
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponentRemoved_Should_call_handler_When_world_disposed()
        {
            World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(true);
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentRemoved((in Entity e, in bool v) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(v).IsTrue();
                called = true;
            });

            world.Dispose();
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponentChanged_Should_call_handler_When_component_changed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            entity.Set(false);
            bool called = false;
            using IDisposable subscription = world.SubscribeComponentChanged((in Entity e, in bool ov, in bool nv) =>
            {
                Check.That(e).IsEqualTo(entity);
                Check.That(ov).IsFalse();
                Check.That(nv).IsTrue();
                called = true;
            });

            entity.Set(true);
            Check.That(called).IsTrue();
        }

        [Fact]
        public void SubscribeComponent_Should_do_nothing_When_entity_disposed_without_component()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            using IDisposable added = world.SubscribeComponentAdded((in Entity _, in bool __) => throw new Exception());
            using IDisposable changed = world.SubscribeComponentChanged((in Entity _, in bool __, in bool ___) => throw new Exception());
            using IDisposable removed = world.SubscribeComponentRemoved((in Entity _, in bool __) => throw new Exception());
            using IDisposable enabled = world.SubscribeComponentEnabled((in Entity _, in bool __) => throw new Exception());
            using IDisposable disabled = world.SubscribeComponentDisabled((in Entity _, in bool __) => throw new Exception());

            Check.ThatCode(entity.Dispose).DoesNotThrow();
        }

        [Fact]
        public void SubscribeComponent_Should_do_nothing_When_world_disposed_without_component()
        {
            World world = new World();
            Entity entity = world.CreateEntity();
            using IDisposable added = world.SubscribeComponentAdded((in Entity _, in bool __) => throw new Exception());
            using IDisposable changed = world.SubscribeComponentChanged((in Entity _, in bool __, in bool ___) => throw new Exception());
            using IDisposable removed = world.SubscribeComponentRemoved((in Entity _, in bool __) => throw new Exception());
            using IDisposable enabled = world.SubscribeComponentEnabled((in Entity _, in bool __) => throw new Exception());
            using IDisposable disabled = world.SubscribeComponentDisabled((in Entity _, in bool __) => throw new Exception());

            Check.ThatCode(world.Dispose).DoesNotThrow();
        }

        [Fact]
        public void SubscribeComponent_Should_do_nothing_When_subscription_disposed()
        {
            using World world = new World();
            Entity entity = world.CreateEntity();
            world.SubscribeComponentAdded((in Entity _, in bool __) => throw new Exception()).Dispose();
            world.SubscribeComponentChanged((in Entity _, in bool __, in bool ___) => throw new Exception()).Dispose();
            world.SubscribeComponentRemoved((in Entity _, in bool __) => throw new Exception()).Dispose();
            world.SubscribeComponentEnabled((in Entity _, in bool __) => throw new Exception()).Dispose();
            world.SubscribeComponentDisabled((in Entity _, in bool __) => throw new Exception()).Dispose();

            Check.ThatCode(() => entity.Set(true)).DoesNotThrow();
        }

        #endregion
    }
}
