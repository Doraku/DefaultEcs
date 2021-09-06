using System.Collections.Concurrent;
using System.Threading;

namespace DefaultEcs.Internal
{
    internal sealed class IntDispenser
    {
        #region Fields

        private readonly ConcurrentStack<int> _freeInts;

        private int _lastInt;

        #endregion

        #region Properties

        public int LastInt => _lastInt;

        #endregion

        #region Initialisation

        public IntDispenser(int startInt)
        {
            _freeInts = new ConcurrentStack<int>();

            _lastInt = startInt;
        }

        #endregion

        #region Methods

        public int GetFreeInt()
        {
            if (!_freeInts.TryPop(out int freeInt))
            {
                freeInt = Interlocked.Increment(ref _lastInt);
            }

            return freeInt;
        }

        public void ReleaseInt(int releasedInt) => _freeInts.Push(releasedInt);

        #endregion
    }
}
