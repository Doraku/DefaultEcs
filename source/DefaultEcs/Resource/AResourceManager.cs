using System;
using System.Collections.Generic;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Helper;

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

        #endregion

        #region Fields

        private readonly object _lockObject;
        private readonly Dictionary<TInfo, Resource> _resources;

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
        /// <param name="info"></param>
        /// <param name="resource"></param>
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
                yield return w.SubscribeComponentAdded<ManagedResource<TInfo, TResource>>(OnAdded);
                yield return w.SubscribeComponentChanged<ManagedResource<TInfo, TResource>>(OnChanged);
                yield return w.SubscribeComponentRemoved<ManagedResource<TInfo, TResource>>(OnRemoved);
                yield return w.SubscribeComponentAdded<ManagedResource<TInfo[], TResource>>(OnAdded);
                yield return w.SubscribeComponentChanged<ManagedResource<TInfo[], TResource>>(OnChanged);
                yield return w.SubscribeComponentRemoved<ManagedResource<TInfo[], TResource>>(OnRemoved);
            }

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
            foreach (var pair in _resources)
            {
                Unload(pair.Key, pair.Value.Value);
            }

            _resources.Clear();
        }

        #endregion
    }
}
