using NFluent;
using Xunit;

namespace DefaultEcs.Test.Observer
{
    public sealed class EntitySetObserverEventsTest
    {
        [Fact]
        public void OnEntityAdded_Should_call_event()
        {
            EntitySetObserverEvents observer = new EntitySetObserverEvents();

            bool called = false;

            observer.OnEntityAdded += (in Entity _) => called = true;

            (observer as IEntitySetObserver)?.OnEntityAdded(default);

            Check.That(called).IsTrue();
        }

        [Fact]
        public void OnEntityRemoved_Should_call_event()
        {
            EntitySetObserverEvents observer = new EntitySetObserverEvents();

            bool called = false;

            observer.OnEntityRemoved += (in Entity _) => called = true;

            (observer as IEntitySetObserver)?.OnEntityRemoved(default);

            Check.That(called).IsTrue();
        }
    }
}
