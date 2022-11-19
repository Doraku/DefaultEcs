using System;
using DefaultEcs.System;
using NFluent;
using NSubstitute;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class SequentialSystemTest
    {
        #region Tests

        [Fact]
        public void SequentialSystem_Should_throw_When_systems_is_null()
        {
            ISystem<float>[] systems = null;

            Check
                .ThatCode(() => new SequentialSystem<float>(systems))
                .Throws<ArgumentNullException>()
                .WithProperty(e => e.ParamName, "systems");
        }

        [Fact]
        public void Update_Should_call_update_on_all_systems()
        {
            bool done1 = false;
            bool done2 = false;

            using (ISystem<int> system = new SequentialSystem<int>(
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true)))
            {
                system.Update(0);
            }

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
        }

        [Fact]
        public void Update_Should_not_call_update_on_any_systems_When_disabled()
        {
            bool done1 = false;
            bool done2 = false;

            using (ISystem<int> system = new SequentialSystem<int>(
                new ActionSystem<int>(_ => done1 = true),
                new ActionSystem<int>(_ => done2 = true)))
            {
                system.IsEnabled = false;
                system.Update(0);
            }

            Check.That(done1).IsFalse();
            Check.That(done2).IsFalse();
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

            ISystem<int> system = new SequentialSystem<int>(s1, s2);

            system.Dispose();

            Check.That(done1).IsTrue();
            Check.That(done2).IsTrue();
        }

        #endregion
    }
}
