using System;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class ParallelSystemTest
    {
        #region Tests

        [Fact]
        public void ParallelSystem_Should_throw_When_systems_is_null()
        {
            ISystem<float>[] systems = null;

            Check
                .ThatCode(() => new ParallelSystem<float>(Substitute.For<IParallelRunner>(), systems))
                .Throws<ArgumentNullException>()
                .WithProperty(e => e.ParamName, "systems");
        }

        [Fact]
        public void ParallelSystem_Should_throw_When_runner_is_null() => Check
            .ThatCode(() => new ParallelSystem<float>(null))
            .Throws<ArgumentNullException>()
            .WithProperty(e => e.ParamName, "runner");

        [Fact]
        public void Update_Should_call_update_on_all_systems()
        {
            bool mainDone = false;
            bool done1 = false;
            bool done2 = false;

            using (ISystem<int> system = new ParallelSystem<int>(
                new ActionSystem<int>(_ => mainDone = true),
                new DefaultParallelRunner(1),
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true)))
            {
                system.Update(0);
            }

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

            using (DefaultParallelRunner runner = new(2))
            using (ISystem<int> system = new ParallelSystem<int>(
                runner,
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true),
                new ActionSystem<int>(_ => done3 = true),
                new ActionSystem<int>(_ => done4 = true)))
            {
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

            using (DefaultParallelRunner runner = new(2))
            using (ISystem<int> system = new ParallelSystem<int>(
                runner,
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true),
                new ActionSystem<int>(_ => done3 = true),
                new ActionSystem<int>(_ => done4 = true)))
            {
                system.IsEnabled = false;
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

            ISystem<int> system = new ParallelSystem<int>(s1, Substitute.For<IParallelRunner>(), s2);

            system.Dispose();

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
        }

        #endregion
    }
}
