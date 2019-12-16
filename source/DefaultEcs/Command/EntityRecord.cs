﻿using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical.Command;

namespace DefaultEcs.Command
{
    /// <summary>
    /// Represents an <see cref="Entity"/> on which to create commands to record in a <see cref="EntityCommandRecorder"/>.
    /// </summary>
    public readonly ref struct EntityRecord
    {
        #region Fields

        private readonly EntityCommandRecorder _recorder;
        private readonly int _offset;
        private readonly Entity _entity;

        #endregion

        #region Properties

        /// <summary>
        /// Gets whether the corresponding <see cref="Entity"/> is alive or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is alive; otherwise, false.</returns>
        public bool IsAlive
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _entity.IsAlive;
        }

        #endregion

        #region Initialisation

        internal EntityRecord(EntityCommandRecorder recorder, int offset, in Entity entity)
        {
            _recorder = recorder;
            _offset = offset;
            _entity = entity;
        }

        internal EntityRecord(EntityCommandRecorder recorder, int offset)
            : this(recorder, offset, default)
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Enables the corresponding <see cref="Entity"/> so it can appear in <see cref="EntitySet"/>.
        /// This command takes 5 bytes.
        /// </summary>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Enable() => _recorder.WriteCommand(new EntityOffsetCommand(CommandType.Enable, _offset));

        /// <summary>
        /// Disables the corresponding <see cref="Entity"/> so it does not appear in <see cref="EntitySet"/>.
        /// This command takes 5 bytes.
        /// </summary>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Disable() => _recorder.WriteCommand(new EntityOffsetCommand(CommandType.Disable, _offset));

        /// <summary>
        /// Enables the corresponding <see cref="Entity"/> component of type <typeparamref name="T"/> so it can appear in <see cref="EntitySet"/>.
        /// Does nothing if corresponding <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// This command takes 9 bytes.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Enable<T>() => _recorder.WriteCommand(new EntityOffsetComponentCommand(CommandType.EnableT, ComponentCommands.ComponentCommand<T>.Index, _offset));

        /// <summary>
        /// Disables the corresponding <see cref="Entity"/> component of type <typeparamref name="T"/> so it does not appear in <see cref="EntitySet"/>.
        /// This command takes 9 bytes.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Disable<T>() => _recorder.WriteCommand(new EntityOffsetComponentCommand(CommandType.DisableT, ComponentCommands.ComponentCommand<T>.Index, _offset));

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the corresponding <see cref="Entity"/>.
        /// For a blittable component, this command takes 9 bytes + the size of the component.
        /// For non blittable component, this command takes 13 bytes and may cause some allocation because of boxing on struct component type.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Set<T>(in T component = default) => _recorder.WriteSetCommand(_offset, component);

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the corresponding <see cref="Entity"/> to the same instance of an other <see cref="EntityRecord"/>.
        /// This command takes 13 bytes.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="reference">The other <see cref="EntityRecord"/> used as reference.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void SetSameAs<T>(in EntityRecord reference) => _recorder.WriteCommand(new EntityReferenceOffsetComponentCommand(CommandType.SetSameAs, ComponentCommands.ComponentCommand<T>.Index, _offset, reference._offset));

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the corresponding <see cref="Entity"/>.
        /// This command takes 9 bytes.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Remove<T>() => _recorder.WriteCommand(new EntityOffsetComponentCommand(CommandType.Remove, ComponentCommands.ComponentCommand<T>.Index, _offset));

        /// <summary>
        /// Makes it so when given <see cref="EntityRecord"/> corresponding <see cref="Entity"/> is disposed, corresponding <see cref="Entity"/> will also be disposed.
        /// This command takes 9 bytes.
        /// </summary>
        /// <param name="parent">The <see cref="EntityRecord"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void SetAsChildOf(in EntityRecord parent) => _recorder.WriteCommand(new ChildParentOffsetCommand(CommandType.SetAsChildOf, _offset, parent._offset));

        /// <summary>
        /// Makes it so when corresponding <see cref="Entity"/> is disposed, given <see cref="EntityRecord"/> corresponding <see cref="Entity"/> will also be disposed.
        /// This command takes 9 bytes.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void SetAsParentOf(in EntityRecord child) => child.SetAsChildOf(this);

        /// <summary>
        /// Remove the given <see cref="EntityRecord"/> corresponding <see cref="Entity"/> from corresponding <see cref="Entity"/> parents.
        /// This command takes 9 bytes.
        /// </summary>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void RemoveFromChildrenOf(in EntityRecord parent) => _recorder.WriteCommand(new ChildParentOffsetCommand(CommandType.RemoveFromChildrenOf, _offset, parent._offset));

        /// <summary>
        /// Remove the given <see cref="EntityRecord"/> corresponding <see cref="Entity"/> from corresponding <see cref="Entity"/> children.
        /// This command takes 9 bytes.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void RemoveFromParentsOf(in EntityRecord child) => child.RemoveFromChildrenOf(this);

        /// <summary>
        /// Clean the corresponding <see cref="Entity"/> of all its components.
        /// The current <see cref="EntityRecord"/> should not be used again after calling this method.
        /// This command takes 5 bytes.
        /// </summary>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public void Dispose() => _recorder.WriteCommand(new EntityOffsetCommand(CommandType.Dispose, _offset));

        /// <summary>
        /// Gets whether the corresponding <see cref="Entity"/> is enabled or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled() => _entity.IsEnabled();

        /// <summary>
        /// Gets whether the corresponding <see cref="Entity"/> component of type <typeparamref name="T"/> is enabled or not.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/> enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled<T>() => _entity.IsEnabled<T>();

        /// <summary>
        /// Returns whether the corresponding <see cref="Entity"/> has a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/>; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has<T>() => _entity.Has<T>();

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the corresponding <see cref="Entity"/>.
        /// Does not create a command if the value is modified.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the component.</returns>
        /// <exception cref="Exception">Corresponding <see cref="Entity"/> was not created from a <see cref="World"/> or does not have a component of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get<T>() => ref _entity.Get<T>();

        #endregion
    }
}
