using System;
using DefaultEcs.Internal.Messages;

namespace DefaultEcs.Internal
{
    internal sealed class EntityContainerWatcher
    {
        #region Fields

        private readonly DefaultEcs.IEntityContainer _container;
        private readonly Predicate<ComponentEnum> _filter;
        private readonly Predicate<int> _predicate;

        #endregion

        #region Initialisation

        public EntityContainerWatcher(DefaultEcs.IEntityContainer container, Predicate<ComponentEnum> filter, Predicate<int> predicate)
        {
            _container = container;
            _filter = filter;
            _predicate = predicate;
        }

        #endregion

        #region Callbacks

        public void On(in TrimExcessMessage _) => _container.TrimExcess();

        public void Add(in EntityCreatedMessage message) => _container.Add(message.EntityId);

        public void AddOrRemove<T>(in EntityComponentChangedMessage<T> message)
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

        public void CheckedAdd<T>(in EntityComponentAddedMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in EntityComponentChangedMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in EntityComponentRemovedMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in EntityComponentEnabledMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void CheckedAdd<T>(in EntityComponentDisabledMessage<T> message)
        {
            if (_filter(message.Components) && _predicate(message.EntityId))
            {
                _container.Add(message.EntityId);
            }
        }

        public void Remove(in EntityDisposingMessage message) => _container.Remove(message.EntityId);

        public void Remove(in EntityEnabledMessage message) => _container.Remove(message.EntityId);

        public void Remove(in EntityDisabledMessage message) => _container.Remove(message.EntityId);

        public void Remove<T>(in EntityComponentAddedMessage<T> message) => _container.Remove(message.EntityId);

        public void Remove<T>(in EntityComponentRemovedMessage<T> message) => _container.Remove(message.EntityId);

        public void Remove<T>(in EntityComponentEnabledMessage<T> message) => _container.Remove(message.EntityId);

        public void Remove<T>(in EntityComponentDisabledMessage<T> message) => _container.Remove(message.EntityId);

        public void CheckedRemove<T>(in EntityComponentAddedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        public void CheckedRemove<T>(in EntityComponentRemovedMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        public void CheckedRemove<T>(in EntityComponentEnabledMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        public void CheckedRemove<T>(in EntityComponentDisabledMessage<T> message)
        {
            if (!_filter(message.Components))
            {
                _container.Remove(message.EntityId);
            }
        }

        #endregion
    }
}
