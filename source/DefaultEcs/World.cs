using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Serialization;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Debug;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;
using DefaultEcs.Threading;

namespace DefaultEcs
{
    /// <summary>
    /// Represents a item used to create and manage <see cref="Entity"/> objects.
    /// </summary>
    [DebuggerTypeProxy(typeof(WorldDebugView))]
    public sealed class World : IEnumerable<Entity>, IPublisher, IDisposable
    {
        #region Types

        private class Optimizer : IParallelRunnable
        {
            private readonly List<IOptimizable> _items;

            private Action _mainAction;
            private bool shouldContinue;
            private int _lastIndex;

            public Optimizer()
            {
                _items = new List<IOptimizable>();
            }

            public void Add(IOptimizable item)
            {
                lock (this)
                {
                    _items.Add(item);
                }
            }

            public void Remove(IOptimizable item)
            {
                lock (this)
                {
                    _items.Remove(item);
                }
            }

            public void PrepareForRun(Action mainAction)
            {
                _mainAction = mainAction;
                Volatile.Write(ref shouldContinue, true);
                Interlocked.Exchange(ref _lastIndex, -1);
            }

            public void Run(int index, int maxIndex)
            {
                if (index == maxIndex && _mainAction != null)
                {
                    _mainAction();
                    Volatile.Write(ref shouldContinue, false);
                }

                while (Volatile.Read(ref shouldContinue) && (index = Interlocked.Increment(ref _lastIndex)) < _items.Count)
                {
                    _items[index].Optimize(ref shouldContinue);
                }
            }
        }

        #endregion

        #region Fields

        private static readonly object _lockObject;
        private static readonly IntDispenser _worldIdDispenser;

        internal static readonly ComponentFlag IsAliveFlag;
        internal static readonly ComponentFlag IsEnabledFlag;

        internal static World[] Worlds;

        private readonly IntDispenser _entityIdDispenser;
        private readonly Optimizer _optimizer;

        internal readonly short WorldId;

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
        /// Gets the maximum number of <see cref="Entity"/> this <see cref="World"/> can handle.
        /// </summary>
        public int MaxCapacity { get; }

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
        /// <param name="maxCapacity">The maximum number of <see cref="Entity"/> that can exist in this <see cref="World"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="maxCapacity"/> cannot be negative.</exception>
        public World(int maxCapacity)
        {
            if (maxCapacity < 0)
            {
                throw new ArgumentException("Argument cannot be negative", nameof(maxCapacity));
            }

            _entityIdDispenser = new IntDispenser(-1);
            _optimizer = new Optimizer();
            WorldId = (short)_worldIdDispenser.GetFreeInt();

            MaxCapacity = maxCapacity;
            EntityInfos = EmptyArray<EntityInfo>.Value;

            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Worlds, WorldId);

                Worlds[WorldId] = this;
            }

            Subscribe<EntityDisposingMessage>(On);
            Subscribe<EntityDisposedMessage>(On);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
            : this(int.MaxValue)
        { }

        #endregion

        #region Callbacks

        private void On(in EntityDisposingMessage message)
        {
            EntityDisposed?.Invoke(new Entity(WorldId, message.EntityId));
            EntityInfos[message.EntityId].Components.Clear();
        }

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

        #endregion

        #region Methods

        internal void Add(IOptimizable optimizable) => _optimizer.Add(optimizable);

        internal void Remove(IOptimizable optimizable) => _optimizer.Remove(optimizable);

