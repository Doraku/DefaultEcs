using System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class ASystem<T> : ISystem<T>
    {
        #region Fields

        private readonly EntitySet _set;
        private readonly SystemRunner<T> _runner;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="ASystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="SystemRunner{T}"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected ASystem(EntitySet set, SystemRunner<T> runner)
        {
            _set = set ?? throw new ArgumentNullException(nameof(set));
            _runner = runner;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="ASystem{T}"/> class with the given <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected ASystem(EntitySet set)
            : this(set, null)
        { }

        #endregion

        #region Methods

        internal void Update(T state, int index, int maxIndex)
        {
            int entitiesToUpdate = _set.Count / (maxIndex + 1);

            InternalUpdate(state, index == maxIndex ? _set.GetEntities().Slice(index * entitiesToUpdate) : _set.GetEntities().Slice(index * entitiesToUpdate, entitiesToUpdate));
        }

        /// <summary>
        /// Update the given <see cref="Entity"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to update.</param>
        protected abstract void InternalUpdate(T state, ReadOnlySpan<Entity> entities);

        #endregion

        #region ISystem

        /// <summary>
        /// Updates the system once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            if (_runner != null)
            {
                _runner.Update(state, this);
            }
            else
            {
                InternalUpdate(state, _set.GetEntities());
            }
        }

        #endregion
    }
}
