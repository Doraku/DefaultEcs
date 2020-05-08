using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal sealed class EntityWriter : IComponentReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, ushort> _types;
        private readonly Dictionary<Entity, int> _entities;
        private readonly Dictionary<(Entity, Type), int> _components;
        private readonly Predicate<Type> _componentFilter;

        private ushort _currentType;
        private int _entityCount;
        private Entity _currentEntity;

        #endregion

        #region Initialisation

        public EntityWriter(in StreamWriterWrapper writer, Dictionary<Type, ushort> types, Predicate<Type> componentFilter)
        {
            _writer = writer;
            _types = types;
            _entities = new Dictionary<Entity, int>();
            _components = new Dictionary<(Entity, Type), int>();
            _componentFilter = componentFilter;

            _currentType = (ushort)types.Count;
            _entityCount = -1;
        }

        #endregion

        #region Methods

        public void Write(IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                _writer.WriteByte((byte)(entity.IsEnabled() ? EntryType.Entity : EntryType.DisabledEntity));
                ++_entityCount;

                _entities.Add(entity, _entityCount);
                _currentEntity = entity;

                entity.ReadAllComponents(this);
            }

            foreach (KeyValuePair<Entity, int> pair in _entities)
            {
                foreach (Entity child in pair.Key.GetChildren())
                {
                    _writer.WriteByte((byte)EntryType.ParentChild);
                    _writer.Write(pair.Value);
                    _writer.Write(_entities[child]);
                }
            }
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public void WriteComponent<T>(in T component, in Entity componentOwner)
        {
            if (!_types.TryGetValue(typeof(T), out ushort typeId))
            {
                typeId = _currentType++;
                _types.Add(typeof(T), typeId);

                _writer.WriteByte((byte)EntryType.ComponentType);
                _writer.Write(typeId);
                _writer.WriteString(TypeNames.Get(typeof(T)));
            }

            (Entity, Type) componentKey = (componentOwner, typeof(T));
            if (_components.TryGetValue(componentKey, out int key))
            {
                _writer.WriteByte((byte)(_currentEntity.IsEnabled<T>() ? EntryType.ComponentSameAs : EntryType.DisabledComponentSameAs));
                _writer.Write(typeId);
                _writer.Write(key);
            }
            else
            {
                _components.Add(componentKey, _entityCount);

                _writer.WriteByte((byte)(_currentEntity.IsEnabled<T>() ? EntryType.Component : EntryType.DisabledComponent));
                _writer.Write(typeId);

                Converter<T>.Write(_writer, component);
            }
        }

        #endregion

        #region IComponentReader

        void IComponentReader.OnRead<T>(ref T component, in Entity componentOwner)
        {
            if (_componentFilter(typeof(T)))
            {
                Action<EntityWriter, T, Entity> action = _writer.Context?.GetEntityWrite<T>();
                if (action is null)
                {
                    WriteComponent(component, componentOwner);
                }
                else
                {
                    action(this, component, componentOwner);
                }
            }
        }

        #endregion
    }
}
