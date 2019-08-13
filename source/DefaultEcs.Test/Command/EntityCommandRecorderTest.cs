using System;
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
        public void CreateEntity_Should_create_an_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            {
                recorder.CreateEntity();
                recorder.CreateEntity();
                recorder.CreateEntity();
                recorder.CreateEntity();
                recorder.CreateEntity();

                using (World world = new World())
                {
                    recorder.Execute(world);

                    Check.That(world.GetAllEntities().Count()).IsEqualTo(5);
                }
            }
        }

        [Fact]
        public void Disable_Should_disable_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.Disable();

                recorder.Execute(world);

                Check.That(entity.IsEnabled()).IsFalse();
            }
        }

        [Fact]
        public void Disable_Should_disable_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Disable();

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().IsEnabled()).IsFalse();
            }
        }

        [Fact]
        public void Enable_Should_enable_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();
                entity.Disable();

                EntityRecord record = recorder.Record(entity);
                record.Enable();

                recorder.Execute(world);

                Check.That(entity.IsEnabled()).IsTrue();
            }
        }

        [Fact]
        public void Enable_Should_enable_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Disable();
                record.Enable();

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().IsEnabled()).IsTrue();
            }
        }

        [Fact]
        public void Set_Should_set__blittable_component_on_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.Set(true);

                recorder.Execute(world);

                Check.That(entity.Get<bool>()).IsTrue();
            }
        }

        [Fact]
        public void Set_Should_set__blittable_component_on_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            {
                using (World world = new World())
                {
                    EntityRecord record = recorder.CreateEntity();
                    record.Set(true);

                    recorder.Execute(world);

                    Check.That(world.GetAllEntities().Single().Get<bool>()).IsTrue();
                }
            }
        }

        [Fact]
        public void Set_Should_set__reference_component_on_recorded_entity()
        {
            object o = new object();
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.Set(o);

                recorder.Execute(world);

                Check.That(entity.Get<object>()).IsEqualTo(o);
            }
        }

        [Fact]
        public void Set_Should_set__reference_component_on_created_entity()
        {
            object o = new object();
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Set(o);

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().Get<object>()).IsEqualTo(o);
            }
        }

        [Fact]
        public void Set_Should_set__non_blittable_component_on_recorded_entity()
        {
            object o = new object();
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.Set(new NonBlittable(42, o));

                recorder.Execute(world);

                Check.That(entity.Get<NonBlittable>().Id).IsEqualTo(42);
                Check.That(entity.Get<NonBlittable>().Item).IsEqualTo(o);
            }
        }

        [Fact]
        public void Set_Should_set__non_blittable_component_on_created_entity()
        {
            object o = new object();
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Set(new NonBlittable(42, o));

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().Get<NonBlittable>().Id).IsEqualTo(42);
                Check.That(world.GetAllEntities().Single().Get<NonBlittable>().Item).IsEqualTo(o);
            }
        }

        [Fact]
        public void DisableT_Should_disable_component_of_type_T_on_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();
                entity.Set(true);

                EntityRecord record = recorder.Record(entity);
                record.Disable<bool>();

                recorder.Execute(world);

                Check.That(entity.IsEnabled<bool>()).IsFalse();
            }
        }

        [Fact]
        public void DisableT_Should_disable_component_of_type_T_on_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Set(true);
                record.Disable<bool>();

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().IsEnabled<bool>()).IsFalse();
            }
        }

        [Fact]
        public void EnableT_Should_enable_component_of_type_T_on_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();
                entity.Set(true);
                entity.Disable<bool>();

                EntityRecord record = recorder.Record(entity);
                record.Enable<bool>();

                recorder.Execute(world);

                Check.That(entity.IsEnabled()).IsTrue();
            }
        }

        [Fact]
        public void EnableT_Should_enable_component_of_type_T_on_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Set(true);
                record.Disable<bool>();
                record.Enable<bool>();

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().IsEnabled()).IsTrue();
            }
        }

        [Fact]
        public void Remove_Should_remove_component_on_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();
                entity.Set(true);

                EntityRecord record = recorder.Record(entity);
                record.Remove<bool>();

                recorder.Execute(world);

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Remove_Should_remove_component_on_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Set(true);
                record.Remove<bool>();

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Single().Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Dispose_Should_dispose_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.Dispose();

                recorder.Execute(world);

                Check.That(entity.IsAlive).IsFalse();
            }
        }

        [Fact]
        public void Dispose_Should_dispose_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                EntityRecord record = recorder.CreateEntity();
                record.Dispose();

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Count()).IsEqualTo(0);
            }
        }

        [Fact]
        public void SetSameAs_Should_set_same_as_on_recorded_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity reference = world.CreateEntity();
                reference.Set(true);
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.SetSameAs<bool>(recorder.Record(reference));

                recorder.Execute(world);

                Check.That(entity.Get<bool>()).IsTrue();
            }
        }

        [Fact]
        public void SetSameAs_Should_set_same_as_on_created_entity()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity reference = world.CreateEntity();
                reference.Set(true);

                EntityRecord record = recorder.CreateEntity();
                record.SetSameAs<bool>(recorder.Record(reference));

                recorder.Execute(world);

                reference.Dispose();

                Check.That(world.GetAllEntities().Single().Get<bool>()).IsTrue();
            }
        }

        [Fact]
        public void SetAsChildOf_Should_set_recorded_entity_as_child()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity parent = world.CreateEntity();
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.SetAsChildOf(recorder.Record(parent));

                recorder.Execute(world);

                Check.That(parent.GetChildren()).Contains(entity);
            }
        }

        [Fact]
        public void SetAsParentOf_Should_set_recorded_entity_as_parent()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity child = world.CreateEntity();
                Entity entity = world.CreateEntity();

                EntityRecord record = recorder.Record(entity);
                record.SetAsParentOf(recorder.Record(child));

                recorder.Execute(world);

                Check.That(entity.GetChildren()).Contains(child);
            }
        }

        [Fact]
        public void SetAsChildOf_Should_set_created_entity_as_child()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity parent = world.CreateEntity();

                EntityRecord record = recorder.CreateEntity();
                record.SetAsChildOf(recorder.Record(parent));

                recorder.Execute(world);

                Check.That(parent.GetChildren()).Contains(world.GetAllEntities().Skip(1).Single());
            }
        }

        [Fact]
        public void SetAsParentOf_Should_set_created_entity_as_child()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity child = world.CreateEntity();

                EntityRecord record = recorder.CreateEntity();
                record.SetAsParentOf(recorder.Record(child));

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Skip(1).Single().GetChildren()).Contains(child);
            }
        }

        [Fact]
        public void RemoveFromChildrenOf_Should_set_recorded_entity_as_child()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity parent = world.CreateEntity();
                Entity entity = world.CreateEntity();
                entity.SetAsChildOf(parent);

                EntityRecord record = recorder.Record(entity);
                record.RemoveFromChildrenOf(recorder.Record(parent));

                recorder.Execute(world);

                Check.That(parent.GetChildren()).IsEmpty();
            }
        }

        [Fact]
        public void RemoveFromParentsOf_Should_set_recorded_entity_as_parent()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity child = world.CreateEntity();
                Entity entity = world.CreateEntity();
                entity.SetAsParentOf(child);

                EntityRecord record = recorder.Record(entity);
                record.RemoveFromParentsOf(recorder.Record(child));

                recorder.Execute(world);

                Check.That(entity.GetChildren()).IsEmpty();
            }
        }

        [Fact]
        public void RemoveFromChildrenOf_Should_set_created_entity_as_child()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity parent = world.CreateEntity();

                EntityRecord parentRecord = recorder.Record(parent);
                EntityRecord record = recorder.CreateEntity();
                record.SetAsChildOf(parentRecord);
                record.RemoveFromChildrenOf(parentRecord);

                recorder.Execute(world);

                Check.That(parent.GetChildren()).IsEmpty();
            }
        }

        [Fact]
        public void RemoveFromParentsOf_Should_set_created_entity_as_child()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(1024))
            using (World world = new World())
            {
                Entity child = world.CreateEntity();

                EntityRecord childRecord = recorder.Record(child);
                EntityRecord record = recorder.CreateEntity();
                record.SetAsParentOf(childRecord);
                record.RemoveFromParentsOf(childRecord);

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Skip(1).Single().GetChildren()).IsEmpty();
            }
        }

        [Fact]
        public void Should_work_in_multithread()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(8, int.MaxValue))
            using (World world = new World())
            {
                Enumerable.Range(0, 100000).AsParallel().ForAll(_ => recorder.CreateEntity());

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Count()).IsEqualTo(100000);
            }
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
            using (EntityCommandRecorder recorder = new EntityCommandRecorder(16))
            {
                recorder.CreateEntity();

                Check.ThatCode(() => recorder.CreateEntity()).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void Execute_Should_clear_recorded_command_after_executing()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder())
            using (World world = new World())
            {
                recorder.CreateEntity();
                recorder.Execute(world);

                Check.That(world.GetAllEntities().Count()).IsEqualTo(1);

                recorder.Execute(world);

                Check.That(world.GetAllEntities().Count()).IsEqualTo(1);
            }
        }

        [Fact]
        public void Clear_Should_clear_recorded_command()
        {
            using (EntityCommandRecorder recorder = new EntityCommandRecorder())
            using (World world = new World())
            {
                recorder.CreateEntity();
                recorder.Clear();
                recorder.Execute(world);

                Check.That(world.GetAllEntities().Count()).IsZero();
            }
        }

        #endregion
    }
}
