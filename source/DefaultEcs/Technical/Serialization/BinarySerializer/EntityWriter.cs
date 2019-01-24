using System;
using System.Collections.Generic;
using System.IO;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal sealed unsafe class EntityWriter : IComponentReader
    {
        #region Fields

        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly byte* _bufferP;
        private readonly Dictionary<Type, ushort> _types;
        private readonly Dictionary<Entity, int> _entities;
        private readonly Dictionary<Tuple<Entity, Type>, int> _components;

        private ushort _currentType;
        private int _entityCount;
        private Entity _currentEntity;

        #endregion

        #region Initialisation

        public EntityWriter(Stream stream, byte[] buffer, byte* bufferP, Dictionary<Type, ushort> types)
        {
            _stream = stream;
            _buffer = buffer;
            _bufferP = bufferP;
            _types = types;
            _entities = new Dictionary<Entity, int>();
            _components = new Dictionary<Tuple<Entity, Type>, int>();

            _currentType = (ushort)types.Count;
            _entityCount = -1;
        }

        #endregion

        #region Methods

        public void Write(IEnumerable<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                *_bufferP = (byte)EntryType.Entity;
                ++_entityCount;

                _stream.Write(_buffer, 0, sizeof(byte));

                _entities.Add(entity, _entityCount);
                _currentEntity = entity;

                entity.ReadAllComponents(this);
            }

            foreach (KeyValuePair<Entity, int> pair in _entities)
            {
                *_bufferP = (byte)EntryType.ParentChild;
                int* ids = (int*)(_bufferP + 1);
                *ids++ = pair.Value;

                foreach (Entity child in pair.Key.GetChildren())
                {
                    *ids = _entities[child];

                    _stream.Write(_buffer, 0, sizeof(byte) + (sizeof(int) * 2));
                }
            }
        }

        #endregion

        #region IComponentReader

        void IComponentReader.OnRead<T>(ref T component, in Entity componentOwner)
        {
            if (!_types.TryGetValue(typeof(T), out ushort currentType))
            {
                _types.Add(typeof(T), _currentType);

                *_bufferP = (byte)EntryType.ComponentType;
                ushort* entryType = (ushort*)(_bufferP + 1);
                *(entryType++) = _currentType;
                _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort));
                Converter<string>.Write(typeof(T).AssemblyQualifiedName, _stream, _buffer, _bufferP);

                ++_currentType;
            }

            Tuple<Entity, Type> componentKey = Tuple.Create(componentOwner, typeof(T));
            if (_components.TryGetValue(componentKey, out int key))
            {
                *_bufferP = (byte)EntryType.ComponentSameAs;
                ushort* typeId = (ushort*)(_bufferP + 1);
                *typeId++ = _types[typeof(T)];
                *(int*)typeId = key;

                _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort) + sizeof(int));
            }
            else
            {
                _components.Add(componentKey, _entityCount);
                *_bufferP = (byte)EntryType.Component;
                *(ushort*)(_bufferP + 1) = _types[typeof(T)];

                _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort));

                Converter<T>.Write(component, _stream, _buffer, _bufferP);
            }
        }

        #endregion
    }
}
