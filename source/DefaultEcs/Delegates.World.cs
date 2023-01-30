namespace DefaultEcs
{
    /// <summary>
    /// Represents the method that will called when a <see cref="World"/> is created.
    /// </summary>
    /// <param name="world">The dusposed <see cref="World"/>.</param>
    public delegate void WorldDisposedHandler(World world);

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
}
