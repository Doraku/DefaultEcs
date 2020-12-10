using DefaultEcs.Command;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Command
{
    public sealed class EntityRecordTest
    {
        #region Tests

        [Fact]
        public void Equals_Should_return_false()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record = recorder.CreateEntity();

            Check.That(record.Equals(default)).IsFalse();
        }

        [Fact]
        public void GetHashCode_Should_return_hashcode()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = recorder.CreateEntity();

            Check.That(record1.GetHashCode()).IsNotEqualTo(record2.GetHashCode());
            Check.That(record1.GetHashCode()).IsEqualTo(record1.GetHashCode());
        }

        [Fact]
        public void OperatorEqual_Should_return_true_When_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = record1;

            Check.That(record1 == record2).IsTrue();
        }

        [Fact]
        public void OperatorEqual_Should_return_false_When_not_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = recorder.CreateEntity();

            Check.That(record1 == default).IsFalse();
            Check.That(record1 == record2).IsFalse();
        }

        [Fact]
        public void OperatorNotEqual_Should_return_true_When_not_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = recorder.CreateEntity();

            Check.That(record1 != default).IsTrue();
            Check.That(record1 != record2).IsTrue();
        }

        [Fact]
        public void OperatorNotEqual_Should_return_false_When_equal()
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder(1024);

            EntityRecord record1 = recorder.CreateEntity();
            EntityRecord record2 = record1;

            Check.That(record1 != record2).IsFalse();
        }

        #endregion
    }
}
