using System;
using System.Collections.Generic;
using System.Threading;
using DefaultEcs.Technical.Command;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Command
{
    /// <summary>
    /// Represents a buffer of structural modifications to apply on <see cref="Entity"/> to record as postoned commands. 
    /// </summary>
    public sealed unsafe class EntityCommandRecorder
    {
        #region Fields

        private readonly int _maxCapacity;
        private readonly List<object> _objects;

        private ReaderWriterLockSlim _lockObject;
        private byte[] _memory;
        private int _nextCommandOffset;

        #endregion

        #region Initialisation

        public EntityCommandRecorder(int maxCapacity, int startCapacity)
        {
            if (maxCapacity < 0)
            {
                throw new ArgumentException("Argument cannot be negative.", nameof(maxCapacity));
            }
            if (startCapacity < 0)
            {
                throw new ArgumentException("Argument cannot be negative.", nameof(startCapacity));
            }
            if (maxCapacity < startCapacity)
            {
                throw new ArgumentException($"{nameof(maxCapacity)} is inferior to {nameof(startCapacity)}.");
            }

            _maxCapacity = maxCapacity;
            _objects = new List<object>();
            _lockObject = maxCapacity == startCapacity ? null : new ReaderWriterLockSlim();
            _memory = new byte[startCapacity];
            _nextCommandOffset = 0;
        }

        public EntityCommandRecorder(int maxCapacity)
            : this(maxCapacity, maxCapacity)
        { }

        public EntityCommandRecorder()
            : this(int.MaxValue, 1024)
        { }

        #endregion

        #region Methods

        private void WriteCommand<T>(int offset, in T command)
            where T : unmanaged
        {
            _lockObject?.EnterReadLock();
            try
            {
                fixed (byte* memory = _memory)
                {
                    *(T*)(memory + offset) = command;
                }
            }
            finally
            {
                _lockObject?.ExitReadLock();
            }
        }

        private int ReserveNextCommand(int commandSize)
        {
            void Throw() => throw new Exception("CommandBuffer is full.");

            int commandOffset;
            int nextCommandOffset;

            do
            {
                commandOffset = _nextCommandOffset;
                nextCommandOffset = commandOffset + commandSize;
                if (nextCommandOffset > _memory.Length)
                {
                    if (nextCommandOffset > _maxCapacity)
                    {
                        Throw();
                    }

                    _lockObject?.EnterWriteLock();
                    try
                    {
                        ArrayExtension.EnsureLength(ref _memory, nextCommandOffset, _maxCapacity);
                    }
                    finally
                    {
                        _lockObject?.ExitWriteLock();
                    }
                }
            }
            while (Interlocked.CompareExchange(ref _nextCommandOffset, nextCommandOffset, commandOffset) != commandOffset);

            return commandOffset;
        }

        private void WriteCommand<T>(in T command) where T : unmanaged => WriteCommand(ReserveNextCommand(sizeof(T)), command);

        internal void Enable(int entityOffset) => WriteCommand(new EntityOffsetCommand(CommandType.Enable, entityOffset));

        internal void Disable(int entityOffset) => WriteCommand(new EntityOffsetCommand(CommandType.Disable, entityOffset));

        internal void Enable<T>(int entityOffset) => WriteCommand(new EntityOffsetComponentCommand(CommandType.EnableT, ComponentCommands.ComponentCommand<T>.Index, entityOffset));

        internal void Disable<T>(int entityOffset) => WriteCommand(new EntityOffsetComponentCommand(CommandType.DisableT, ComponentCommands.ComponentCommand<T>.Index, entityOffset));

        internal void Set<T>(int entityOffset, in T component)
        {
            int offset = ReserveNextCommand(sizeof(EntityOffsetComponentCommand) + ComponentCommands.ComponentCommand<T>.SizeOfT);

            _lockObject?.EnterReadLock();
            try
            {
                fixed (byte* memory = _memory)
                {
                    *(EntityOffsetComponentCommand*)(memory + offset) = new EntityOffsetComponentCommand(CommandType.Set, ComponentCommands.ComponentCommand<T>.Index, entityOffset);
                    ComponentCommands.ComponentCommand<T>.WriteComponent(_objects, memory + offset + sizeof(EntityOffsetComponentCommand), component);
                }
            }
            finally
            {
                _lockObject?.ExitReadLock();
            }
        }

        internal void SetSameAs<T>(int entityOffset, int referenceOffset) => WriteCommand(new EntityReferenceOffsetComponentCommand(CommandType.SetSameAs, ComponentCommands.ComponentCommand<T>.Index, entityOffset, referenceOffset));

        internal void Remove<T>(int entityOffset) => WriteCommand(new EntityOffsetComponentCommand(CommandType.Remove, ComponentCommands.ComponentCommand<T>.Index, entityOffset));

        internal void SetAsChildOf(int childOffset, int parentOffset) => WriteCommand(new ChildParentOffsetCommand(CommandType.SetAsChildOf, childOffset, parentOffset));

        internal void RemoveFromChildrenOf(int childOffset, int parentOffset) => WriteCommand(new ChildParentOffsetCommand(CommandType.RemoveFromChildrenOf, childOffset, parentOffset));

        internal void Dispose(int entityOffset) => WriteCommand(new EntityOffsetCommand(CommandType.Dispose, entityOffset));

        /// <summary>
        /// Gives an <see cref="EntityRecord"/> to record action on the given <see cref="Entity"/>.
        /// This command takes 9 bytes.
        /// </summary>
        /// <param name="entity">The <see cref="EntityRecord"/> used to record action on the given <see cref="Entity"/>.</param>
        /// <returns></returns>
        public EntityRecord Record(in Entity entity)
        {
            int offset = ReserveNextCommand(sizeof(EntityCommand));

            WriteCommand(offset, new EntityCommand(CommandType.Entity, entity));

            return new EntityRecord(this, offset + sizeof(CommandType));
        }

        /// <summary>
        /// Records the creation of an <see cref="Entity"/> and returns an <see cref="EntityRecord"/> to record action on it.
        /// This command takes 9 bytes.
        /// </summary>
        /// <returns>The <see cref="EntityRecord"/> used to record actions on the later created <see cref="Entity"/>.</returns>
        public EntityRecord CreateEntity()
        {
            int offset = ReserveNextCommand(sizeof(EntityCommand));

            WriteCommand(offset, new EntityCommand(CommandType.CreateEntity, default));

            return new EntityRecord(this, offset + sizeof(CommandType));
        }

        /// <summary>
        /// Executes all recorded commands and clears those commands.
        /// </summary>
        /// <param name="world">The <see cref="World"/> on which the commands to create new <see cref="Entity"/> will be executed.</param>
        public void Execute(World world)
        {
            fixed (byte* memory = _memory)
            {
                byte* commands = memory;
                while (_nextCommandOffset > 0)
                {
                    int commandSize = 0;

                    switch (*(CommandType*)commands)
                    {
                        case CommandType.Entity:
                            commandSize = sizeof(EntityCommand);
                            break;

                        case CommandType.CreateEntity:
                            (*(EntityCommand*)commands).Entity = world.CreateEntity();
                            commandSize = sizeof(EntityCommand);
                            break;

                        case CommandType.Enable:
                            (*(Entity*)(memory + (*(EntityOffsetCommand*)commands).EntityOffset)).Enable();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;

                        case CommandType.Disable:
                            (*(Entity*)(memory + (*(EntityOffsetCommand*)commands).EntityOffset)).Disable();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;

                        case CommandType.EnableT:
                            EntityOffsetComponentCommand* componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Enable(*(Entity*)(memory + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.DisableT:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Disable(*(Entity*)(memory + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.Set:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            commandSize += ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Set(*(Entity*)(memory + (*componentCommand).EntityOffset), _objects, commands + sizeof(EntityOffsetComponentCommand));
                            break;

                        case CommandType.SetSameAs:
                            EntityReferenceOffsetComponentCommand* entityReferenceComponentCommand = (EntityReferenceOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*entityReferenceComponentCommand).ComponentIndex).SetSameAs(
                                *(Entity*)(memory + (*entityReferenceComponentCommand).EntityOffset),
                                *(Entity*)(memory + (*entityReferenceComponentCommand).ReferenceOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.Remove:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Remove(*(Entity*)(memory + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.SetAsChildOf:
                            ChildParentOffsetCommand* childParent = (ChildParentOffsetCommand*)commands;
                            (*(Entity*)(memory + (*childParent).ChildOffset)).SetAsChildOf(*(Entity*)(memory + (*childParent).ParentOffset));
                            commandSize = sizeof(ChildParentOffsetCommand);
                            break;

                        case CommandType.RemoveFromChildrenOf:
                            childParent = (ChildParentOffsetCommand*)commands;
                            (*(Entity*)(memory + (*childParent).ChildOffset)).RemoveFromChildrenOf(*(Entity*)(memory + (*childParent).ParentOffset));
                            commandSize = sizeof(ChildParentOffsetCommand);
                            break;

                        case CommandType.Dispose:
                            (*(Entity*)(memory + (*(EntityOffsetCommand*)commands).EntityOffset)).Dispose();
                            commandSize = sizeof(ChildParentOffsetCommand);
                            break;
                    }

                    commands += commandSize;
                    _nextCommandOffset -= commandSize;
                }
            }

            _objects.Clear();

            if (_lockObject != null && _maxCapacity == _memory.Length)
            {
                _lockObject.Dispose();
                _lockObject = null;
            }
        }

        #endregion
    }
}
