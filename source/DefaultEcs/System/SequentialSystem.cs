namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a collection of <see cref="ISystem{T}"/> to update sequentially.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the systems.</typeparam>
    public sealed class SequentialSystem<T> : ISystem<T>
    {
        #region Fields

        private readonly ISystem<T>[] _systems;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="SequentialSystem{T}"/> class.
        /// </summary>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public SequentialSystem(params ISystem<T>[] systems)
        {
            _systems = systems ?? new ISystem<T>[0];
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Updates all the systems once sequentially.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            foreach (ISystem<T> system in _systems)
            {
                system?.Update(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes all the inner <see cref="ISystem{T}"/> instances.
        /// </summary>
        public void Dispose()
        {
            for (int i = _systems.Length - 1; i >= 0; --i)
            {
                _systems[i]?.Dispose();
            }
        }

        #endregion
    }
}
