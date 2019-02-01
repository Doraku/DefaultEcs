using System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a class to set up easily a custom action as a system update.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public sealed class ActionSystem<T> : ISystem<T>
    {
        #region Fields

        private readonly Action<T> _action;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="ActionSystem{T}"/> class with the given <see cref="Action{T}"/>.
        /// </summary>
        /// <param name="action">The <see cref="Action{T}"/> to call as update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public ActionSystem(Action<T> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            IsEnabled = true;
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="ActionSystem{T}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Updates the system once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            if (IsEnabled)
            {
                _action(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Does nothing.
        /// </summary>
        public void Dispose()
        { }

        #endregion
    }
}
