using DefaultEcs.System;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.System
{
    public class ParallelSystemTest
    {
        #region Tests

        [Fact]
        public void Update_Should_call_update_on_all_systems()
        {
            bool done1 = false;
            bool done2 = false;

            ISystem<int> system = new ParallelSystem<int>(
                null,
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true));

            system.Update(0);

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
        }

        [Fact]
        public void Update_with_runner_Should_call_update_on_all_systems()
        {
            bool done1 = false;
            bool done2 = false;
            bool done3 = false;
            bool done4 = false;

            using (SystemRunner<int> runner = new SystemRunner<int>(2))
            {
                ISystem<int> system = new ParallelSystem<int>(
                    runner,
                    new ActionSystem<int>(_ => done1 = true),
                    new ActionSystem<int>(_ => done2 = true),
                    new ActionSystem<int>(_ => done3 = true),
                    new ActionSystem<int>(_ => done4 = true));

                system.Update(0);
            }

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
            Check.That(done3).IsTrue();
            Check.That(done4).IsTrue();
        }

        #endregion
    }
}
