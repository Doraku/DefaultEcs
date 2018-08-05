using System.IO;

namespace DefaultEcs.Serialization
{
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
    }
}
