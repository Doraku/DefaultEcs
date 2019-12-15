using System;

namespace DefaultEcs.Threading
{
    /// <summary>
    /// Exposes a method to run in parallel a <see cref="IParallelRunnable"/>.
    /// </summary>
    public interface IParallelRunner : IDisposable
    {
        /// <summary>
        /// Gets the degree of parallelism used to run an <see cref="IParallelRunnable"/>.
        /// </summary>
        int DegreeOfParallelism { get; }

        /// <summary>
        /// Runs the provided <see cref="IParallelRunnable"/>.
        /// </summary>
        /// <param name="runnable">The <see cref="IParallelRunnable"/> to run.</param>
        void Run(IParallelRunnable runnable);
    }
}
