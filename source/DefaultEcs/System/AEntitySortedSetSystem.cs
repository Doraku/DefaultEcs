using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultEcs.Internal.System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySortedSet{TComponent}"/> instance.
    /// Only <see cref="Entity.Get{T}()"/> operations on already present component type are safe.
    /// Any other operation maybe change the inner <see cref="EntitySortedSet{TComponent}"/> and should be done either by using setting "useBuffer" of the available constructors to true or using an <see cref="Command.EntityCommandRecorder"/>.
    /// </summary>
    /// <typeparam name="TState">The type of the object used as state to update the system.</typeparam>
    /// <typeparam name="TComponent">The type of the component to sort <see cref="Entity"/> by.</typeparam>
    public abstract class AEntitySortedSetSystem<TState, TComponent> : ISystem<TState>
    {
        #region Fields

        private readonly bool _useBuffer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="EntitySortedSet{TComponent}"/> instance on which this system operates.
        /// </summary>
        public EntitySortedSet<TComponent> SortedSet { get; }

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance on which this system operates.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World { get; }

        #endregion

        #region Initialisation

        private AEntitySortedSetSystem(Func<object, EntitySortedSet<TComponent>> factory)
        {
            SortedSet = factory(this);
            World = SortedSet.World;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySortedSetSystem{TState, TComponent}"/> class with the given <see cref="EntitySortedSet{TComponent}"/>.
        /// </summary>
        /// <param name="sortedSet">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sortedSet"/> is null.</exception>
        protected AEntitySortedSetSystem(EntitySortedSet<TComponent> sortedSet, bool useBuffer = false)
            : this(sortedSet is null ? throw new ArgumentNullException(nameof(sortedSet)) : _ => sortedSet)
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySortedSetSystem{TState, TComponent}"/> class with the given <see cref="DefaultEcs.World"/> and factory.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="factory">The factory used to create the <see cref="EntitySortedSet{TComponent}"/>.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is null.</exception>
        protected AEntitySortedSetSystem(World world, Func<object, World, EntitySortedSet<TComponent>> factory, bool useBuffer)
            : this(world is null ? throw new ArgumentNullException(nameof(world)) : factory is null ? throw new ArgumentNullException(nameof(factory)) : o => factory(o, world))
        {
            _useBuffer = useBuffer;
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySortedSetSystem{TState, TComponent}"/> class with the given <see cref="DefaultEcs.World"/> and factory.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="useBuffer">Whether the entities should be copied before being processed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySortedSetSystem(World world, bool useBuffer = false)
            : this(world, static (o, w) => EntityRuleBuilderFactory.Create(o.GetType())(o, w).AsSortedSet(o as IComparer<TComponent>), useBuffer)
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
        /// Update the given <see cref="Entity"/> instance once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entity">The <see cref="Entity"/> instance to update.</param>
        protected virtual void Update(TState state, in Entity entity) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to update.</param>
        protected virtual void Update(TState state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                Update(state, entity);
            }
        }

        #endregion

        #region ISystem

        /// <summary>
        /// Gets or sets whether the current <see cref="AEntitySortedSetSystem{TState, TComponent}"/> instance should update or not.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Updates the system once.
        /// Does nothing if <see cref="IsEnabled"/> is false or if the inner <see cref="EntitySortedSet{TComponent}"/> is empty.
        /// </summary>
        /// <param name="state">The state to use.</param>
        public void Update(TState state)
        {
            if (IsEnabled && SortedSet.Count > 0)
            {
                PreUpdate(state);

                if (_useBuffer)
                {
                    Entity[] buffer = ArrayPool<Entity>.Shared.Rent(SortedSet.Count);
                    SortedSet.GetEntities().CopyTo(buffer);

                    Update(state, new ReadOnlySpan<Entity>(buffer, 0, SortedSet.Count));

                    ArrayPool<Entity>.Shared.Return(buffer);
                }
                else
                {
                    Update(state, SortedSet.GetEntities());
                }

                SortedSet.Complete();

                PostUpdate(state);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes of the inner <see cref="EntitySortedSet{TComponent}"/> instance.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);

            SortedSet.Dispose();
        }

        #endregion
    }
}
