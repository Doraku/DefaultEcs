using System;

namespace DefaultEcs
{
    internal interface IEntityContainer : Internal.IEntityContainer, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance from which current <see cref="IEntityContainer"/> originate.
        /// </summary>
        World World { get; }

        /// <summary>
        /// Occurs when an <see cref="Entity"/> is added in the current <see cref="IEntityContainer"/>.
        /// </summary>
        event EntityAddedHandler EntityAdded;

        /// <summary>
        /// Occurs when an <see cref="Entity"/> is removed from the current <see cref="IEntityContainer"/>.
        /// </summary>
        event EntityRemovedHandler EntityRemoved;

        /// <summary>
        /// Determines whether the <see cref="IEntityContainer"/> contains a specific <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to locate in the <see cref="IEntityContainer"/>.</param>
        /// <returns>true if the <see cref="IEntityContainer"/> contains the specified <see cref="Entity"/>; otherwise, false.</returns>
        bool Contains(in Entity entity);

        /// <summary>
        /// Clears current instance of its entities if it was created with some reactive filter (<see cref="EntityQueryBuilder.WhenAdded{T}"/>, <see cref="EntityQueryBuilder.WhenChanged{T}"/> or <see cref="EntityQueryBuilder.WhenRemoved{T}"/>).
        /// Does nothing if it was created from a static filter.
        /// This method need to be called after current instance content has been processed in a update cycle.
        /// </summary>
        void Complete();

        /// <summary>
        /// Resizes inner storage to exactly the number of <see cref="Entity"/> this <see cref="IEntityContainer"/> contains.
        /// </summary>
        void TrimExcess();
    }
}
