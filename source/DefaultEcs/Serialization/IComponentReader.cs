namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Exposes a method to be called back when getting an <see cref="Entity"/> components, primarly used for serialization purpose.
    /// </summary>
    public interface IComponentReader
    {
        /// <summary>
        /// Processes the component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="component">The component.</param>
        /// <param name="componentOwner">The owner of the component instance, in case it is used by multiple <see cref="Entity"/>.</param>
        void OnRead<T>(in T component, in Entity componentOwner);
    }
}
