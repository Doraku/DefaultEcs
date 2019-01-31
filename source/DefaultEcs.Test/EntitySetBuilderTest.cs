using System.Collections.Generic;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntitySetBuilderTest
    {
        #region Tests

        [Fact]
        public void Build_Should_return_EntitySet_with_all_Entity()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().Build())
            {
                List<Entity> entities = new List<Entity>
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
        }

        [Fact]
        public void Build_With_T_Should_return_EntitySet_with_all_Entity_with_component_T()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().With<bool>().Build())
            {
                List<Entity> entities = new List<Entity>
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
            }
        }

        [Fact]
        public void Build_With_T1_T2_Should_return_EntitySet_with_all_Entity_with_component_T1_T2()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().With<bool>().With<int>().Build())
            {
                List<Entity> entities = new List<Entity>
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
        }

        [Fact]
        public void Build_Without_T_Should_return_EntitySet_with_all_Entity_without_component_T()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().Without<int>().Build())
            {
                List<Entity> entities = new List<Entity>
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
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(temp);
            }
        }

        [Fact]
        public void Build_WithOneOf_T1_T2_Should_return_EntitySet_with_all_Entity_with_component_T1_or_T2()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntities().WithOneOf(typeof(bool), typeof(int)).Build())
            {
                List<Entity> entities = new List<Entity>
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

                temp.Remove<int>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        #endregion
    }
}
