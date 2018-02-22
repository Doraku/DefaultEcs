namespace DefaultEcs.Message
{
    /// <summary>
    /// Message sent when an <see cref="DefaultEcs.Entity"/> is disposed.
    /// </summary>
    public readonly struct EntityDisposedMessage
    {
        /// <summary>
        /// The <see cref="DefaultEcs.Entity"/> cleaned up.
        /// </summary>
        public readonly Entity Entity;

        internal EntityDisposedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
