using System;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents a base class to process updates on a given <see cref="World"/> instance to all its components of type <typeparamref name="TComponent"/>.
    /// </summary>
    /// <typeparam name="TState">The type of the object used as state to update the system.</typeparam>
    /// <typeparam name="TComponent">The type of component to update.</typeparam>
    public abstract class AComponentSystem<TState, TComponent> : ASystem<TState>
    {
        #region Fields

        private readonly World _world;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="AComponentSystem{TState, TComponent}"/> class with the given <see cref="World"/> and <see cref="SystemRunner{TState}"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AComponentSystem(World world, SystemRunner<TState> runner)
            : base(runner)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

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
        /// Update the given <typeparamref name="TComponent"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="components">The <see cref="Entity"/> instances to update.</param>
        protected abstract void Update(TState state, Span<TComponent> components);

        #endregion

        #region ASystem

        private protected sealed override void DefaultUpdate(TState state)
        {
            Update(state, _world.GetAllComponents<TComponent>());
        }

        internal sealed override void Update(TState state, int index, int maxIndex)
        {
            Span<TComponent> components = _world.GetAllComponents<TComponent>();
            int componentsToUpdate = components.Length / (maxIndex + 1);

            Update(state, index == maxIndex ? components.Slice(index * componentsToUpdate) : components.Slice(index * componentsToUpdate, componentsToUpdate));
        }

        #endregion
    }
}
