using System;
using System.Diagnostics;
using DefaultEcs.Internal;
using DefaultEcs.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="World"/> instance to all its components of type <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TState">The type of the object used as state to update the system.</typeparam>
    /// <typeparam name="TComponent">The type of component to update.</typeparam>
    public abstract class AComponentSystem<TState, TComponent> : ISystem<TState>
    {
        #region Types

        private sealed class Runnable : IParallelRunnable
        {
            private readonly AComponentSystem<TState, TComponent> _system;

            public TState CurrentState;
            public int ComponentsPerIndex;

            public Runnable(AComponentSystem<TState, TComponent> system)
            {
                _system = system;
            }

#if NETSTANDARD2_1_OR_GREATER
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0057:Use range operator")]
#endif
            public void Run(int index, int maxIndex)
            {
                Span<TComponent> components = _system._components.AsSpan();
                int start = index * ComponentsPerIndex;

                _system.Update(CurrentState, index == maxIndex ? components.Slice(start) : components.Slice(start, ComponentsPerIndex));
            }
        }

        #endregion

        #region Fields

        private readonly IParallelRunner _runner;
        private readonly Runnable _runnable;
        private readonly ComponentPool<TComponent> _components;
        private readonly int _minComponentCountByRunnerIndex;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance on which this system operates.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World { get; }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="AComponentSystem{TState, TComponent}"/> class with the given <see cref="World"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minComponentCountByRunnerIndex">The minimum number of component per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AComponentSystem(World world, IParallelRunner runner, int minComponentCountByRunnerIndex)
        {
            _runner = runner ?? DefaultParallelRunner.Default;
            _runnable = new Runnable(this);
            _components = ComponentManager<TComponent>.GetOrCreate(world.ThrowIfNull().WorldId);
            _minComponentCountByRunnerIndex = _runner.DegreeOfParallelism > 1 ? minComponentCountByRunnerIndex : int.MaxValue;

            World = world;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AComponentSystem{TState, TComponent}"/> class with the given <see cref="World"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AComponentSystem(World world, IParallelRunner runner)
            : this(world, runner, 0)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AComponentSystem{TState, TComponent}"/> class with the given <see cref="World"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AComponentSystem(World world)
            : this(world, null)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Performs a pre-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PreUpdate(TState state) { }

        /// <summary>
        /// Performs a post-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PostUpdate(TState state) { }

        /// <summary>
        /// Update the given <typeparamref name="TComponent"/> once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="component">The <typeparamref name="TComponent"/> to update.</param>
        protected virtual void Update(TState state, ref TComponent component) { }

        /// <summary>
        /// Update the given <typeparamref name="TComponent"/> once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="components">The <typeparamref name="TComponent"/> to update.</param>
        protected virtual void Update(TState state, Span<TComponent> components)
        {
            foreach (ref TComponent component in components)
            {
                Update(state, ref component);
            }
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AComponentSystem{TState, TComponent}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if there is no component of type <typeparamref name="TComponent"/> in the <see cref="World"/>.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(TState state)
        {
            if (IsEnabled && _components.IsNotEmpty)
            {
                PreUpdate(state);

                _runnable.ComponentsPerIndex = _components.Count / _runner.DegreeOfParallelism;

                if (_runnable.ComponentsPerIndex < _minComponentCountByRunnerIndex)
                {
                    Update(state, _components.AsSpan());
                }
                else
                {
                    _runnable.CurrentState = state;
                    _runner.Run(_runnable);
                }

                PostUpdate(state);
            }
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
