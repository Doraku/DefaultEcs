using System;
using System.Collections;
using System.Collections.Generic;
using DefaultEcs.Internal;

namespace DefaultEcs.Resource
{
    /// <summary>
    /// Base type used to load resources of type <typeparamref name="TResource"/> using info of type <typeparamref name="TInfo"/>.
    /// <typeparamref name="TInfo"/> is used as key if the same resource is requested on multiple <see cref="Entity"/> to only load the <typeparamref name="TResource"/> resource once.
    /// If no <see cref="Entity"/> contains the <see cref="ManagedResource{TInfo, TResource}"/> component identifying the resource anymore, the <typeparamref name="TResource"/> instance is then unloaded automatically.
    /// By default, if <typeparamref name="TResource"/> is <see cref="IDisposable"/>, <see cref="Unload(TInfo, TResource)"/> will call the <see cref="IDisposable.Dispose"/> method of the resource.
    /// </summary>
    /// <typeparam name="TInfo">The type used to identify a resource.</typeparam>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    public abstract class AResourceManager<TInfo, TResource> : IDisposable
    {
        #region Types

        private sealed class Resource
        {
            public readonly TResource Value;

            private int _referencesCount;

            public Resource(TResource value)
            {
                Value = value;
                _referencesCount = 0;
            }

            public void AddReference() => ++_referencesCount;

            public bool RemoveReference() => --_referencesCount == 0;
        }

        /// <summary>
        /// Allows to enumerate the resources of a <see cref="AResourceManager{TInfo, TResource}" />.
        /// </summary>
        public readonly struct ResourceEnumerable : IEnumerable<KeyValuePair<TInfo, TResource>>
        {
            private readonly AResourceManager<TInfo, TResource> _manager;

            internal ResourceEnumerable(AResourceManager<TInfo, TResource> manager)
            {
                _manager = manager;
            }

            #region IEnumerable

            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>An enumerator that can be used to iterate through the collection.</returns>
            public ResourceEnumerator GetEnumerator() => new(_manager);

            /// <inheritdoc cref="GetEnumerator" />
            IEnumerator<KeyValuePair<TInfo, TResource>> IEnumerable<KeyValuePair<TInfo, TResource>>.GetEnumerator() => GetEnumerator();

            /// <inheritdoc cref="GetEnumerator" />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            #endregion
        }

        /// <summary>
        /// Enumerates the resources of a <see cref="AResourceManager{TInfo, TResource}" />.
        /// </summary>
        public struct ResourceEnumerator : IEnumerator<KeyValuePair<TInfo, TResource>>
        {
            private readonly KeyValuePair<TInfo, TResource>[] _resources;

            private int _index;

            internal ResourceEnumerator(AResourceManager<TInfo, TResource> manager)
            {
                lock (manager._lockObject)
                {
                    _resources = new KeyValuePair<TInfo, TResource>[manager._resources.Count];
                    _index = 0;
                    foreach (KeyValuePair<TInfo, Resource> pair in manager._resources)
                    {
                        _resources[_index++] = new KeyValuePair<TInfo, TResource>(pair.Key, pair.Value.Value);
                    }
                }

                _index = -1;

                Current = default;
            }

            #region IEnumerator

            /// <summary>
            /// Gets the resource at the current position of the enumerator.
            /// </summary>
            /// <returns>The resource at the current position of the enumerator.</returns>
            public KeyValuePair<TInfo, TResource> Current { get; private set; }

            /// <inheritdoc cref="Current" />
            object IEnumerator.Current => Current;

            /// <summary>Advances the enumerator to the next resource of the <see cref="AResourceManager{TInfo, TResource}" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next resource; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                if (++_index < _resources.Length)
                {
                    Current = _resources[_index];
                    return true;
                }

                Current = default;
                return false;
            }

            /// <inheritdoc />
            void IEnumerator.Reset() => _index = -1;

            #endregion

            #region IDisposable

            /// <summary>
            /// Releases all resources used by the <see cref="ResourceEnumerator" />.
            /// </summary>
            public void Dispose()
            { }

            #endregion
        }

        #endregion

        #region Fields

        private readonly object _lockObject;
        private readonly Dictionary<TInfo, Resource> _resources;

        #endregion

        #region Properties

        /// <summary>
        /// Gets all the <typeparamref name="TResource"/> loaded by the current instance and their corresponding <typeparamref name="TInfo"/>.
        /// </summary>
        public ResourceEnumerable Resources => new(this);

        #endregion

        #region Initialisation

        /// <summary>
        /// Creates an instance of type <see cref="AResourceManager{TInfo, TResource}"/>.
        /// </summary>
        protected AResourceManager()
        {
            _lockObject = new object();
            _resources = new Dictionary<TInfo, Resource>();
        }

        #endregion

        #region Callbacks

        private void OnAdded(in Entity entity, in ManagedResource<TInfo, TResource> value) => Add(entity, value.Info);

        private void OnChanged(in Entity entity, in ManagedResource<TInfo, TResource> oldValue, in ManagedResource<TInfo, TResource> newValue)
        {
            Add(entity, newValue.Info);
            Remove(oldValue.Info);
        }

        private void OnRemoved(in Entity entity, in ManagedResource<TInfo, TResource> value) => Remove(value.Info);

        private void OnAdded(in Entity entity, in ManagedResource<TInfo[], TResource> value)
        {
            foreach (TInfo info in value.Info)
            {
                Add(entity, info);
            }
        }

