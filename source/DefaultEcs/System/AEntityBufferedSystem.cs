using System;
using System.Buffers;
using DefaultEcs.Technical.System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance.
    /// <see cref="Entity"/> instances are buffered in a rented array from <see cref="ArrayPool{T}.Shared"/> so structural modification are possible without the use of a <see cref="Command.EntityCommandRecorder"/>.
    /// The updates are single threaded, all <see cref="Entity"/> operations are safe.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class AEntityBufferedSystem<T> : ISystem<T>
    {
        #region Fields

        private readonly EntitySet _set;

        /// <summary>
        /// Event called when an <see cref="Entity"/> is added to the inner <see cref="EntitySet"/>.
        /// </summary>
        public event MessageHandler<Entity> EntityAdded
        {
            add => _set.EntityAdded += value;
            remove => _set.EntityAdded -= value;
        }

        /// <summary>
        /// Event called when an <see cref="Entity"/> is removed from the inner <see cref="EntitySet"/>.
        /// </summary>
        public event MessageHandler<Entity> EntityRemoved
        {
            add => _set.EntityRemoved += value;
            remove => _set.EntityRemoved -= value;
        }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityBufferedSystem{T}"/> class with the given <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntityBufferedSystem(EntitySet set)
        {
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntityBufferedSystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntityBufferedSystem(World world)
        {
            _set = EntitySetFactory.Create(GetType())(world ?? throw new ArgumentNullException(nameof(world)));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs a pre-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PreUpdate(T state) { }

        /// <summary>
        /// Performs a post-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PostUpdate(T state) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instance once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entity">The <see cref="Entity"/> instance to update.</param>
        protected virtual void Update(T state, in Entity entity) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to update.</param>
        protected virtual void Update(T state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                Update(state, entity);
            }
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AEntityBufferedSystem{T}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if the inner <see cref="EntitySet"/> is empty.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            if (IsEnabled && _set.Count > 0)
            {
                PreUpdate(state);

                Entity[] entities = ArrayPool<Entity>.Shared.Rent(_set.Count);
                _set.GetEntities().CopyTo(entities);

                Update(state, new ReadOnlySpan<Entity>(entities, 0, _set.Count));

                ArrayPool<Entity>.Shared.Return(entities);
                _set.Complete();

                PostUpdate(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntitySet"/> instance.
        /// </summary>
        public virtual void Dispose()
        {
            _set.Dispose();
        }

        #endregion
    }
}
