namespace DefaultEcs.Resource
{
    /// <summary>
    /// Provides static methods for creating <see cref="ManagedResource{TInfo, TResource}"/> object.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    public static class ManagedResource<TResource>
    {
        /// <summary>
        /// Create a <see cref="ManagedResource{TInfo, TResource}"/> object
        /// </summary>
        /// <typeparam name="TInfo">The infos used to identify the resources.</typeparam>
        /// <param name="info">The info used to identify the resource.</param>
        /// <returns>The <see cref="ManagedResource{TInfo, TResource}"/> object.</returns>
        public static ManagedResource<TInfo, TResource> Create<TInfo>(TInfo info) => new(info);

        /// <summary>
        /// Create a <see cref="ManagedResource{TInfo, TResource}"/> object with multiple infos.
        /// </summary>
        /// <typeparam name="TInfo">The infos used to identify the resources.</typeparam>
        /// <param name="infos">The type used to identify a resource.</param>
        /// <returns>The <see cref="ManagedResource{TInfo, TResource}"/> object.</returns>
        public static ManagedResource<TInfo[], TResource> Create<TInfo>(params TInfo[] infos) => new(infos);
    }

    /// <summary>
    /// Component type used to load managed resource with a <see cref="AResourceManager{TInfo, TResource}"/>.
    /// </summary>
    /// <typeparam name="TInfo">The type used to identify a resource.</typeparam>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    public readonly struct ManagedResource<TInfo, TResource>
    {
        /// <summary>
        /// Gets the info about the resource to load.
        /// </summary>
        public readonly TInfo Info;

        /// <summary>
        /// Creates a component of type <see cref="ManagedResource{TInfo, TResource}"/> used to load a resource of type <typeparamref name="TResource"/>.
        /// </summary>
        /// <param name="info">The info used to identify the resource.</param>
        public ManagedResource(TInfo info)
        {
            Info = info;
        }
    }
}
