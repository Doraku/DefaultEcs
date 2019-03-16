using System;

namespace DefaultEcs.Resource
{
    /// <summary>
    /// Component type used to load managed resource with a <see cref="AResourceManager{TInfo, TResource}"/>.
    /// </summary>
    /// <typeparam name="TInfo">The type used to identify a resource.</typeparam>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    public readonly struct ManagedResource<TInfo, TResource>
        where TResource : IDisposable
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
