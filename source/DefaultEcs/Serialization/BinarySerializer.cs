using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using DefaultEcs.Technical.Serialization.BinarySerializer;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="ISerializer"/> interface using a binary format.
    /// </summary>
    public unsafe sealed class BinarySerializer : ISerializer
    {
        #region Types

        private sealed class ComponentTypeWriter : IComponentTypeReader
        {
            #region Fields

            private readonly Stream _stream;
            private readonly byte[] _buffer;
            private readonly byte* _bufferP;
            private readonly Dictionary<Type, ushort> _types;
            private readonly int _maxEntityCount;

            private ushort _currentType;

            #endregion

            #region Initialisation

            public ComponentTypeWriter(Stream stream, byte[] buffer, byte* bufferP, Dictionary<Type, ushort> types, int maxEntityCount)
            {
                _stream = stream;
                _buffer = buffer;
                _bufferP = bufferP;
                _types = types;
                _maxEntityCount = maxEntityCount;
            }

            #endregion

            #region IComponentTypeReader

            public void OnRead<T>(int maxComponentCount)
            {
                _types.Add(typeof(T), _currentType);

                *_bufferP = _componentType;
                ushort* entryType = (ushort*)(_bufferP + 1);
                *(entryType++) = _currentType;
                int* typeSize = (int*)entryType;
                string typeName = typeof(T).AssemblyQualifiedName;
                *(typeSize++) = typeName.Length;
                char* type = (char*)typeSize;
                foreach (char c in typeName)
                {
                    *(type++) = c;
                }

                _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort) + sizeof(int) + sizeof(char) * typeName.Length);

                if (maxComponentCount != _maxEntityCount)
                {
                    *_bufferP = _maxComponentCount;
                    entryType = (ushort*)(_bufferP + 1);
                    *(entryType++) = _currentType;
                    *(int*)entryType = maxComponentCount;

                    _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort) + sizeof(int));
                }

                ++_currentType;
            }

            #endregion
        }

        private sealed class ComponentWriter : IComponentReader
        {
            #region Fields

            private readonly Stream _stream;
            private readonly byte[] _buffer;
            private readonly byte* _bufferP;
            private readonly Dictionary<Type, ushort> _types;
            private readonly Dictionary<Entity, int> _entities;
            private readonly Dictionary<Tuple<Entity, Type>, int> _components;

            private int _entityCount;
            private Entity _currentEntity;

            #endregion

            #region Initialisation

            public ComponentWriter(Stream stream, byte[] buffer, byte* bufferP, Dictionary<Type, ushort> types)
            {
                _stream = stream;
                _buffer = buffer;
                _bufferP = bufferP;
                _types = types;
                _entities = new Dictionary<Entity, int>();
                _components = new Dictionary<Tuple<Entity, Type>, int>();

                _entityCount = -1;
            }

            #endregion

            #region Methods

            public void WriteEntity(in Entity entity)
            {
                *_bufferP = _entity;
                ++_entityCount;

                _stream.Write(_buffer, 0, sizeof(byte));

                _entities.Add(entity, _entityCount);
                _currentEntity = entity;

                entity.ReadAllComponents(this);
            }

            #endregion

            #region IComponentReader

            public void OnRead<T>(ref T component, in Entity componentOwner)
            {
                var componentKey = Tuple.Create(componentOwner, typeof(T));
                if (_components.TryGetValue(componentKey, out int key))
                {
                    *_bufferP = _componentSameAs;
                    ushort* typeId = (ushort*)(_bufferP + 1);
                    *(typeId++) = _types[typeof(T)];
                    *(int*)typeId = key;

                    _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort) + sizeof(int));
                }
                else
                {
                    _components.Add(componentKey, _entityCount);
                    *_bufferP = _component;
                    *(ushort*)(_bufferP + 1) = _types[typeof(T)];

                    _stream.Write(_buffer, 0, sizeof(byte) + sizeof(ushort));

                    Converter<T>.Write(component, _stream, _buffer, _bufferP);
                }
            }

            #endregion
        }

        private interface IOperation
        {
            void SetMaximumComponentCount(World world, int maxComponentCount);
            void SetComponent(in Entity entity, Stream stream, byte[] buffer, byte* bufferP);
            void SetSameAsComponent(in Entity entity, in Entity reference);
        }

        private sealed class Operation<T> : IOperation
        {
            #region IOperation

            public void SetMaximumComponentCount(World world, int maxComponentCount) => world.SetMaximumComponentCount<T>(maxComponentCount);

            public void SetComponent(in Entity entity, Stream stream, byte[] buffer, byte* bufferP)
            {
                try
                {
                    entity.Set(Converter<T>.Read(stream, buffer, bufferP));
                }
                catch (Exception exception)
                {
                    throw new ArgumentException("Error while parsing", exception);
                }
            }

            public void SetSameAsComponent(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            #endregion
        }

        #endregion

        #region Fields

        private const byte _componentType = 1;
        private const byte _maxComponentCount = 2;
        private const byte _entity = 3;
        private const byte _component = 4;
        private const byte _componentSameAs = 5;

        private static readonly ConcurrentDictionary<Type, IOperation> _operations = new ConcurrentDictionary<Type, IOperation>();

        #endregion

        #region Methods

        private static World CreateWorld(Stream stream, byte[] buffer, byte* bufferP)
        {
            World world = null;

            if (stream.Read(buffer, 0, sizeof(int)) == sizeof(int))
            {
                world = new World(*(int*)bufferP);
            }

            return world;
        }

        private static IOperation CreateOperation(Type type) => (IOperation)Activator.CreateInstance(typeof(Operation<>).MakeGenericType(type));

        private static void CreateOperation(Stream stream, byte[] buffer, byte* bufferP, Dictionary<ushort, IOperation> operations)
        {
            if (stream.Read(buffer, 0, sizeof(ushort)) == sizeof(ushort))
            {
                ushort typeId = *(ushort*)bufferP;

                operations.Add(typeId, _operations.GetOrAdd(Type.GetType(Converter<string>.Read(stream, buffer, bufferP), true), CreateOperation));
            }
        }

        private static void SetMaxComponentCount(World world, Stream stream, byte[] buffer, byte* bufferP, Dictionary<ushort, IOperation> operations)
        {
            if (stream.Read(buffer, 0, sizeof(ushort) + sizeof(int)) == sizeof(ushort) + sizeof(int))
            {
                ushort typeId = *(ushort*)bufferP;
                int maxComponentCount = *(int*)((ushort*)bufferP + 1);

                if (!operations.TryGetValue(typeId, out IOperation operation))
                {
                    throw new ArgumentException($"Unknown component type used");
                }

                operation.SetMaximumComponentCount(world, maxComponentCount);
            }
        }

        private static void SetComponent(in Entity entity, Stream stream, byte[] buffer, byte* bufferP, Dictionary<ushort, IOperation> operations)
        {
            if (entity.Equals(default))
            {
                throw new ArgumentException($"Encountered a component before creation of an Entity");
            }
            if (stream.Read(buffer, 0, sizeof(ushort)) == sizeof(ushort))
            {
                if (!operations.TryGetValue(*(ushort*)bufferP, out IOperation operation))
                {
                    throw new ArgumentException($"Unknown component type used");
                }

                operation.SetComponent(entity, stream, buffer, bufferP);
            }
        }

        private static void SetSameAsComponent(in Entity entity, Stream stream, byte[] buffer, byte* bufferP, Entity[] entities, Dictionary<ushort, IOperation> operations)
        {
            if (entity.Equals(default))
            {
                throw new ArgumentException($"Encountered a component before creation of an Entity");
            }
            if (stream.Read(buffer, 0, sizeof(ushort) + sizeof(int)) == sizeof(ushort) + sizeof(int))
            {
                if (!operations.TryGetValue(*(ushort*)bufferP, out IOperation operation))
                {
                    throw new ArgumentException($"Unknown component type used");
                }

                operation.SetSameAsComponent(entity, entities[*(int*)((ushort*)bufferP + 1)]);
            }
        }

        #endregion

        #region ISerializer

        /// <summary>
        /// Serializes the given <see cref="World"/> into the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> in which the data will be saved.</param>
        /// <param name="world">The <see cref="World"/> instance to save.</param>
        public void Serialize(Stream stream, World world)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            world = world ?? throw new ArgumentNullException(nameof(world));

            using (stream)
            using (EntitySet set = world.GetEntities().Build())
            {
                ReadOnlySpan<Entity> entities = set.GetEntities();
                byte[] buffer = new byte[1024];
                fixed (byte* bufferP = buffer)
                {
                    *(int*)bufferP = world.MaxEntityCount;
                    *(((int*)bufferP) + 1) = entities.Length;
                    stream.Write(buffer, 0, sizeof(int) * 2);

                    Dictionary<Type, ushort> types = new Dictionary<Type, ushort>();

                    world.ReadAllComponentTypes(new ComponentTypeWriter(stream, buffer, bufferP, types, world.MaxEntityCount));

                    ComponentWriter componentReader = new ComponentWriter(stream, buffer, bufferP, types);
                    for (int i = 0; i < entities.Length; i++)
                    {
                        componentReader.WriteEntity(entities[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes a <see cref="World"/> instance from the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <returns>The <see cref="World"/> instance loaded.</returns>
        public World Deserialize(Stream stream)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));

            using (stream)
            {
                byte[] buffer = new byte[1024];
                fixed (byte* bufferP = buffer)
                {
                    World world = CreateWorld(stream, buffer, bufferP) ?? throw new ArgumentException("Could not create a World instance from the provided Stream");
                    if (stream.Read(buffer, 0, sizeof(int)) == sizeof(int))
                    {
                        Entity[] entities = new Entity[*(int*)bufferP];
                        Entity currentEntity = default;
                        int currentId = 0;

                        Dictionary<ushort, IOperation> operations = new Dictionary<ushort, IOperation>();

                        int entryType;
                        while ((entryType = stream.ReadByte()) >= 0)
                        {
                            switch (entryType)
                            {
                                case _componentType:
                                    CreateOperation(stream, buffer, bufferP, operations);
                                    break;

                                case _maxComponentCount:
                                    SetMaxComponentCount(world, stream, buffer, bufferP, operations);
                                    break;

                                case _entity:
                                    currentEntity = world.CreateEntity();
                                    entities[currentId++] = currentEntity;
                                    break;

                                case _component:
                                    SetComponent(currentEntity, stream, buffer, bufferP, operations);
                                    break;

                                case _componentSameAs:
                                    SetSameAsComponent(currentEntity, stream, buffer, bufferP, entities, operations);
                                    break;
                            }
                        }
                    }

                    return world;
                }
            }
        }

        #endregion
    }
}
