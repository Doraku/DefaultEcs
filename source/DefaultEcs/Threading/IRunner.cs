using System;

namespace DefaultEcs.Threading
{
    /// <summary>
    /// Exposes a method to run in parallel a <see cref="IRunnable"/>.
    /// </summary>
    public interface IRunner : IDisposable
    {
        /// <summary>
        /// Gets the degree of parallelism used to run an <see cref="IRunnable"/>.
        /// </summary>
        int DegreeOfParallelism { get; }

        /// <summary>
        /// Runs the provided <see cref="IRunnable"/>.
        /// </summary>
        /// <param name="runnable">The <see cref="IRunnable"/> to run.</param>
        void Run(IRunnable runnable);
    }
}
