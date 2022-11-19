using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using DefaultEcs.Internal.Serialization;
using DefaultEcs.Internal.Serialization.TextSerializer;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="ISerializer"/> interface using a text readable format.
    /// </summary>
    public sealed class TextSerializer : ISerializer
    {
        #region Types

        internal interface IComponentOperation
        {
            void SetMaxCapacity(World world, int maxCapacity);
            void Set(World world, StreamReaderWrapper reader);
            void Set(in Entity entity, StreamReaderWrapper reader);
            void SetSameAs(in Entity entity, in Entity reference);
            void SetSameAsWorld(in Entity entity);
            void SetDisabled(in Entity entity, StreamReaderWrapper reader);
            void SetDisabledSameAs(in Entity entity, in Entity reference);
            void SetDisabledSameAsWorld(in Entity entity);
            IComponentOperation ApplyContext(TextSerializationContext context);
        }

        private sealed class ComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) => world.SetMaxCapacity<T>(maxCapacity);

            public void Set(World world, StreamReaderWrapper reader) => world.Set(Converter<T>.Read(reader));

            public void Set(in Entity entity, StreamReaderWrapper reader) => entity.Set(Converter<T>.Read(reader));

            public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetSameAsWorld(in Entity entity) => entity.SetSameAsWorld<T>();

            public void SetDisabled(in Entity entity, StreamReaderWrapper reader)
            {
                Set(entity, reader);
                entity.Disable<T>();
            }

            public void SetDisabledSameAs(in Entity entity, in Entity reference)
            {
                SetSameAs(entity, reference);
                entity.Disable<T>();
            }

            public void SetDisabledSameAsWorld(in Entity entity)
            {
                SetSameAsWorld(entity);
                entity.Disable<T>();
            }

            public IComponentOperation ApplyContext(TextSerializationContext context) => context?.GetComponentOperation<T>() ?? this;

            #endregion
        }

        private sealed class IgnoreComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) { }

            public void Set(World world, StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void Set(in Entity entity, StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void SetSameAs(in Entity entity, in Entity reference) { }

            public void SetSameAsWorld(in Entity entity) { }

            public void SetDisabled(in Entity entity, StreamReaderWrapper reader) => Set(entity, reader);

            public void SetDisabledSameAs(in Entity entity, in Entity reference) { }

            public void SetDisabledSameAsWorld(in Entity entity) { }

            public IComponentOperation ApplyContext(TextSerializationContext context) => this;

            #endregion
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, IComponentOperation> _componentOperations = new();
        private static readonly ConcurrentDictionary<Type, IComponentOperation> _ignoreComponentOperations = new();

        private readonly Predicate<Type> _componentFilter;
        private readonly TextSerializationContext _context;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSerializer"/> class.
        /// </summary>
        /// <param name="componentFilter">A filter used to check wether a component type should be serialized/deserialized or not. A <see langword="null"/> value means everything is taken.</param>
        /// <param name="context">The <see cref="TextSerializationContext"/> used to convert type during serialization/deserialization.</param>
        public TextSerializer(Predicate<Type> componentFilter, TextSerializationContext context)
        {
            _componentFilter = componentFilter ?? new Predicate<Type>(_ => true);
            _context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSerializer"/> class.
        /// </summary>
        /// <param name="context">The <see cref="TextSerializationContext"/> used to convert type during serialization/deserialization.</param>
        public TextSerializer(TextSerializationContext context)
            : this(null, context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSerializer"/> class.
        /// </summary>
        /// <param name="componentFilter">A filter used to check wether a component type should be serialized/deserialized or not. A <see langword="null"/> value means everything is taken.</param>
        public TextSerializer(Predicate<Type> componentFilter)
            : this(componentFilter, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextSerializer"/> class.
        /// </summary>
        public TextSerializer()
            : this(null, null)
        { }

        #endregion

        #region Methods

        private ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            static IComponentOperation ReadComponentOperation(StreamReaderWrapper reader, Dictionary<string, IComponentOperation> componentOperations) =>
                !componentOperations.TryGetValue(reader.ReadFromLine(), out IComponentOperation componentOperation)
                    ? throw new ArgumentException($"Unknown component type used on line {reader.LineNumber}")
                    : componentOperation;

            static Entity ReadEntity(StreamReaderWrapper reader, Dictionary<string, Entity> entities) =>
                !entities.TryGetValue(reader.ReadFromLine(), out Entity entity)
                    ? throw new ArgumentException($"Unknown entity on line {reader.LineNumber}")
                    : entity;

            static int ReadInt(StreamReaderWrapper reader)
            {
#if NETSTANDARD2_1_OR_GREATER
                ReadOnlySpan<char> value = reader.ReadFromLineAsSpan();
                if (!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int intValue))
                {
                    throw new ArgumentException($"Unable to convert '{new string(value)}' to a number on line {reader.LineNumber}");
                }
#else
                string value = reader.ReadFromLine();
                if (!int.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out int intValue))
                {
                    throw new ArgumentException($"Unable to convert '{value}' to a number on line {reader.LineNumber}");
                }
#endif

                return intValue;
            }

            bool isNewWorld = world is null;
            Dictionary<string, Entity> entities = new();

            try
            {
                using StreamReaderWrapper reader = new(stream, _context);

                Entity currentEntity = default;
                Dictionary<string, IComponentOperation> componentOperations = new();

                while (!reader.EndOfStream)
                {
                    switch (reader.ReadFromLine())
                    {
                        case nameof(EntryType.WorldMaxCapacity):
                            if (!isNewWorld || world != null)
                            {
                                throw new ArgumentException($"Encoutered {nameof(EntryType.WorldMaxCapacity)} on line {reader.LineNumber}");
                            }

                            world = new World(ReadInt(reader));
                            break;

                        case nameof(EntryType.Entity):
                            world ??= new World();

                            currentEntity = world.CreateEntity();
                            string id = reader.ReadFromLine();
                            if (!string.IsNullOrEmpty(id))
                            {
                                entities.Add(id, currentEntity);
                            }
                            break;

                        case nameof(EntryType.DisabledEntity):
                            world ??= new World();

                            currentEntity = world.CreateEntity();
                            currentEntity.Disable();
                            id = reader.ReadFromLine();
                            if (!string.IsNullOrEmpty(id))
                            {
                                entities.Add(id, currentEntity);
                            }
                            break;

                        case nameof(EntryType.ComponentType):
                            string componentType = reader.ReadFromLine();
                            if (string.IsNullOrEmpty(componentType))
                            {
                                throw new ArgumentException($"No component type identifier on line {reader.LineNumber}");
                            }

                            Type type = Type.GetType(reader.ReadString(), false) ?? throw new ArgumentException($"Unable to read type on line {reader.LineNumber}");

                            componentOperations.Add(
                                componentType,
                                (_componentFilter(type)
                                    ? _componentOperations.GetOrAdd(
                                        type,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(ComponentOperation<>).MakeGenericType(t)))
                                    : _ignoreComponentOperations.GetOrAdd(
                                        type,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(IgnoreComponentOperation<>).MakeGenericType(t)))).ApplyContext(_context));
                            break;

                        case nameof(EntryType.ComponentMaxCapacity):
                            if (!isNewWorld)
                            {
                                throw new ArgumentException($"Encoutered {nameof(EntryType.ComponentMaxCapacity)} line");
                            }

                            world ??= new World();

                            ReadComponentOperation(reader, componentOperations).SetMaxCapacity(world, ReadInt(reader));
                            break;

                        case nameof(EntryType.Component):
                            if (currentEntity == default)
                            {
                                if (!isNewWorld)
                                {
                                    throw new ArgumentException($"Encoutered {nameof(EntryType.ComponentMaxCapacity)} line");
                                }

                                world ??= new World();

                                ReadComponentOperation(reader, componentOperations).Set(world, reader);
                            }
                            else
                            {
                                ReadComponentOperation(reader, componentOperations).Set(currentEntity, reader);
                            }
                            break;

                        case nameof(EntryType.ComponentSameAs):
                            if (currentEntity.Equals(default))
                            {
                                throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");
                            }

                            ReadComponentOperation(reader, componentOperations).SetSameAs(currentEntity, ReadEntity(reader, entities));
                            break;

                        case nameof(EntryType.ComponentSameAsWorld):
                            if (currentEntity.Equals(default))
                            {
                                throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");
                            }

                            ReadComponentOperation(reader, componentOperations).SetSameAsWorld(currentEntity);
                            break;

                        case nameof(EntryType.DisabledComponent):
                            if (currentEntity.Equals(default))
                            {
                                throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");
                            }

                            ReadComponentOperation(reader, componentOperations).SetDisabled(currentEntity, reader);
                            break;

                        case nameof(EntryType.DisabledComponentSameAs):
                            if (currentEntity.Equals(default))
                            {
                                throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");
                            }

                            ReadComponentOperation(reader, componentOperations).SetDisabledSameAs(currentEntity, ReadEntity(reader, entities));
                            break;

                        case nameof(EntryType.DisabledComponentSameAsWorld):
                            if (currentEntity.Equals(default))
                            {
                                throw new ArgumentException($"Encountered a component before creation of an Entity on line {reader.LineNumber}");
                            }

                            ReadComponentOperation(reader, componentOperations).SetDisabledSameAsWorld(currentEntity);
                            break;
                    }

                    reader.EndLine();
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
        /// <param name="context">The <see cref="TextSerializationContext"/> used to convert type during serialization.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static void Write<T>(Stream stream, in T value, TextSerializationContext context)
        {
            stream.ThrowIfNull();

            using StreamWriterWrapper writer = new(stream, context);

            Converter<T>.Write(writer, value);
        }

        /// <summary>
        /// Writes an object of type <typeparamref name="T"/> on the given stream.
        /// </summary>
        /// <typeparam name="T">The type of the object serialized.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> instance on which the object is to be serialized.</param>
        /// <param name="value">The object to serialize.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static void Write<T>(Stream stream, in T value) => Write(stream, value, null);

        /// <summary>
        /// Read an object of type <typeparamref name="T"/> from the given stream.
        /// </summary>
        /// <typeparam name="T">The type of the object deserialized.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> instance from which the object is to be deserialized.</param>
        /// <param name="context">The <see cref="TextSerializationContext"/> used to convert type during deserialization.</param>
        /// <returns>The object deserialized.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static T Read<T>(Stream stream, TextSerializationContext context)
        {
            stream.ThrowIfNull();

            using StreamReaderWrapper reader = new(stream, context);

            return Converter<T>.Read(reader);
        }

        /// <summary>
        /// Read an object of type <typeparamref name="T"/> from the given stream.
        /// </summary>
        /// <typeparam name="T">The type of the object deserialized.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> instance from which the object is to be deserialized.</param>
        /// <returns>The object deserialized.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static T Read<T>(Stream stream) => Read<T>(stream, null);

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
            stream.ThrowIfNull();
            world.ThrowIfNull();

            using StreamWriterWrapper writer = new(stream, _context);

            Dictionary<Type, string> types = new();

            if (world.MaxCapacity != int.MaxValue)
            {
                writer.Write(nameof(EntryType.WorldMaxCapacity));
                writer.WriteSpace();
                writer.Stream.WriteLine(world.MaxCapacity);
            }

            world.ReadAllComponentTypes(new ComponentTypeWriter(world, writer, types, world.MaxCapacity, _componentFilter));

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
            stream.ThrowIfNull();

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
            stream.ThrowIfNull();
            entities.ThrowIfNull();

            using StreamWriterWrapper writer = new(stream, _context);

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
            stream.ThrowIfNull();
            world.ThrowIfNull();

            return Deserialize(stream, ref world);
        }

        #endregion
    }
}
