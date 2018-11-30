using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal sealed class EntityWriter : IComponentReader
    {
        #region Fields

        private readonly StreamWriter _writer;
        private readonly Dictionary<Type, string> _types;
        private readonly Dictionary<Entity, int> _entities;
        private readonly Dictionary<Tuple<Entity, Type>, int> _components;

        private int _entityCount;
        private Entity _currentEntity;

        #endregion

        #region Initialisation

        public EntityWriter(StreamWriter writer, Dictionary<Type, string> types)
        {
            _writer = writer;
            _types = types;
            _entities = new Dictionary<Entity, int>();
            _components = new Dictionary<Tuple<Entity, Type>, int>();
        }

        #endregion

        #region Methods

        public void Write(IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                _entities.Add(entity, ++_entityCount);
                _currentEntity = entity;

                _writer.WriteLine();
                _writer.WriteLine($"{nameof(EntryType.Entity)} {_entityCount}");

                entity.ReadAllComponents(this);
            }

            foreach (KeyValuePair<Entity, int> pair in _entities)
            {
                foreach (Entity child in pair.Key.GetChildren())
                {
                    if (_entities.TryGetValue(child, out int childId))
                    {
                        _writer.WriteLine($"{nameof(EntryType.ParentChild)} {pair.Value} {childId}");
                    }
                }
            }
        }

        #endregion

        #region IComponentReader

        void IComponentReader.OnRead<T>(ref T component, in Entity componentOwner)
        {
            if (!_types.TryGetValue(typeof(T), out string typeName))
            {
                typeName = typeof(T).Name;

                int repeatCount = 1;
                while (_types.ContainsValue(typeName))
                {
                    typeName = $"{typeof(T).Name}_{repeatCount}";
                }

                _types.Add(typeof(T), typeName);

                _writer.WriteLine($"{nameof(EntryType.ComponentType)} {typeName} {typeof(T).FullName}, {typeof(T).GetTypeInfo().Assembly.GetName().Name}");
            }

            Tuple<Entity, Type> componentKey = Tuple.Create(componentOwner, typeof(T));
            if (_components.TryGetValue(componentKey, out int key))
            {
                _writer.WriteLine($"{nameof(EntryType.ComponentSameAs)} {_types[typeof(T)]} {key}");
            }
            else
            {
                _components.Add(componentKey, _entityCount);
                _writer.Write($"{nameof(EntryType.Component)} {_types[typeof(T)]} ");
                Converter<T>.Write(component, _writer, 0);
            }
        }

        #endregion
    }
}
