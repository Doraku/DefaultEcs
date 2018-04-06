using System;
using System.Collections.Generic;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public class EntitySetTest
    {
        #region Tests

        [Fact]
        public void CopyEntitiesTo_Should_copy_all_Entity_to_destination()
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

                Span<Entity> copy = stackalloc Entity[set.Count];

                set.CopyEntitiesTo(copy);

                Check.That(copy.ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void CopyEntities_Should_return_an_array_with_all_Entity()
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

                Check.That(set.CopyEntities()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void Should_return_previously_created_Entity()
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

                    Check.That(set.CopyEntities()).ContainsExactly(entities);
                }
            }
        }

        #endregion
    }
}
