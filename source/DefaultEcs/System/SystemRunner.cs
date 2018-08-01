using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents an helper object used to update a system in parallel.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public sealed class SystemRunner<T> : IDisposable
    {
        #region Fields

        internal static readonly SystemRunner<T> Default = new SystemRunner<T>(1);

        private readonly CancellationTokenSource _disposeHandle;
        private readonly Barrier _barrier;
        private readonly Task[] _tasks;

        private volatile ASystem<T> _currentSystem;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="SystemRunner{T}"/> class.
        /// </summary>
        /// <param name="degreeOfParallelism">The number of <see cref="Task"/> instances used to update a system in parallel.</param>
        /// <exception cref="ArgumentException"><paramref name="degreeOfParallelism"/> cannot be inferior to one.</exception>
        public SystemRunner(int degreeOfParallelism)
        {
            IEnumerable<int> indices = degreeOfParallelism >= 1 ? Enumerable.Range(0, degreeOfParallelism - 1) : throw new ArgumentException("Argument cannot be inferior to one", nameof(degreeOfParallelism));

            _disposeHandle = new CancellationTokenSource();
            _barrier = degreeOfParallelism > 1 ? new Barrier(degreeOfParallelism) : null;
            _tasks = indices.Select(index => new Task(Update, index, TaskCreationOptions.LongRunning)).ToArray();

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

            _barrier.SignalAndWait();

            while (!_disposeHandle.IsCancellationRequested)
            {
                _currentSystem.Update(index, _tasks.Length);

                _barrier.SignalAndWait();
                _barrier.SignalAndWait();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Update(ASystem<T> system)
        {
            _currentSystem = system;

            _barrier?.SignalAndWait();

            system.Update(_tasks.Length, _tasks.Length);

            _barrier?.SignalAndWait();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases all the resources used by the current <see cref="SystemRunner{T}"/> instance.
        /// </summary>
        public void Dispose()
        {
            _disposeHandle.Cancel();

            _barrier?.SignalAndWait();

            Task.WaitAll(_tasks);

            _barrier?.Dispose();
            _disposeHandle.Dispose();
        }

        #endregion
    }
}
