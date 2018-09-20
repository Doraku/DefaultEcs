using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DefaultEcs.Technical.Serialization.TextSerializer;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="ISerializer"/> interface using a text readable format.
    /// </summary>
    public sealed class TextSerializer : ISerializer
    {
        #region Types

        private sealed class ComponentTypeWriter : IComponentTypeReader
        {
            #region Fields

            private readonly StreamWriter _writer;
            private readonly Dictionary<Type, string> _types;
            private readonly int _maxEntityCount;

            #endregion

            #region Initialisation

            public ComponentTypeWriter(StreamWriter writer, Dictionary<Type, string> types, int maxEntityCount)
            {
                _writer = writer;
                _types = types;
                _maxEntityCount = maxEntityCount;
            }

            #endregion

            #region IComponentTypeReader

            public void OnRead<T>(int maxComponentCount)
            {
                string shortName = typeof(T).Name;

                int repeatCount = 1;
                while (_types.ContainsValue(shortName))
                {
                    shortName = $"{typeof(T).Name}_{repeatCount}";
                }

                _types.Add(typeof(T), shortName);

                _writer.WriteLine($"{_componentType} {shortName} {typeof(T).FullName}, {typeof(T).GetTypeInfo().Assembly.GetName().Name}");
                if (maxComponentCount != _maxEntityCount)
                {
                    _writer.WriteLine($"{_maxComponentCount} {shortName} {maxComponentCount}");
                }
            }

            #endregion
        }

        private sealed class ComponentWriter : IComponentReader
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

            public ComponentWriter(StreamWriter writer, Dictionary<Type, string> types)
            {
                _writer = writer;
                _types = types;
                _entities = new Dictionary<Entity, int>();
                _components = new Dictionary<Tuple<Entity, Type>, int>();
            }

            #endregion

            #region Methods

            public void WriteEntity(in Entity entity)
            {
                _entities.Add(entity, ++_entityCount);
                _currentEntity = entity;

                _writer.WriteLine();
                _writer.WriteLine($"{_entity} {_entityCount}");

                entity.ReadAllComponents(this);
            }

            public void WriteChildren()
            {
                foreach (KeyValuePair<Entity, int> pair in _entities)
                {
                    foreach (Entity child in pair.Key.GetChildren())
                    {
                        if (_entities.TryGetValue(child, out int childId))
                        {
                            _writer.WriteLine($"{_parentChild} {pair.Value} {childId}");
                        }
                    }
                }
            }

            #endregion

            #region IComponentReader

            public void OnRead<T>(ref T component, in Entity componentOwner)
            {
                Tuple<Entity, Type> componentKey = Tuple.Create(componentOwner, typeof(T));
                if (_components.TryGetValue(componentKey, out int key))
                {
                    _writer.WriteLine($"{_componentSameAs} {_types[typeof(T)]} {key}");
                }
                else
                {
                    _components.Add(componentKey, _entityCount);
                    _writer.Write($"{_component} {_types[typeof(T)]} ");
                    Converter<T>.Write(component, _writer, 0);
                }
            }

            #endregion
        }

        private interface IOperation
        {
            void SetMaximumComponentCount(World world, int maxComponentCount);
            void SetComponent(in Entity entity, string line, StreamReader reader);
            void SetSameAsComponent(in Entity entity, in Entity reference);
        }

        private sealed class Operation<T> : IOperation
        {
            #region IOperation

            public void SetMaximumComponentCount(World world, int maxComponentCount) => world.SetMaximumComponentCount<T>(maxComponentCount);

            public void SetComponent(in Entity entity, string line, StreamReader reader)
            {
                try
                {
                    entity.Set(Converter<T>.Read(line, reader));
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

        private const string _maxEntityCount = "MaxEntityCount";
        private const string _componentType = "ComponentType";
        private const string _maxComponentCount = "MaxComponentCount";
        private const string _entity = "Entity";
        private const string _component = "Component";
        private const string _componentSameAs = "ComponentSameAs";
        private const string _parentChild = "ParentChild";

        private static readonly char[] _split = new[] { ' ', '\t' };
        private static readonly ConcurrentDictionary<Type, IOperation> _operations = new ConcurrentDictionary<Type, IOperation>();

        #endregion

        #region Methods

        private static World CreateWorld(StreamReader reader)
        {
            World world = null;
            do
            {
                string[] lineParts = reader.ReadLine()?.Split(_split, StringSplitOptions.RemoveEmptyEntries);
                if (lineParts?.Length > 1
                    && _maxEntityCount.Equals(lineParts[0]))
                {
                    if (!int.TryParse(lineParts[1], out int maxEntityCount))
                    {
                        throw new ArgumentException($"Unable to convert '{lineParts[1]}' to a number");
                    }

                    world = new World(maxEntityCount);
                    break;
                }
            }
            while (!reader.EndOfStream);

            return world;
        }

        private static IOperation CreateOperation(Type type) => (IOperation)Activator.CreateInstance(typeof(Operation<>).MakeGenericType(type));

        private static void CreateOperation(string entry, Dictionary<string, IOperation> operations)
        {
            string[] componentTypeEntry = entry.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
            Type type = Type.GetType(componentTypeEntry[1], false) ?? throw new ArgumentException($"Unable to get type from '{componentTypeEntry[1]}'");

            operations.Add(componentTypeEntry[0], _operations.GetOrAdd(type, CreateOperation));
        }

        private static void SetMaxComponentCount(World world, string entry, Dictionary<string, IOperation> operations)
        {
            string[] maxComponentCountEntry = entry.Split(_split, StringSplitOptions.RemoveEmptyEntries);
            if (maxComponentCountEntry.Length < 2)
            {
                throw new ArgumentException($"Unable to get {_maxComponentCount} information from '{entry}'");
            }
            if (!operations.TryGetValue(maxComponentCountEntry[0], out IOperation operation))
            {
                throw new ArgumentException($"Unknown component type used '{maxComponentCountEntry[0]}'");
            }
            if (!int.TryParse(maxComponentCountEntry[1], out int maxComponentCount))
            {
                throw new ArgumentException($"Unable to convert '{maxComponentCountEntry[1]}' to a number");
            }

            operation.SetMaximumComponentCount(world, maxComponentCount);
        }

        private static void SetComponent(StreamReader reader, in Entity entity, string entry, Dictionary<string, IOperation> operations)
        {
            if (entity.Equals(default))
            {
                throw new ArgumentException($"Encountered a component before creation of an Entity");
            }
            string[] componentEntry = entry.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
            if (componentEntry.Length < 1)
            {
                throw new ArgumentException($"Unable to get component type information from '{entry}'");
            }
            if (!operations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out IOperation operation))
            {
                throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
            }

            operation.SetComponent(entity, componentEntry.Length > 1 ? componentEntry[1] : null, reader);
        }

        private static void SetSameAsComponent(in Entity entity, string entry, Dictionary<string, Entity> entities, Dictionary<string, IOperation> operations)
        {
            if (entity.Equals(default))
            {
                throw new ArgumentException($"Encountered a component before creation of an Entity");
            }
            string[] componentEntry = entry.Split(_split, StringSplitOptions.RemoveEmptyEntries);
            if (componentEntry.Length < 2)
            {
                throw new ArgumentException($"Unable to get component type information from '{entry}'");
            }
            if (!operations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out IOperation operation))
            {
                throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
            }
            if (!entities.TryGetValue(componentEntry[1], out Entity reference))
            {
                throw new ArgumentException($"Unknown reference Entity '{componentEntry[1]}'");
            }

            operation.SetSameAsComponent(entity, reference);
        }

        private static void SetAsParentOf(string entry, Dictionary<string, Entity> entities)
        {
            string[] componentEntry = entry.Split(_split, StringSplitOptions.RemoveEmptyEntries);
            if (componentEntry.Length < 2)
            {
                throw new ArgumentException($"Unable to get Entity ids from '{entry}'");
            }
            if (!entities.TryGetValue(componentEntry[0], out Entity parent))
            {
                throw new ArgumentException($"Unknown parent Entity '{componentEntry[0]}'");
            }
            if (!entities.TryGetValue(componentEntry[1], out Entity child))
            {
                throw new ArgumentException($"Unknown child Entity '{componentEntry[1]}'");
            }

            parent.SetAsParentOf(child);
        }

        /// <summary>
        /// Writes an object of type <typeparamref name="T"/> on the given stream.
        /// </summary>
        /// <typeparam name="T">The type of the object serialized.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> instance on which the object is to be serialized.</param>
        /// <param name="obj">The object to serialize.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static void Write<T>(Stream stream, in T obj)
        {
            using (StreamWriter writer = new StreamWriter(stream ?? throw new ArgumentNullException(nameof(stream)), new UTF8Encoding(false, true), 1024, true))
            {
                Converter<T>.Write(obj, writer, 0);
            }
        }

        /// <summary>
        /// Read an object of type <typeparamref name="T"/> from the given stream.
        /// </summary>
        /// <typeparam name="T">The type of the object deserialized.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> instance from which the object is to be deserialized.</param>
        /// <returns>The object deserialized.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static T Read<T>(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream ?? throw new ArgumentNullException(nameof(stream)), Encoding.UTF8, true, 1024, true))
            {
                return Converter<T>.Read(null, reader);
            }
        }

        //public static Func<Entity> GetFactory(Stream stream)
        //{

        //}

        #endregion

        #region ISerializer

        /// <summary>
        /// Serializes the given <see cref="World"/> into the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> in which the data will be saved.</param>
        /// <param name="world">The <see cref="World"/> instance to save.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        public void Serialize(Stream stream, World world)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            world = world ?? throw new ArgumentNullException(nameof(world));

            using (StreamWriter writer = new StreamWriter(stream))
            {
                Dictionary<Type, string> types = new Dictionary<Type, string>();

                writer.WriteLine($"{_maxEntityCount} {world.MaxEntityCount}");
                world.ReadAllComponentTypes(new ComponentTypeWriter(writer, types, world.MaxEntityCount));

                ComponentWriter componentWriter = new ComponentWriter(writer, types);

                using (EntitySet set = world.GetEntities().Build())
                {
                    ReadOnlySpan<Entity> entities = set.GetEntities();
                    for (int i = 0; i < entities.Length; i++)
                    {
                        componentWriter.WriteEntity(entities[i]);
                    }

                    componentWriter.WriteChildren();
                }
            }
        }

        /// <summary>
        /// Deserializes a <see cref="World"/> instance from the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <returns>The <see cref="World"/> instance loaded.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public World Deserialize(Stream stream)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));

            using (StreamReader reader = new StreamReader(stream))
            {
                World world = CreateWorld(reader) ?? throw new ArgumentException("Could not create a World instance from the provided Stream");
                Entity currentEntity = default;
                Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
                Dictionary<string, IOperation> operations = new Dictionary<string, IOperation>();

                do
                {
                    string[] lineParts = reader.ReadLine()?.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (lineParts?.Length > 0)
                    {
                        string entry = lineParts[0];
                        if (_entity.Equals(entry))
                        {
                            currentEntity = world.CreateEntity();
                            if (lineParts.Length > 1)
                            {
                                entities.Add(lineParts[1], currentEntity);
                            }
                        }
                        else if (lineParts.Length > 1)
                        {
                            if (_componentType.Equals(entry))
                            {
                                CreateOperation(lineParts[1], operations);
                            }
                            else if (_maxComponentCount.Equals(entry))
                            {
                                SetMaxComponentCount(world, lineParts[1], operations);
                            }
                            else if (_component.Equals(entry))
                            {
                                SetComponent(reader, currentEntity, lineParts[1], operations);
                            }
                            else if (_componentSameAs.Equals(entry))
                            {
                                SetSameAsComponent(currentEntity, lineParts[1], entities, operations);
                            }
                            else if (_parentChild.Equals(entry))
                            {
                                SetAsParentOf(lineParts[1], entities);
                            }
                        }
                    }
                }
                while (!reader.EndOfStream);

                return world;
            }
        }

        /// <summary>
        /// Serializes the given <see cref="Entity"/> instances with their components into the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> in which the data will be saved.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to save.</param>
        public void Serialize(Stream stream, IEnumerable<Entity> entities)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            entities = entities ?? throw new ArgumentNullException(nameof(entities));

            using (StreamWriter writer = new StreamWriter(stream))
            {
                ComponentWriter entityWriter = new ComponentWriter(writer, new Dictionary<Type, string>());

                foreach (Entity entity in entities)
                {
                    entityWriter.WriteEntity(entity);
                }

                entityWriter.WriteChildren();
            }
        }

        /// <summary>
        /// Deserializes <see cref="Entity"/> instances with their components from the given <see cref="Stream"/> into the given <see cref="World"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <param name="world">The <see cref="World"/> instance on which the <see cref="Entity"/> will be created.</param>
        /// <returns>The <see cref="Entity"/> instances loaded.</returns>
        public ICollection<Entity> Deserialize(Stream stream, World world)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            world = world ?? throw new ArgumentNullException(nameof(world));

            using (StreamReader reader = new StreamReader(stream))
            {
                Entity currentEntity = default;
                Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
                Dictionary<string, IOperation> operations = new Dictionary<string, IOperation>();

                int unnamedCount = 0;

                do
                {
                    string[] lineParts = reader.ReadLine()?.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (lineParts?.Length > 0)
                    {
                        string entry = lineParts[0];
                        if (_entity.Equals(entry))
                        {
                            currentEntity = world.CreateEntity();
                            entities.Add(lineParts.Length > 1 ? lineParts[1] : $" {++unnamedCount}", currentEntity);
                        }
                        else if (lineParts.Length > 1)
                        {
                            if (_componentType.Equals(entry))
                            {
                                CreateOperation(lineParts[1], operations);
                            }
                            else if (_component.Equals(entry))
                            {
                                SetComponent(reader, currentEntity, lineParts[1], operations);
                            }
                            else if (_componentSameAs.Equals(entry))
                            {
                                SetSameAsComponent(currentEntity, lineParts[1], entities, operations);
                            }
                            else if (_parentChild.Equals(entry))
                            {
                                SetAsParentOf(lineParts[1], entities);
                            }
                        }
                    }
                }
                while (!reader.EndOfStream);

                return entities.Values;
            }
        }

        #endregion
    }
}