        private void OnChanged(in Entity entity, in ManagedResource<TInfo[], TResource> oldValue, in ManagedResource<TInfo[], TResource> newValue)
        {
            foreach (TInfo info in newValue.Info)
            {
                Add(entity, info);
            }
            foreach (TInfo info in oldValue.Info)
            {
                Remove(info);
            }
        }

        private void OnRemoved(in Entity entity, in ManagedResource<TInfo[], TResource> value)
        {
            foreach (TInfo info in value.Info)
            {
                Remove(info);
            }
        }

        #endregion

        #region Methods

        private void Add(in Entity entity, TInfo info)
        {
            Resource resource;

            lock (_lockObject)
            {
                if (!_resources.TryGetValue(info, out resource))
                {
                    resource = new Resource(Load(info));
                    _resources.Add(info, resource);
                }

                resource.AddReference();
            }

            OnResourceLoaded(entity, info, resource.Value);
        }

        private void Remove(TInfo info)
        {
            lock (_lockObject)
            {
                if (_resources.TryGetValue(info, out Resource resource) && resource.RemoveReference())
                {
                    try
                    {
                        Unload(info, resource.Value);
                    }
                    finally
                    {
                        _resources.Remove(info);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a resource of type <typeparamref name="TResource"/> using the provided <typeparamref name="TInfo"/> parameter.
        /// </summary>
        /// <param name="info">The <typeparamref name="TInfo"/> instance used to load the resource.</param>
        /// <returns>The <typeparamref name="TResource"/> instance.</returns>
        protected abstract TResource Load(TInfo info);

        /// <summary>
        /// Called when a resource is loaded from a <see cref="ManagedResource{TInfo, TResource}"/> component of an <see cref="Entity"/>.
        /// </summary>
        /// <param name="entity">The w<see cref="Entity"/> with the <see cref="ManagedResource{TInfo, TResource}"/> component.</param>
        /// <param name="info">The <typeparamref name="TInfo"/> info used to load the resource.</param>
        /// <param name="resource">The <typeparamref name="TResource"/> resource.</param>
        protected abstract void OnResourceLoaded(in Entity entity, TInfo info, TResource resource);

        /// <summary>
        /// Unloads a resource once it is no longer referenced by a <see cref="ManagedResource{TInfo, TResource}"/>.
        /// By default if <typeparamref name="TResource"/> is <see cref="IDisposable"/>, calls the <see cref="IDisposable.Dispose"/> method.
        /// </summary>
        /// <param name="info">The <typeparamref name="TInfo"/> that was used to load the resource.</param>
        /// <param name="resource">The <typeparamref name="TResource"/> to unload.</param>
        protected virtual void Unload(TInfo info, TResource resource) => (resource as IDisposable)?.Dispose();

        /// <summary>
        /// Sets up current <see cref="AResourceManager{TInfo, TResource}"/> instance to react to <see cref="ManagedResource{TInfo, TResource}"/> components on <see cref="Entity"/> instances of the provided <see cref="World"/>.
        /// Once no <see cref="Entity"/> contains a <see cref="ManagedResource{TInfo, TResource}"/> component anymore, the shared <typeparamref name="TResource"/> resource is disposed automatically.
        /// </summary>
        /// <param name="world">The <see cref="World"/> instance on which to react to <see cref="ManagedResource{TInfo, TResource}"/> components.</param>
        /// <returns>An <see cref="IDisposable"/> instance used to make current <see cref="AResourceManager{TInfo, TResource}"/> instance stop reacting to <see cref="ManagedResource{TInfo, TResource}"/> component of the provided <see cref="World"/>.</returns>
        public IDisposable Manage(World world)
        {
            IEnumerable<IDisposable> GetSubscriptions(World w)
            {
                yield return w.SubscribeEntityComponentAdded<ManagedResource<TInfo, TResource>>(OnAdded);
                yield return w.SubscribeEntityComponentChanged<ManagedResource<TInfo, TResource>>(OnChanged);
                yield return w.SubscribeEntityComponentRemoved<ManagedResource<TInfo, TResource>>(OnRemoved);
                yield return w.SubscribeEntityComponentAdded<ManagedResource<TInfo[], TResource>>(OnAdded);
                yield return w.SubscribeEntityComponentChanged<ManagedResource<TInfo[], TResource>>(OnChanged);
                yield return w.SubscribeEntityComponentRemoved<ManagedResource<TInfo[], TResource>>(OnRemoved);
            }

            world.ThrowIfNull();

            ComponentPool<ManagedResource<TInfo, TResource>> singleComponents = ComponentManager<ManagedResource<TInfo, TResource>>.Get(world.WorldId);
            if (singleComponents != null)
            {
                foreach (Entity entity in singleComponents.GetEntities())
                {
                    OnAdded(entity, singleComponents.Get(entity.EntityId));
                }
            }

            ComponentPool<ManagedResource<TInfo[], TResource>> arrayComponents = ComponentManager<ManagedResource<TInfo[], TResource>>.Get(world.WorldId);
            if (arrayComponents != null)
            {
                foreach (Entity entity in arrayComponents.GetEntities())
                {
                    OnAdded(entity, arrayComponents.Get(entity.EntityId));
                }
            }

            return GetSubscriptions(world).Merge();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Unloads all loaded resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            foreach (KeyValuePair<TInfo, Resource> pair in _resources)
            {
                Unload(pair.Key, pair.Value.Value);
            }

            _resources.Clear();
        }

        #endregion
    }
}
