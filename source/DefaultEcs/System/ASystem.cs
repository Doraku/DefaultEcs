namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class ASystem<T> : ISystem<T>
    {
        #region Fields

        private readonly SystemRunner<T> _runner;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="ASystem{T}"/> class with the given <see cref="SystemRunner{T}"/>.
        /// </summary>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        protected ASystem(SystemRunner<T> runner)
        {
            _runner = runner;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class.
        /// </summary>
        protected ASystem()
            : this(null)
        { }

        #endregion

        #region Methods

        private protected abstract void DefaultUpdate(T state);

        internal abstract void Update(T state, int index, int maxIndex);

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
                DefaultUpdate(state);
            }
        }

        #endregion
    }
}
