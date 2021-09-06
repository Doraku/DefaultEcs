using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Serialization.TextSerializer
{
    internal sealed class EntityWriter : IComponentReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, string> _types;
        private readonly Dictionary<(Entity, Type), int> _components;
        private readonly Predicate<Type> _componentFilter;

        private int _entityCount;
        private Entity _currentEntity;

        #endregion

        #region Initialisation

        public EntityWriter(StreamWriterWrapper writer, Dictionary<Type, string> types, Predicate<Type> componentFilter)
        {
            _writer = writer;
            _types = types;
            _components = new Dictionary<(Entity, Type), int>();
            _componentFilter = componentFilter;
        }

        #endregion

        #region Methods

        public void Write(IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                _currentEntity = entity;

                _writer.Stream.WriteLine();
                string entry = entity.IsEnabled() ? nameof(EntryType.Entity) : nameof(EntryType.DisabledEntity);
                _writer.Write(entry);
                _writer.WriteSpace();
                _writer.Stream.WriteLine(++_entityCount);

                entity.ReadAllComponents(this);
            }
        }

        public void WriteComponent<T>(in T component, in Entity componentOwner, bool isEnabled)
        {
            if (!_types.TryGetValue(typeof(T), out _))
            {
                string typeName = typeof(T).Name;

                int repeatCount = 1;
                while (_types.ContainsValue(typeName))
                {
                    typeName = $"{typeof(T).Name}_{repeatCount++}";
                }

                _types.Add(typeof(T), typeName);

                _writer.Write(nameof(EntryType.ComponentType));
                _writer.WriteSpace();
                _writer.Write(typeName);
                _writer.WriteSpace();
                _writer.WriteLine(TypeNames.Get(typeof(T)));
            }

            if (componentOwner.IsAlive)
            {
                (Entity, Type) componentKey = (componentOwner, typeof(T));
                if (_components.TryGetValue(componentKey, out int key))
                {
                    string entry = isEnabled ? nameof(EntryType.ComponentSameAs) : nameof(EntryType.DisabledComponentSameAs);

                    _writer.Write(entry);
                    _writer.WriteSpace();
                    _writer.Write(_types[typeof(T)]);
                    _writer.WriteSpace();
                    _writer.Stream.WriteLine(key);
                }
                else
                {
                    _components.Add(componentKey, _entityCount);
                    string entry = isEnabled ? nameof(EntryType.Component) : nameof(EntryType.DisabledComponent);

                    _writer.Write(entry);
                    _writer.WriteSpace();
                    _writer.Write(_types[typeof(T)]);
                    _writer.WriteSpace();
                    Converter<T>.Write(_writer, component);
                }
            }
            else
            {
                string entry = isEnabled ? nameof(EntryType.ComponentSameAsWorld) : nameof(EntryType.DisabledComponentSameAsWorld);

                _writer.Write(entry);
                _writer.WriteSpace();
                _writer.WriteLine(_types[typeof(T)]);
            }
        }

        #endregion

        #region IComponentReader

        void IComponentReader.OnRead<T>(in T component, in Entity componentOwner)
        {
            if (_componentFilter(typeof(T)))
            {
                Action<EntityWriter, T, Entity, bool> action = _writer.Context?.GetEntityWrite<T>();
                if (action is null)
                {
                    WriteComponent(component, componentOwner, _currentEntity.IsEnabled<T>());
                }
                else
                {
                    action(this, component, componentOwner, _currentEntity.IsEnabled<T>());
                }
            }
        }

        #endregion
    }
}
