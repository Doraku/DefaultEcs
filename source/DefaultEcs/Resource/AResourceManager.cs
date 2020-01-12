using System;
using System.Collections.Generic;
using System.Linq;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Resource
{
    /// <summary>
    /// Base type used to load resources of type <typeparamref name="TResource"/> using info of type <typeparamref name="TInfo"/>.
    /// <typeparamref name="TInfo"/> is used as key if the same resource is requested on multiple <see cref="Entity"/> to only load the <typeparamref name="TResource"/> resource once.
    /// If no <see cref="Entity"/> contains the <see cref="ManagedResource{TInfo, TResource}"/> component identifying the resource anymore, the <typeparamref name="TResource"/> instance is then disposed automatically.
    /// </summary>
    /// <typeparam name="TInfo">The type used to identify a resource.</typeparam>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    public abstract class AResourceManager<TInfo, TResource> : IDisposable
        where TResource : IDisposable
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

        private void On(in ManagedResourceRequestMessage<ManagedResource<TInfo, TResource>> message)
        {
            Resource resource;

            lock (_lockObject)
            {
                if (!_resources.TryGetValue(message.ManagedResource.Info, out resource))
                {
                    resource = new Resource(Load(message.ManagedResource.Info));
                    _resources.Add(message.ManagedResource.Info, resource);
                }

                resource.AddReference();
            }

            OnResourceLoaded(message.Entity, message.ManagedResource.Info, resource.Value);
        }

        private void On(in ManagedResourceReleaseMessage<ManagedResource<TInfo, TResource>> message)
        {
            lock (_lockObject)
            {
                if (_resources.TryGetValue(message.ManagedResource.Info, out Resource resource) && resource.RemoveReference())
                {
                    resource.Value?.Dispose();
                    _resources.Remove(message.ManagedResource.Info);
                }
            }
        }

        private void On(in ManagedResourceRequestMessage<ManagedResource<TInfo[], TResource>> message)
        {
            foreach (TInfo info in message.ManagedResource.Info)
            {
                On(new ManagedResourceRequestMessage<ManagedResource<TInfo, TResource>>(message.Entity, new ManagedResource<TInfo, TResource>(info)));
            }
        }

        private void On(in ManagedResourceReleaseMessage<ManagedResource<TInfo[], TResource>> message)
        {
            foreach (TInfo info in message.ManagedResource.Info)
            {
                On(new ManagedResourceReleaseMessage<ManagedResource<TInfo, TResource>>(new ManagedResource<TInfo, TResource>(info)));
            }
        }

        #endregion

        #region Methods

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
        /// Sets up current <see cref="AResourceManager{TInfo, TResource}"/> instance to react to <see cref="ManagedResource{TInfo, TResource}"/> components on <see cref="Entity"/> instances of the provided <see cref="World"/>.
        /// Once no <see cref="Entity"/> contains a <see cref="ManagedResource{TInfo, TResource}"/> component anymore, the shared <typeparamref name="TResource"/> resource is disposed automatically.
        /// </summary>
        /// <param name="world">The <see cref="World"/> instance on which to react to <see cref="ManagedResource{TInfo, TResource}"/> components.</param>
        /// <returns>An <see cref="IDisposable"/> instance used to make current <see cref="AResourceManager{TInfo, TResource}"/> instance stop reacting to <see cref="ManagedResource{TInfo, TResource}"/> component of the provided <see cref="World"/>.</returns>
        public IDisposable Manage(World world)
        {
            IEnumerable<IDisposable> GetSubscriptions(World w)
            {
                yield return w.Subscribe<ManagedResourceRequestMessage<ManagedResource<TInfo, TResource>>>(On);
                yield return w.Subscribe<ManagedResourceReleaseMessage<ManagedResource<TInfo, TResource>>>(On);
                yield return w.Subscribe<ManagedResourceRequestMessage<ManagedResource<TInfo[], TResource>>>(On);
                yield return w.Subscribe<ManagedResourceReleaseMessage<ManagedResource<TInfo[], TResource>>>(On);
            }

            ComponentPool<ManagedResource<TInfo, TResource>> singleComponents = ComponentManager<ManagedResource<TInfo, TResource>>.Get(world.WorldId);
            if (singleComponents != null)
            {
                foreach (Entity entity in world.Where(e => singleComponents.Has(e.EntityId)))
                {
                    On(new ManagedResourceRequestMessage<ManagedResource<TInfo, TResource>>(entity, singleComponents.Get(entity.EntityId)));
                }
            }

            ComponentPool<ManagedResource<TInfo[], TResource>> multipleComponents = ComponentManager<ManagedResource<TInfo[], TResource>>.Get(world.WorldId);
            if (multipleComponents != null)
            {
                foreach (Entity entity in world.Where(e => multipleComponents.Has(e.EntityId)))
                {
                    On(new ManagedResourceRequestMessage<ManagedResource<TInfo[], TResource>>(entity, multipleComponents.Get(entity.EntityId)));
                }
            }

            return GetSubscriptions(world).Merge();
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Disposes all loaded resources.
        /// </summary>
        public void Dispose()
        {
            foreach (Resource resource in _resources.Values)
            {
                resource.Value?.Dispose();
            }

            _resources.Clear();
        }

        #endregion
    }
}
