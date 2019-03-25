namespace DefaultEcs
{
    /// <summary>
    /// Exposes methods called when <see cref="Entity"/> are added/removed from an <see cref="EntitySet"/>.
    /// </summary>
    public interface IEntitySetObserver
    {
        /// <summary>
        /// Called when an <see cref="Entity"/> is added to the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="entity"></param>
        void OnEntityAdded(in Entity entity);

        /// <summary>
        /// Called when an <see cref="Entity"/> is removed from the <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="entity"></param>
        void OnEntityRemoved(in Entity entity);
    }
}
