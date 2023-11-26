using System;
using System.Threading;

namespace DefaultEcs.Threading
{
    /// <summary>
    /// Represents an object used to run an <see cref="IParallelRunnable"/> by using multiple <see cref="Thread"/>.
    /// </summary>
    public sealed class DefaultParallelRunner : IParallelRunner
    {
        #region Fields

        internal static readonly DefaultParallelRunner Default = new(1);

        private readonly object _syncObject = new object();
        private readonly ManualResetEventSlim _workStartEvent;
        private readonly Thread[] _threads;
        private readonly bool[] _threadsWorkState;

        private volatile bool _isAlive;
        private volatile int _pendingTasks;
        private volatile IParallelRunnable _currentRunnable;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="DefaultParallelRunner"/> class.
        /// </summary>
        /// <param name="degreeOfParallelism">The number of concurrent <see cref="Thread"/> used to update an <see cref="IParallelRunnable"/> in parallel.</param>
        /// <param name="threadNamePrefix"> Name prefix for the threads in case you have more than one runner and need to mark them. </param>
        /// <exception cref="ArgumentException"><paramref name="degreeOfParallelism"/> cannot be inferior to one.</exception>
        public DefaultParallelRunner(int degreeOfParallelism, string threadNamePrefix = null)
        {
            if (0 >= degreeOfParallelism)
                throw new ArgumentException($"Argument {nameof(degreeOfParallelism)} cannot be inferior to one!");

            _isAlive = true;
            threadNamePrefix ??= "";
            _workStartEvent = new ManualResetEventSlim(initialState: false);
            _threads = new Thread[degreeOfParallelism - 1];
            _threadsWorkState = new bool[_threads.Length];
            for (int threadIndex = 0; _threads.Length > threadIndex; threadIndex++)
            {
                _threads[threadIndex] = new Thread(new ParameterizedThreadStart(this.ThreadExecutionLoop));
                Thread newThread = _threads[threadIndex];
                newThread.Name = threadNamePrefix + $"{nameof(DefaultParallelRunner)} worker {threadIndex + 1}";
                newThread.IsBackground = true;
                newThread.Start(threadIndex);
            }
        }

        #endregion

        #region Methods

        private void ThreadExecutionLoop(object initObject)
        {
            int workerIndex = (int)initObject;
            while (_isAlive)
            {
                _workStartEvent.Wait();
                if (!_isAlive) return;
                if (!_threadsWorkState[workerIndex]) continue;

                try
                {
                    _currentRunnable?.Run(workerIndex, _threads.Length);
                }
                finally
                {
                    lock (_syncObject)
                    {
                        _pendingTasks--;
                        _threadsWorkState[workerIndex] = false;
                    }
                }
            }
        }

        private bool IsAllThreadsStopped()
        {
            bool result = true;
            foreach (Thread thread in _threads)
            {
                if (thread.ThreadState == ThreadState.Running)
                {
                    result = false;
                    break;
                }
            }
            return result;
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
            if (!_isAlive) throw new InvalidOperationException("Runner was already disposed!");
            runnable.ThrowIfNull();

            _currentRunnable = runnable;
            if (_threads.Length > 0)
            {
                _pendingTasks = _threads.Length;
                _threadsWorkState.Fill<bool>(true);
                _workStartEvent.Set();
                try
                {
                    _currentRunnable.Run(index: _threads.Length, maxIndex: _threads.Length);
                }
                finally
                {
                    SpinWait.SpinUntil(() => _pendingTasks == 0);
                    _workStartEvent.Reset();
                    SpinWait.SpinUntil(IsAllThreadsStopped);
                }
            }
            else
            {
                _currentRunnable.Run(index: _threads.Length, maxIndex: _threads.Length);
            }
            _currentRunnable = null;
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases all the resources used by the current <see cref="DefaultParallelRunner"/> instance.
        /// </summary>
        public void Dispose()
        {
            if (!_isAlive) return;
            _isAlive = false;
            _currentRunnable = null;
            _workStartEvent.Set();
            Thread.Sleep(millisecondsTimeout: 1);
            _workStartEvent.Dispose();
        }

        #endregion
    }
}
