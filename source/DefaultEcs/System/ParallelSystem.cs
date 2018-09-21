using System.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a collection of <see cref="ISystem{T}"/> to update in parallel.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the systems.</typeparam>
    public sealed class ParallelSystem<T> : ASystem<T>
    {
        #region Fields

        private readonly ISystem<T> _mainSystem;
        private readonly ISystem<T>[] _systems;

        private int _lastIndex;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="mainSystem">The <see cref="ISystem{T}"/> instance to be updated on the calling thread.</param>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(ISystem<T> mainSystem, SystemRunner<T> runner, params ISystem<T>[] systems)
            : base(runner)
        {
            _mainSystem = mainSystem;
            _systems = systems ?? new ISystem<T>[0];
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(SystemRunner<T> runner, params ISystem<T>[] systems)
            : this(null, runner, systems)
        { }

        #endregion

        #region ASystem

        internal override void Update(int index, int maxIndex)
        {
            if (index == maxIndex)
            {
                _mainSystem?.Update(CurrentState);
            }

            while ((index = Interlocked.Increment(ref _lastIndex)) < _systems.Length)
            {
                _systems[index]?.Update(CurrentState);
            }
        }

        /// <summary>
        /// Performs a pre-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected override void PreUpdate(T state) => Interlocked.Exchange(ref _lastIndex, -1);

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes all the inner <see cref="ISystem{T}"/> instances.
        /// </summary>
        public override void Dispose()
        {
            _mainSystem?.Dispose();

            foreach (ISystem<T> system in _systems)
            {
                system?.Dispose();
            }
        }

        #endregion
    }
}
