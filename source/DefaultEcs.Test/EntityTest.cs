using System;
using System.Collections.Generic;
using DefaultEcs.Message;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public class EntityTest
    {
        #region Tests

        [Fact]
        public void Has_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Has<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Has_Should_return_false_When_World_does_not_have_component()
        {
            using (World world = new World(1))
            {
                Entity entity = world.CreateEntity();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Has_Should_return_false_When_Entity_does_not_have_component()
        {
            using (World world = new World(1))
            {
                world.AddComponentType<bool>(0);

                Entity entity = world.CreateEntity();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Has_Should_return_true_When_Entity_has_component()
        {
            using (World world = new World(1))
            {
                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();
                entity.Set(true);

                Check.That(entity.Has<bool>()).IsTrue();
            }
        }

        [Fact]
        public void Set_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Set(true)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Set_Should_throw_When_component_type_not_added_to_World()
        {
            using (World world = new World(1))
            {
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.Set(true)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void Set_Should_throw_When_max_number_of_component_reached()
        {
            using (World world = new World(1))
            {
                world.AddComponentType<bool>(0);
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.Set(true)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void Set_Should_set_component_value()
        {
            using (World world = new World(1))
            {
                world.AddComponentType<bool>(1);
                Entity entity = world.CreateEntity();

                entity.Set(true);

                Check.That(entity.Get<bool>()).IsTrue();
            }
        }

        [Fact]
        public void Set_Should_publish_ComponentSettedMessage_When_setted_for_the_first_time()
        {
            using (World world = new World(2))
            {
                ComponentSettedMessage<bool> message = default;

                world.Subscribe<ComponentSettedMessage<bool>>(m => message = m);

                world.AddComponentType<bool>(1);
                world.CreateEntity();
                Entity entity = world.CreateEntity();

                entity.Set(true);

                Check.That(message.Entity).IsEqualTo(entity);
            }
        }

        [Fact]
        public void Set_Should_not_publish_ComponentSettedMessage_When_not_setted_for_the_first_time()
        {
            using (World world = new World(2))
            {
                bool done = false;

                world.AddComponentType<bool>(1);
                world.CreateEntity();
                Entity entity = world.CreateEntity();

                entity.Set(true);

                world.Subscribe<ComponentSettedMessage<bool>>(m => done = true);

                entity.Set(true);

                Check.That(done).IsFalse();
            }
        }

        [Fact]
        public void SetSameAs_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.SetSameAs<bool>(default)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetSameAs_Should_throw_When_reference_not_created_from_World()
        {
            using (World world = new World(1))
            {
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.SetSameAs<bool>(default)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void SetSameAs_Should_throw_When_component_type_not_added_to_World()
        {
            using (World world = new World(2))
            {
                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                Check.ThatCode(() => entity.SetSameAs<bool>(reference)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void SetSameAs_Should_throw_When_reference_comes_from_a_different_World()
        {
            using (World world = new World(1))
            using (World worldRef = new World(1))
            {
                Entity entity = world.CreateEntity();
                Entity reference = worldRef.CreateEntity();

                Check.ThatCode(() => entity.SetSameAs<bool>(reference)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void SetSameAs_Should_throw_When_reference_does_not_have_a_component()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                Check.ThatCode(() => entity.SetSameAs<bool>(reference)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void SetSameAs_Should_set_component_to_reference()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(false);
                entity.SetSameAs<bool>(reference);

                Check.That(entity.Get<bool>()).IsEqualTo(reference.Get<bool>());

                reference.Set(true);

                Check.That(entity.Get<bool>()).IsEqualTo(reference.Get<bool>());

                entity.Set(false);

                Check.That(reference.Get<bool>()).IsEqualTo(entity.Get<bool>());
            }
        }

        [Fact]
        public void SetSameAs_Should_publish_ComponentSettedMessage_When_setted_for_the_first_time()
        {
            using (World world = new World(2))
            {
                ComponentSettedMessage<bool> message = default;

                world.AddComponentType<bool>(1);
                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);

                world.Subscribe<ComponentSettedMessage<bool>>(m => message = m);

                entity.SetSameAs<bool>(reference);

                Check.That(message.Entity).IsEqualTo(entity);
            }
        }

        [Fact]
        public void SetSameAs_Should_not_publish_ComponentSettedMessage_When_not_setted_for_the_first_time()
        {
            using (World world = new World(2))
            {
                bool done = false;

                world.AddComponentType<bool>(2);
                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);
                entity.Set(true);

                world.Subscribe<ComponentSettedMessage<bool>>(m => done = true);

                entity.SetSameAs<bool>(reference);

                Check.That(done).IsFalse();
            }
        }

        [Fact]
        public void Remove_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Remove<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Remove_Should_remove_component()
        {
            using (World world = new World(1))
            {
                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();

                entity.Set(true);

                Check.That(entity.Has<bool>()).IsTrue();

                entity.Remove<bool>();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Remove_Should_publish_ComponentRemovedMessage_When_component_removed()
        {
            using (World world = new World(1))
            {
                ComponentRemovedMessage<bool> message = default;

                world.AddComponentType<bool>(1);
                world.Subscribe<ComponentRemovedMessage<bool>>(m => message = m);

                Entity entity = world.CreateEntity();

                entity.Set(true);
                entity.Remove<bool>();
                Check.That(message.Entity).IsEqualTo(entity);
            }
        }

        [Fact]
        public void Remove_Should_not_publish_ComponentRemovedMessage_When_does_not_have_component()
        {
            using (World world = new World(1))
            {
                bool done = false;
                world.Subscribe<ComponentSettedMessage<bool>>(m => done = true);

                Entity entity = world.CreateEntity();

                entity.Remove<bool>();
                Check.That(done).IsFalse();
            }
        }

        [Fact]
        public void Remove_Should_remove_component_without_removing_reference()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);
                entity.SetSameAs<bool>(reference);

                entity.Remove<bool>();

                Check.That(entity.Has<bool>()).IsFalse();
                Check.That(reference.Has<bool>()).IsTrue();
            }
        }

        [Fact]
        public void Remove_Should_remove_component_of_all_referenced_Entity()
        {
            using (World world = new World(3))
            {
                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();
                world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);
                entity.SetSameAs<bool>(reference);

                reference.Remove<bool>();

                Check.That(entity.Has<bool>()).IsFalse();
                Check.That(reference.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Remove_Should_publish_ComponentRemovedMessage_for_all_referenced_Entity()
        {
            using (World world = new World(4))
            {
                List<Entity> messages = new List<Entity>();
                world.Subscribe<ComponentRemovedMessage<bool>>(m => messages.Add(m.Entity));

                world.AddComponentType<bool>(1);

                Entity entity = world.CreateEntity();
                Entity entity2 = world.CreateEntity();
                world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);
                entity.SetSameAs<bool>(reference);
                entity2.SetSameAs<bool>(reference);

                reference.Remove<bool>();

                Check.That(messages).IsOnlyMadeOf(new[] { entity, entity2, reference });
            }
        }

        [Fact]
        public void Get_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Get<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Get_Should_throw_When_component_type_not_added_to_World()
        {
            using (World world = new World(2))
            {
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.Get<bool>()).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void Get_Should_throw_When_Entity_does_not_have_component()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<bool>(0);
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.Get<bool>()).Throws<IndexOutOfRangeException>();
            }
        }

        [Fact]
        public void Get_Should_get_component()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<bool>(1);
                Entity entity = world.CreateEntity();

                entity.Set(true);

                Check.That(entity.Get<bool>()).IsTrue();

                entity.Set(false);

                Check.That(entity.Get<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Get_Should_get_component_of_reference_When_is_same_as()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<bool>(1);
                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);
                entity.SetSameAs<bool>(reference);

                Check.That(entity.Get<bool>()).IsTrue();

                reference.Set(false);

                Check.That(entity.Get<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Clean_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Clean()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Clean_Should_release_Entity()
        {
            using (World world = new World(2))
            {
                Entity deletedEntity = world.CreateEntity();

                deletedEntity.Clean();

                Entity entity = world.CreateEntity();

                Check.That(entity).IsEqualTo(deletedEntity);
            }
        }

        [Fact]
        public void Clean_Should_publish_EntityCleanedMessage()
        {
            using (World world = new World(2))
            {
                Entity deletedEntity = default;
                Entity entity = world.CreateEntity();

                world.Subscribe<EntityCleanedMessage>(m => deletedEntity = m.Entity);

                entity.Clean();

                Check.That(deletedEntity).IsEqualTo(entity);
            }
        }

        [Fact]
        public void Clean_Should_publish_ComponentRemovedMessage_for_all_component()
        {
            using (World world = new World(2))
            {
                ComponentRemovedMessage<bool> message = default;

                world.Subscribe<ComponentRemovedMessage<bool>>(m => message = m);

                world.AddComponentType<bool>(1);
                world.CreateEntity();
                Entity deletedEntity = world.CreateEntity();
                deletedEntity.Set(true);
                
                deletedEntity.Clean();

                Check.That(message.Entity).IsEqualTo(deletedEntity);

                Entity entity = world.CreateEntity();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        #endregion
    }
}
