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
            _action = action.ThrowIfNull();
            IsEnabled = true;
        }

        #endregion

        #region ISystem

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }

        /// <inheritdoc/>
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
