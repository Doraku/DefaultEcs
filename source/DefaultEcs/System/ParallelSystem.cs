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

        private readonly ISystem<T>[] _systems;

        private int _lastIndex;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises a new instance of the <see cref="ParallelSystem{T}"/> class.
        /// </summary>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <param name="systems">The <see cref="ISystem{T}"/> instances.</param>
        public ParallelSystem(SystemRunner<T> runner, params ISystem<T>[] systems)
            : base(runner)
        {
            _systems = systems ?? new ISystem<T>[0];
        }

        #endregion

        #region ASystem

        private protected override void DefaultUpdate(T state)
        {
            foreach (ISystem<T> system in _systems)
            {
                system?.Update(state);
            }
        }

        internal override void Update(T state, int index, int maxIndex)
        {
            while ((index = Interlocked.Increment(ref _lastIndex)) < _systems.Length)
            {
                _systems[index].Update(state);
            }
        }

        /// <summary>
        /// Performs a pre-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected override void PreUpdate(T state) => Interlocked.Exchange(ref _lastIndex, -1);

        #endregion
    }
}
