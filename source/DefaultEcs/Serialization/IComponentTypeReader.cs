namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Exposes a method to be called back when getting the maximum number of component of a <see cref="World"/>, primarly used for serialization purpose.
    /// </summary>
    public interface IComponentTypeReader
    {
        /// <summary>
        /// Processes the maximum number of component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="maxCapacity">The maximum number of component of type <typeparamref name="T"/>.</param>
        void OnRead<T>(int maxCapacity);
    }
}
