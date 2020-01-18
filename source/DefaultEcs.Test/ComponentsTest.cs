using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class ComponentsTest
    {
        #region Tests

        [Fact]
        public void GetComponents_Should_return_fast_access_to_component()
        {
            using World world = new World(4);

            Entity entity1 = world.CreateEntity();
            Entity entity2 = world.CreateEntity();
            Entity entity3 = world.CreateEntity();
            Entity entity4 = world.CreateEntity();

            entity1.Set("1");
            entity2.Set("2");
            entity3.Set("3");
            entity4.Set("4");

            Components<string> strings = world.GetComponents<string>();

            Check.That(entity1.Get<string>()).IsEqualTo(strings[entity1]);
            Check.That(entity2.Get<string>()).IsEqualTo(strings[entity2]);
            Check.That(entity3.Get<string>()).IsEqualTo(strings[entity3]);
            Check.That(entity4.Get<string>()).IsEqualTo(strings[entity4]);
        }

        #endregion
    }
}
