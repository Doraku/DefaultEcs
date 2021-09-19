using System;
using DefaultEcs.Internal.Command;

namespace DefaultEcs.Command
{
    /// <summary>
    /// Represents a <see cref="World"/> on which to create commands to record in a <see cref="EntityCommandRecorder"/>.
    /// </summary>
    public readonly ref struct WorldRecord
    {
        #region Fields

        private readonly EntityCommandRecorder _recorder;
        private readonly short _worldId;

        #endregion

        #region Initialisation

        internal WorldRecord(EntityCommandRecorder recorder, World world)
        {
            _recorder = recorder;
            _worldId = world.WorldId;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Records the creation of an <see cref="Entity"/> on a <see cref="World"/> and returns an <see cref="EntityRecord"/> to record action on it.
        /// This command takes 9 bytes.
        /// </summary>
        /// <returns>The <see cref="EntityRecord"/> used to record actions on the later created <see cref="Entity"/>.</returns>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public EntityRecord CreateEntity() => new(_recorder, _recorder.WriteCommand(new EntityCommand(CommandType.CreateEntity, new Entity(_worldId))) + sizeof(CommandType));

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the corresponding <see cref="World"/>.
        /// For a blittable component, this command takes 7 bytes + the size of the component.
        /// For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Set<T>(in T component) => _recorder.WriteComponentCommand(new WorldCommand(CommandType.WorldSet, ComponentCommands.ComponentCommand<T>.Index, _worldId), component);

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> to its default value on the corresponding <see cref="World"/>.
        /// For a blittable component, this command takes 7 bytes + the size of the component.
        /// For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Set<T>() => Set<T>(default);

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the corresponding <see cref="World"/>.
        /// This command takes 7 bytes.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Remove<T>() => _recorder.WriteCommand(new WorldCommand(CommandType.WorldRemove, ComponentCommands.ComponentCommand<T>.Index, _worldId));

        #endregion
    }
}
