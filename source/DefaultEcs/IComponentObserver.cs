namespace DefaultEcs
{
    /// <summary>
    /// Provides a set of methods to be called when component of type <typeparamref name="T"/> events occured on <see cref="Entity"/> instances.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IComponentObserver<T>
    {
        /// <summary>
        /// Occurs when a component of type <typeparamref name="T"/> is added on an <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> on which the component was added.</param>
        /// <param name="value">The value of the component.</param>
        void OnAdded(in Entity entity, in T value);

        /// <summary>
        /// Occurs when a component of type <typeparamref name="T"/> is changed on an <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> on which the component was changed.</param>
        /// <param name="oldValue">The old value of the component.</param>
        /// <param name="newValue">The new value of the component.</param>
        void OnChanged(in Entity entity, in T oldValue, in T newValue);

        /// <summary>
        /// Occurs when a component of type <typeparamref name="T"/> is removed from an <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> on which the component was removed.</param>
        /// <param name="value">The value of the component.</param>
        void OnRemoved(in Entity entity, in T value);

        /// <summary>
        /// Occurs when a component of type <typeparamref name="T"/> is enabled on an <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> on which the component was enabled.</param>
        /// <param name="value">The value of the component.</param>
        void OnEnabled(in Entity entity, in T value);

        /// <summary>
        /// Occurs when a component of type <typeparamref name="T"/> is disabled on an <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> on which the component was disabled.</param>
        /// <param name="value">The value of the component.</param>
        void OnDisabled(in Entity entity, in T value);
    }
}
