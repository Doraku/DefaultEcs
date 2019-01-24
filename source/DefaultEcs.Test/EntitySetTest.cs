using System.Collections.Generic;
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

        #endregion
    }
}
