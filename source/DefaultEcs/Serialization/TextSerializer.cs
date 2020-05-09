using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
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
            void Set(in Entity entity, StreamReaderWrapper reader);
            void SetSameAs(in Entity entity, in Entity reference);
            void SetDisabled(in Entity entity, StreamReaderWrapper reader);
            void SetDisabledSameAs(in Entity entity, in Entity reference);
        }

        private sealed class ComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) => world.SetMaxCapacity<T>(maxCapacity);

            public void Set(in Entity entity, StreamReaderWrapper reader)
            {
                try
                {
                    entity.Set(Converter<T>.Read(reader));
                }
                catch (Exception exception)
                {
                    throw new ArgumentException("Error while parsing", exception);
                }
            }

            public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetDisabled(in Entity entity, StreamReaderWrapper reader)
            {
                try
                {
                    entity.Set(Converter<T>.Read(reader));
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

        private sealed class IgnoreComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) { }

            public void Set(in Entity entity, StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void SetSameAs(in Entity entity, in Entity reference) { }

            public void SetDisabled(in Entity entity, StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void SetDisabledSameAs(in Entity entity, in Entity reference) { }

            #endregion
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, IComponentOperation> _componentOperations = new ConcurrentDictionary<Type, IComponentOperation>();
        private static readonly ConcurrentDictionary<Type, IComponentOperation> _ignoreComponentOperations = new ConcurrentDictionary<Type, IComponentOperation>();

        private readonly Predicate<Type> _componentFilter;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSerializer"/> class.
        /// </summary>
        /// <param name="componentFilter">A filter used to check wether a component type should be serialized/deserialized or not. A <see langword="null"/> value means everything is taken.</param>
        public TextSerializer(Predicate<Type> componentFilter)
        {
            _componentFilter = componentFilter ?? new Predicate<Type>(_ => true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSerializer"/> class.
        /// </summary>
        public TextSerializer()
            : this(null)
        { }

        #endregion

        #region Methods

        private ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            static IComponentOperation ReadComponentOperation(StreamReaderWrapper reader, Dictionary<string, IComponentOperation> componentOperations)
            {
                if (!componentOperations.TryGetValue(reader.ReadValue(), out IComponentOperation componentOperation))
                {
                    throw new ArgumentException($"Unknown component type used on line {reader.LineNumber}");
                }

                return componentOperation;
            }

            static Entity ReadEntity(StreamReaderWrapper reader, Dictionary<string, Entity> entities)
            {
                if (!entities.TryGetValue(reader.ReadValue(), out Entity entity))
                {
                    throw new ArgumentException($"Unknown entity on line {reader.LineNumber}");
                }

                return entity;
            }

            static int ReadInt(StreamReaderWrapper reader)
            {
                string value = reader.ReadValue();
                if (!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int intValue))
                {
                    throw new ArgumentException($"Unable to convert '{value}' to a number on line {reader.LineNumber}");
                }

                return intValue;
            }

            bool isNewWorld = world is null;
            Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

            try
            {
                using StreamReaderWrapper reader = new StreamReaderWrapper(stream);

                Entity currentEntity = default;
                Dictionary<string, IComponentOperation> componentOperations = new Dictionary<string, IComponentOperation>();

                while (!reader.EndOfStream)
                {
                    switch (reader.ReadValue())
                    {
                        case nameof(EntryType.WorldMaxCapacity):
                            if (!isNewWorld || world != null) throw new ArgumentException($"Encoutered {nameof(EntryType.WorldMaxCapacity)} on line {reader.LineNumber}");

                            world = new World(ReadInt(reader));
                            reader.ReadLine();
                            break;

                        case nameof(EntryType.Entity):
                            world ??= new World();

                            currentEntity = world.CreateEntity();
                            string id = reader.ReadValue();
                            if (!string.IsNullOrEmpty(id))
                            {
                                entities.Add(id, currentEntity);
                                reader.ReadLine();
                            }
                            break;

                        case nameof(EntryType.DisabledEntity):
                            world ??= new World();

                            currentEntity = world.CreateEntity();
                            currentEntity.Disable();
                            id = reader.ReadValue();
                            if (!string.IsNullOrEmpty(id))
                            {
                                entities.Add(id, currentEntity);
                                reader.ReadLine();
                            }
                            break;

                        case nameof(EntryType.ComponentType):
                            string componentType = reader.ReadValue();
                            if (string.IsNullOrEmpty(componentType))
                            {
                                throw new ArgumentException($"No component type identifier on line {reader.LineNumber}");
                            }

                            Type type = Type.GetType(reader.ReadLine(), false) ?? throw new ArgumentException($"Unable to read type on line {reader.LineNumber}");

                            componentOperations.Add(
                                componentType,
                                _componentFilter(type)
                                    ? _componentOperations.GetOrAdd(
                                        type,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(ComponentOperation<>).MakeGenericType(t)))
                                    : _ignoreComponentOperations.GetOrAdd(
                                        type,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(IgnoreComponentOperation<>).MakeGenericType(t))));
                            break;

                        case nameof(EntryType.ComponentMaxCapacity):
                            if (!isNewWorld) throw new ArgumentException($"Encoutered {nameof(EntryType.ComponentMaxCapacity)} line");

                            world ??= new World();

                            ReadComponentOperation(reader, componentOperations).SetMaxCapacity(world, ReadInt(reader));
                            reader.ReadLine();
                            break;

                        case nameof(EntryType.Component):
                            if (currentEntity.Equals(default)) throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");

                            ReadComponentOperation(reader, componentOperations).Set(currentEntity, reader);
                            break;

                        case nameof(EntryType.ComponentSameAs):
                            if (currentEntity.Equals(default)) throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");

                            ReadComponentOperation(reader, componentOperations).SetSameAs(currentEntity, ReadEntity(reader, entities));
                            reader.ReadLine();
                            break;

                        case nameof(EntryType.ParentChild):
                            ReadEntity(reader, entities).SetAsParentOf(ReadEntity(reader, entities));
                            reader.ReadLine();
                            break;

                        case nameof(EntryType.DisabledComponent):
                            if (currentEntity.Equals(default)) throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");

                            ReadComponentOperation(reader, componentOperations).SetDisabled(currentEntity, reader);
                            reader.ReadLine();
                            break;

                        case nameof(EntryType.DisabledComponentSameAs):
                            if (currentEntity.Equals(default)) throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");

                            ReadComponentOperation(reader, componentOperations).SetDisabledSameAs(currentEntity, ReadEntity(reader, entities));
                            reader.ReadLine();
                            break;
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
        /// <param name="value">The object to serialize.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void Write<T>(Stream stream, in T value)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

            Converter<T>.Write(writer, value);
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
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            using StreamReaderWrapper reader = new StreamReaderWrapper(stream);

            return Converter<T>.Read(reader);
        }

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

            using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

            Dictionary<Type, string> types = new Dictionary<Type, string>();

            if (world.MaxCapacity != int.MaxValue)
            {
                writer.Stream.WriteLine($"{nameof(EntryType.WorldMaxCapacity)} {world.MaxCapacity}");
            }

            world.ReadAllComponentTypes(new ComponentTypeWriter(writer, types, world.MaxCapacity, _componentFilter));

            new EntityWriter(writer, types, _componentFilter).Write(world);
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

            using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

            new EntityWriter(writer, new Dictionary<Type, string>(), _componentFilter).Write(entities);
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
