using System;
using DefaultEcs.Technical.System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class AEntitySystem<T> : ASystem<T>
    {
        #region Fields

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

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="SystemRunner{T}"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySystem(EntitySet set, SystemRunner<T> runner)
            : base(runner)
        {
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }

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
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySystem(World world, SystemRunner<T> runner)
            : base(runner)
        {
            _set = EntitySetBuilderFactory.Create(GetType())(world ?? throw new ArgumentNullException(nameof(world))).Build();
        }

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

        #region ASystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AEntitySystem{T}"/> instance should update or not.
        /// Will return false is there is no <see cref="Entity"/> to update.
        /// </summary>
        public sealed override bool IsEnabled
        {
            get => base.IsEnabled && _set.Count > 0;
            set => base.IsEnabled = value;
        }

        internal sealed override void Update(int index, int maxIndex)
        {
            int entitiesToUpdate = _set.Count / (maxIndex + 1);
            int start = index * entitiesToUpdate;
            if (index == maxIndex)
            {
                entitiesToUpdate = _set.Count - start;
            }

            Update(CurrentState, _set.GetEntities(start, entitiesToUpdate));
        }

        /// <summary>
        /// Performs a post-update treatment.
        /// </summary>
        /// <param name="state">The state to use.</param>
        protected override void PostUpdate(T state)
        {
            _set.Complete();

            base.PostUpdate(state);
        }

        /// <summary>
        /// Disposes of the inner <see cref="EntitySet"/> instance.
        /// </summary>
        public override void Dispose()
        {
            _set.Dispose();
        }

        #endregion
    }
}
