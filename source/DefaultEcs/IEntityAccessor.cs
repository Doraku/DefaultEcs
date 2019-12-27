using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;

namespace DefaultEcs
{
    /// <summary>
    /// This interface needed to access Entity components and other stuff
    /// </summary>
    public interface IEntityAccessor
    {
        /// <summary>
        /// Gets whether the current <see cref="Entity"/> is enabled or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is enabled; otherwise, false.</returns>
        bool IsEnabled(Entity entity);

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> component of type <typeparamref name="T"/> is enabled or not.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/> enabled; otherwise, false.</returns>
        bool IsEnabled<T>(Entity entity);

        /// <summary>
        /// Returns whether the current <see cref="Entity"/> has a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/>; otherwise, false.</returns>
        bool Has<T>(Entity entity);

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the component.</returns>
        /// <exception cref="Exception"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/> or does not have a component of type <typeparamref name="T"/>.</exception>
        ref T Get<T>(Entity entity);

        /// <summary>
        /// Gets all the <see cref="Entity"/> setted as children of the current <see cref="Entity"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Entity}"/> of all the current <see cref="Entity"/> children.</returns>
        IEnumerable<Entity> GetChildren(Entity entity);

        /// <summary>
        /// Calls on <paramref name="reader"/> with all the component of the current <see cref="Entity"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="entity">Entity to read from</param>
        /// <param name="reader">The <see cref="IComponentReader"/> instance to be used as callback with the current <see cref="Entity"/> components.</param>
        void ReadAllComponents(Entity entity, IComponentReader reader);
    }
}