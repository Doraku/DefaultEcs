namespace DefaultEcs.Observer
{
    /// <summary>
    /// Basic implementation of <see cref="IEntitySetObserver"/> using events to dynamically add/remove subscriptions.
    /// </summary>
    public sealed class EntitySetObserverEvents : IEntitySetObserver
    {
        /// <summary>
        /// Event called when an <see cref="Entity"/> is added to the <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> OnEntityAdded;

        /// <summary>
        /// Event called when an <see cref="Entity"/> is removed from the <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> OnEntityRemoved;

        void IEntitySetObserver.OnEntityAdded(in Entity entity) => OnEntityAdded?.Invoke(entity);

        void IEntitySetObserver.OnEntityRemoved(in Entity entity) => OnEntityRemoved?.Invoke(entity);
    }
}
