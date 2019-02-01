using DefaultEcs.System;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class ParallelSystemTest
    {
        #region Tests

        [Fact]
        public void Update_Should_call_update_on_all_systems()
        {
            bool mainDone = false;
            bool done1 = false;
            bool done2 = false;

            ISystem<int> system = new ParallelSystem<int>(
                new ActionSystem<int>(_ => mainDone = true),
                null,
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true));

            system.Update(0);

            Check.That(mainDone).IsTrue();
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

        [Fact]
        public void Update_with_runner_Should_not_call_update_on_any_systems_When_disabled()
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
                    new ActionSystem<int>(_ => done4 = true))
                {
                    IsEnabled = false
                };

                system.Update(0);
            }

            Check.That(done1).IsFalse();
            Check.That(done2).IsFalse();
            Check.That(done3).IsFalse();
            Check.That(done4).IsFalse();
        }

        [Fact]
        public void Dispose_Should_call_Dispose_on_all_systems()
        {
            bool done1 = false;
            bool done2 = false;

            ISystem<int> s1 = Substitute.For<ISystem<int>>();
            ISystem<int> s2 = Substitute.For<ISystem<int>>();

            s1.When(s => s.Dispose()).Do(_ => done1 = true);
            s2.When(s => s.Dispose()).Do(_ => done2 = true);

            ISystem<int> system = new ParallelSystem<int>(s1, null, s2);

            system.Dispose();

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
        }

        #endregion
    }
}
