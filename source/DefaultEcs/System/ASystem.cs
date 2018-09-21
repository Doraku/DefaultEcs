namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates, supporting a <see cref="SystemRunner{T}"/>. Do not inherit from this class directly.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class ASystem<T> : ISystem<T>
    {
        #region Fields

        private readonly SystemRunner<T> _runner;

        internal T CurrentState;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="ASystem{T}"/> class with the given <see cref="SystemRunner{T}"/>.
        /// </summary>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        protected ASystem(SystemRunner<T> runner)
        {
            _runner = runner ?? SystemRunner<T>.Default;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="ASystem{T}"/> class.
        /// </summary>
        protected ASystem()
            : this(null)
        { }

        #endregion

        #region Methods

        internal abstract void Update(int index, int maxIndex);

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

        #endregion

        #region ISystem

        /// <summary>
        /// Updates the system once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            CurrentState = state;

            PreUpdate(CurrentState);

            _runner.Update(this);

            PostUpdate(CurrentState);
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Does nothing.
        /// </summary>
        public abstract void Dispose();

        #endregion
    }
}
