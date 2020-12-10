using DefaultEcs.Command;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Command
{
    public sealed class EntityRecordTest
    {
        #region Tests

        [Fact]
        public void equal_Should_return_true_When_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = record1;

            Check.That(record1 == record2).IsTrue();
        }

        [Fact]
        public void equal_Should_return_false_When_not_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = recorder.CreateEntity();

            Check.That(record1 == default).IsFalse();
            Check.That(record1 == record2).IsFalse();
        }

        [Fact]
        public void not_equal_Should_return_true_When_not_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = recorder.CreateEntity();

            Check.That(record1 != default).IsTrue();
            Check.That(record1 != record2).IsTrue();
        }

        [Fact]
        public void not_equal_Should_return_false_When_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = record1;

            Check.That(record1 != record2).IsFalse();
        }

        #endregion
    }
}
