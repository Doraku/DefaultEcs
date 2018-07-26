using System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public class EntityTest
    {
        #region Tests

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
                world.SetComponentTypeMaximumCount<bool>(0);

                Entity entity = world.CreateEntity();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Has_Should_return_true_When_Entity_has_component()
        {
            using (World world = new World(1))
            {
                world.SetComponentTypeMaximumCount<bool>(1);

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
        public void Set_Should_throw_When_max_number_of_component_reached()
        {
            using (World world = new World(1))
            {
                world.SetComponentTypeMaximumCount<bool>(0);
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.Set(true)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void Set_Should_set_component_value()
        {
            using (World world = new World(1))
            {
                world.SetComponentTypeMaximumCount<bool>(1);
                Entity entity = world.CreateEntity();

                entity.Set(true);

                Check.That(entity.Get<bool>()).IsTrue();
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
                world.SetComponentTypeMaximumCount<bool>(1);

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
                world.SetComponentTypeMaximumCount<bool>(1);

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
        public void Remove_Should_remove_component()
        {
            using (World world = new World(1))
            {
                world.SetComponentTypeMaximumCount<bool>(1);

                Entity entity = world.CreateEntity();

                entity.Set(true);

                Check.That(entity.Has<bool>()).IsTrue();

                entity.Remove<bool>();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Remove_Should_remove_component_without_removing_reference()
        {
            using (World world = new World(2))
            {
                world.SetComponentTypeMaximumCount<bool>(1);

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
        public void Remove_Should_remove_component_and_pass_reference()
        {
            using (World world = new World(3))
            {
                world.SetComponentTypeMaximumCount<bool>(2);

                Entity entity = world.CreateEntity();
                Entity reference = world.CreateEntity();
                Entity other = world.CreateEntity();

                reference.Set(true);
                entity.SetSameAs<bool>(reference);

                reference.Remove<bool>();
                other.Set(false);

                Check.That(entity.Has<bool>()).IsTrue();
                Check.That(reference.Has<bool>()).IsFalse();

                Check.That(entity.Get<bool>()).IsTrue();
            }
        }

        [Fact]
        public void Remove_Should_not_remove_component_of_all_referenced_Entity()
        {
            using (World world = new World(3))
            {
                world.SetComponentTypeMaximumCount<bool>(1);

                Entity entity = world.CreateEntity();
                world.CreateEntity();
                Entity reference = world.CreateEntity();

                reference.Set(true);
                entity.SetSameAs<bool>(reference);

                reference.Remove<bool>();

                Check.That(entity.Has<bool>()).IsTrue();
                Check.That(reference.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Get_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Get<bool>()).Throws<Exception>();
        }

        [Fact]
        public void Get_Should_throw_When_Entity_does_not_have_component()
        {
            using (World world = new World(2))
            {
                Entity entity = world.CreateEntity();

                Check.ThatCode(() => entity.Get<bool>()).Throws<Exception>();

                entity.Set(true);
                entity.Remove<bool>();

                Check.ThatCode(() => entity.Get<bool>()).Throws<Exception>();
            }
        }

        [Fact]
        public void Get_Should_get_component()
        {
            using (World world = new World(2))
            {
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
        public void Dispose_Should_release_Entity()
        {
            using (World world = new World(2))
            {
                Entity deletedEntity = world.CreateEntity();

                deletedEntity.Dispose();

                Entity entity = world.CreateEntity();

                Check.That(entity).IsEqualTo(deletedEntity);
            }
        }

        [Fact]
        public void Dispose_Should_remove_all_component()
        {
            using (World world = new World(2))
            {
                world.SetComponentTypeMaximumCount<bool>(1);
                world.CreateEntity();
                Entity deletedEntity = world.CreateEntity();
                deletedEntity.Set(true);

                Check.That(deletedEntity.Has<bool>()).IsTrue();

                deletedEntity.Dispose();
                Check.That(deletedEntity.Has<bool>()).IsFalse();

                Entity entity = world.CreateEntity();

                Check.That(entity.Has<bool>()).IsFalse();
            }
        }

        [Fact]
        public void Dispose_Should_dispose_children_When_SetAsChildOf()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().Build())
            {
                Entity parent = world.CreateEntity();
                Entity other = world.CreateEntity();
                Entity child1 = world.CreateEntity();
                Entity child2 = world.CreateEntity();

                child1.SetAsChildOf(parent);
                child2.SetAsChildOf(parent);

                Check.That(set.GetEntities().Length).IsEqualTo(4);

                parent.Dispose();

                Check.That(set.GetEntities().Length).IsEqualTo(1);
                Check.That(set.GetEntities()[0]).IsEqualTo(other);
            }
        }

        [Fact]
        public void Dispose_Should_dispose_children_When_SetAsParentOf()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().Build())
            {
                Entity parent = world.CreateEntity();
                Entity other = world.CreateEntity();
                Entity child1 = world.CreateEntity();
                Entity child2 = world.CreateEntity();

                parent.SetAsParentOf(child1);
                parent.SetAsParentOf(child2);

                Check.That(set.GetEntities().Length).IsEqualTo(4);

                parent.Dispose();

                Check.That(set.GetEntities().Length).IsEqualTo(1);
                Check.That(set.GetEntities()[0]).IsEqualTo(other);
            }
        }

        [Fact]
        public void Dispose_Should_not_throw_When_dependency_graph_is_circular()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().Build())
            {
                Entity entity1 = world.CreateEntity();
                Entity other = world.CreateEntity();
                Entity entity2 = world.CreateEntity();
                Entity entity3 = world.CreateEntity();

                entity1.SetAsParentOf(entity2);
                entity2.SetAsParentOf(entity3);
                entity3.SetAsParentOf(entity1);

                Check.That(set.GetEntities().Length).IsEqualTo(4);

                Check.ThatCode(entity1.Dispose).Not.ThrowsAny();

                Check.That(set.GetEntities().Length).IsEqualTo(1);
                Check.That(set.GetEntities()[0]).IsEqualTo(other);
            }
        }

        [Fact]
        public void SetAsParentOf_Should_throw_When_Entity_not_created_from_a_World()
        {
            Entity parent = default;
            Entity child = default;

            Check.ThatCode(() => parent.SetAsParentOf(child)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetAsParentOf_Should_throw_When_parent_and_child_not_created_from_same_World()
        {
            using (World world1 = new World(1))
            using (World world2 = new World(1))
            {

                Entity parent = world1.CreateEntity();
                Entity child = world2.CreateEntity();

                Check.ThatCode(() => parent.SetAsParentOf(child)).Throws<InvalidOperationException>();
            }
        }

        #endregion
    }
}
