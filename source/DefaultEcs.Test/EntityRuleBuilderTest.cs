using System;
using System.Collections.Generic;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntityRuleBuilderTest
    {
        #region Tests

        [Fact]
        public void With_Should_throw_When_predicate_is_null()
        {
            using World world = new();

            Check.ThatCode(() => world.GetEntities().With<bool>(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Copy_Should_return_different_instance()
        {
            using World world = new();

            EntityRuleBuilder builder = world.GetEntities().WithEither<bool>().WithoutEither<double>().With((in bool b) => b);
            EntityRuleBuilder copy = builder.Copy();

            Check.That(copy).IsNotEqualTo(builder);

            using EntitySet s1 = builder.With<int>().AsSet();
            using EntitySet s2 = copy.Without<int>().AsSet();

            Entity e = world.CreateEntity();
            Entity e1 = world.CreateEntity();
            Entity e2 = world.CreateEntity();

            e.Set(false);
            e1.Set(true);
            e1.Set(42);
            e2.Set(true);

            Check.That(s1.GetEntities().ToArray()).ContainsExactly(e1);
            Check.That(s2.GetEntities().ToArray()).ContainsExactly(e2);
        }

        [Fact]
        public void AsSet_Should_return_EntitySet_with_all_Entity()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            entities[2].Dispose();
            entities.RemoveAt(2);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_With_T_Should_return_EntitySet_with_all_Entity_with_component_T()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().With<bool>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            entities[2].Remove<bool>();
            entities.RemoveAt(2);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            Entity temp = entities[2];
            temp.Disable<bool>();
            entities.Remove(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            temp.Enable<bool>();
            entities.Add(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_With_predicate_T_Should_return_EntitySet_with_all_Entity_with_component_T_and_validate_predicate()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().With((in bool b) => b).AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            Entity temp = entities[2];
            temp.Set(false);
            entities.Remove(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            temp.Set(true);
            entities.Add(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_With_T1_T2_Should_return_EntitySet_with_all_Entity_with_component_T1_T2()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().With<bool>().With<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(42);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            Entity temp = entities[2];
            temp.Remove<bool>();
            entities.Remove(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            temp.Set(true);
            temp.Remove<int>();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_With_predicate_T1_T2_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_and_validate_predicate()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().With((in bool b) => b).With((in int i) => i > 100).AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(1337);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            Entity temp = entities[2];
            temp.Set(false);
            entities.Remove(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            temp.Set(true);
            temp.Set(42);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WithEither_T1_T2_Should_return_EntitySet_with_all_Entity_with_component_T1_or_T2()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WithEither<bool>().Or<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            foreach (Entity entity in entities)
            {
                entity.Set(42);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            Entity temp = entities[2];
            temp.Remove<bool>();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            temp.Disable<int>();
            entities.Remove(temp);

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            temp.Enable<int>();
            temp.Remove<int>();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_Without_T_Should_return_EntitySet_with_all_Entity_without_component_T()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().Without<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            foreach (Entity entity in entities)
            {
                entity.Set(42);
            }

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            Entity temp = entities[2];
            temp.Disable<int>();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(temp);

            temp.Enable<int>();

            Check.That(set.GetEntities().ToArray()).IsEmpty();

            temp.Remove<int>();

            Check.That(set.GetEntities().ToArray()).ContainsExactly(temp);
        }

        [Fact]
        public void AsSet_WithoutEither_T1_T2_Should_return_EntitySet_with_all_Entity_without_component_T1_or_T2()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WithoutEither<bool>().Or<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            foreach (Entity entity in entities)
            {
                entity.Set(42);
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Disable<bool>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            foreach (Entity entity in entities)
            {
                entity.Enable<bool>();
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Remove<bool>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WhenAdded_T_Should_return_EntitySet_with_all_Entity_when_component_T_is_added()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WhenAdded<bool>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            set.Complete();

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(false);
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Disable<bool>();
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Enable<bool>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WhenAddedEither_T1_T2_Should_return_EntitySet_with_all_Entity_when_component_T1_or_T2_is_added()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WhenAddedEither<bool>().Or<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            set.Complete();

            foreach (Entity entity in entities)
            {
                entity.Set(false);
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(42);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WhenChanged_T_Should_return_EntitySet_with_all_Entity_when_component_T_is_added_and_changed()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WhenChanged<bool>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.Count).IsZero();

            set.Complete();

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(false);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WhenChangedEither_T1_T2_Should_return_EntitySet_with_all_Entity_when_component_T1_or_T2_is_changed()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WhenChangedEither<bool>().Or<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
                entity.Set(42);
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(false);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            set.Complete();
            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(1337);
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WhenRemoved_T_Should_return_EntitySet_with_all_Entity_when_component_T_is_removed()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WhenRemoved<bool>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Disable<bool>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

            foreach (Entity entity in entities)
            {
                entity.Enable<bool>();
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Remove<bool>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsSet_WhenRemovedEither_T1_T2_Should_return_EntitySet_with_all_Entity_when_component_T1_or_T2_is_changed()
        {
            using World world = new(4);
            using EntitySet set = world.GetEntities().WhenRemovedEither<bool>().Or<int>().AsSet();

            List<Entity> entities = new()
            {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Set(true);
                entity.Set(42);
            }

            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Remove<bool>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            set.Complete();
            Check.That(set.Count).IsZero();

            foreach (Entity entity in entities)
            {
                entity.Remove<int>();
            }

            Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
        }

        [Fact]
        public void AsPredicate_With_T_Should_return_true_When_entity_has_component_T()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            Predicate<Entity> predicate = world.GetEntities().With<bool>().AsPredicate();

            Check.That(predicate(entity)).IsFalse();

            entity.Set(true);

            Check.That(predicate(entity)).IsTrue();

            entity.Disable<bool>();

            Check.That(predicate(entity)).IsFalse();

            entity.Enable<bool>();

            Check.That(predicate(entity)).IsTrue();

            entity.Remove<bool>();

            Check.That(predicate(entity)).IsFalse();
        }

        [Fact]
        public void AsPredicate_With_predicate_T_Should_return_true_When_entity_validate_predicate()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            Predicate<Entity> predicate = world.GetEntities().WithEither<bool>().With((in bool b) => b).AsPredicate();

            entity.Set(false);

            Check.That(predicate(entity)).IsFalse();

            entity.Set(true);

            Check.That(predicate(entity)).IsTrue();

            entity.Disable<bool>();

            Check.That(predicate(entity)).IsFalse();

            entity.Enable<bool>();

            Check.That(predicate(entity)).IsTrue();

            entity.Remove<bool>();

            Check.That(predicate(entity)).IsFalse();
        }

        [Fact]
        public void AsPredicate_With_predicate_T1_T2_Should_return_true_When_entity_T_validate_predicate()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            Predicate<Entity> predicate = world.GetEntities().With((in bool b) => b).With((in int i) => i == 42).AsPredicate();

            entity.Set(false);
            entity.Set(1337);

            Check.That(predicate(entity)).IsFalse();

            entity.Set(true);

            Check.That(predicate(entity)).IsFalse();

            entity.Set(42);

            Check.That(predicate(entity)).IsTrue();
        }

        [Fact]
        public void AsPredicate_WithEither_T1_T2_Should_return_true_When_entity_has_component_T1()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            Predicate<Entity> predicate = world.GetEntities().WithEither<bool>().Or<int>().AsPredicate();

            Check.That(predicate(entity)).IsFalse();

            entity.Set(true);

            Check.That(predicate(entity)).IsTrue();

            entity.Disable<bool>();

            Check.That(predicate(entity)).IsFalse();

            entity.Enable<bool>();

            Check.That(predicate(entity)).IsTrue();

            entity.Remove<bool>();

            Check.That(predicate(entity)).IsFalse();

            entity.Set(42);

            Check.That(predicate(entity)).IsTrue();
        }

        [Fact]
        public void AsEnumerable_With_T_Should_return_entity_with_component_T()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            IEnumerable<Entity> enumerable = world.GetEntities().With<bool>().AsEnumerable();

            Check.That(enumerable).IsEmpty();

            entity.Set(true);

            Check.That(enumerable).ContainsExactly(entity);

            entity.Disable<bool>();

            Check.That(enumerable).IsEmpty();

            entity.Enable<bool>();

            Check.That(enumerable).ContainsExactly(entity);

            entity.Remove<bool>();

            Check.That(enumerable).IsEmpty();
        }

        [Fact]
        public void AsEnumerable_With_predicate_T_Should_return_entity_which_validate_predicate()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            IEnumerable<Entity> enumerable = world.GetEntities().WithEither<bool>().With((in bool b) => b).AsEnumerable();

            entity.Set(false);

            Check.That(enumerable).IsEmpty();

            entity.Set(true);

            Check.That(enumerable).ContainsExactly(entity);

            entity.Disable<bool>();

            Check.That(enumerable).IsEmpty();

            entity.Enable<bool>();

            Check.That(enumerable).ContainsExactly(entity);

            entity.Remove<bool>();

            Check.That(enumerable).IsEmpty();
        }

        [Fact]
        public void AsEnumerable_With_predicate_T1_T2_Should_return_entity_with_T__which_validate_predicate()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            IEnumerable<Entity> enumerable = world.GetEntities().With((in bool b) => b).With((in int i) => i == 42).AsEnumerable();

            entity.Set(false);
            entity.Set(1337);

            Check.That(enumerable).IsEmpty();

            entity.Set(true);

            Check.That(enumerable).IsEmpty();

            entity.Set(42);

            Check.That(enumerable).ContainsExactly(entity);
        }

        [Fact]
        public void AsEnumerable_WithEither_T1_T2_Should_return_entity_with_component_T1()
        {
            using World world = new(4);

            Entity entity = world.CreateEntity();

            IEnumerable<Entity> enumerable = world.GetEntities().WithEither<bool>().Or<int>().AsEnumerable();

            Check.That(enumerable).IsEmpty();

            entity.Set(true);

            Check.That(enumerable).ContainsExactly(entity);

            entity.Disable<bool>();

            Check.That(enumerable).IsEmpty();

            entity.Enable<bool>();

            Check.That(enumerable).ContainsExactly(entity);

            entity.Remove<bool>();

            Check.That(enumerable).IsEmpty();

            entity.Set(42);

            Check.That(enumerable).ContainsExactly(entity);
        }

        #endregion
    }
}
