using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DefaultEcs.Technical.System
{
    internal sealed class WorkerBarrier : IDisposable
    {
        #region Fields

        private readonly int _count;
        private readonly AutoResetEvent _endHandle;
        private readonly ManualResetEvent _startHandle;
        private readonly ManualResetEvent _startedHandle;

        private int _runningCount;

        #endregion

        #region Properties

        public bool AllStarted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Volatile.Read(ref _runningCount) <= _count;
        }

        public bool AllDone
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Volatile.Read(ref _runningCount) == 0;
        }

        #endregion

        #region Initialisation

        public WorkerBarrier(int workerCount)
        {
            _count = workerCount;
            _endHandle = new AutoResetEvent(false);
            _startHandle = new ManualResetEvent(false);
            _startedHandle = new ManualResetEvent(false);

            _runningCount = 0;
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StartWorkers()
        {
            _endHandle.Reset();

            Interlocked.Exchange(ref _runningCount, _count * 2);

            _startedHandle.Reset();
            _startHandle.Set();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Start()
        {
            if (Volatile.Read(ref _runningCount) > _count)
            {
                if (Interlocked.Decrement(ref _runningCount) == _count)
                {
                    _startHandle.Reset();
                    _startedHandle.Set();
                }
                
                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Signal()
        {
            if (Interlocked.Decrement(ref _runningCount) == 0)
            {
                _endHandle.Set();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitForAllDone() => _endHandle.WaitOne();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitToStart() => _startHandle.WaitOne();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitForAllStarted() => _startedHandle.WaitOne();

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _endHandle.Dispose();
            _startHandle.Dispose();
            _startedHandle.Dispose();
        }

        #endregion
    }
}
