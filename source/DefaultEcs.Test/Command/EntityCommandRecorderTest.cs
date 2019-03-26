using DefaultEcs.Command;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Command
{
    public sealed class EntityCommandRecorderTest
    {
        [Fact]
        public void OnEntityAdded_Should_call_event()
        {
            EntityCommandRecorder recorder = new EntityCommandRecorder(1024);
            using (World world = new World())
            {
                Entity entity = world.CreateEntity();
                entity.Disable();
                Entity entity2 = world.CreateEntity();

                entity2.Set(true);

                EntityRecord record = recorder.Record(entity);
                EntityRecord record2 = recorder.Record(entity2);

                record.Enable();
                record2.Remove<bool>();

                recorder.Execute(world);

                Check.That(entity.IsEnabled()).IsTrue();
                Check.That(entity2.Has<bool>()).IsFalse();
            }
        }
    }
}
