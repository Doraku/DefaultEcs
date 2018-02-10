namespace DefaultEcs.Message
{
    /// <summary>
    /// Message sent when an <see cref="DefaultEcs.Entity"/> is cleaned up.
    /// </summary>
    public readonly struct EntityCleanedMessage
    {
        /// <summary>
        /// The <see cref="DefaultEcs.Entity"/> cleaned up.
        /// </summary>
        public readonly Entity Entity;

        internal EntityCleanedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
