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

        private readonly CancellationTokenSource _disposeHandle;
        private readonly ManualResetEventSlim[] _startHandles;
        private readonly ManualResetEventSlim[] _endHandles;
        private readonly Task[] _tasks;

        private volatile ASystem<T> _currentSystem;
        private T _currentState;

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
            _startHandles = indices.Select(_ => new ManualResetEventSlim()).ToArray();
            _endHandles = indices.Select(_ => new ManualResetEventSlim()).ToArray();
            _tasks = indices.Select(index => new Task(Update, index, TaskCreationOptions.LongRunning)).ToArray();

            foreach (Task task in _tasks)
            {
                task.Start();
            }
        }

        #endregion

        #region Methods

        private void Update(object state)
        {
            int index = (int)state;
            ManualResetEventSlim startHandle = _startHandles[index];
            ManualResetEventSlim endHandle = _endHandles[index];

            startHandle.Wait();

            while (!_disposeHandle.IsCancellationRequested)
            {
                startHandle.Reset();

                _currentSystem.Update(_currentState, index, _tasks.Length);

                endHandle.Set();
                startHandle.Wait();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void Update(T state, ASystem<T> system)
        {
            _currentState = state;
            _currentSystem = system;

            foreach (ManualResetEventSlim handle in _startHandles)
            {
                handle.Set();
            }

            _currentSystem.Update(_currentState, _tasks.Length, _tasks.Length);

            foreach (ManualResetEventSlim handle in _endHandles)
            {
                handle.Wait();
                handle.Reset();
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases all the resources used by the current <see cref="SystemRunner{T}"/> instance.
        /// </summary>
        public void Dispose()
        {
            _disposeHandle.Cancel();

            foreach (ManualResetEventSlim handle in _startHandles)
            {
                handle.Set();
            }
            Task.WaitAll(_tasks);

            foreach (ManualResetEventSlim handle in _startHandles)
            {
                handle.Dispose();
            }
            foreach (ManualResetEventSlim handle in _endHandles)
            {
                handle.Dispose();
            }
            _disposeHandle.Dispose();
        }

        #endregion
    }
}
