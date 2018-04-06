using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

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
    public sealed class World : IDisposable
    {
        #region Fields

        private static readonly IntDispenser _worldIdDispenser;

        internal static readonly object Locker;

        internal static ComponentEnum[][] EntityComponents;

        internal static event Action<int> ClearWorld;

        private readonly IntDispenser _entityIdDispenser;

        internal readonly int WorldId;

        #endregion

        #region Properties

        internal int LastEntityId => _entityIdDispenser.LastInt;

        /// <summary>
        /// Gets the maximum number of <see cref="Entity"/> this <see cref="World"/> can create.
        /// </summary>
        public int MaxEntityCount => EntityComponents[WorldId].Length;

        #endregion

        #region Initialisation

        static World()
        {
            _worldIdDispenser = new IntDispenser(0);
            EntityComponents = new ComponentEnum[0][];
            Locker = new object();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        /// <param name="maxEntityCount">The maximum number of <see cref="Entity"/> that can exist in this <see cref="World"/>.</param>
        public World(int maxEntityCount)
        {
            _entityIdDispenser = new IntDispenser(-1);
            WorldId = _worldIdDispenser.GetFreeInt();

            lock (typeof(ComponentEnum))
            {
                if (WorldId >= EntityComponents.Length)
                {
                    Array.Resize(ref EntityComponents, (WorldId + 1) * 2);
                }
                EntityComponents[WorldId] = new ComponentEnum[maxEntityCount];
            }

            Subscribe<EntityDisposedMessage>(On);
        }

        #endregion

        #region Callbacks

        private void On(in EntityDisposedMessage message)
        {
            EntityComponents[WorldId][message.Entity.EntityId].Clear();
            _entityIdDispenser.ReleaseInt(message.Entity.EntityId);
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Publish<T>(int worldId, in T arg)
        {
            if (worldId < Publisher<T>.Actions.Length)
            {
                Publisher<T>.Actions[worldId]?.Invoke(arg);
            }
        }

        /// <summary>
        /// Subscribes an <see cref="SubscribeAction{T}"/> to be called back when a <typeparamref name="T"/> object is published.
        /// </summary>
        /// <typeparam name="T">The type of the object to be called back with.</typeparam>
        /// <param name="action">The delegate to be called back.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDisposable Subscribe<T>(SubscribeAction<T> action) => Publisher<T>.Subscribe(WorldId, action);

        /// <summary>
        /// Publishes a <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">The type of the object to publish.</typeparam>
        /// <param name="arg">The object to publish.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Publish<T>(in T arg) => Publish(WorldId, arg);

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

            Entity entity = new Entity(WorldId, entityId);
            Publish(new EntityCreatedMessage(entity));

            return entity;
        }

        /// <summary>
        /// Sets up the current <see cref="World"/> to handle component of type <typeparamref name="T"/> with a different maximum count than <see cref="MaxEntityCount"/>.
        /// If the type of component is already handled by the current <see cref="World"/>, does nothing.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="maxComponentCount">The maximum number of component of type <typeparamref name="T"/> that can exist in this <see cref="World"/>.</param>
        /// <returns>The current <see cref="World"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="maxComponentCount"/> can not be negative.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public World SetComponentTypeMaximumCount<T>(int maxComponentCount)
        {
            if (maxComponentCount < 0)
            {
                throw new ArgumentException("Argument can not be negative", nameof(maxComponentCount));
            }

            ComponentManager<T>.GetOrCreate(WorldId, maxComponentCount);

            return this;
        }

        /// <summary>
        /// Gets all the component of a given type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>A <see cref="Span{T}"/> pointing directly to the component values to edit them.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetAllComponents<T>() => ComponentManager<T>.GetOrCreate(WorldId).GetAll();

        /// <summary>
        /// Gets an <see cref="EntitySetBuilder"/> to create a subset of <see cref="Entity"/> of the current <see cref="World"/>.
        /// </summary>
        /// <returns>An <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder GetEntities() => new EntitySetBuilder(this);

        #endregion

        #region IDisposable

        /// <summary>
        /// Cleans up all the components of existing <see cref="Entity"/>.
        /// The current <see cref="World"/>, all <see cref="Entity"/> and <see cref="EntitySet"/> created from this instance, should not be used again after calling this method.
        /// </summary>
        public void Dispose()
        {
            lock (typeof(ComponentEnum))
            {
                EntityComponents[WorldId] = null;
            }

            ClearWorld?.Invoke(WorldId);
            _worldIdDispenser.ReleaseInt(WorldId);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
