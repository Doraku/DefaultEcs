using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DefaultEcs.Serialization;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Debug;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a item used to create and manage <see cref="Entity"/> objects.
    /// </summary>
    [DebuggerTypeProxy(typeof(WorldDebugView))]
    public sealed class World : IPublisher, IDisposable
    {
        #region Fields

        private static readonly object _lockObject;
        private static readonly IntDispenser _worldIdDispenser;

        internal static readonly ComponentFlag IsAliveFlag;
        internal static readonly ComponentFlag IsEnabledFlag;

        internal static World[] Worlds;

        private readonly IntDispenser _entityIdDispenser;

        internal readonly short WorldId;
        
        private IEntityMutator _entityMutator;
        private IEntityAccessor _entityAccessor;

        internal EntityInfo[] EntityInfos;

        /// <summary>
        /// Event called just before an <see cref="Entity"/> from the current <see cref="World"/> instance is disposed.
        /// The Entity still contains all its components.
        /// </summary>
        public event ActionIn<Entity> EntityDisposed;

        #endregion

        #region Properties

        internal int LastEntityId => _entityIdDispenser.LastInt;

        /// <summary>
        /// Gets the maximum number of <see cref="Entity"/> this <see cref="World"/> can create.
        /// </summary>
        public int MaxEntityCount { get; }

        #endregion

        #region Initialisation

        static World()
        {
            _lockObject = new object();
            _worldIdDispenser = new IntDispenser(0);

            Worlds = new World[2];

            IsAliveFlag = ComponentFlag.GetNextFlag();
            IsEnabledFlag = ComponentFlag.GetNextFlag();
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
            _entityMutator = new EntityMutator();
            _entityAccessor = new EntityAccessor();
            WorldId = (short)_worldIdDispenser.GetFreeInt();

            MaxEntityCount = maxEntityCount;
            EntityInfos = EmptyArray<EntityInfo>.Value;

            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Worlds, WorldId);

                Worlds[WorldId] = this;
            }

#pragma warning disable IDE0067 // Dispose objects before losing scope
            this.Subscribe(this);
#pragma warning restore IDE0067 // Dispose objects before losing scope
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
            : this(int.MaxValue)
        { }

        #endregion

        #region Callbacks
#pragma warning disable IDE0051 // Remove unused private members

        [Subscribe]
        private void On(in EntityDisposingMessage message)
        {
            EntityDisposed?.Invoke(new Entity(WorldId, message.EntityId));
            EntityInfos[message.EntityId].Components.Clear();
        }

        [Subscribe]
        private void On(in EntityDisposedMessage message)
        {
            ref EntityInfo entityInfo = ref EntityInfos[message.EntityId];

            _entityIdDispenser.ReleaseInt(message.EntityId);
            ++entityInfo.Version;

            Func<int, bool> cleanParent = entityInfo.Parents;
            entityInfo.Parents = null;
            cleanParent?.Invoke(message.EntityId);

            HashSet<int> children = entityInfo.Children;
            if (children != null)
            {
                entityInfo.Children = null;
                foreach (int childId in children)
                {
                    EntityInfos[childId].Parents -= children.Remove;
                    Publish(new EntityDisposingMessage(childId));
                    Publish(new EntityDisposedMessage(childId));
                }
            }
        }

