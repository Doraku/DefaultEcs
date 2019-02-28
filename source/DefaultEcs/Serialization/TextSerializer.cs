using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using DefaultEcs.Technical.Serialization;
using DefaultEcs.Technical.Serialization.TextSerializer;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="ISerializer"/> interface using a text readable format.
    /// </summary>
    public sealed class TextSerializer : ISerializer
    {
        #region Types

        private interface IOperation
        {
            void SetMaximumComponentCount(World world, int maxComponentCount);
            void SetComponent(in Entity entity, string line, StreamReader reader);
            void SetSameAsComponent(in Entity entity, in Entity reference);
            void SetDisabledComponent(in Entity entity, string line, StreamReader reader);
            void SetDisabledSameAsComponent(in Entity entity, in Entity reference);
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

            public void SetDisabledComponent(in Entity entity, string line, StreamReader reader)
            {
                try
                {
                    entity.SetDisabled(Converter<T>.Read(line, reader));
                }
                catch (Exception exception)
                {
                    throw new ArgumentException("Error while parsing", exception);
                }
            }

            public void SetDisabledSameAsComponent(in Entity entity, in Entity reference) => entity.SetSameAsDisabled<T>(reference);

            #endregion
        }

        #endregion

        #region Fields

        private static readonly char[] _split = new[] { ' ', '\t' };
        private static readonly ConcurrentDictionary<Type, IOperation> _operations = new ConcurrentDictionary<Type, IOperation>();

        #endregion

        #region Methods

        private ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            bool isNewWorld = world == null;
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

            try
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Entity currentEntity = default;
                    Dictionary<string, IOperation> operations = new Dictionary<string, IOperation>();

                    while (!reader.EndOfStream)
                    {
                        string[] lineParts = reader.ReadLine()?.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);

                        if (lineParts?.Length > 0)
                        {
                            string entry = lineParts[0];
                            if (nameof(EntryType.Entity).Equals(entry))
                            {
                                if (world == null)
                                {
                                    world = new World();
                                }

                                currentEntity = world.CreateEntity();
                                if (lineParts.Length > 1)
                                {
                                    entities.Add(lineParts[1], currentEntity);
                                }
                            }
                            else if (nameof(EntryType.DisabledEntity).Equals(entry))
                            {
                                if (world == null)
                                {
                                    world = new World();
                                }

                                currentEntity = world.CreateDisabledEntity();
                                if (lineParts.Length > 1)
                                {
                                    entities.Add(lineParts[1], currentEntity);
                                }
                            }
                            else if (lineParts.Length > 1)
                            {
                                switch (entry)
                                {
                                    case nameof(EntryType.MaxEntityCount):
                                        if (!isNewWorld)
                                        {
                                            throw new ArgumentException("Encoutered MaxEntityCount line");
                                        }
                                        if (world != null)
                                        {
                                            throw new ArgumentException("Encoutered MaxEntityCount, MaxComponentCount or Entity line before current MaxEntityCount");
                                        }
                                        if (!int.TryParse(lineParts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out int maxEntityCount))
                                        {
                                            throw new ArgumentException($"Unable to convert '{lineParts[1]}' to a number");
                                        }

                                        world = new World(maxEntityCount);
                                        break;

                                    case nameof(EntryType.ComponentType):
                                        string[] componentTypeEntry = lineParts[1].Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                                        Type type = Type.GetType(componentTypeEntry[1], false) ?? throw new ArgumentException($"Unable to get type from '{componentTypeEntry[1]}'");

                                        operations.Add(
                                            componentTypeEntry[0],
                                            _operations.GetOrAdd(
                                                type,
                                                t => (IOperation)Activator.CreateInstance(typeof(Operation<>).MakeGenericType(t))));
                                        break;

                                    case nameof(EntryType.MaxComponentCount):
                                        if (!isNewWorld)
                                        {
                                            throw new ArgumentException("Encoutered MaxComponentCount line");
                                        }
                                        string[] maxComponentCountEntry = lineParts[1].Split(_split, StringSplitOptions.RemoveEmptyEntries);
                                        if (maxComponentCountEntry.Length < 2)
                                        {
                                            throw new ArgumentException($"Unable to get {nameof(EntryType.MaxComponentCount)} informations from '{lineParts[1]}'");
                                        }
                                        if (!operations.TryGetValue(maxComponentCountEntry[0], out IOperation operation))
                                        {
                                            throw new ArgumentException($"Unknown component type used '{maxComponentCountEntry[0]}'");
                                        }
                                        if (!int.TryParse(maxComponentCountEntry[1], NumberStyles.Any, CultureInfo.InvariantCulture, out int maxComponentCount))
                                        {
                                            throw new ArgumentException($"Unable to convert '{maxComponentCountEntry[1]}' to a number");
                                        }

                                        if (world == null)
                                        {
                                            world = new World();
                                        }

                                        operation.SetMaximumComponentCount(world, maxComponentCount);
                                        break;

                                    case nameof(EntryType.Component):
                                        if (currentEntity.Equals(default))
                                        {
                                            throw new ArgumentException("Encountered a component before creation of an Entity");
                                        }
                                        string[] componentEntry = lineParts[1].Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                                        if (componentEntry.Length < 1)
                                        {
                                            throw new ArgumentException($"Unable to get component type information from '{lineParts[1]}'");
                                        }
                                        if (!operations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out operation))
                                        {
                                            throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                        }

                                        operation.SetComponent(currentEntity, componentEntry.Length > 1 ? componentEntry[1] : null, reader);
                                        break;

                                    case nameof(EntryType.ComponentSameAs):
                                        if (currentEntity.Equals(default))
                                        {
                                            throw new ArgumentException("Encountered a component before creation of an Entity");
                                        }
                                        componentEntry = lineParts[1].Split(_split, StringSplitOptions.RemoveEmptyEntries);
                                        if (componentEntry.Length < 2)
                                        {
                                            throw new ArgumentException($"Unable to get component type information from '{lineParts[1]}'");
                                        }
                                        if (!operations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out operation))
                                        {
                                            throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                        }
                                        if (!entities.TryGetValue(componentEntry[1], out Entity reference))
                                        {
                                            throw new ArgumentException($"Unknown reference Entity '{componentEntry[1]}'");
                                        }

                                        operation.SetSameAsComponent(currentEntity, reference);
                                        break;

                                    case nameof(EntryType.ParentChild):
                                        componentEntry = lineParts[1].Split(_split, StringSplitOptions.RemoveEmptyEntries);
                                        if (componentEntry.Length < 2)
                                        {
                                            throw new ArgumentException($"Unable to get Entity ids from '{lineParts[1]}'");
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
                                        break;

                                    case nameof(EntryType.DisabledComponent):
                                        if (currentEntity.Equals(default))
                                        {
                                            throw new ArgumentException("Encountered a component before creation of an Entity");
                                        }
                                        componentEntry = lineParts[1].Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                                        if (componentEntry.Length < 1)
                                        {
                                            throw new ArgumentException($"Unable to get component type information from '{lineParts[1]}'");
                                        }
                                        if (!operations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out operation))
                                        {
                                            throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                        }

                                        operation.SetDisabledComponent(currentEntity, componentEntry.Length > 1 ? componentEntry[1] : null, reader);
                                        break;

                                    case nameof(EntryType.DisabledComponentSameAs):
                                        if (currentEntity.Equals(default))
                                        {
                                            throw new ArgumentException("Encountered a component before creation of an Entity");
                                        }
                                        componentEntry = lineParts[1].Split(_split, StringSplitOptions.RemoveEmptyEntries);
                                        if (componentEntry.Length < 2)
                                        {
                                            throw new ArgumentException($"Unable to get component type information from '{lineParts[1]}'");
                                        }
                                        if (!operations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out operation))
                                        {
                                            throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                        }
                                        if (!entities.TryGetValue(componentEntry[1], out reference))
                                        {
                                            throw new ArgumentException($"Unknown reference Entity '{componentEntry[1]}'");
                                        }

                                        operation.SetDisabledSameAsComponent(currentEntity, reference);
                                        break;
                                }
                            }
                        }
                    }

                    return isNewWorld ? null : entities.Values.ToArray();
                }
            }
            catch
            {
                if (isNewWorld)
                {
                    world?.Dispose();
                }
                else
                {
                    foreach (Entity entity in entities.Values)
                    {
                        entity.Dispose();
                    }
                }

                throw;
            }
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

                if (world.MaxEntityCount != int.MaxValue)
                {
                    writer.WriteLine($"{nameof(EntryType.MaxEntityCount)} {world.MaxEntityCount}");
                }

                world.ReadAllComponentTypes(new ComponentTypeWriter(writer, types, world.MaxEntityCount));

                new EntityWriter(writer, types).Write(world.GetAllEntities());
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

            World world = null;
            Deserialize(stream, ref world);

            return world;
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
                new EntityWriter(writer, new Dictionary<Type, string>()).Write(entities);
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

            return Deserialize(stream, ref world);
        }

        #endregion
    }
}
