using System;
using DefaultEcs.Command;
using DefaultEcs.Technical.System;
using DefaultEcs.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance by recording commands to be executed in a deferred way.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class AEntityDeferredSystem<T> : ISystem<T>
    {
        #region Types

        private class Runnable : IParallelRunnable
        {
            private readonly AEntityDeferredSystem<T> _system;

            public T CurrentState;
            public int EntitiesPerIndex;

            public Runnable(AEntityDeferredSystem<T> system)
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
        private readonly World _world;
        private readonly EntityCommandRecorder _recorder;
        private readonly EntitySet _set;

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

        private AEntityDeferredSystem(IParallelRunner runner, World world, EntityCommandRecorder recorder)
        {
            _runner = runner ?? DefaultParallelRunner.Default;
            _runnable = new Runnable(this);
            _world = world ?? throw new ArgumentNullException(nameof(world));
            _recorder = recorder ?? new EntityCommandRecorder();
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which to execute the deferred commands.</param>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="recorder">The <see cref="EntityCommandRecorder"/> used to record the commands to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntityDeferredSystem(World world, EntitySet set, IParallelRunner runner = null, EntityCommandRecorder recorder = null)
            : this(runner, world, recorder)
        {
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which to execute the deferred commands and from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="recorder">The <see cref="EntityCommandRecorder"/> used to record the commands to execute.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntityDeferredSystem(World world, IParallelRunner runner = null, EntityCommandRecorder recorder = null)
            : this(runner, world, recorder)
        {
            _set = EntitySetFactory.Create(GetType())(world ?? throw new ArgumentNullException(nameof(world)));
        }

        #endregion

        #region Methods

        private void Update(T state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                Update(state, _recorder.Record(entity));
            }
        }

        /// <summary>
        /// Records the creation of an <see cref="Entity"/> and returns an <see cref="EntityRecord"/> to record action on it.
        /// </summary>
        /// <returns>The <see cref="EntityRecord"/> used to record actions on the later created <see cref="Entity"/>.</returns>
        /// <exception cref="InvalidOperationException">The internal <see cref="EntityCommandRecorder"/> buffer is full.</exception>
        protected EntityRecord CreateEntity() => _recorder.CreateEntity();

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
        protected abstract void Update(T state, in EntityRecord entity);

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
                _runner.Run(_runnable);

                _set.Complete();
                _recorder.Execute(_world);

                PostUpdate(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntitySet"/> and <see cref="EntityCommandRecorder"/> instances.
        /// </summary>
        public virtual void Dispose()
        {
            _set.Dispose();
            _recorder.Dispose();
        }

        #endregion
    }
}
