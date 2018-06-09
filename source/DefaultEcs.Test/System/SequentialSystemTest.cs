using DefaultEcs.System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.System
{
    public class SequentialSystemTest
    {
        #region Tests

        [Fact]
        public void Update_Should_call_update_on_all_systems()
        {
            bool done1 = false;
            bool done2 = false;

            ISystem<int> system = new SequentialSystem<int>(
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true));

            system.Update(0);

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
        }

        #endregion
    }
}
