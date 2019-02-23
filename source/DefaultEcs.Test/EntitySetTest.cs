using System.Collections.Generic;
using System.Linq;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EntitySetTest
    {
        #region Tests

        [Fact]
        public void GetEntities_Should_return_previously_created_Entity()
        {
            using (World world = new World(4))
            {
                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                using (EntitySet set = world.GetEntities().Build())
                {
                    Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
                }
            }
        }

        [Fact]
        public void GetEntities_Should_not_return_disabled_Entity()
        {
            using (World world = new World(4))
            {
                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                entities[0].Disable();

                using (EntitySet set = world.GetEntities().Build())
                {
                    Check.That(set.GetEntities().ToArray()).ContainsExactly(entities.Skip(1));
                }
            }
        }

        [Fact]
        public void GetEntities_Should_not_return_Entity_with_disabled_component()
        {
            using (World world = new World(4))
            {
                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                foreach (Entity entity in entities)
                {
                    entity.Set<bool>();
                }
                entities[0].Disable<bool>();

                using (EntitySet set = world.GetEntities().With<bool>().Build())
                {
                    Check.That(set.GetEntities().ToArray()).ContainsExactly(entities.Skip(1));
                }
            }
        }

        #endregion
    }
}
