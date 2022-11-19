using System;
using System.Collections.Generic;
using System.IO;

namespace DefaultEcs.Serialization
{
    /// <summary>
    /// Provides extension methods to the <see cref="ISerializer"/> type.
    /// </summary>
    public static class ISerializerExtension
    {
        /// <summary>
        /// Serializes the given <see cref="Entity"/> instances with their components into the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="serializer">The <see cref="ISerializer"/> instance to use.</param>
        /// <param name="stream">The <see cref="Stream"/> in which the data will be saved.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to save.</param>
        public static void Serialize(this ISerializer serializer, Stream stream, params Entity[] entities) => serializer.ThrowIfNull().Serialize(stream, entities);
    }

    /// <summary>
    /// Provides a set of methods to save and load DefaultEcs objects.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes the given <see cref="World"/> into the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> in which the data will be saved.</param>
        /// <param name="world">The <see cref="World"/> instance to save.</param>
        void Serialize(Stream stream, World world);

        /// <summary>
        /// Deserializes a <see cref="World"/> instance from the given <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <returns>The <see cref="World"/> instance loaded.</returns>
        World Deserialize(Stream stream);

        /// <summary>
        /// Serializes the given <see cref="Entity"/> instances with their components into the provided <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> in which the data will be saved.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to save.</param>
        void Serialize(Stream stream, IEnumerable<Entity> entities);

        /// <summary>
        /// Deserializes <see cref="Entity"/> instances with their components from the given <see cref="Stream"/> into the given <see cref="World"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> from which the data will be loaded.</param>
        /// <param name="world">The <see cref="World"/> instance on which the <see cref="Entity"/> will be created.</param>
        /// <returns>The <see cref="Entity"/> instances loaded.</returns>
        ICollection<Entity> Deserialize(Stream stream, World world);
    }
}
