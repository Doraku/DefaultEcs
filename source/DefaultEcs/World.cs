using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using DefaultEcs.Serialization;
using DefaultEcs.Internal;
using DefaultEcs.Internal.Debug;
using DefaultEcs.Internal.Helper;
using DefaultEcs.Internal.Message;
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
            private readonly List<ISortable> _items;

            private Action _mainAction;
            private bool shouldContinue;
            private int _lastIndex;

            public Optimizer()
            {
                _items = new List<ISortable>();
            }

            public void Add(ISortable item)
            {
                lock (this)
                {
                    _items.Add(item);
                }
            }

            public void Remove(ISortable item)
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
                    _items[index].Sort(ref shouldContinue);
                }
            }
        }

        /// <summary>
        /// Enumerates the <see cref="Entity"/> of a <see cref="World" />.
        /// </summary>
        public struct Enumerator : IEnumerator<Entity>
        {
            private readonly short _worldId;
            private readonly EntityInfo[] _entityInfos;
            private readonly int _maxIndex;

            private int _index;

            internal Enumerator(World world)
            {
                _worldId = world.WorldId;
                _entityInfos = world.EntityInfos;
                _maxIndex = Math.Min(_entityInfos.Length, world.LastEntityId + 1);

                _index = -1;
            }

            #region IEnumerator

            /// <summary>
            /// Gets the <see cref="Entity"/> at the current position of the enumerator.
            /// </summary>
            /// <returns>The <see cref="Entity"/> in the <see cref="World" /> at the current position of the enumerator.</returns>
            public Entity Current => new(_worldId, _index);

            /// <inheritdoc cref="Current" />
            object IEnumerator.Current => Current;

            /// <summary>
            /// Advances the enumerator to the next <see cref="Entity"/> of the <see cref="World" />.
            /// </summary>
            /// <returns>true if the enumerator was successfully advanced to the next <see cref="Entity"/>; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                while (++_index < _maxIndex)
                {
                    if (_entityInfos[_index].Components[IsAliveFlag])
                    {
                        return true;
                    }
                }

                return false;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first <see cref="Entity"/> in the collection.
            /// </summary>
            public void Reset() => _index = -1;

            #endregion

            #region IDisposable

            /// <summary>
            /// Releases all resources used by the <see cref="Enumerator" />.
            /// </summary>
            public void Dispose()
            { }

            #endregion
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

        private volatile bool _isDisposed;

        internal EntityInfo[] EntityInfos;

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

            _entityIdDispenser = new IntDispenser(0);
            _optimizer = new Optimizer();
            WorldId = (short)_worldIdDispenser.GetFreeInt();

            MaxCapacity = maxCapacity;
            EntityInfos = EmptyArray<EntityInfo>.Value;

            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Worlds, WorldId);

                Worlds[WorldId] = this;
            }

            Subscribe<EntityDisposedMessage>(On);

            _isDisposed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
            : this(int.MaxValue)
        { }

        #endregion

        #region Callbacks

        private void On(in EntityDisposedMessage message)
        {
            ref EntityInfo entityInfo = ref EntityInfos[message.EntityId];

            entityInfo.Components.Clear();
            _entityIdDispenser.ReleaseInt(message.EntityId);
            ++entityInfo.Version;
        }

        #endregion

        #region Methods

        internal void Add(ISortable optimizable) => _optimizer.Add(optimizable);

        internal void Remove(ISortable optimizable) => _optimizer.Remove(optimizable);

        /// <summary>
        /// Creates a new instance of the <see cref="Entity"/> struct.
        /// This method is not thread safe.
        /// </summary>
        /// <returns>The created <see cref="Entity"/>.</returns>
        /// <exception cref="InvalidOperationException">Max number of <see cref="Entity"/> reached.</exception>
        public Entity CreateEntity()
        {
            int entityId = _entityIdDispenser.GetFreeInt();

            if (entityId < 0 || entityId > MaxCapacity)
            {
                throw new InvalidOperationException("Max number of Entity reached");
            }

            ArrayExtension.EnsureLength(ref EntityInfos, entityId, MaxCapacity == int.MaxValue ? int.MaxValue : (MaxCapacity + 1));

            EntityInfos[entityId].Components[IsAliveFlag] = true;
            EntityInfos[entityId].Components[IsEnabledFlag] = true;
            Publish(new EntityCreatedMessage(entityId));

            return new Entity(WorldId, entityId);
        }

        /// <summary>
        /// Sets up the current <see cref="World"/> to handle component of type <typeparamref name="T"/> with a different maximum count than <see cref="MaxCapacity"/>.
        /// If the type of component is already handled by the current <see cref="World"/>, does nothing.
        /// This method is not thread safe.
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
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>The maximum number of <typeparamref name="T"/> components this <see cref="World"/> can create, or -1 if it is currently not handled.</returns>
        public int GetMaxCapacity<T>() => ComponentManager<T>.Get(WorldId)?.MaxCapacity ?? -1;

        /// <summary>
        /// Gets all the component of a given type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>A <see cref="Span{T}"/> pointing directly to the component values to edit them.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> GetAll<T>() => ComponentManager<T>.GetOrCreate(WorldId).AsSpan();

        /// <summary>
        /// Gets an <see cref="Components{T}"/> to get a fast access to the component of type <typeparamref name="T"/> of this <see cref="World"/> instance <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        /// <returns>A <see cref="Components{T}"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Components<T> GetComponents<T>() => ComponentManager<T>.GetOrCreate(WorldId).AsComponents();

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="World"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>(in T component) => ComponentManager<T>.GetOrCreate(WorldId).Set(0, component);

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> to its default value on the current <see cref="World"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>() => Set<T>(default);

        /// <summary>
        /// Returns whether the current <see cref="World"/> has a component of type <typeparamref name="T"/>.
        /// It has nothing to do whether or not the current <see cref="World"/> instance has an <see cref="Entity"/> with a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="World"/> has a component of type <typeparamref name="T"/>; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has<T>() => ComponentManager<T>.Get(WorldId)?.Has(0) ?? false;

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the current <see cref="World"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the component.</returns>
        /// <exception cref="Exception"><see cref="World"/> does not have a component of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get<T>() => ref ComponentManager<T>.Pools[WorldId].Get(0);

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the current <see cref="World"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        public void Remove<T>() => ComponentManager<T>.Get(WorldId)?.Remove(0);

        /// <summary>
        /// Gets an <see cref="EntityQueryBuilder"/> to create a subset of <see cref="Entity"/> of the current <see cref="World"/>.
        /// </summary>
        /// <returns>An <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder GetEntities() => new(this, true);

        /// <summary>
        /// Gets an <see cref="EntityQueryBuilder"/> to create a subset of disabled <see cref="Entity"/> of the current <see cref="World"/>.
        /// </summary>
        /// <returns>An <see cref="EntityQueryBuilder"/>.</returns>
        public EntityQueryBuilder GetDisabledEntities() => new(this, false);

        /// <summary>
        /// Calls on <paramref name="reader"/> with all the maximum number of component of the current <see cref="World"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="reader">The <see cref="IComponentTypeReader"/> instance to be used as callback with the current <see cref="World"/> maximum number of component.</param>
        public void ReadAllComponentTypes(IComponentTypeReader reader) => Publish(new ComponentTypeReadMessage(reader ?? throw new ArgumentNullException(nameof(reader))));

        /// <summary>
        /// Sorts current instance inner storage so accessing <see cref="Entity"/> and their components from <see cref="EntitySet"/> and <see cref="EntityMultiMap{TKey}"/> always move forward in memory.
        /// This method will return once <paramref name="mainAction"/> is executed even if the optimization process has not finished.
        /// This method is not thread safe.
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
        /// Sorts current instance inner storage so accessing <see cref="Entity"/> and their components from <see cref="EntitySet"/> and <see cref="EntityMultiMap{TKey}"/> always move forward in memory.
        /// This method is not thread safe.
        /// </summary>
        /// <param name="runner">The <see cref="IParallelRunner"/> to process this operation in parallel.</param>
        public void Optimize(IParallelRunner runner)
        {
            if (runner is null) throw new ArgumentNullException(nameof(runner));

            _optimizer.PrepareForRun(null);
            runner.Run(_optimizer);
        }

        /// <summary>
        /// Sorts current instance inner storage so accessing <see cref="Entity"/> and their components from <see cref="EntitySet"/> and <see cref="EntityMultiMap{TKey}"/> always move forward in memory.
        /// This method is not thread safe.
        /// </summary>
        public void Optimize() => Optimize(DefaultParallelRunner.Default);

        /// <summary>
        /// Resizes inner storage to exactly the number of <typeparamref name="T"/> components this <see cref="World"/> contains.
        /// This method is not thread safe.
        /// </summary>
        public void TrimExcess<T>()
        {
            ComponentManager<T>.Get(WorldId)?.TrimExcess();
            ComponentManager<T>.GetPrevious(WorldId)?.TrimExcess();
        }

        /// <summary>
        /// Resizes all inner storage to exactly the number of <see cref="Entity"/> and components this <see cref="World"/> contains.
        /// This method is not thread safe.
        /// </summary>
        public void TrimExcess()
        {
            ArrayExtension.Trim(ref EntityInfos, Array.FindLastIndex(EntityInfos, i => i.Components[IsAliveFlag]) + 1);

            Publish(new TrimExcessMessage());
        }

        /// <summary>
        /// Subscribes an <see cref="WorldDisposedHandler"/> on the current <see cref="World"/> to be called when current instance is disposed.
        /// </summary>
        /// <param name="action">The <see cref="WorldDisposedHandler"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeWorldDisposed(WorldDisposedHandler action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in WorldDisposedMessage _) => action(this));
        }

        /// <summary>
        /// Subscribes an <see cref="EntityCreatedHandler"/> on the current <see cref="World"/> to be called when an <see cref="Entity"/> is created.
        /// </summary>
        /// <param name="action">The <see cref="EntityCreatedHandler"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeEntityCreated(EntityCreatedHandler action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in EntityCreatedMessage message) => action(new Entity(WorldId, message.EntityId)));
        }

        /// <summary>
        /// Subscribes an <see cref="EntityEnabledHandler"/> on the current <see cref="World"/> to be called when an <see cref="Entity"/> is enabled.
        /// </summary>
        /// <param name="action">The <see cref="EntityEnabledHandler"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeEntityEnabled(EntityEnabledHandler action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in EntityEnabledMessage message) => action(new Entity(WorldId, message.EntityId)));
        }

        /// <summary>
        /// Subscribes an <see cref="EntityDisabledHandler"/> on the current <see cref="World"/> to be called when an <see cref="Entity"/> is disabled.
        /// </summary>
        /// <param name="action">The <see cref="EntityDisabledHandler"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeEntityDisabled(EntityDisabledHandler action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in EntityDisabledMessage message) => action(new Entity(WorldId, message.EntityId)));
        }

        /// <summary>
        /// Subscribes an <see cref="EntityDisposedHandler"/> on the current <see cref="World"/> to be called when an <see cref="Entity"/> is disposed.
        /// </summary>
        /// <param name="action">The <see cref="EntityDisposedHandler"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeEntityDisposed(EntityDisposedHandler action)
        {
            IEnumerable<IDisposable> GetSubscriptions(EntityDisposedHandler a)
            {
                yield return Subscribe((in EntityDisposingMessage message) => a(new Entity(WorldId, message.EntityId)));
                yield return Subscribe((in WorldDisposedMessage _) =>
                {
                    foreach (Entity entity in this)
                    {
                        a(entity);
                    }
                });
            }

            if (action is null) throw new ArgumentNullException(nameof(action));

            return GetSubscriptions(action).Merge();
        }

        /// <summary>
        /// Subscribes a <see cref="ComponentAddedHandler{T}"/> on the current <see cref="World"/> to be called when a component of type <typeparamref name="T"/> is added.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="action">The <see cref="ComponentAddedHandler{T}"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeComponentAdded<T>(ComponentAddedHandler<T> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in ComponentAddedMessage<T> message) => action(
                new Entity(WorldId, message.EntityId),
                ComponentManager<T>.Get(WorldId).Get(message.EntityId)));
        }

        /// <summary>
        /// Subscribes a <see cref="ComponentChangedHandler{T}"/> on the current <see cref="World"/> to be called when a component of type <typeparamref name="T"/> is changed.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="action">The <see cref="ComponentChangedHandler{T}"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeComponentChanged<T>(ComponentChangedHandler<T> action)
        {
            ComponentManager<T>.GetOrCreatePrevious(WorldId);

            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in ComponentChangedMessage<T> message) => action(
                new Entity(WorldId, message.EntityId),
                ComponentManager<T>.GetPrevious(WorldId).Get(message.EntityId),
                ComponentManager<T>.Get(WorldId).Get(message.EntityId)));
        }

        /// <summary>
        /// Subscribes an <see cref="ComponentRemovedHandler{T}"/> on the current <see cref="World"/> to be called when a component of type <typeparamref name="T"/> is removed.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="action">The <see cref="ComponentRemovedHandler{T}"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeComponentRemoved<T>(ComponentRemovedHandler<T> action)
        {
            IEnumerable<IDisposable> GetSubscriptions(ComponentRemovedHandler<T> a)
            {
                yield return Subscribe((in ComponentRemovedMessage<T> message) => a(
                    new Entity(WorldId, message.EntityId),
                    ComponentManager<T>.GetPrevious(WorldId).Get(message.EntityId)));
                yield return Subscribe((in EntityDisposingMessage message) =>
                {
                    ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
                    if (pool?.Has(message.EntityId) is true)
                    {
                        a(new Entity(WorldId, message.EntityId), pool.Get(message.EntityId));
                    }
                });
                yield return Subscribe((in WorldDisposedMessage _) =>
                {
                    ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
                    if (pool != null)
                    {
                        foreach (Entity entity in pool.GetEntities())
                        {
                            a(entity, pool.Get(entity.EntityId));
                        }
                    }
                });
            }

            if (action is null) throw new ArgumentNullException(nameof(action));

            ComponentManager<T>.GetOrCreatePrevious(WorldId);

            return GetSubscriptions(action).Merge();
        }

        /// <summary>
        /// Subscribes a <see cref="ComponentEnabledHandler{T}"/> on the current <see cref="World"/> to be called when a component of type <typeparamref name="T"/> is enabled.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="action">The <see cref="ComponentEnabledHandler{T}"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeComponentEnabled<T>(ComponentEnabledHandler<T> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in ComponentEnabledMessage<T> message) => action(
                new Entity(WorldId, message.EntityId),
                ComponentManager<T>.Get(WorldId).Get(message.EntityId)));
        }

        /// <summary>
        /// Subscribes a <see cref="ComponentDisabledHandler{T}"/> on the current <see cref="World"/> to be called when a component of type <typeparamref name="T"/> is disabled.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="action">The <see cref="ComponentDisabledHandler{T}"/> to be called.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public IDisposable SubscribeComponentDisabled<T>(ComponentDisabledHandler<T> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));

            return Subscribe((in ComponentDisabledMessage<T> message) => action(
                new Entity(WorldId, message.EntityId),
                ComponentManager<T>.Get(WorldId).Get(message.EntityId)));
        }

        #endregion

        #region IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Entity"/> of the current <see cref="World"/> instance.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the <see cref="Entity"/>.</returns>
        public Enumerator GetEnumerator() => new(this);

        /// <inheritdoc cref="GetEnumerator" />
        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator() => GetEnumerator();

        /// <inheritdoc cref="GetEnumerator" />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region IPublisher

        /// <summary>
        /// Subscribes an <see cref="MessageHandler{T}"/> to be called back when a <typeparamref name="T"/> object is published.
        /// </summary>
        /// <typeparam name="T">The type of the object to be called back with.</typeparam>
        /// <param name="action">The delegate to be called back.</param>
        /// <returns>An <see cref="IDisposable"/> object used to unsubscribe.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IDisposable Subscribe<T>(MessageHandler<T> action) => Publisher<T>.Subscribe(WorldId, action);

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
            if (!_isDisposed)
            {
                _isDisposed = true;

                Publish(new WorldDisposedMessage(WorldId));
                Publisher.Publish(0, new WorldDisposedMessage(WorldId));

                lock (_lockObject)
                {
                    Worlds[WorldId] = null;
                }

                _worldIdDispenser.ReleaseInt(WorldId);

                GC.SuppressFinalize(this);
            }
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
