using System;
using System.Collections.Generic;
using System.Threading;
using DefaultEcs.Internal.Command;

namespace DefaultEcs.Command
{
    /// <summary>
    /// Represents a buffer of structural modifications to apply on <see cref="Entity"/> to record as postoned commands.
    /// </summary>
    public sealed unsafe class EntityCommandRecorder : IDisposable
    {
        #region Fields

        private readonly List<object> _objects;

        private ReaderWriterLockSlim _lockObject;
        private byte[] _memory;
        private int _nextCommandOffset;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the maximum capacity the current instance can grow to.
        /// </summary>
        public int MaxCapacity { get; }

        /// <summary>
        /// Gets current capacity of the current instance.
        /// </summary>
        public int Capacity => _memory.Length;

        /// <summary>
        /// Gets the size taken by recorded commands in current instance.
        /// </summary>
        public int Size => _nextCommandOffset;

        #endregion

        #region Initialisation

        /// <summary>
        /// Creates an <see cref="EntityCommandRecorder"/> with a custom default size which can grow to a maximum capacity.
        /// </summary>
        /// <param name="capacity">The default size of the <see cref="EntityCommandRecorder"/>.</param>
        /// <param name="maxCapacity">The maximum capacity of the <see cref="EntityCommandRecorder"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="capacity"/> cannot be negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="maxCapacity"/> cannot be negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="maxCapacity"/> is inferior to <paramref name="capacity"/>.</exception>
        public EntityCommandRecorder(int capacity, int maxCapacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Argument cannot be negative.", nameof(capacity));
            }
            if (maxCapacity < capacity)
            {
                throw new ArgumentException($"{nameof(maxCapacity)} is inferior to {nameof(capacity)}.", nameof(maxCapacity));
            }

            MaxCapacity = maxCapacity;
            _objects = new List<object>();
            _lockObject = maxCapacity == capacity ? null : new ReaderWriterLockSlim();
            _memory = new byte[capacity];
            _nextCommandOffset = 0;
        }

        /// <summary>
        /// Creates a fixed sized <see cref="EntityCommandRecorder"/>.
        /// </summary>
        /// <param name="maxCapacity">The size of the <see cref="EntityCommandRecorder"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="maxCapacity"/> cannot be negative.</exception>
        public EntityCommandRecorder(int maxCapacity)
            : this(maxCapacity, maxCapacity)
        { }

        /// <summary>
        /// Creates a default sized <see cref="EntityCommandRecorder"/> of 1ko which can grow as needed.
        /// </summary>
        public EntityCommandRecorder()
            : this(1024, int.MaxValue)
        { }

        #endregion

        #region Methods

        private int ReserveNextCommand(int commandSize)
        {
            static void Throw() => throw new InvalidOperationException("CommandBuffer is full.");

            int commandOffset;
            int nextCommandOffset;

            do
            {
                commandOffset = _nextCommandOffset;
                nextCommandOffset = commandOffset + commandSize;
                if (nextCommandOffset > _memory.Length)
                {
                    if (nextCommandOffset > MaxCapacity)
                    {
                        Throw();
                    }

                    _lockObject?.EnterWriteLock();
                    try
                    {
                        ArrayExtension.EnsureLength(ref _memory, nextCommandOffset, MaxCapacity);
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

        internal int WriteCommand<T>(in T command) where T : unmanaged
        {
            int offset = ReserveNextCommand(sizeof(T));

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

            return offset;
        }

        internal int WriteComponentCommand<TCommand, TComponent>(in TCommand command, in TComponent component) where TCommand : unmanaged
        {
            int offset = ReserveNextCommand(sizeof(TCommand) + ComponentCommands.ComponentCommand<TComponent>.SizeOfT);

            _lockObject?.EnterReadLock();
            try
            {
                fixed (byte* memory = _memory)
                {
                    *(TCommand*)(memory + offset) = command;
                    ComponentCommands.ComponentCommand<TComponent>.WriteComponent(_objects, memory + offset + sizeof(TCommand), component);
                }
            }
            finally
            {
                _lockObject?.ExitReadLock();
            }

            return offset;
        }

        internal void WriteCloneCommand(int sourceOffset, int targetOffset, ComponentCloner cloner)
        {
            int clonerIndex;
            lock (_objects)
            {
                clonerIndex = _objects.Count;
                _objects.Add(cloner);
            }

            WriteCommand(new CloneCommand(sourceOffset, targetOffset, clonerIndex));
        }

        /// <summary>
        /// Gives an <see cref="WorldRecord"/> to record action on the given <see cref="World"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> to record action for.</param>
        /// <returns>The <see cref="WorldRecord"/> used to record actions on the given <see cref="World"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        public WorldRecord Record(World world) => new(this, world.ThrowIfNull());

        /// <summary>
        /// Gives an <see cref="EntityRecord"/> to record action on the given <see cref="Entity"/>.
        /// This command takes 9 bytes.
        /// </summary>
        /// <param name="entity">The <see cref="Entity"/> to record action for.</param>
        /// <returns>The <see cref="EntityRecord"/> used to record actions on the given <see cref="Entity"/>.</returns>
        /// <exception cref="InvalidOperationException">Command buffer is full.</exception>
        public EntityRecord Record(in Entity entity) => new(this, WriteCommand(new EntityCommand(CommandType.Entity, entity)) + sizeof(CommandType));

        /// <summary>
        /// Executes all recorded commands and clears those commands.
        /// </summary>
        public void Execute()
        {
            Executer.Execute(_memory, _nextCommandOffset, _objects);

            Clear();
        }

        /// <summary>
        /// Clears all recorded commands.
        /// </summary>
        public void Clear()
        {
            _nextCommandOffset = 0;
            _objects.Clear();

            if (_lockObject != null && MaxCapacity == _memory.Length)
            {
                _lockObject.Dispose();
                _lockObject = null;
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Releases inner unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _lockObject?.Dispose();
        }

        #endregion
    }
}
