using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using DefaultEcs.Technical.Serialization;
using DefaultEcs.Technical.Serialization.BinarySerializer;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides a basic implementation of the <see cref="ISerializer"/> interface using a binary format.
    /// </summary>
    public sealed class BinarySerializer : ISerializer
    {
        #region Types

        private interface IComponentOperation
        {
            void SetMaxCapacity(World world, int maxCapacity);
            void Set(in Entity entity, in StreamReaderWrapper reader);
            void SetSameAs(in Entity entity, in Entity reference);
            void SetDisabled(in Entity entity, in StreamReaderWrapper reader);
            void SetDisabledSameAs(in Entity entity, in Entity reference);
        }

        private sealed class ComponentOperation<T> : IComponentOperation
        {
            #region IOperation

            public void SetMaxCapacity(World world, int maxCapacity) => world.SetMaxCapacity<T>(maxCapacity);

            public void Set(in Entity entity, in StreamReaderWrapper reader) => entity.Set(Converter<T>.Read(reader));

            public void SetSameAs(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetDisabled(in Entity entity, in StreamReaderWrapper reader)
            {
                entity.Set(Converter<T>.Read(reader));
                entity.Disable<T>();
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

            public void Set(in Entity entity, in StreamReaderWrapper reader) => Converter<T>.Read(reader);

            public void SetSameAs(in Entity entity, in Entity reference) { }

            public void SetDisabled(in Entity entity, in StreamReaderWrapper reader) => Converter<T>.Read(reader);

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
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class.
        /// </summary>
        /// <param name="componentFilter">A filter used to check wether a component type should be serialized or not. A <see langword="null"/> value means everything should be serialized.</param>
        public BinarySerializer(Predicate<Type> componentFilter)
        {
            _componentFilter = componentFilter ?? new Predicate<Type>(_ => true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializer"/> class.
        /// </summary>
        public BinarySerializer()
            : this(null)
        { }

        #endregion

        #region Methods

        private ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            bool isNewWorld = world is null;
            List<Entity> entities = new List<Entity>(128);

            try
            {
                using StreamReaderWrapper reader = new StreamReaderWrapper(stream);

                world ??= new World(reader.Read<int>());

                Entity currentEntity = default;
                Dictionary<ushort, IComponentOperation> componentOperations = new Dictionary<ushort, IComponentOperation>();

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
                                _componentFilter(componentType)
                                    ? _componentOperations.GetOrAdd(
                                        componentType,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(ComponentOperation<>).MakeGenericType(t)))
                                    : _ignoreComponentOperations.GetOrAdd(
                                        componentType,
                                        t => (IComponentOperation)Activator.CreateInstance(typeof(IgnoreComponentOperation<>).MakeGenericType(t))));
                            break;

                        case EntryType.ComponentMaxCapacity:
                            componentOperations[reader.Read<ushort>()].SetMaxCapacity(world, reader.Read<int>());
                            break;

                        case EntryType.Entity:
                            entities.Add(currentEntity = world.CreateEntity());
                            break;

                        case EntryType.Component:
                            componentOperations[reader.Read<ushort>()].Set(currentEntity, reader);
                            break;

                        case EntryType.ComponentSameAs:
                            componentOperations[reader.Read<ushort>()].SetSameAs(currentEntity, entities[reader.Read<int>()]);
                            break;

                        case EntryType.ParentChild:
                            entities[reader.Read<int>()].SetAsParentOf(entities[reader.Read<int>()]);
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
        /// <param name="obj">The object to serialize.</param>
        /// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void Write<T>(Stream stream, in T obj)
        {
            if (stream is null) throw new ArgumentNullException(nameof(stream));

            using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

            Converter<T>.Write(writer, obj);
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

            writer.Write(world.MaxCapacity);

            Dictionary<Type, ushort> types = new Dictionary<Type, ushort>();

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
            if (stream is null) throw new ArgumentNullException(nameof(stream));
            if (world is null) throw new ArgumentNullException(nameof(world));

            return Deserialize(stream, ref world);
        }

        #endregion
    }
}
