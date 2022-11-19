using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using DefaultEcs.Internal.Serialization;
using DefaultEcs.Internal.Serialization.BinarySerializer;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="ISerializer"/> interface using a binary format.
    /// </summary>
    public sealed class BinarySerializer : ISerializer
    {
        #region Types

        internal interface IComponentOperation
        {
            void SetMaxCapacity(World world, int maxCapacity);
            void Set(World world, in StreamReaderWrapper reader);
            void Set(in Entity entity, in StreamReaderWrapper reader);
            void SetSameAs(in Entity entity, in Entity reference);
            void SetSameAsWorld(in Entity entity);
            void SetDisabled(in Entity entity, in StreamReaderWrapper reader);
            void SetDisabledSameAs(in Entity entity, in Entity reference);
            void SetDisabledSameAsWorld(in Entity entity);
            IComponentOperation ApplyContext(BinarySerializationContext context);
        }

        private sealed class ComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) => world.SetMaxCapacity<T>(maxCapacity);

            public void Set(World world, in StreamReaderWrapper reader) => world.Set(Converter<T>.Read(reader));

            public void Set(in Entity entity, in StreamReaderWrapper reader) => entity.Set(Converter<T>.Read(reader));

            public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetSameAsWorld(in Entity entity) => entity.SetSameAsWorld<T>();

            public void SetDisabled(in Entity entity, in StreamReaderWrapper reader)
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

            public IComponentOperation ApplyContext(BinarySerializationContext context) => context?.GetComponentOperation<T>() ?? this;

            #endregion
        }

        private sealed class IgnoreComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) { }

            public void Set(World world, in StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void Set(in Entity entity, in StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void SetSameAs(in Entity entity, in Entity reference) { }

            public void SetSameAsWorld(in Entity entity) { }

            public void SetDisabled(in Entity entity, in StreamReaderWrapper reader) => Set(entity, reader);

            public void SetDisabledSameAs(in Entity entity, in Entity reference) { }

            public void SetDisabledSameAsWorld(in Entity entity) { }

            public IComponentOperation ApplyContext(BinarySerializationContext context) => this;

            #endregion
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, IComponentOperation> _componentOperations = new();
        private static readonly ConcurrentDictionary<Type, IComponentOperation> _ignoreComponentOperations = new();

        private readonly Predicate<Type> _componentFilter;
        private readonly BinarySerializationContext _context;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class.
        /// </summary>
        /// <param name="componentFilter">A filter used to check wether a component type should be serialized/deserialized or not. A <see langword="null"/> value means everything is taken.</param>
        /// <param name="context">The <see cref="BinarySerializationContext"/> used to convert type during serialization/deserialization.</param>
        public BinarySerializer(Predicate<Type> componentFilter, BinarySerializationContext context)
        {
            _componentFilter = componentFilter ?? new Predicate<Type>(_ => true);
            _context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class.
        /// </summary>
        /// <param name="context">The <see cref="BinarySerializationContext"/> used to convert type during serialization/deserialization.</param>
        public BinarySerializer(BinarySerializationContext context)
            : this(null, context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class.
        /// </summary>
        /// <param name="componentFilter">A filter used to check wether a component type should be serialized/deserialized or not. A <see langword="null"/> value means everything is taken.</param>
        public BinarySerializer(Predicate<Type> componentFilter)
            : this(componentFilter, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class.
        /// </summary>
        public BinarySerializer()
            : this(null, null)
        { }

        #endregion

        #region Methods

        private ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            bool isNewWorld = world is null;
            List<Entity> entities = new(128);

            try
            {
                using StreamReaderWrapper reader = new(stream, _context);

                world ??= new World(reader.Read<int>());

                Entity currentEntity = default;
                Dictionary<ushort, IComponentOperation> componentOperations = new();

                int entryType;
                while ((entryType = stream.ReadByte()) >= 0)
                {
                    switch ((EntryType)entryType)
                    {
                        case EntryType.ComponentType:
                            ushort operationIndex = reader.Read<ushort>();
                            Type componentType = Type.GetType(reader.ReadString(), true);
                            componentOperations.Add(
                                operationIndex,
                                (_componentFilter(componentType)
                                    ? _componentOperations.GetOrAdd(
                                        componentType,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(ComponentOperation<>).MakeGenericType(t)))
                                    : _ignoreComponentOperations.GetOrAdd(
                                        componentType,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(IgnoreComponentOperation<>).MakeGenericType(t)))).ApplyContext(_context));
                            break;

                        case EntryType.ComponentMaxCapacity:
                            componentOperations[reader.Read<ushort>()].SetMaxCapacity(world, reader.Read<int>());
                            break;

                        case EntryType.Entity:
                            entities.Add(currentEntity = world.CreateEntity());
                            break;

                        case EntryType.Component:
                            if (currentEntity == default)
                            {
                                componentOperations[reader.Read<ushort>()].Set(world, reader);
                            }
                            else
                            {
                                componentOperations[reader.Read<ushort>()].Set(currentEntity, reader);
                            }
                            break;

                        case EntryType.ComponentSameAs:
                            componentOperations[reader.Read<ushort>()].SetSameAs(currentEntity, entities[reader.Read<int>()]);
                            break;

                        case EntryType.ComponentSameAsWorld:
                            componentOperations[reader.Read<ushort>()].SetSameAsWorld(currentEntity);
                            break;

                        case EntryType.DisabledEntity:
                            currentEntity = world.CreateEntity();
                            currentEntity.Disable();
                            entities.Add(currentEntity);
                            break;

                        case EntryType.DisabledComponent:
                            componentOperations[reader.Read<ushort>()].SetDisabled(currentEntity, reader);
                            break;

                        case EntryType.DisabledComponentSameAs:
                            componentOperations[reader.Read<ushort>()].SetDisabledSameAs(currentEntity, entities[reader.Read<int>()]);
                            break;

                        case EntryType.DisabledComponentSameAsWorld:
                            componentOperations[reader.Read<ushort>()].SetDisabledSameAsWorld(currentEntity);
                            break;
                    }
                }

                return entities;
            }
            catch
            {
                if (isNewWorld)
                {
                    world?.Dispose();
                }
                else
                {
                    foreach (Entity entity in entities)
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
        /// <param name="context">The <see cref="BinarySerializationContext"/> used to convert type during serialization.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static void Write<T>(Stream stream, in T value, BinarySerializationContext context)
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
        /// <param name="context">The <see cref="BinarySerializationContext"/> used to convert type during deserialization.</param>
        /// <returns>The object deserialized.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        public static T Read<T>(Stream stream, BinarySerializationContext context)
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

            writer.Write(world.MaxCapacity);

            Dictionary<Type, ushort> types = new();

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

            new EntityWriter(writer, new Dictionary<Type, ushort>(), _componentFilter).Write(entities);
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
