using System;

namespace DefaultEcs {
    /// <summary>
    /// A thing that responsible to mutate Entities
    /// </summary>
    public interface IEntityMutator {

        /// <summary>
        /// Some internal stuff 
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <param name="component"></param>
        /// <typeparam name="T"></typeparam>
        void SetDisabled<T>(Entity entity, in T component);

        /// <summary>
        /// Some internal stuff 
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <param name="reference"></param>
        /// <typeparam name="T"></typeparam>
        void SetSameAsDisabled<T>(Entity entity, in Entity reference);
        
        /// <summary>
        /// Enables the current <see cref="Entity"/> so it can appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        void Enable(Entity entity);

        /// <summary>
        /// Disables the current <see cref="Entity"/> so it does not appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        void Disable(Entity entity);

        /// <summary>
        /// Enables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it can appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        void Enable<T>(Entity entity);

        /// <summary>
        /// Disables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it does not appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        void Disable<T>(Entity entity);

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        void Set<T>(Entity entity, in T component);

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/> to the same instance of an other <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="reference">The other <see cref="Entity"/> used as reference.</param>
        /// <param name="target">Entity to mutate</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> comes from a different <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.</exception>
        void SetSameAs<T>(Entity target, in Entity reference);

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        void Remove<T>(Entity entity);

        /// <summary>
        /// Makes it so when given <see cref="Entity"/> is disposed, current <see cref="Entity"/> will also be disposed.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        void SetAsChildOf(Entity entity, in Entity parent);

        /// <summary>
        /// Makes it so when current <see cref="Entity"/> is disposed, given <see cref="Entity"/> will also be disposed.
        /// </summary>
        /// <param name="parent">Entity to mutate</param>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        void SetAsParentOf(Entity parent, in Entity child);

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> parents.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        void RemoveFromChildrenOf(Entity entity, in Entity parent);

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> children.
        /// </summary>
        /// <param name="parent">Entity to mutate</param>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        void RemoveFromParentsOf(Entity parent, in Entity child);

        /// <summary>
        /// Clean the current <see cref="Entity"/> of all its components.
        /// The current <see cref="Entity"/> should not be used again after calling this method.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        void Dispose(Entity entity);

        /// <summary>
        /// Creates a copy of current <see cref="Entity"/> with all of its components in the given <see cref="DefaultEcs.World"/>.
        /// </summary>
        /// <param name="entity">Entity to mutate</param>
        /// <param name="world">The <see cref="DefaultEcs.World"/> instance to which copy current <see cref="Entity"/> and its components.</param>
        /// <returns>The created <see cref="Entity"/> in the given <see cref="DefaultEcs.World"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        Entity CopyTo(Entity entity, World world);
    }
}