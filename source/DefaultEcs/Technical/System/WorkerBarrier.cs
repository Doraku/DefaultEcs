using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DefaultEcs.Technical.System
{
    internal sealed class WorkerBarrier : IDisposable
    {
        #region Fields

        private readonly int _count;
        private readonly ManualResetEvent _endHandle;
        private readonly ManualResetEvent _startHandle;

        private bool _allStarted;
        private int _runningCount;

        #endregion

        #region Initialisation

        public WorkerBarrier(int workerCount)
        {
            _count = workerCount;
            _endHandle = new ManualResetEvent(false);
            _startHandle = new ManualResetEvent(false);

            _allStarted = false;
            _runningCount = 0;
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StartWorkers()
        {
            Volatile.Write(ref _allStarted, false);
            _startHandle.Set();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Start()
        {
            _startHandle.WaitOne();

            if (Interlocked.Increment(ref _runningCount) == _count)
            {
                _startHandle.Reset();
                Volatile.Write(ref _allStarted, true);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Signal()
        {
            while (!Volatile.Read(ref _allStarted))
            { }

            if (Interlocked.Decrement(ref _runningCount) == 0)
            {
                _endHandle.Set();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitForWorkers()
        {
            _endHandle.WaitOne();
            _endHandle.Reset();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _endHandle.Dispose();
            _startHandle.Dispose();
        }

        #endregion
    }
}
