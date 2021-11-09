﻿using System;
using System.Linq;
using DefaultEcs.Command;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Command
{
    public sealed class EntityCommandRecorderTest
    {
        private struct NonBlittable
        {
            public readonly int Id;
            public readonly object Item;

            public NonBlittable(int id, object item)
            {
                Id = id;
                Item = item;
            }
        }

        #region Tests

        [Fact]
        public void Record_Should_throw_When_world_is_null()
        {
            using EntityCommandRecorder recorder = new(1024);

            Check.ThatCode(() => recorder.Record(default)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void CreateEntity_Should_create_an_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            WorldRecord record = recorder.Record(world);

            record.CreateEntity();
            record.CreateEntity();
            record.CreateEntity();
            record.CreateEntity();
            record.CreateEntity();

            recorder.Execute();

            Check.That(world.Count()).IsEqualTo(5);
        }

        [Fact]
        public void Set_Should_set_blittable_component_on_world()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            recorder.Record(world).Set<int>();

            recorder.Execute();

            Check.That(world.Get<int>()).IsEqualTo(0);
        }

        [Fact]
        public void Set_Should_set_non_blittable_component_on_world()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            recorder.Record(world).Set("kikoo");

            recorder.Execute();

            Check.That(world.Get<string>()).IsEqualTo("kikoo");
        }

        [Fact]
        public void Remove_Should_remove_component_from_world()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            world.Set(42);
            recorder.Record(world).Remove<int>();

            recorder.Execute();

            Check.That(world.Has<string>()).IsFalse();
        }

        [Fact]
        public void Disable_Should_disable_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();

            EntityRecord record = recorder.Record(entity);
            record.Disable();

            recorder.Execute();

            Check.That(entity.IsEnabled()).IsFalse();
        }

        [Fact]
        public void Disable_Should_disable_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Disable();

            recorder.Execute();

            Check.That(world.Single().IsEnabled()).IsFalse();
        }

        [Fact]
        public void Enable_Should_enable_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Disable();

            EntityRecord record = recorder.Record(entity);
            record.Enable();

            recorder.Execute();

            Check.That(entity.IsEnabled()).IsTrue();
        }

        [Fact]
        public void Enable_Should_enable_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Disable();
            record.Enable();

            recorder.Execute();

            Check.That(world.Single().IsEnabled()).IsTrue();
        }

        [Fact]
        public void Set_Should_set_blittable_component_on_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();

            EntityRecord record = recorder.Record(entity);
            record.Set<bool>();

            recorder.Execute();

            Check.That(entity.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Set_Should_set_blittable_component_on_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(true);

            recorder.Execute();

            Check.That(world.Single().Get<bool>()).IsTrue();
        }

        [Fact]
        public void Set_Should_set_reference_component_on_recorded_entity()
        {
            object o = new();
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();

            EntityRecord record = recorder.Record(entity);
            record.Set(o);

            recorder.Execute();

            Check.That(entity.Get<object>()).IsEqualTo(o);
        }

        [Fact]
        public void Set_Should_set_reference_component_on_created_entity()
        {
            object o = new();
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(o);

            recorder.Execute();

            Check.That(world.Single().Get<object>()).IsEqualTo(o);
        }

        [Fact]
        public void Set_Should_set_non_blittable_component_on_recorded_entity()
        {
            object o = new();
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();

            EntityRecord record = recorder.Record(entity);
            record.Set(new NonBlittable(42, o));

            recorder.Execute();

            Check.That(entity.Get<NonBlittable>().Id).IsEqualTo(42);
            Check.That(entity.Get<NonBlittable>().Item).IsEqualTo(o);
        }

        [Fact]
        public void Set_Should_set_non_blittable_component_on_created_entity()
        {
            object o = new();
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(new NonBlittable(42, o));

            recorder.Execute();

            Check.That(world.Single().Get<NonBlittable>().Id).IsEqualTo(42);
            Check.That(world.Single().Get<NonBlittable>().Item).IsEqualTo(o);
        }

        [Fact]
        public void DisableT_Should_disable_component_of_type_T_on_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(true);

            EntityRecord record = recorder.Record(entity);
            record.Disable<bool>();

            recorder.Execute();

            Check.That(entity.IsEnabled<bool>()).IsFalse();
        }

        [Fact]
        public void DisableT_Should_disable_component_of_type_T_on_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(true);
            record.Disable<bool>();

            recorder.Execute();

            Check.That(world.Single().IsEnabled<bool>()).IsFalse();
        }

        [Fact]
        public void EnableT_Should_enable_component_of_type_T_on_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(true);
            entity.Disable<bool>();

            EntityRecord record = recorder.Record(entity);
            record.Enable<bool>();

            recorder.Execute();

            Check.That(entity.IsEnabled()).IsTrue();
        }

        [Fact]
        public void EnableT_Should_enable_component_of_type_T_on_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(true);
            record.Disable<bool>();
            record.Enable<bool>();

            recorder.Execute();

            Check.That(world.Single().IsEnabled()).IsTrue();
        }

        [Fact]
        public void Remove_Should_remove_component_on_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(true);

            EntityRecord record = recorder.Record(entity);
            record.Remove<bool>();

            recorder.Execute();

            Check.That(entity.Has<bool>()).IsFalse();
        }

        [Fact]
        public void Remove_Should_remove_component_on_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(true);
            record.Remove<bool>();

            recorder.Execute();

            Check.That(world.Single().Has<bool>()).IsFalse();
        }

        [Fact]
        public void NotifyChanged_Should_change_component_on_recorded_entity()
        {
            Entity result = default;

            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(true);

            using IDisposable changed = world.SubscribeComponentChanged((in Entity e, in bool _, in bool _) => result = e);

            recorder.Record(entity).NotifyChanged<bool>();

            recorder.Execute();

            Check.That(result).IsEqualTo(world.Single());
        }

        [Fact]
        public void NotifyChanged_Should_change_component_on_created_entity()
        {
            Entity result = default;

            using EntityCommandRecorder recorder = new(1024);
            using World world = new();
            using IDisposable changed = world.SubscribeComponentChanged((in Entity e, in bool _, in bool _) => result = e);

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Set(true);
            record.NotifyChanged<bool>();

            recorder.Execute();

            Check.That(result).IsEqualTo(world.Single());
        }

        [Fact]
        public void Dispose_Should_dispose_recorded_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();

            EntityRecord record = recorder.Record(entity);
            record.Dispose();

            recorder.Execute();

            Check.That(entity.IsAlive).IsFalse();
        }

        [Fact]
        public void Dispose_Should_dispose_created_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            EntityRecord record = recorder.Record(world).CreateEntity();
            record.Dispose();

            recorder.Execute();

            Check.That(world.Count()).IsEqualTo(0);
        }

        //[Fact]
        //public void SetSameAs_Should_set_same_as_on_recorded_entity()
        //{
        //    using EntityCommandRecorder recorder = new(1024);
        //    using World world = new();

        //    Entity reference = world.CreateEntity();
        //    reference.Set(true);
        //    Entity entity = world.CreateEntity();

        //    EntityRecord record = recorder.Record(entity);
        //    record.SetSameAs<bool>(recorder.Record(reference));

        //    recorder.Execute();

        //    Check.That(entity.Get<bool>()).IsTrue();
        //}

        //[Fact]
        //public void SetSameAs_Should_set_same_as_on_created_entity()
        //{
        //    using EntityCommandRecorder recorder = new(1024);
        //    using World world = new();

        //    Entity reference = world.CreateEntity();
        //    reference.Set(true);

        //    EntityRecord record = recorder.Record(world).CreateEntity();
        //    record.SetSameAs<bool>(recorder.Record(reference));

        //    recorder.Execute();

        //    reference.Dispose();

        //    Check.That(world.Single().Get<bool>()).IsTrue();
        //}

        //[Fact]
        //public void SetSameAsWorld_Should_set_same_as_on_created_entity()
        //{
        //    using EntityCommandRecorder recorder = new(1024);
        //    using World world = new();

        //    world.Set(true);

        //    EntityRecord record = recorder.Record(world).CreateEntity();
        //    record.SetSameAsWorld<bool>();

        //    recorder.Execute();

        //    Check.That(world.Single().Get<bool>()).IsTrue();
        //}

        [Fact]
        public void Should_work_in_multithread()
        {
            using EntityCommandRecorder recorder = new(8, int.MaxValue);
            using World world = new();

            Enumerable.Range(0, 100000).AsParallel().ForAll(_ => recorder.Record(world).CreateEntity());

            recorder.Execute();

            Check.That(world.Count()).IsEqualTo(100000);
        }

        [Fact]
        public void EntityCommandRecorder_Should_throw_When_maxCapacity_inferior_to_zero()
        {
            Check.ThatCode(() => new EntityCommandRecorder(-1)).Throws<ArgumentException>();
        }

        [Fact]
        public void EntityCommandRecorder_Should_throw_When_defaultCapacity_inferior_to_zero()
        {
            Check.ThatCode(() => new EntityCommandRecorder(-1, 42)).Throws<ArgumentException>();
        }

        [Fact]
        public void EntityCommandRecorder_Should_throw_When_maxCapacity_inferior_to_defaultCapacity()
        {
            Check.ThatCode(() => new EntityCommandRecorder(1337, 42)).Throws<ArgumentException>();
        }

        [Fact]
        public void Shoud_throw_When_no_more_space()
        {
            using EntityCommandRecorder recorder = new(8, 16);
            using World world = new();

            Check.That(recorder.Size).IsZero();
            Check.That(recorder.Capacity).IsEqualTo(8);
            Check.That(recorder.MaxCapacity).IsEqualTo(16);

            recorder.Record(world).CreateEntity();

            Check.That(recorder.Size).IsEqualTo(9);
            Check.That(recorder.Capacity).IsEqualTo(recorder.MaxCapacity);

            Check.ThatCode(() => recorder.Record(world).CreateEntity()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Execute_Should_clear_recorded_command_after_executing()
        {
            using EntityCommandRecorder recorder = new();
            using World world = new();

            recorder.Record(world).CreateEntity();

            Check.That(recorder.Size).IsNotZero();

            recorder.Execute();

            Check.That(world.Count()).IsEqualTo(1);

            Check.That(recorder.Size).IsZero();

            recorder.Execute();

            Check.That(world.Count()).IsEqualTo(1);
        }

        [Fact]
        public void Clear_Should_clear_recorded_command()
        {
            using EntityCommandRecorder recorder = new(5, 10);
            using World world = new();

            recorder.Record(world).CreateEntity();

            Check.That(recorder.Size).IsNotZero();

            recorder.Clear();

            Check.That(recorder.Size).IsZero();

            recorder.Execute();

            Check.That(world.Count()).IsZero();
        }

        [Fact]
        public void CopyTo_Should_throw_When_cloner_is_null()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Check.ThatCode(() => recorder.Record(world).CreateEntity().CopyTo(world, default)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void CopyTo_Should_clone_entity()
        {
            using EntityCommandRecorder recorder = new(1024);
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            EntityRecord record = recorder.Record(entity);

            record.CopyTo(world);

            recorder.Execute();

            Check.That(world.GetEntities().With((in int i) => i == 42).AsEnumerable().Count()).IsEqualTo(2);
        }

        #endregion
    }
}
