using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class AoTHelpTest
    {
        #region Tests

        [Fact]
        public void RegisterMessage_Should_not_throw()
        {
            Check.ThatCode(AoTHelper.RegisterMessage<string>).DoesNotThrow();
        }

        [Fact]
        public void RegisterComponent_Should_not_throw()
        {
            Check.ThatCode(AoTHelper.RegisterComponent<string>).DoesNotThrow();
        }

        [Fact]
        public void RegisterUnmanagedComponent_Should_not_throw()
        {
            Check.ThatCode(AoTHelper.RegisterUnmanagedComponent<int>).DoesNotThrow();
        }

        #endregion
    }
}
