using System;
using DefaultEcs.Threading;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Threading
{
    public sealed class DefaultRunnerTest
    {
        #region Tests

        [Fact]
        public void DefaultRunner_Should_throw_When_degreeOfParallelism_is_inferior_to_one()
        {
            Check.ThatCode(() => new DefaultRunner(-1)).Throws<ArgumentException>();
        }

        #endregion
    }
}
