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

        private interface IComponentOperation
        {
            void SetMaxCapacity(World world, int maxCapacity);
            void Set(in Entity entity, string line, StreamReader reader);
            void SetSameAs(in Entity entity, in Entity reference);
            void SetDisabled(in Entity entity, string line, StreamReader reader);
            void SetDisabledSameAs(in Entity entity, in Entity reference);
        }

        private sealed class ComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) => world.SetMaxCapacity<T>(maxCapacity);

            public void Set(in Entity entity, string line, StreamReader reader)
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

            public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetDisabled(in Entity entity, string line, StreamReader reader)
            {
                try
                {
                    entity.Set(Converter<T>.Read(line, reader));
                    entity.Disable<T>();
                }
                catch (Exception exception)
                {
                    throw new ArgumentException("Error while parsing", exception);
                }
            }

            public void SetDisabledSameAs(in Entity entity, in Entity reference)
            {
                entity.SetSameAs<T>(reference);
                entity.Disable<T>();
            }

            #endregion
        }

        #endregion

        #region Fields

        private static readonly char[] _split = new[] { ' ', '\t' };
        private static readonly ConcurrentDictionary<Type, IComponentOperation> _componentOperations = new ConcurrentDictionary<Type, IComponentOperation>();

        #endregion

        #region Methods

        private ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            bool isNewWorld = world is null;
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

            try
            {
                using StreamReader reader = new StreamReader(stream);

                Entity currentEntity = default;
                Dictionary<string, IComponentOperation> componentOperations = new Dictionary<string, IComponentOperation>();

                while (!reader.EndOfStream)
                {
                    string[] lineParts = reader.ReadLine()?.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);

                    if (lineParts?.Length > 0)
                    {
                        string entry = lineParts[0];
                        if (nameof(EntryType.Entity).Equals(entry))
                        {
                            world ??= new World();

                            currentEntity = world.CreateEntity();
                            if (lineParts.Length > 1)
                            {
                                entities.Add(lineParts[1], currentEntity);
                            }
                        }
                        else if (nameof(EntryType.DisabledEntity).Equals(entry))
                        {
                            world ??= new World();

                            currentEntity = world.CreateEntity();
                            currentEntity.Disable();
                            if (lineParts.Length > 1)
                            {
                                entities.Add(lineParts[1], currentEntity);
                            }
                        }
                        else if (lineParts.Length > 1)
                        {
                            switch (entry)
                            {
                                case nameof(EntryType.WorldMaxCapacity):
                                    if (!isNewWorld)
                                    {
                                        throw new ArgumentException($"Encoutered {nameof(EntryType.WorldMaxCapacity)} line");
                                    }
                                    if (world != null)
                                    {
                                        throw new ArgumentException($"Encoutered {nameof(EntryType.ComponentMaxCapacity)} or Entity line before current {nameof(EntryType.WorldMaxCapacity)}");
                                    }
                                    if (!int.TryParse(lineParts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out int worldMaxCapacity))
                                    {
                                        throw new ArgumentException($"Unable to convert '{lineParts[1]}' to a number");
                                    }

                                    world = new World(worldMaxCapacity);
                                    break;

                                case nameof(EntryType.ComponentType):
                                    string[] componentTypeEntry = lineParts[1].Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                                    Type type = Type.GetType(componentTypeEntry[1], false) ?? throw new ArgumentException($"Unable to get type from '{componentTypeEntry[1]}'");

                                    componentOperations.Add(
                                        componentTypeEntry[0],
                                        _componentOperations.GetOrAdd(
                                            type,
                                            t => (IComponentOperation)Activator.CreateInstance(typeof(ComponentOperation<>).MakeGenericType(t))));
                                    break;

                                case nameof(EntryType.ComponentMaxCapacity):
                                    if (!isNewWorld)
                                    {
                                        throw new ArgumentException($"Encoutered {nameof(EntryType.ComponentMaxCapacity)} line");
                                    }
                                    string[] componentMaxCapacityEntry = lineParts[1].Split(_split, StringSplitOptions.RemoveEmptyEntries);
                                    if (componentMaxCapacityEntry.Length < 2)
                                    {
                                        throw new ArgumentException($"Unable to get {nameof(EntryType.ComponentMaxCapacity)} informations from '{lineParts[1]}'");
                                    }
                                    if (!componentOperations.TryGetValue(componentMaxCapacityEntry[0], out IComponentOperation componentOperation))
                                    {
                                        throw new ArgumentException($"Unknown component type used '{componentMaxCapacityEntry[0]}'");
                                    }
                                    if (!int.TryParse(componentMaxCapacityEntry[1], NumberStyles.Any, CultureInfo.InvariantCulture, out int maxCapacity))
                                    {
                                        throw new ArgumentException($"Unable to convert '{componentMaxCapacityEntry[1]}' to a number");
                                    }

                                    world ??= new World();

                                    componentOperation.SetMaxCapacity(world, maxCapacity);
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
                                    if (!componentOperations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out componentOperation))
                                    {
                                        throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                    }

                                    componentOperation.Set(currentEntity, componentEntry.Length > 1 ? componentEntry[1] : null, reader);
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
                                    if (!componentOperations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out componentOperation))
                                    {
                                        throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                    }
                                    if (!entities.TryGetValue(componentEntry[1], out Entity reference))
                                    {
                                        throw new ArgumentException($"Unknown reference Entity '{componentEntry[1]}'");
                                    }

                                    componentOperation.SetSameAs(currentEntity, reference);
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
                                    if (!componentOperations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out componentOperation))
                                    {
                                        throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                    }

                                    componentOperation.SetDisabled(currentEntity, componentEntry.Length > 1 ? componentEntry[1] : null, reader);
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
                                    if (!componentOperations.TryGetValue(componentEntry[0].TrimEnd(':', '='), out componentOperation))
                                    {
                                        throw new ArgumentException($"Unknown component type used '{componentEntry[0].TrimEnd(':', '=')}'");
                                    }
                                    if (!entities.TryGetValue(componentEntry[1], out reference))
                                    {
                                        throw new ArgumentException($"Unknown reference Entity '{componentEntry[1]}'");
                                    }

                                    componentOperation.SetDisabledSameAs(currentEntity, reference);
                                    break;
                            }
                        }
                    }
                }

                return isNewWorld ? null : entities.Values.ToArray();
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
            using StreamWriter writer = new StreamWriter(stream ?? throw new ArgumentNullException(nameof(stream)), new UTF8Encoding(false, true), 1024, true);

            Converter<T>.Write(obj, writer, 0);
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
            using StreamReader reader = new StreamReader(stream ?? throw new ArgumentNullException(nameof(stream)), Encoding.UTF8, true, 1024, true);

            return Converter<T>.Read(null, reader);
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
            if (stream is null) throw new ArgumentNullException(nameof(stream));
            if (world is null) throw new ArgumentNullException(nameof(world));

            using StreamWriter writer = new StreamWriter(stream);

            Dictionary<Type, string> types = new Dictionary<Type, string>();

            if (world.MaxCapacity != int.MaxValue)
            {
                writer.WriteLine($"{nameof(EntryType.WorldMaxCapacity)} {world.MaxCapacity}");
            }

            world.ReadAllComponentTypes(new ComponentTypeWriter(writer, types, world.MaxCapacity));

            new EntityWriter(writer, types).Write(world);
        }

        /// <summary>
        /// Deserializes a <see cref="World"/> instance from the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <returns>The <see cref="World"/> instance loaded.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public World Deserialize(Stream stream)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

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
            if (stream is null) throw new ArgumentNullException(nameof(stream));
            if (entities is null) throw new ArgumentNullException(nameof(entities));

            using StreamWriter writer = new StreamWriter(stream);

            new EntityWriter(writer, new Dictionary<Type, string>()).Write(entities);
        }

        /// <summary>
        /// Deserializes <see cref="Entity"/> instances with their components from the given <see cref="Stream"/> into the given <see cref="World"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <param name="world">The <see cref="World"/> instance on which the <see cref="Entity"/> will be created.</param>
        /// <returns>The <see cref="Entity"/> instances loaded.</returns>
        public ICollection<Entity> Deserialize(Stream stream, World world)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));
            if (world is null) throw new ArgumentNullException(nameof(world));

            return Deserialize(stream, ref world);
        }

        #endregion
    }
}
