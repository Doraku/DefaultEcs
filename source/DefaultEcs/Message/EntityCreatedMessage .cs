namespace DefaultEcs.Message
{
    /// <summary>
    /// Message sent when an <see cref="DefaultEcs.Entity"/> is created.
    /// </summary>
    public readonly struct EntityCreatedMessage
    {
        /// <summary>
        /// The <see cref="DefaultEcs.Entity"/> created.
        /// </summary>
        public readonly Entity Entity;

        internal EntityCreatedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