#pragma warning restore IDE0051 // Remove unused private members
        #endregion

        #region Methods

        internal Entity CreateDisabledEntity()
        {
            int entityId = _entityIdDispenser.GetFreeInt();

            if (entityId >= MaxEntityCount)
            {
                throw new InvalidOperationException("Max number of Entity reached");
            }

            ArrayExtension.EnsureLength(ref EntityInfos, entityId, MaxEntityCount);

            ref ComponentEnum components = ref EntityInfos[entityId].Components;
            components[IsAliveFlag] = true;
            Publish(new EntityDisabledMessage(entityId, components));

            return new Entity(WorldId, entityId);
        }

        /// <summary>
        /// Sets world's EntityMutator
        /// </summary>
        /// <param name="entityMutator"></param>
        public void SetEntityMutator(IEntityMutator entityMutator)
        {
            _entityMutator = entityMutator;
        }

        /// <summary>
        /// Returns current EntityMutator. 
        /// </summary>
        /// <returns></returns>
        public IEntityMutator GetEntityMutator()
        {
            return _entityMutator;
        }

        /// <summary>
        /// Sets world's EntityAccessor
        /// </summary>
        /// <param name="entityAccessor"></param>
        public void SetEntityAccessor(IEntityAccessor entityAccessor)
        {
            _entityAccessor = entityAccessor;
        }

        /// <summary>
        /// Returns current EntityAccessor. 
        /// </summary>
        /// <returns><see cref="IEntityAccessor"/></returns>
        public IEntityAccessor GetEntityAccessor()
        {
            return _entityAccessor;
        }

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

            ArrayExtension.EnsureLength(ref EntityInfos, entityId, MaxEntityCount);

            EntityInfos[entityId].Components[IsAliveFlag] = true;
            EntityInfos[entityId].Components[IsEnabledFlag] = true;
            Publish(new EntityCreatedMessage(entityId));

            return new Entity(WorldId, entityId);
        }

        /// <summary>
        /// Sets up the current <see cref="World"/> to handle component of type <typeparamref name="T"/> with a different maximum count than <see cref="MaxEntityCount"/>.
        /// If the type of component is already handled by the current <see cref="World"/>, does nothing.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="maxComponentCount">The maximum number of component of type <typeparamref name="T"/> that can exist in this <see cref="World"/>.</param>
        /// <returns>Whether the maximum count has been setted or not.</returns>
        /// <exception cref="ArgumentException"><paramref name="maxComponentCount"/> cannot be negative.</exception>
        public bool SetMaximumComponentCount<T>(int maxComponentCount)
        {
            if (maxComponentCount < 0)
            {
                throw new ArgumentException("Argument cannot be negative", nameof(maxComponentCount));
            }

            return ComponentManager<T>.GetOrCreate(WorldId, maxComponentCount).MaxComponentCount == maxComponentCount;
        }

        /// <summary>
        /// Gets the maximum number of <typeparamref name="T"/> components this <see cref="World"/> can create.
        /// Returns a negative value if there is no limit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int GetMaximumComponentCount<T>() => ComponentManager<T>.Get(WorldId)?.MaxComponentCount ?? MaxEntityCount;

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
        public EntitySetBuilder GetEntities() => new EntitySetBuilder(this, true);

        /// <summary>
        /// Gets an <see cref="EntitySetBuilder"/> to create a subset of disabled <see cref="Entity"/> of the current <see cref="World"/>.
        /// </summary>
        /// <returns>An <see cref="EntitySetBuilder"/>.</returns>
        public EntitySetBuilder GetDisabledEntities() => new EntitySetBuilder(this, false);

        /// <summary>
        /// Get all the <see cref="Entity"/> of the current <see cref="World"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <returns>All the <see cref="Entity"/> of the current <see cref="World"/>.</returns>
        public IEnumerable<Entity> GetAllEntities()
        {
            for (int i = 0; i <= Math.Min(EntityInfos.Length, LastEntityId); ++i)
            {
                if (EntityInfos[i].Components[IsAliveFlag])
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

        #region IPublisher

        /// <summary>
        /// Subscribes an <see cref="ActionIn{T}"/> to be called back when a <typeparamref name="T"/> object is published.
        /// </summary>
        /// <typeparam name="T">The type of the object to be called back with.</typeparam>
        /// <param name="action">The delegate to be called back.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDisposable Subscribe<T>(ActionIn<T> action) => Publisher<T>.Subscribe(WorldId, action);

        /// <summary>
        /// Publishes a <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">The type of the object to publish.</typeparam>
        /// <param name="message">The object to publish.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Publish<T>(in T message) => Publisher<T>.Publish(WorldId, message);

        #endregion

        #region IDisposable

        /// <summary>
        /// Cleans up all the components of existing <see cref="Entity"/>.
        /// The current <see cref="World"/>, all <see cref="Entity"/> and <see cref="EntitySet"/> created from this instance, should not be used again after calling this method.
        /// </summary>
        public void Dispose()
        {
            lock (_lockObject)
            {
                Worlds[WorldId] = null;
            }

            Publish(new ManagedResourceReleaseAllMessage());
            Publisher.Publish(0, new WorldDisposedMessage(WorldId));
            _worldIdDispenser.ReleaseInt(WorldId);

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Object

        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string representing this instance.</returns>
        public override string ToString() => $"World {WorldId}";

        #endregion
    }
}
