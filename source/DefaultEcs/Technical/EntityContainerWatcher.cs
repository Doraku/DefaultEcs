using System;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal sealed class EntityContainerWatcher
    {
        #region Fields

        private readonly IEntityContainer _container;
        private readonly Predicate<ComponentEnum> _filter;
        private readonly Predicate<int> _predicate;

        #endregion

        #region Initialisation

        public EntityContainerWatcher(IEntityContainer container, Predicate<ComponentEnum> filter, Predicate<int> predicate)
        {
            _container = container;
            _filter = filter;
            _predicate = predicate;
        }

        #endregion

        #region Callbacks

        public void On(in TrimExcessMessage _) => _container.TrimExcess();

        public void Add(in EntityCreatedMessage message) => _container.Add(message.EntityId);

        public void AddOrRemove<T>(in ComponentChangedMessage<T> message)
        {
            if (_filter(message.Components))
            {
                if (_predicate(message.EntityId))
                {
                    _container.Add(message.EntityId);
                }
                else
                {
                    _container.Remove(message.EntityId);
                }
            }
        }

        public void CheckedAdd(in EntityEnabledMessage message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd(in EntityDisabledMessage message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in ComponentAddedMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in ComponentChangedMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in ComponentRemovedMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in ComponentEnabledMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in ComponentDisabledMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void Remove(in EntityDisposingMessage message) => _container.Remove(message.EntityId);

        public void Remove(in EntityEnabledMessage message) => _container.Remove(message.EntityId);

        public void Remove(in EntityDisabledMessage message) => _container.Remove(message.EntityId);

        public void Remove<T>(in ComponentAddedMessage<T> message) => _container.Remove(message.EntityId);

        public void Remove<T>(in ComponentRemovedMessage<T> message) => _container.Remove(message.EntityId);

        public void Remove<T>(in ComponentEnabledMessage<T> message) => _container.Remove(message.EntityId);

        public void Remove<T>(in ComponentDisabledMessage<T> message) => _container.Remove(message.EntityId);

        public void CheckedRemove<T>(in ComponentAddedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        public void CheckedRemove<T>(in ComponentRemovedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        public void CheckedRemove<T>(in ComponentEnabledMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        public void CheckedRemove<T>(in ComponentDisabledMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        #endregion
    }
}
