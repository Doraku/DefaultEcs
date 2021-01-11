using System;
using System.Buffers;
using System.Diagnostics;
using DefaultEcs.Technical.System;
using DefaultEcs.Threading;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance.
    /// Only <see cref="Entity.Get{T}()"/>, <see cref="Entity.Set{T}(in T)"/> and <see cref="Entity.SetSameAs{T}(in Entity)"/> operation on already present component type are safe.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class AEntitySetSystem<T> : ISystem<T>
    {
        #region Types

        private class Runnable : IParallelRunnable
        {
            private readonly AEntitySetSystem<T> _system;

            public T CurrentState;
            public int EntitiesPerIndex;

            public Runnable(AEntitySetSystem<T> system)
            {
                _system = system;
            }

            public void Run(int index, int maxIndex)
            {
                int start = index * EntitiesPerIndex;

                _system.Update(CurrentState, _system.Set.GetEntities(start, index == maxIndex ? _system.Set.Count - start : EntitiesPerIndex));
            }
        }

        #endregion

        #region Fields

        private readonly bool _useBuffer;
        private readonly IParallelRunner _runner;
        private readonly Runnable _runnable;
        private readonly int _minEntityCountByRunnerIndex;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="EntitySet"/> instance on which this system operates.
        /// </summary>
        public EntitySet Set { get; }

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance on which this system operates.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World { get; }

        #endregion

        #region Initialisation

        private AEntitySetSystem(Func<object, EntitySet> factory, IParallelRunner runner, int minEntityCountByRunnerIndex)
        {
            Set = factory(this);
            World = Set.World;

            _runner = runner ?? DefaultParallelRunner.Default;
            _runnable = new Runnable(this);
            _minEntityCountByRunnerIndex = minEntityCountByRunnerIndex;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySetSystem(EntitySet set, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : this(_ => set ?? throw new ArgumentNullException(nameof(set)), runner, minEntityCountByRunnerIndex)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="IParallelRunner"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySetSystem(EntitySet set, IParallelRunner runner)
            : this(set, runner, 0)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySetSystem(EntitySet set, bool useBuffer)
            : this(set, null)
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySetSystem(EntitySet set)
            : this(set, false)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="World"/> and factory.
        /// The current instance will be passed as the first parameter of the factory.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="factory">The factory used to create the <see cref="EntitySet"/>.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is null.</exception>
        protected AEntitySetSystem(World world, Func<object, World, EntitySet> factory, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : this(s => (factory ?? throw new ArgumentNullException(nameof(factory)))(s, world ?? throw new ArgumentNullException(nameof(world))), runner, minEntityCountByRunnerIndex)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <param name="minEntityCountByRunnerIndex">The minimum number of <see cref="Entity"/> per runner index to use the given <paramref name="runner"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySetSystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : this(world, static (o, w) => EntityRuleBuilderFactory.Create(o.GetType())(o, w).AsSet(), runner, minEntityCountByRunnerIndex)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="IParallelRunner"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySetSystem(World world, IParallelRunner runner)
            : this(world, runner, 0)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="factory">The factory used to create the <see cref="EntitySet"/>.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is null.</exception>
        protected AEntitySetSystem(World world, Func<object, World, EntitySet> factory, bool useBuffer)
            : this(world, factory, null, 0)
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySetSystem(World world, bool useBuffer)
            : this(world, null)
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySetSystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySetSystem(World world)
            : this(world, false)
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
        protected virtual void Update(T state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                Update(state, entity);
            }
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AEntitySetSystem{T}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if the inner <see cref="EntitySet"/> is empty.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(T state)
        {
            if (IsEnabled && Set.Count > 0)
            {
                PreUpdate(state);

                if (_useBuffer)
                {
                    Entity[] buffer = ArrayPool<Entity>.Shared.Rent(Set.Count);
                    Set.GetEntities().CopyTo(buffer);

                    Update(state, new ReadOnlySpan<Entity>(buffer, 0, Set.Count));

                    ArrayPool<Entity>.Shared.Return(buffer);
                }
                else
                {
                    _runnable.CurrentState = state;
                    _runnable.EntitiesPerIndex = Set.Count / _runner.DegreeOfParallelism;

                    if (_runnable.EntitiesPerIndex < _minEntityCountByRunnerIndex)
                    {
                        Update(state, Set.GetEntities());
                    }
                    else
                    {
                        _runner.Run(_runnable);
                    }
                }

                Set.Complete();

                PostUpdate(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntitySet"/> instance.
        /// </summary>
        public virtual void Dispose() => Set.Dispose();

        #endregion
    }
}
