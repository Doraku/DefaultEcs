namespace DefaultEcs
{
    /// <summary>
    /// Encapsulates a method that has a single in parameter and does not return a value used for <see cref="IPublisher.Subscribe{T}(MessageHandler{T})"/> method.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    /// <param name="message">The parameter of the method that this delegate encapsulates.</param>
    public delegate void MessageHandler<T>(in T message);

    /// <summary>
    /// Represents the method that defines a set of criteria and determines whether the specified component meets those criteria.
    /// </summary>
    /// <typeparam name="T">The type of the component to compare.</typeparam>
    /// <param name="value">The component value.</param>
    /// <returns>true if the component meets the criteria; otherwise, false.</returns>
    public delegate bool ComponentPredicate<T>(in T value);
}
