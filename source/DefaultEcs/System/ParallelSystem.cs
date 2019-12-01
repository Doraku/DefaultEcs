using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DefaultEcs.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a collection of <see cref="ISystem{T}"/> to update in parallel.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the systems.</typeparam>
    public sealed class ParallelSystem<T> : ISystem<T>
    {
        #region Types

        private class Runnable : IRunnable
        {
            private readonly ParallelSystem<T> _system;

            public T CurrentState;
            public int LastIndex;

            public Runnable(ParallelSystem<T> system)
            {
                _system = system;
            }

            public void Run(int index, int maxIndex)
            {
                if (index == maxIndex)
                {
                    _system._mainSystem?.Update(CurrentState);
                }

                while ((index = Interlocked.Increment(ref LastIndex)) < _system._systems.Length)
                {
                    _system._systems[index].Update(CurrentState);
                }
            }
        }

        #endregion

        #region Fields

        private readonly IRunner _runner;
        private readonly Runnable _runnable;
        private readonly ISystem<T> _mainSystem;
        private readonly ISystem<T>[] _systems;

        #endregion

        #region Initialisation

        private ParallelSystem(IRunner runner)
        {
            _runner = runner ?? DefaultRunner.Default;
            _runnable = new Runnable(this);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="mainSystem">The <see cref="ISystem{T}"/> instance to be updated on the calling thread.</param>
        /// <param name="runner">The <see cref="IRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(ISystem<T> mainSystem, IRunner runner, IEnumerable<ISystem<T>> systems)
            : this(runner)
        {
            _mainSystem = mainSystem;
            _systems = (systems ?? Enumerable.Empty<ISystem<T>>()).Where(s => s != null).ToArray();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="mainSystem">The <see cref="ISystem{T}"/> instance to be updated on the calling thread.</param>
        /// <param name="runner">The <see cref="IRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(ISystem<T> mainSystem, IRunner runner, params ISystem<T>[] systems)
            : this(mainSystem, runner, systems as IEnumerable<ISystem<T>>)
        { }

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="runner">The <see cref="IRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(IRunner runner, IEnumerable<ISystem<T>> systems)
            : this(null, runner, systems)
        { }

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="runner">The <see cref="IRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(IRunner runner, params ISystem<T>[] systems)
            : this(null, runner, systems as IEnumerable<ISystem<T>>)
        { }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="ParallelSystem{T}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            if (IsEnabled)
            {
                _runnable.CurrentState = state;
                Interlocked.Exchange(ref _runnable.LastIndex, -1);
                _runner.Run(_runnable);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes all the inner <see cref="ISystem{T}"/> instances.
        /// </summary>
        public void Dispose()
        {
            _mainSystem?.Dispose();

            foreach (ISystem<T> system in _systems)
            {
                system.Dispose();
            }
        }

        #endregion
    }
}
