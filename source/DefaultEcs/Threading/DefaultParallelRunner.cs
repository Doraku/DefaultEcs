using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Threading;

namespace DefaultEcs.Threading
{
    /// <summary>
    /// Represents an object used to run an <see cref="IParallelRunnable"/> by using multiple <see cref="Task"/>.
    /// </summary>
    public sealed class DefaultParallelRunner : IParallelRunner
    {
        #region Fields

        internal static readonly DefaultParallelRunner Default = new(1);

        private readonly CancellationTokenSource _disposeHandle;
        private readonly WorkerBarrier _barrier;
        private readonly DefaultThread[] _threads;

        private IParallelRunnable _currentRunnable;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="DefaultParallelRunner"/> class.
        /// </summary>
        /// <param name="degreeOfParallelism">The number of concurrent <see cref="Task"/> used to update an <see cref="IParallelRunnable"/> in parallel.</param>
        /// <exception cref="ArgumentException"><paramref name="degreeOfParallelism"/> cannot be inferior to one.</exception>
        public DefaultParallelRunner(int degreeOfParallelism)
        {
            IEnumerable<int> indices = degreeOfParallelism >= 1 ? Enumerable.Range(0, degreeOfParallelism - 1) : throw new ArgumentException("Argument cannot be inferior to one", nameof(degreeOfParallelism));

            _disposeHandle = new CancellationTokenSource();
            _threads = indices.Select(index => new DefaultThread(Update, index)).ToArray();
            _barrier = degreeOfParallelism > 1 ? new WorkerBarrier(_threads.Length) : null;

            foreach (DefaultThread thread in _threads)
            {
                thread.Start();
            }
        }

        #endregion

        #region Methods

        private void Update(object state)
        {
            int index = (int)state;

            goto Start;

        Work:
            Volatile.Read(ref _currentRunnable).Run(index, _threads.Length);

            _barrier.Signal();

        Start:
            _barrier.Start();

            if (!_disposeHandle.IsCancellationRequested)
            {
                goto Work;
            }
        }

        #endregion

        #region IRunner

        /// <summary>
        /// Gets the degree of parallelism used to run an <see cref="IParallelRunnable"/>.
        /// </summary>
        public int DegreeOfParallelism => _threads.Length + 1;

        /// <summary>
        /// Runs the provided <see cref="IParallelRunnable"/>.
        /// </summary>
        /// <param name="runnable">The <see cref="IParallelRunnable"/> to run.</param>
        public void Run(IParallelRunnable runnable)
        {
            Volatile.Write(ref _currentRunnable, runnable);

            _barrier?.StartWorkers();

            runnable.Run(_threads.Length, _threads.Length);

            _barrier?.WaitForWorkers();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases all the resources used by the current <see cref="DefaultParallelRunner"/> instance.
        /// </summary>
        public void Dispose()
        {
            _disposeHandle.Cancel();

            _barrier?.StartWorkers();

            foreach (DefaultThread thread in _threads)
            {
                thread.Wait();
            }

            _barrier?.Dispose();
            _disposeHandle.Dispose();
        }

        #endregion
    }
}
