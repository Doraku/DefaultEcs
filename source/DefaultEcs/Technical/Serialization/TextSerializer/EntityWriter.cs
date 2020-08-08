using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class EntityWriter : IComponentReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, string> _types;
        private readonly Dictionary<Entity, int> _entities;
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
            _entities = new Dictionary<Entity, int>();
            _components = new Dictionary<(Entity, Type), int>();
            _componentFilter = componentFilter;
        }

        #endregion

        #region Methods

        public void Write(IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                _entities.Add(entity, ++_entityCount);
                _currentEntity = entity;

                _writer.Stream.WriteLine();
                string entry = entity.IsEnabled() ? nameof(EntryType.Entity) : nameof(EntryType.DisabledEntity);
                _writer.Write(entry);
                _writer.WriteSpace();
                _writer.Stream.WriteLine(_entityCount);

                entity.ReadAllComponents(this);
            }

            foreach (KeyValuePair<Entity, int> pair in _entities)
            {
                foreach (Entity child in pair.Key.GetChildren())
                {
                    if (_entities.TryGetValue(child, out int childId))
                    {
                        _writer.Write(nameof(EntryType.ParentChild));
                        _writer.WriteSpace();
                        _writer.Stream.Write(pair.Value);
                        _writer.WriteSpace();
                        _writer.Stream.WriteLine(childId);
                    }
                }
            }
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
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

        #endregion

        #region IComponentReader

        void IComponentReader.OnRead<T>(ref T component, in Entity componentOwner)
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
