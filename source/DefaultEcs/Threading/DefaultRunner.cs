using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DefaultEcs.Technical.Threading;

namespace DefaultEcs.Threading
{
    /// <summary>
    /// Represents an object used to run an <see cref="IRunnable"/> by using multiple <see cref="Task"/>.
    /// </summary>
    public sealed class DefaultRunner : IRunner
    {
        #region Fields

        internal static readonly DefaultRunner Default = new DefaultRunner(1);

        private readonly CancellationTokenSource _disposeHandle;
        private readonly WorkerBarrier _barrier;
        private readonly Task[] _tasks;

        private IRunnable _currentRunnable;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="DefaultRunner"/> class.
        /// </summary>
        /// <param name="degreeOfParallelism">The number of concurrent <see cref="Task"/> used to update an <see cref="IRunnable"/> in parallel.</param>
        /// <exception cref="ArgumentException"><paramref name="degreeOfParallelism"/> cannot be inferior to one.</exception>
        public DefaultRunner(int degreeOfParallelism)
        {
            IEnumerable<int> indices = degreeOfParallelism >= 1 ? Enumerable.Range(0, degreeOfParallelism - 1) : throw new ArgumentException("Argument cannot be inferior to one", nameof(degreeOfParallelism));

            _disposeHandle = new CancellationTokenSource();
            _tasks = indices.Select(index => new Task(Update, index, TaskCreationOptions.LongRunning)).ToArray();
            _barrier = degreeOfParallelism > 1 ? new WorkerBarrier(_tasks.Length) : null;

            foreach (Task task in _tasks)
            {
                task.Start(TaskScheduler.Default);
            }
        }

        #endregion

        #region Methods

        private void Update(object state)
        {
            int index = (int)state;

            goto Start;

        Work:
            Volatile.Read(ref _currentRunnable).Run(index, _tasks.Length);

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
        /// Gets the degree of parallelism used to run an <see cref="IRunnable"/>.
        /// </summary>
        public int DegreeOfParallelism => _tasks.Length + 1;

        /// <summary>
        /// Runs the provided <see cref="IRunnable"/>.
        /// </summary>
        /// <param name="runnable">The <see cref="IRunnable"/> to run.</param>
        public void Run(IRunnable runnable)
        {
            Volatile.Write(ref _currentRunnable, runnable);

            _barrier?.StartWorkers();

            runnable.Run(_tasks.Length, _tasks.Length);

            _barrier?.WaitForWorkers();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases all the resources used by the current <see cref="DefaultRunner"/> instance.
        /// </summary>
        public void Dispose()
        {
            _disposeHandle.Cancel();

            _barrier?.StartWorkers();

            Task.WaitAll(_tasks);

            _barrier?.Dispose();
            _disposeHandle.Dispose();
        }

        #endregion
    }
}
