namespace DefaultEcs.Message
{
    /// <summary>
    /// Message sent when the component of type <typeparamref name="T"/> is setted on an <see cref="DefaultEcs.Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    public readonly struct ComponentAddedMessage<T>
    {
        /// <summary>
        /// The <see cref="DefaultEcs.Entity"/> on which the component was setted.
        /// </summary>
        public readonly Entity Entity;

        internal ComponentAddedMessage(in Entity entity)
        {
            Entity = entity;
        }
    }
}
