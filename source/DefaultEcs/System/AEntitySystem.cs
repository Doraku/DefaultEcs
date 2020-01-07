using System;
using DefaultEcs.Technical.System;
using DefaultEcs.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class AEntitySystem<T> : ISystem<T>
    {
        #region Types

        private class Runnable : IParallelRunnable
        {
            private readonly AEntitySystem<T> _system;

            public T CurrentState;
            public int EntitiesPerIndex;

            public Runnable(AEntitySystem<T> system)
            {
                _system = system;
            }

            public void Run(int index, int maxIndex)
            {
                int start = index * EntitiesPerIndex;

                _system.Update(CurrentState, _system._set.GetEntities(start, index == maxIndex ? _system._set.Count - start : EntitiesPerIndex));
            }
        }

        #endregion

        #region Fields

        private readonly IParallelRunner _runner;
        private readonly Runnable _runnable;
        private readonly EntitySet _set;
        private readonly int _minEntityCountByRunnerIndex;

        /// <summary>
        /// Event called when an <see cref="Entity"/> is added to the inner <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> EntityAdded
        {
            add => _set.EntityAdded += value;
            remove => _set.EntityAdded -= value;
        }

        /// <summary>
        /// Event called when an <see cref="Entity"/> is removed from the inner <see cref="EntitySet"/>.
        /// </summary>
        public event ActionIn<Entity> EntityRemoved
        {
            add => _set.EntityRemoved += value;
            remove => _set.EntityRemoved -= value;
        }

        #endregion

        #region Initialisation

        private AEntitySystem(IParallelRunner runner, int minEntityCountByRunnerIndex)
        {
            _runner = runner ?? DefaultParallelRunner.Default;
            _runnable = new Runnable(this);
            _minEntityCountByRunnerIndex = minEntityCountByRunnerIndex;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySystem(EntitySet set, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : this(runner, minEntityCountByRunnerIndex)
        {
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySystem(EntitySet set, IParallelRunner runner)
            : this(set, runner, 0)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySystem(EntitySet set)
            : this(set, null)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : this(runner, minEntityCountByRunnerIndex)
        {
            _set = EntitySetFactory.Create(GetType())(world ?? throw new ArgumentNullException(nameof(world)));
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySystem(World world, IParallelRunner runner)
            : this(world, runner, 0)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySystem(World world)
            : this(world, null)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Performs a pre-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PreUpdate(T state) { }

        /// <summary>
        /// Performs a post-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected virtual void PostUpdate(T state) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instance once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entity">The <see cref="Entity"/> instance to update.</param>
        protected virtual void Update(T state, in Entity entity) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to update.</param>
#pragma warning disable RCS1231 // Make parameter ref read-only. For some reason, less performant with a "in"
        protected virtual void Update(T state, ReadOnlySpan<Entity> entities)
#pragma warning restore RCS1231 // Make parameter ref read-only.
        {
            foreach (ref readonly Entity entity in entities)
            {
                Update(state, entity);
            }
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AEntitySystem{T}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if the inner <see cref="EntitySet"/> is empty.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            if (IsEnabled && _set.Count > 0)
            {
                PreUpdate(state);

                _runnable.CurrentState = state;
                _runnable.EntitiesPerIndex = _set.Count / _runner.DegreeOfParallelism;

                if (_runnable.EntitiesPerIndex < _minEntityCountByRunnerIndex)
                {
                    Update(state, _set.GetEntities());
                }
                else
                {
                    _runner.Run(_runnable);
                }

                _set.Complete();

                PostUpdate(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntitySet"/> instance.
        /// </summary>
        public virtual void Dispose()
        {
            _set.Dispose();
        }

        #endregion
    }
}
