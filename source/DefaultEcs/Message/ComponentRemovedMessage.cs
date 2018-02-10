namespace DefaultEcs.Message
{
    /// <summary>
    /// Message sent when the component of type <typeparamref name="T"/> is removed from an <see cref="DefaultEcs.Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    public readonly struct ComponentRemovedMessage<T>
    {
        /// <summary>
        /// The <see cref="DefaultEcs.Entity"/> from which the component was removed.
        /// </summary>
        public readonly Entity Entity;

        internal ComponentRemovedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
