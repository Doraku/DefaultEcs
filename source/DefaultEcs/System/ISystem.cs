using System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Exposes a method to update a system.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public interface ISystem<T> : IDisposable
    {
        /// <summary>
        /// Updates the system once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        void Update(T state);
    }
}
