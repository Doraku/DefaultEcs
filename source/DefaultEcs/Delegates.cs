namespace DefaultEcs
{
    /// <summary>
    /// Encapsulates a method that has a single in parameter and does not return a value used for <see cref="IPublisher.Subscribe{T}(MessageHandler{T})"/> method.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    /// <param name="message">The parameter of the method that this delegate encapsulates.</param>
    public delegate void MessageHandler<T>(in T message);

    /// <summary>
    /// Represents the method that will called when a <see cref="World"/> is created.
    /// </summary>
    /// <param name="world">The dusposed <see cref="World"/>.</param>
    public delegate void WorldDisposedHandler(World world);

    /// <summary>
    /// Represents the method that will called when an <see cref="Entity"/> is created.
    /// </summary>
    /// <param name="entity">The created <see cref="Entity"/>.</param>
    public delegate void EntityCreatedHandler(in Entity entity);

    /// <summary>
    /// Represents the method that will called when an <see cref="Entity"/> is enabled.
    /// </summary>
    /// <param name="entity">The enabled <see cref="Entity"/>.</param>
    public delegate void EntityEnabledHandler(in Entity entity);

    /// <summary>
    /// Represents the method that will called when an <see cref="Entity"/> is disabled.
    /// </summary>
    /// <param name="entity">The disabled <see cref="Entity"/>.</param>
    public delegate void EntityDisabledHandler(in Entity entity);

    /// <summary>
    /// Represents the method that will called when an <see cref="Entity"/> is disposed.
    /// </summary>
    /// <param name="entity">The disposed <see cref="Entity"/>.</param>
    public delegate void EntityDisposedHandler(in Entity entity);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is added on an <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component added.</typeparam>
    /// <param name="entity">The <see cref="Entity"/> on which the component was added.</param>
    /// <param name="value">The value of the component.</param>
    public delegate void ComponentAddedHandler<T>(in Entity entity, in T value);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is changed on an <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component removed.</typeparam>
    /// <param name="entity">The <see cref="Entity"/> on which the component was changed.</param>
    /// <param name="oldValue">The previous value of the component.</param>
    /// <param name="newValue">The new value of the component.</param>
    public delegate void ComponentChangedHandler<T>(in Entity entity, in T oldValue, in T newValue);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is removed from an <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component removed.</typeparam>
    /// <param name="entity">The <see cref="Entity"/> on which the component was removed.</param>
    /// <param name="value">The value of the component.</param>
    public delegate void ComponentRemovedHandler<T>(in Entity entity, in T value);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is added on a <see cref="World"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component added.</typeparam>
    /// <param name="world">The <see cref="World"/> on which the component was added.</param>
    /// <param name="value">The value of the component.</param>
    public delegate void WorldComponentAddedHandler<T>(World world, in T value);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is changed on a <see cref="World"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component removed.</typeparam>
    /// <param name="world">The <see cref="World"/> on which the component was changed.</param>
    /// <param name="oldValue">The previous value of the component.</param>
    /// <param name="newValue">The new value of the component.</param>
    public delegate void WorldComponentChangedHandler<T>(World world, in T oldValue, in T newValue);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is removed from a <see cref="World"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component removed.</typeparam>
    /// <param name="world">The <see cref="World"/> on which the component was removed.</param>
    /// <param name="value">The value of the component.</param>
    public delegate void WorldComponentRemovedHandler<T>(World world, in T value);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is enabled on an <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component enabled.</typeparam>
    /// <param name="entity">The <see cref="Entity"/> on which the component was enabled.</param>
    /// <param name="value">The value of the component.</param>
    public delegate void ComponentEnabledHandler<T>(in Entity entity, in T value);

    /// <summary>
    /// Represents the method that will called when a component of type <typeparamref name="T"/> is disabled on an <see cref="Entity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the component disabled.</typeparam>
    /// <param name="entity">The <see cref="Entity"/> on which the component was disabled.</param>
    /// <param name="value">The value of the component.</param>
    public delegate void ComponentDisabledHandler<T>(in Entity entity, in T value);

    /// <summary>
    /// Represents the method that defines a set of criteria and determines whether the specified component meets those criteria.
    /// </summary>
    /// <typeparam name="T">The type of the component to compare.</typeparam>
    /// <param name="value">The component value.</param>
    /// <returns>true if the component meets the criteria; otherwise, false.</returns>
    public delegate bool ComponentPredicate<T>(in T value);

    /// <summary>
    /// Represents the method that will called when an <see cref="Entity"/> is added to a container.
    /// </summary>
    /// <param name="entity">The added <see cref="Entity"/>.</param>
    public delegate void EntityAddedHandler(in Entity entity);

    /// <summary>
    /// Represents the method that will called when an <see cref="Entity"/> is removed from a container.
    /// </summary>
    /// <param name="entity">The removed <see cref="Entity"/>.</param>
    public delegate void EntityRemovedHandler(in Entity entity);
}
