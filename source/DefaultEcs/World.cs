using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultEcs.Serialization;
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

        internal static readonly ComponentFlag AliveFlag;
        internal static EntityInfo[][] EntityInfos;

        private readonly IntDispenser _entityIdDispenser;

        internal readonly int WorldId;

        #endregion

        #region Properties

        internal int LastEntityId => _entityIdDispenser.LastInt;

        /// <summary>
        /// Gets the maximum number of <see cref="Entity"/> this <see cref="World"/> can create.
        /// </summary>
        public int MaxEntityCount => EntityInfos[WorldId].Length;

        #endregion

        #region Initialisation

        static World()
        {
            _worldIdDispenser = new IntDispenser(0);
            EntityInfos = new EntityInfo[1][];
            AliveFlag = ComponentFlag.GetNextFlag();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        /// <param name="maxEntityCount">The maximum number of <see cref="Entity"/> that can exist in this <see cref="World"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="maxEntityCount"/> cannot be negative.</exception>
        public World(int maxEntityCount)
        {
            if (maxEntityCount < 0)
            {
                throw new ArgumentException("Argument cannot be negative", nameof(maxEntityCount));
            }

            _entityIdDispenser = new IntDispenser(-1);
            WorldId = _worldIdDispenser.GetFreeInt();

            lock (typeof(ComponentEnum))
            {
                if (WorldId >= EntityInfos.Length)
                {
                    Array.Resize(ref EntityInfos, WorldId * 2);
                }
                EntityInfos[WorldId] = new EntityInfo[maxEntityCount];
            }

            Subscribe<EntityDisposedMessage>(On);
        }

        #endregion

        #region Callbacks

        private void On(in EntityDisposedMessage message)
        {
            EntityInfos[WorldId][message.EntityId].Components.Clear();
            _entityIdDispenser.ReleaseInt(message.EntityId);

            Func<int, bool> cleanParent = EntityInfos[WorldId][message.EntityId].Parents;
            EntityInfos[WorldId][message.EntityId].Parents = null;
            cleanParent?.Invoke(message.EntityId);

            HashSet<int> children = EntityInfos[WorldId][message.EntityId].Children;
            if (children != null)
            {
                EntityInfos[WorldId][message.EntityId].Children = null;
                foreach (int childId in children)
                {
                    EntityInfos[WorldId][childId].Parents -= children.Remove;
                    Publish(new EntityDisposedMessage(childId));
                }
            }
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
        public Entity CreateEntity()
        {
            int entityId = _entityIdDispenser.GetFreeInt();

            if (entityId >= MaxEntityCount)
            {
                throw new InvalidOperationException("Max number of Entity reached");
            }

            EntityInfos[WorldId][entityId].Components[AliveFlag] = true;
            Publish(new EntityCreatedMessage(entityId));

            return new Entity(WorldId, entityId);
        }

        /// <summary>
        /// Sets up the current <see cref="World"/> to handle component of type <typeparamref name="T"/> with a different maximum count than <see cref="MaxEntityCount"/>.
        /// If the type of component is already handled by the current <see cref="World"/>, does nothing.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="maxComponentCount">The maximum number of component of type <typeparamref name="T"/> that can exist in this <see cref="World"/>.</param>
        /// <returns>The current <see cref="World"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="maxComponentCount"/> cannot be negative.</exception>
        public World SetMaximumComponentCount<T>(int maxComponentCount)
        {
            if (maxComponentCount < 0)
            {
                throw new ArgumentException("Argument cannot be negative", nameof(maxComponentCount));
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

        /// <summary>
        /// Get all the <see cref="Entity"/> of the current <see cref="World"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <returns>All the <see cref="Entity"/> of the current <see cref="World"/>.</returns>
        public IEnumerable<Entity> GetAllEntities()
        {
            for (int i = 0; i <= LastEntityId; ++i)
            {
                if (EntityInfos[WorldId][i].Components[AliveFlag])
                {
                    yield return new Entity(WorldId, i);
                }
            }
        }

        /// <summary>
        /// Calls on <paramref name="reader"/> with all the maximum number of component of the current <see cref="World"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="reader">The <see cref="IComponentTypeReader"/> instance to be used as callback with the current <see cref="World"/> maximum number of component.</param>
        public void ReadAllComponentTypes(IComponentTypeReader reader) => Publish(new ComponentTypeReadMessage(reader ?? throw new ArgumentNullException(nameof(reader))));

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
                EntityInfos[WorldId] = null;
            }

            Publish(0, new WorldDisposedMessage(WorldId));
            _worldIdDispenser.ReleaseInt(WorldId);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
