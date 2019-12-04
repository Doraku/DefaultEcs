using System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Exposes a method to update a system.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public interface ISystem<in T> : IDisposable
    {
        /// <summary>
        /// Gets or sets whether the current <see cref="ISystem{T}"/> instance should update or not.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false.
        /// </summary>
        /// <param name="state">The state to use.</param>
        void Update(T state);
    }
}
