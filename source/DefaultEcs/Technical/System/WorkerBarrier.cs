using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DefaultEcs.Technical.System
{
    internal sealed class WorkerBarrier : IDisposable
    {
        #region Fields

        private readonly int _count;
        private readonly ManualResetEventSlim _handle;

        private int _runningCount;
        private int _startingCount;

        #endregion

        public WorkerBarrier(int workerCount)
        {
            _count = workerCount;
            _handle = new ManualResetEventSlim();

            _runningCount = 0;
            _startingCount = 0;
        }

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Start()
        {
            Interlocked.Exchange(ref _runningCount, _count);
            Interlocked.Exchange(ref _startingCount, _count - 1);
            _handle.Set();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StartWorker()
        {
            if (Volatile.Read(ref _startingCount) > 0)
            {
                Interlocked.Decrement(ref _startingCount);

                return true;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool AllStarted() => Volatile.Read(ref _startingCount) == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Signal()
        {
            if (Interlocked.Decrement(ref _runningCount) == 0)
            {
                _handle.Set();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsDone() => Volatile.Read(ref _runningCount) == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Wait() => _handle.Wait();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void End() => _handle.Reset();

        #endregion

        #region IDisposable

        public void Dispose() => _handle.Dispose();

        #endregion
    }
}