        internal Entity CreateDisabledEntity()
        {
            int entityId = _entityIdDispenser.GetFreeInt();

            if (entityId >= MaxCapacity)
            {
                throw new InvalidOperationException("Max number of Entity reached");
            }

            ArrayExtension.EnsureLength(ref EntityInfos, entityId, MaxCapacity);

            ref ComponentEnum components = ref EntityInfos[entityId].Components;
            components[IsAliveFlag] = true;
            Publish(new EntityDisabledMessage(entityId, components));

            return new Entity(WorldId, entityId);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Entity"/> struct.
        /// </summary>
        /// <returns>The created <see cref="Entity"/>.</returns>
        /// <exception cref="InvalidOperationException">Max number of <see cref="Entity"/> reached.</exception>
        public Entity CreateEntity()
        {
            int entityId = _entityIdDispenser.GetFreeInt();

            if (entityId >= MaxCapacity)
            {
                throw new InvalidOperationException("Max number of Entity reached");
            }

            ArrayExtension.EnsureLength(ref EntityInfos, entityId, MaxCapacity);

            EntityInfos[entityId].Components[IsAliveFlag] = true;
            EntityInfos[entityId].Components[IsEnabledFlag] = true;
            Publish(new EntityCreatedMessage(entityId));

            return new Entity(WorldId, entityId);
        }

        /// <summary>
        /// Sets up the current <see cref="World"/> to handle component of type <typeparamref name="T"/> with a different maximum count than <see cref="MaxCapacity"/>.
        /// If the type of component is already handled by the current <see cref="World"/>, does nothing.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <param name="maxCapacity">The maximum number of component of type <typeparamref name="T"/> that can exist in this <see cref="World"/>.</param>
        /// <returns>Whether the maximum count has been setted or not.</returns>
        /// <exception cref="ArgumentException"><paramref name="maxCapacity"/> cannot be negative.</exception>
        public bool SetMaxCapacity<T>(int maxCapacity)
        {
            if (maxCapacity < 0)
            {
                throw new ArgumentException("Argument cannot be negative", nameof(maxCapacity));
            }

            return ComponentManager<T>.GetOrCreate(WorldId, maxCapacity).MaxCapacity == maxCapacity;
        }

        /// <summary>
        /// Gets the maximum number of <typeparamref name="T"/> components this <see cref="World"/> can create.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The maximum number of <typeparamref name="T"/> components this <see cref="World"/> can create, or -1 if it is currently not handled.</returns>
        public int GetMaxCapacity<T>() => ComponentManager<T>.Get(WorldId)?.MaxCapacity ?? -1;

        /// <summary>
        /// Gets all the component of a given type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>A <see cref="Span{T}"/> pointing directly to the component values to edit them.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> Get<T>() => ComponentManager<T>.GetOrCreate(WorldId).AsSpan();

        /// <summary>
        /// Gets an <see cref="Components{T}"/> to get a fast access to the component of type <typeparamref name="T"/> of this <see cref="World"/> instance <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>A <see cref="Components{T}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Components<T> GetComponents<T>() => ComponentManager<T>.GetOrCreate(WorldId).AsComponents();

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
        /// Calls on <paramref name="reader"/> with all the maximum number of component of the current <see cref="World"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="reader">The <see cref="IComponentTypeReader"/> instance to be used as callback with the current <see cref="World"/> maximum number of component.</param>
        public void ReadAllComponentTypes(IComponentTypeReader reader) => Publish(new ComponentTypeReadMessage(reader ?? throw new ArgumentNullException(nameof(reader))));

        /// <summary>
        /// Sorts current instance inner storage so accessing <see cref="Entity"/> and their components from <see cref="EntitySet"/> always move forward in memory.
        /// This method will return once <paramref name="mainAction"/> is executed even if the optimization process has not finished.
        /// </summary>
        /// <param name="runner">The <see cref="IParallelRunner"/> to process this operation in parallel.</param>
        /// <param name="mainAction">An <see cref="Action"/> to execute on the main thread while the optimization is in process.</param>
        public void Optimize(IParallelRunner runner, Action mainAction)
        {
            if (runner is null) throw new ArgumentNullException(nameof(runner));
            if (mainAction is null) throw new ArgumentNullException(nameof(mainAction));

            _optimizer.PrepareForRun(mainAction);
            runner.Run(_optimizer);
        }

        /// <summary>
        /// Sorts current instance inner storage so accessing <see cref="Entity"/> and their components from <see cref="EntitySet"/> always move forward in memory.
        /// </summary>
        /// <param name="runner">The <see cref="IParallelRunner"/> to process this operation in parallel.</param>
        public void Optimize(IParallelRunner runner)
        {
            if (runner is null) throw new ArgumentNullException(nameof(runner));

            _optimizer.PrepareForRun(null);
            runner.Run(_optimizer);
        }

        /// <summary>
        /// Sorts current instance inner storage so accessing <see cref="Entity"/> and their components from <see cref="EntitySet"/> always move forward in memory.
        /// </summary>
        public void Optimize() => Optimize(DefaultParallelRunner.Default);

        #endregion

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Entity"/> of the current <see cref="World"/> instance.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="Entity"/>.</returns>
        public IEnumerator<Entity> GetEnumerator()
        {
            for (int i = 0; i <= Math.Min(EntityInfos.Length, LastEntityId); ++i)
            {
                if (EntityInfos[i].Components[IsAliveFlag])
                {
                    yield return new Entity(WorldId, i);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
            Publish(new ManagedResourceReleaseAllMessage());
            Publisher.Publish(0, new WorldDisposedMessage(WorldId));

            lock (_lockObject)
            {
                Worlds[WorldId] = null;
            }

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
