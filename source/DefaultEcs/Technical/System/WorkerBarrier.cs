using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DefaultEcs.Technical.System
{
    internal sealed class WorkerBarrier : IDisposable
    {
        #region Fields

        private readonly int _count;
        private readonly ManualResetEventSlim _endHandle;
        private readonly ManualResetEventSlim _startHandle;
        private readonly ManualResetEventSlim _startedHandle;

        private int _runningCount;
        private int _startingCount;

        #endregion

        #region Properties

        public bool AllStarted
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Volatile.Read(ref _startingCount) == 0;
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
            _endHandle = new ManualResetEventSlim();
            _startHandle = new ManualResetEventSlim();
            _startedHandle = new ManualResetEventSlim();

            _runningCount = 0;
            _startingCount = 0;
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StartWorkers()
        {
            Interlocked.Exchange(ref _runningCount, _count);
            Interlocked.Exchange(ref _startingCount, _count);

            _startedHandle.Reset();
            _startHandle.Set();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Start()
        {
            if (Volatile.Read(ref _startingCount) > 0)
            {
                if (Interlocked.Decrement(ref _startingCount) == 0)
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
        public void WaitForAllDone()
        {
            _endHandle.Wait();
            _endHandle.Reset();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitToStart() => _startHandle.Wait();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WaitForAllStarted() => _startedHandle.Wait();

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
