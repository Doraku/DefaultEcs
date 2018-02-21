using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Message;

namespace DefaultEcs
{
    #region Types

    /// <summary>
    /// Encapsulates a method that has a single in parameter and does not return a value used for <see cref="World.Subscribe{T}(SubscribeAction{T})"/> method.
    /// </summary>
    /// <typeparam name="T">The type of message to subscribe to.</typeparam>
    public delegate void SubscribeAction<T>(in T message);

    #endregion

    /// <summary>
    /// Represents a item use to create and manage <see cref="Entity"/> objects.
    /// </summary>
    public sealed partial class World : IDisposable
    {
        #region Fields

        private static Action<int> _newWorld;
        private static Action<int> _cleanPublisher;
        private static Action<int> _cleanWorld;

        private static readonly IntDispenser _worldIdDispenser;

        private readonly int _worldId;
        private readonly IntDispenser _entityIdDispenser;

        /// <summary>
        /// Gets the maximum number of <see cref="Entity"/> this <see cref="World"/> can create.
        /// </summary>
        public readonly int MaxEntityCount;

        #endregion

        #region Initialisation

        static World()
        {
            _worldIdDispenser = new IntDispenser(0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        /// <param name="maxEntityCount">The maximum number of <see cref="Entity"/> that can exist in this <see cref="World"/>.</param>
        public World(int maxEntityCount)
        {
            _worldId = _worldIdDispenser.GetFreeInt();
            _newWorld?.Invoke(_worldId);
            _entityIdDispenser = new IntDispenser(-1);
            MaxEntityCount = maxEntityCount;

            Subscribe<EntityCleanedMessage>(On);
        }

        #endregion

        #region Callbacks

        private void On(in EntityCleanedMessage message) => _entityIdDispenser.ReleaseInt(message.Entity.EntityId);

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IDisposable Subscribe<T>(int worldId, SubscribeAction<T> action) => InnerPublisher<T>.Subscribe(worldId, action);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Publish<T>(int worldId, in T arg) => InnerPublisher<T>.Actions[worldId]?.Invoke(arg);

        /// <summary>
        /// Subscribes an <see cref="SubscribeAction{T}"/> to be called back when a <typeparamref name="T"/> object is published.
        /// </summary>
        /// <typeparam name="T">The type of the object to be called back with.</typeparam>
        /// <param name="action">The delegate to be called back.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDisposable Subscribe<T>(SubscribeAction<T> action) => Subscribe(_worldId, action);

        /// <summary>
        /// Publishes a <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">The type of the object to publish.</typeparam>
        /// <param name="arg">The object to publish.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Publish<T>(in T arg) => Publish(_worldId, arg);

        /// <summary>
        /// Creates a new instance of the <see cref="Entity"/> struct.
        /// </summary>
        /// <returns>The created <see cref="Entity"/>.</returns>
        /// <exception cref="InvalidOperationException">Max number of <see cref="Entity"/> reached.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Entity CreateEntity()
        {
            int entityId = _entityIdDispenser.GetFreeInt();

            if (entityId >= MaxEntityCount)
            {
                throw new InvalidOperationException("Max number of Entity reached");
            }

            Entity entity = new Entity(_worldId, entityId);

            Publish(new EntityCreatedMessage(entity));

            return entity;
        }

        /// <summary>
        /// Sets up the current <see cref="World"/> to handle component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="maxComponentCount">The maximum number of component of type <typeparamref name="T"/> that can exist in this <see cref="World"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="maxComponentCount"/> can not be negative.</exception>
        /// <exception cref="InvalidOperationException">This component type has already been added.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddComponentType<T>(int maxComponentCount)
        {
            if (maxComponentCount < 0)
            {
                throw new ArgumentException("Argument can not be negative", nameof(maxComponentCount));
            }

            ref ComponentPool<T> pool = ref ComponentManager<T>.Pools[_worldId];
            if (pool != null)
            {
                throw new InvalidOperationException("This component type has already been added");
            }

            pool = new ComponentPool<T>(MaxEntityCount, maxComponentCount);
            Subscribe<EntityCleanedMessage>(ComponentPool<T>.On);
        }

        /// <summary>
        /// Gets all the component of a given type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>A <see cref="Span{T}"/> pointing directly to the component values to edit them.</returns>
        /// <exception cref="InvalidOperationException">The type of component <typeparamref name="T"/> has not been added to the current <see cref="World"/> yet.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetAllComponents<T>()
        {
            ComponentPool<T> pool = ComponentManager<T>.Pools[_worldId];

            if (pool == null)
            {
                throw new InvalidOperationException($"This type of component {nameof(T)} has not been added to the current World yet");
            }

            return pool.GetAll();
        }

        /// <summary>
        /// Gets an <see cref="EntitySet"/> of all the <see cref="Entity"/> of the current <see cref="World"/>.
        /// </summary>
        /// <returns>An <see cref="EntitySet"/>.</returns>
        public EntitySet GetAllEntity() => new AllEntitySet(this);

        /// <summary>
        /// Gets an <see cref="EntitySet"/> of all the <see cref="Entity"/> of the current <see cref="World"/>
        /// which have a component <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A type of component needed.</typeparam>
        /// <returns>An <see cref="EntitySet"/>.</returns>
        public EntitySet GetEntityWith<T>() => new EntitySet<T>(this);


        /// <summary>
        /// Gets an <see cref="EntitySet"/> of all the <see cref="Entity"/> of the current <see cref="World"/>
        /// which have a component <typeparamref name="T1"/> and <typeparamref name="T2"/>.
        /// </summary>
        /// <typeparam name="T1">A type of component needed.</typeparam>
        /// <typeparam name="T2">A type of component needed.</typeparam>
        /// <returns>An <see cref="EntitySet"/>.</returns>
        public EntitySet GetEntityWith<T1, T2>() => new EntitySet<T1, T2>(this);

        /// <summary>
        /// Gets an <see cref="EntitySet"/> of all the <see cref="Entity"/> of the current <see cref="World"/>
        /// which have a component <typeparamref name="T1"/>, <typeparamref name="T2"/> and <typeparamref name="T3"/>.
        /// </summary>
        /// <typeparam name="T1">A type of component needed.</typeparam>
        /// <typeparam name="T2">A type of component needed.</typeparam>
        /// <typeparam name="T3">A type of component needed.</typeparam>
        /// <returns>An <see cref="EntitySet"/>.</returns>
        public EntitySet GetEntityWith<T1, T2, T3>() => new EntitySet<T1, T2, T3>(this);

        /// <summary>
        /// Gets an <see cref="EntitySet"/> of all the <see cref="Entity"/> of the current <see cref="World"/>
        /// which have a component <typeparamref name="T1"/>, <typeparamref name="T2"/>, <typeparamref name="T3"/> and <typeparamref name="T4"/>.
        /// </summary>
        /// <typeparam name="T1">A type of component needed.</typeparam>
        /// <typeparam name="T2">A type of component needed.</typeparam>
        /// <typeparam name="T3">A type of component needed.</typeparam>
        /// <typeparam name="T4">A type of component needed.</typeparam>
        /// <returns>An <see cref="EntitySet"/>.</returns>
        public EntitySet GetEntityWith<T1, T2, T3, T4>() => new EntitySet<T1, T2, T3, T4>(this);

        #endregion

        #region IDisposable

        /// <summary>
        /// Cleans up all the components of existing <see cref="Entity"/>.
        /// The current <see cref="World"/>, all <see cref="Entity"/> and <see cref="EntitySet"/> created from this instance, should not be used again after calling this method.
        /// </summary>
        public void Dispose()
        {
            _cleanPublisher?.Invoke(_worldId);
            _cleanWorld?.Invoke(_worldId);
            _worldIdDispenser.ReleaseInt(_worldId);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
