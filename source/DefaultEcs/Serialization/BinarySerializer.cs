using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        private interface IOperation
        {
            void SetMaximumComponentCount(World world, int maxComponentCount);
            void SetComponent(in Entity entity, in StreamReaderWrapper reader);
            void SetSameAsComponent(in Entity entity, in Entity reference);
            void SetDisabledComponent(in Entity entity, in StreamReaderWrapper reader);
            void SetDisabledSameAsComponent(in Entity entity, in Entity reference);
        }

        private sealed class Operation<T> : IOperation
        {
            #region IOperation

            public void SetMaximumComponentCount(World world, int maxComponentCount) => world.SetMaximumComponentCount<T>(maxComponentCount);

            public void SetComponent(in Entity entity, in StreamReaderWrapper reader) => entity.Set(Converter<T>.Read(reader));

            public void SetSameAsComponent(in Entity entity, in Entity reference) => entity.SetSameAs<T>(reference);

            public void SetDisabledComponent(in Entity entity, in StreamReaderWrapper reader) => entity.SetDisabled(Converter<T>.Read(reader));

            public void SetDisabledSameAsComponent(in Entity entity, in Entity reference) => entity.SetSameAsDisabled<T>(reference);

            #endregion
        }

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, IOperation> _operations = new ConcurrentDictionary<Type, IOperation>();

        #endregion

        #region Methods

        private static ICollection<Entity> Deserialize(Stream stream, ref World world)
        {
            bool isNewWorld = world == null;
            List<Entity> entities = new List<Entity>(128);

            try
            {
                using (stream)
                {
                    using StreamReaderWrapper reader = new StreamReaderWrapper(stream);

                    world ??= new World(reader.Read<int>());

                    Entity currentEntity = default;
                    Dictionary<ushort, IOperation> operations = new Dictionary<ushort, IOperation>();

                    int entryType;
                    while ((entryType = stream.ReadByte()) >= 0)
                    {
                        switch ((EntryType)entryType)
                        {
                            case EntryType.ComponentType:
                                operations.Add(
                                    reader.Read<ushort>(),
                                    _operations.GetOrAdd(
                                        Type.GetType(reader.ReadString(), true),
                                        t => (IOperation)Activator.CreateInstance(typeof(Operation<>).MakeGenericType(t))));
                                break;

                            case EntryType.MaxComponentCount:
                                operations[reader.Read<ushort>()].SetMaximumComponentCount(world, reader.Read<int>());
                                break;

                            case EntryType.Entity:
                                entities.Add(currentEntity = world.CreateEntity());
                                break;

                            case EntryType.Component:
                                operations[reader.Read<ushort>()].SetComponent(currentEntity, reader);
                                break;

                            case EntryType.ComponentSameAs:
                                operations[reader.Read<ushort>()].SetSameAsComponent(currentEntity, entities[reader.Read<int>()]);
                                break;

                            case EntryType.ParentChild:
                                entities[reader.Read<int>()].SetAsParentOf(entities[reader.Read<int>()]);
                                break;

                            case EntryType.DisabledEntity:
                                entities.Add(currentEntity = world.CreateDisabledEntity());
                                break;

                            case EntryType.DisabledComponent:
                                operations[reader.Read<ushort>()].SetDisabledComponent(currentEntity, reader);
                                break;

                            case EntryType.DisabledComponentSameAs:
                                operations[reader.Read<ushort>()].SetDisabledSameAsComponent(currentEntity, entities[reader.Read<int>()]);
                                break;
                        }
                    }

                    return entities;
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
        public static void Write<T>(Stream stream, in T obj)
        {
            stream = stream ?? throw new ArgumentNullException(nameof(stream));

            using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

            Converter<T>.Write(obj, writer);
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
            stream = stream ?? throw new ArgumentNullException(nameof(stream));

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
            stream = stream ?? throw new ArgumentNullException(nameof(stream));
            world = world ?? throw new ArgumentNullException(nameof(world));

            using (stream)
            {
                using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

                writer.Write(world.MaxEntityCount);

                Dictionary<Type, ushort> types = new Dictionary<Type, ushort>();

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

            using (stream)
            {
                using StreamWriterWrapper writer = new StreamWriterWrapper(stream);

                new EntityWriter(writer, new Dictionary<Type, ushort>()).Write(entities);
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
