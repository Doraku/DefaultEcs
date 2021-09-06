using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Serialization.BinarySerializer
{
    internal sealed class EntityWriter : IComponentReader
    {
        #region Fields

        private readonly StreamWriterWrapper _writer;
        private readonly Dictionary<Type, ushort> _types;
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

                _currentEntity = entity;

                entity.ReadAllComponents(this);
            }
        }

        public void WriteComponent<T>(in T component, in Entity componentOwner, bool isEnabled)
        {
            if (!_types.TryGetValue(typeof(T), out ushort typeId))
            {
                typeId = _currentType++;
                _types.Add(typeof(T), typeId);

                _writer.WriteByte((byte)EntryType.ComponentType);
                _writer.Write(typeId);
                _writer.WriteString(TypeNames.Get(typeof(T)));
            }

            if (componentOwner.IsAlive)
            {
                (Entity, Type) componentKey = (componentOwner, typeof(T));
                if (_components.TryGetValue(componentKey, out int key))
                {
                    _writer.WriteByte((byte)(isEnabled ? EntryType.ComponentSameAs : EntryType.DisabledComponentSameAs));
                    _writer.Write(typeId);
                    _writer.Write(key);
                }
                else
                {
                    _components.Add(componentKey, _entityCount);

                    _writer.WriteByte((byte)(isEnabled ? EntryType.Component : EntryType.DisabledComponent));
                    _writer.Write(typeId);

                    Converter<T>.Write(_writer, component);
                }
            }
            else
            {
                _writer.WriteByte((byte)(isEnabled ? EntryType.ComponentSameAsWorld : EntryType.DisabledComponentSameAsWorld));
                _writer.Write(typeId);
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
