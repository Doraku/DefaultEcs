#if NETSTANDARD1_1
using System;
using System.Threading.Tasks;
#else
using System.Threading;
#endif

namespace DefaultEcs.Internal.Helper
{
    internal sealed class DefaultThread
    {
#if NETSTANDARD1_1
        private readonly Task _task;

        public DefaultThread(Action<object> action, object state)
        {
            _task = new Task(action, state, TaskCreationOptions.LongRunning);
        }

        public void Start() => _task.Start(TaskScheduler.Default);

        public void Wait() => _task.Wait();
#else
        private readonly Thread _thread;
        private readonly object _state;

        public DefaultThread(ParameterizedThreadStart action, object state)
        {
            _thread = new Thread(action);
            _state = state;

            _thread.Name = $"{nameof(DefaultThread)} {state}";
        }

        public void Start() => _thread.Start(_state);

        public void Wait() => _thread.Join();
#endif
    }
}
