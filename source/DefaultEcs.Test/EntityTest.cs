using System;
using System.Text.RegularExpressions;
using DefaultEcs.Serialization;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntityTest
    {
        #region Types

        private class ComponentReader : IComponentReader
        {
            public int ComponentCount;
            public int? IntValue;
            public long? LongValue;
            public float? FloatValue;

            public void OnRead<T>(in T component, in Entity componentOwner)
            {
                ++ComponentCount;

                if (typeof(T) == typeof(int))
                {
                    IntValue = (int)(object)component;
                }

                if (typeof(T) == typeof(long))
                {
                    LongValue = (long)(object)component;
                }

                if (typeof(T) == typeof(float))
                {
                    FloatValue = (float)(object)component;
                }
            }
        }

        private struct FlagType { }

        #endregion

        #region Tests

        [Fact]
        public void World_Should_return_world()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            Check.That(entity.World).IsEqualTo(world);
        }

        [Fact]
        public void World_Should_return_null_when_world_is_disposed()
        {
            Entity entity = default;

            Check.That(entity.World).IsNull();

            using (World world = new(1))
            {
                entity = world.CreateEntity();

                Check.That(entity.World).IsEqualTo(world);
            }

            Check.That(entity.World).IsNull();
        }

        [Fact]
        public void IsAlive_Should_return_true()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            Check.That(entity.IsAlive).IsTrue();
        }

        [Fact]
        public void IsAlive_Should_return_false_When_default()
        {
            Entity entity = default;
            Check.That(entity.IsAlive).IsFalse();
        }

        [Fact]
        public void IsAlive_Should_return_false_When_disposed()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            entity.Dispose();
            Check.That(entity.IsAlive).IsFalse();
        }

        [Fact]
        public void IsAlive_Should_return_false_When_disposed_even_if_recreated()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            entity.Dispose();
            Entity newEntity = world.CreateEntity();
            Check.That(entity.IsAlive).IsFalse();
            Check.That(entity.GetHashCode()).IsEqualTo(newEntity.GetHashCode());
        }

        [Fact]
        public void IsEnabled_Should_return_true_by_default()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            Check.That(entity.IsEnabled()).IsTrue();
        }

        [Fact]
        public void IsEnabled_Should_return_true_for_default()
        {
            Entity entity = default;
            Check.That(entity.IsEnabled()).IsFalse();
        }

        [Fact]
        public void Disable_Should_throw_When_default()
        {
            Entity entity = default;
            Check.ThatCode(() => entity.Disable()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Disable_Should_disable_Entity()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            entity.Disable();

            Check.That(entity.IsEnabled()).IsFalse();
        }

        [Fact]
        public void Enable_Should_throw_When_default()
        {
            Entity entity = default;
            Check.ThatCode(() => entity.Enable()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Enable_Should_enable_Entity()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            entity.Disable();
            entity.Enable();

            Check.That(entity.IsEnabled()).IsTrue();
        }

        [Fact]
        public void IsEnabled_T_Should_return_false_for_default()
        {
            Entity entity = default;

            Check.That(entity.IsEnabled<bool>()).IsFalse();
        }

        [Fact]
        public void IsEnabled_T_Should_return_true_by_default()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            entity.Set<bool>();

            Check.That(entity.IsEnabled<bool>()).IsTrue();
        }

        [Fact]
        public void Disable_T_Should_throw_When_default()
        {
            Entity entity = default;
            Check.ThatCode(() => entity.Disable<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Disable_T_Should_disable_component()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            entity.Set<bool>();
            entity.Disable<bool>();

            Check.That(entity.Get<bool>()).IsFalse();
            Check.That(entity.IsEnabled<bool>()).IsFalse();
        }

        [Fact]
        public void Enable_T_Should_throw_When_default()
        {
            Entity entity = default;
            Check.ThatCode(() => entity.Enable<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void Enable_T_Should_enable_component()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            entity.Set<bool>();
            entity.Disable<bool>();
            entity.Enable<bool>();

            Check.That(entity.IsEnabled<bool>()).IsTrue();
        }

        [Fact]
        public void Has_Should_return_false_When_World_does_not_have_component()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            Check.That(entity.Has<bool>()).IsFalse();
        }

        [Fact]
        public void Has_Should_return_false_When_Entity_does_not_have_component()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            Check.That(entity.Has<bool>()).IsFalse();
        }

        [Fact]
        public void Has_Should_return_true_When_Entity_has_component()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            entity.Set(true);

            Check.That(entity.Has<bool>()).IsTrue();
        }

        [Fact]
        public void Set_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.Set(true)).Throws<InvalidOperationException>();
        }

        //[Fact]
        //public void Set_Should_throw_When_max_number_of_component_reached()
        //{
        //    using World world = new(1);

        //    world.SetMaxCapacity<bool>(0);
        //    Entity entity = world.CreateEntity();

        //    Check.ThatCode(() => entity.Set(true)).Throws<InvalidOperationException>();
        //}

        [Fact]
        public void Set_Should_set_component_value()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            entity.Set(true);

            Check.That(entity.Get<bool>()).IsTrue();
        }

        [Fact]
        public void Set_Should_not_thow_When_more_than_32_components()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            entity.Set<bool>();
            entity.Set<short>();
            entity.Set<ushort>();
            entity.Set<long>();
            entity.Set<ulong>();
            entity.Set<int>();
            entity.Set<uint>();
            entity.Set<double>();
            entity.Set<float>();
            entity.Set<decimal>();
            entity.Set<object>();
            entity.Set<string>();
            entity.Set<char>();
            entity.Set<byte>();
            entity.Set<World>();
            entity.Set<Entity>();
            entity.Set<Delegate>();
            entity.Set<Action>();
            entity.Set<Action<bool>>();
            entity.Set<Action<short>>();
            entity.Set<Action<ushort>>();
            entity.Set<Action<long>>();
            entity.Set<Action<ulong>>();
            entity.Set<Action<int>>();
            entity.Set<Action<uint>>();
            entity.Set<Action<double>>();
            entity.Set<Action<float>>();
            entity.Set<Action<decimal>>();
            entity.Set<Action<object>>();
            entity.Set<Action<string>>();
            entity.Set<Action<char>>();
            entity.Set<Action<byte>>();
        }

        [Fact]
        public void Set_Should_override_SetSameAs()
        {
            using World world = new();

            Entity reference = world.CreateEntity();
            Entity entity = world.CreateEntity();

            reference.Set(true);
            entity.SetSameAs<bool>(reference);
            entity.Set(false);

            Check.That(reference.Get<bool>()).IsTrue();
            Check.That(entity.Get<bool>()).IsFalse();
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
            using World world = new(1);

            Entity entity = world.CreateEntity();

            Check.ThatCode(() => entity.SetSameAs<bool>(default)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetSameAs_Should_throw_When_reference_comes_from_a_different_World()
        {
            using World world = new(1);
            using World worldRef = new(1);

            Entity entity = world.CreateEntity();
            Entity reference = worldRef.CreateEntity();

            Check.ThatCode(() => entity.SetSameAs<bool>(reference)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetSameAs_Should_throw_When_reference_does_not_have_a_component()
        {
            using World world = new(2);

            Entity entity = world.CreateEntity();
            Entity reference = world.CreateEntity();

            Check.ThatCode(() => entity.SetSameAs<bool>(reference)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetSameAs_Should_set_component_to_reference()
        {
            using World world = new(2);

            Entity entity = world.CreateEntity();
            Entity reference = world.CreateEntity();

            reference.Set(false);
            entity.SetSameAs<bool>(reference);

            Check.That(entity.Get<bool>()).IsEqualTo(reference.Get<bool>());

            reference.Get<bool>() = true;

            Check.That(entity.Get<bool>()).IsEqualTo(reference.Get<bool>());

            entity.Get<bool>() = false;

            Check.That(reference.Get<bool>()).IsEqualTo(entity.Get<bool>());
        }

        [Fact]
        public void SetSameAs_Should_override_SetSameAs()
        {
            using World world = new();

            Entity reference = world.CreateEntity();
            Entity reference2 = world.CreateEntity();
            Entity entity = world.CreateEntity();

            reference.Set(true);
            reference2.Set(false);
            entity.SetSameAs<bool>(reference);
            entity.SetSameAs<bool>(reference2);

            Check.That(reference.Get<bool>()).IsTrue();
            Check.That(reference2.Get<bool>()).IsFalse();
            Check.That(entity.Get<bool>()).IsFalse();
        }

        [Fact]
        public void SetSameAsWorld_Should_throw_When_Entity_not_created_from_World()
        {
            Entity entity = default;

            Check.ThatCode(() => entity.SetSameAsWorld<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetSameAsWorld_Should_throw_When_world_does_not_have_a_component()
        {
            using World world = new();

            Entity entity = world.CreateEntity();

            Check.ThatCode(() => entity.SetSameAsWorld<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void SetSameAsWorld_Should_set_component_to_world()
        {
            using World world = new();

            world.Set(true);
            Entity entity = world.CreateEntity();
            entity.SetSameAsWorld<bool>();

            Check.That(entity.Get<bool>()).IsTrue();

            world.Get<bool>() = false;
            Check.That(entity.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Remove_Should_not_throw_When_no_component()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            entity.Remove<bool>();
        }

        [Fact]
        public void Remove_Should_remove_component()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();

            entity.Set(true);

            Check.That(entity.Has<bool>()).IsTrue();

            entity.Remove<bool>();

            Check.That(entity.Has<bool>()).IsFalse();
        }

        [Fact]
        public void Remove_Should_remove_component_without_removing_reference()
        {
            using World world = new(2);

            Entity entity = world.CreateEntity();
            Entity reference = world.CreateEntity();

            reference.Set(true);
            entity.SetSameAs<bool>(reference);

            entity.Remove<bool>();

            Check.That(entity.Has<bool>()).IsFalse();
            Check.That(reference.Has<bool>()).IsTrue();
        }

        [Fact]
        public void Remove_Should_remove_component_and_pass_reference()
        {
            using World world = new(3);

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

        [Fact]
        public void Remove_Should_not_remove_component_of_all_referenced_Entity()
        {
            using World world = new(3);

            Entity entity = world.CreateEntity();
            world.CreateEntity();
            Entity reference = world.CreateEntity();

            reference.Set(true);
            entity.SetSameAs<bool>(reference);

            reference.Remove<bool>();

            Check.That(entity.Has<bool>()).IsTrue();
            Check.That(reference.Has<bool>()).IsFalse();
        }

        [Fact]
        public void NotifyChanged_Should_throw_When_Entity_not_created_from_a_World()
        {
            Check.ThatCode(() => default(Entity).NotifyChanged<bool>()).Throws<InvalidOperationException>();
        }

        [Fact]
        public void NotifyChanged_Should_throw_When_Entity_does_not_have_component()
        {
            using World world = new();

            Check.ThatCode(() => world.CreateEntity().NotifyChanged<bool>()).Throws<InvalidOperationException>();
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
            using World world = new(2);

            Entity entity = world.CreateEntity();

            Check.ThatCode(() => entity.Get<bool>()).Throws<Exception>();

            entity.Set(true);
            entity.Remove<bool>();

            Check.ThatCode(() => entity.Get<bool>()).Throws<Exception>();
        }

        [Fact]
        public void Get_Should_get_component()
        {
            using World world = new(2);

            Entity entity = world.CreateEntity();

            entity.Set(true);

            Check.That(entity.Get<bool>()).IsTrue();

            entity.Set(false);

            Check.That(entity.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Get_Should_get_component_of_reference_When_is_same_as()
        {
            using World world = new(2);

            Entity entity = world.CreateEntity();
            Entity reference = world.CreateEntity();

            reference.Set(true);
            entity.SetSameAs<bool>(reference);

            Check.That(entity.Get<bool>()).IsTrue();

            reference.Get<bool>() = false;

            Check.That(entity.Get<bool>()).IsFalse();
        }

        [Fact]
        public void Dispose_Should_release_Entity()
        {
            using World world = new(2);

            Entity deletedEntity = world.CreateEntity();

            deletedEntity.Dispose();

            Entity entity = world.CreateEntity();

            Check.That(entity.GetHashCode()).IsEqualTo(deletedEntity.GetHashCode());
        }

        [Fact]
        public void Dispose_Should_remove_all_component()
        {
            using World world = new(2);

            world.CreateEntity();
            Entity deletedEntity = world.CreateEntity();
            deletedEntity.Set(true);

            Check.That(deletedEntity.Has<bool>()).IsTrue();

            deletedEntity.Dispose();
            Check.That(deletedEntity.Has<bool>()).IsFalse();

            Entity entity = world.CreateEntity();

            Check.That(entity.Has<bool>()).IsFalse();
        }

        [Fact]
        public void CopyTo_Should_copy_entity_with_its_components()
        {
            using World world1 = new(1);
            using World world2 = new(1);

            Entity main = world1.CreateEntity();

            main.Set(42);
            main.Set("kikoo");

            Entity copy = main.CopyTo(world2);

            Check.That(copy.Get<int>()).IsEqualTo(main.Get<int>());
            Check.That(copy.Get<string>()).IsEqualTo(main.Get<string>());
        }

        [Fact]
        public void CopyTo_Should_copy_entity_with_its_components_and_its_state()
        {
            using World world1 = new(1);
            using World world2 = new(1);

            Entity main = world1.CreateEntity();

            main.Set(42);
            main.Disable<int>();
            main.Set("kikoo");
            main.Disable();

            Entity copy = main.CopyTo(world2);

            Check.That(main.IsEnabled()).IsEqualTo(copy.IsEnabled());
            Check.That(main.IsEnabled<int>()).IsEqualTo(copy.IsEnabled<int>());
            Check.That(main.IsEnabled<string>()).IsEqualTo(copy.IsEnabled<string>());
        }

        [Fact]
        public void CopyTo_Should_left_no_trace_When_there_is_an_exception()
        {
            using World world1 = new(1);
            using World world2 = new(1);

            Entity main = world1.CreateEntity();

            main.Set(42);
            main.Set("kikoo");

            Check.ThatCode(() => main.CopyTo(world2)).ThrowsAny();
            Check.That(world2.GetAll<int>().Length).IsEqualTo(0);
            Check.That(world2.GetEntities().AsSet().Count).IsEqualTo(0);
        }

        [Fact]
        public void CopyTo_Should_throw_When_not_created_from_same_World()
        {
            using World world = new(1);

            Entity entity = default;
            Check.ThatCode(() => entity.CopyTo(world)).Throws<InvalidOperationException>();
        }

        [Fact]
        public void CopyTo_Should_throw_When_World_is_null()
        {
            Entity entity = default;
            Check.ThatCode(() => entity.CopyTo(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void CopyTo_Should_throw_When_cloner_is_null()
        {
            using World world = new(1);

            Entity entity = default;
            Check.ThatCode(() => entity.CopyTo(world, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ReadAllComponents_Should_throw_ArgumentNullException_When_reader_is_null()
        {
            using World world = new(1);

            Entity entity = world.CreateEntity();
            Check.ThatCode(() => entity.ReadAllComponents(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void ReadAllComponents_Should_callback_reader()
        {
            using World world = new(42);

            Entity entity = world.CreateEntity();
            entity.Set(42);
            entity.Set(1337L);

            ComponentReader reader = new();

            entity.ReadAllComponents(reader);

            Check.That(reader.ComponentCount).IsEqualTo(2);
            Check.That(reader.IntValue).IsEqualTo(42);
            Check.That(reader.LongValue).IsEqualTo(1337L);
            Check.That(reader.FloatValue.HasValue).IsFalse();
        }

        [Fact]
        public void ReadAllComponents_Should_not_return_previous_value_components()
        {
            using World world = new();
            using EntityMap<int> map = world.GetEntities().AsMap<int>();

            Entity entity = world.CreateEntity();
            entity.Set(42);

            ComponentReader reader = new();

            entity.ReadAllComponents(reader);

            Check.That(reader.ComponentCount).IsEqualTo(1);
            Check.That(reader.IntValue).IsEqualTo(42);
        }

        [Fact]
        public void Equal_Should_return_false_When_other_is_not_an_Entity()
        {
            Entity entity = default;

            Check.That(entity.Equals(new object())).IsFalse();
        }

        [Fact]
        public void OperatorEqual_Should_return_true_When_entities_are_equal()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            Entity copy = entity;

            Check.That(entity == copy).IsTrue();
        }

        [Fact]
        public void OperatorEqual_Should_return_false_When_entities_are_not_equal()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            Entity otherEntity = world.CreateEntity();

            Check.That(entity == otherEntity).IsFalse();
        }

        [Fact]
        public void OperatorNotEqual_Should_return_false_When_entities_are_equal()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            Entity copy = entity;

            Check.That(entity != copy).IsFalse();
        }

        [Fact]
        public void OperatorNotEqual_Should_return_true_When_entities_are_not_equal()
        {
            using World world = new();

            Entity entity = world.CreateEntity();
            Entity otherEntity = world.CreateEntity();

            Check.That(entity != otherEntity).IsTrue();
        }

        [Fact]
        public void ToString_Should_not_throw()
        {
            Entity entity = default;

            Check.That(Regex.IsMatch(entity.ToString(), "^Entity \\d*:\\d*.\\d*$")).IsTrue();
        }

        #endregion
    }
}
