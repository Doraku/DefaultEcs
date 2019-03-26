using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace DefaultEcs.Command
{
    public sealed unsafe class EntityCommandRecorder
    {
        private enum CommandType : byte
        {
            Entity = 0,
            CreateEntity = 1,
            Enable = 2,
            Disable = 3,
            EnableT = 4,
            DisableT = 5,
            Set = 6,
            SetSameAs = 7,
            Remove = 8,
            SetAsChildOf = 9,
            RemoveFromChildrenOf = 10,
            Dispose = 11
        }

        private interface IComponentCommand
        {
            void Enable(in Entity entity);
            void Disable(in Entity entity);
            void Set(byte* memory, int* data);
            void SetSameAs(byte* memory, int* data);
            void Remove(in Entity entity);
        }

        private class ComponentCommand<T> : IComponentCommand
            where T : unmanaged
        {
            public static readonly int Index;

            static ComponentCommand()
            {
                lock (_componentCommands)
                {
                    Index = _componentCommands.Count;
                    _componentCommands.Add(new ComponentCommand<T>());
                }
            }

            public void Enable(in Entity entity) => entity.Enable<T>();

            public void Disable(in Entity entity) => entity.Disable<T>();

            public void Set(byte* memory, int* data) => (*(Entity*)(memory + *data++)).Set(*(T*)data);

            public void SetSameAs(byte* memory, int* data) => (*(Entity*)(memory + *data++)).SetSameAs<T>(*(Entity*)(memory + *data));

            public void Remove(in Entity entity) => entity.Remove<T>();
        }

        private const int _baseCommandSize = sizeof(int) + sizeof(byte);
        private static readonly int _baseComponentCommandSize = _baseCommandSize + sizeof(int);

        private static readonly List<IComponentCommand> _componentCommands = new List<IComponentCommand>();

        private static readonly ConcurrentDictionary<CommandType, int> _commandSizes = new ConcurrentDictionary<CommandType, int>
        {
            [CommandType.Entity] = _baseCommandSize + sizeof(Entity),
            [CommandType.CreateEntity] = _baseCommandSize + sizeof(Entity),
            [CommandType.Enable] = _baseCommandSize + sizeof(int),
            [CommandType.Disable] = _baseCommandSize + sizeof(int),
            [CommandType.EnableT] = _baseComponentCommandSize + sizeof(int),
            [CommandType.DisableT] = _baseComponentCommandSize + sizeof(int),
            [CommandType.Set] = _baseComponentCommandSize + sizeof(int),
            [CommandType.SetSameAs] = _baseComponentCommandSize + sizeof(int) + sizeof(int),
            [CommandType.Remove] = _baseComponentCommandSize + sizeof(int),
            [CommandType.SetAsChildOf] = _baseCommandSize + sizeof(int) + sizeof(int),
            [CommandType.RemoveFromChildrenOf] = _baseCommandSize + sizeof(int) + sizeof(int),
            [CommandType.Dispose] = _baseCommandSize + sizeof(int),
        };

        private readonly byte[] _memory;

        private int _nextCommandOffset;

        public EntityCommandRecorder(int size)
        {
            _memory = new byte[size];
            _nextCommandOffset = 0;
        }

        private byte* ReserveNextCommand(byte* memory, CommandType commandType, out int commandOffset, int extraSize = 0)
        {
            void Throw() => throw new Exception("CommandBuffer is full.");

            int commandSize = _commandSizes[commandType] + extraSize;

            do
            {
                commandOffset = _nextCommandOffset;
                if (commandOffset > _memory.Length)
                {
                    Throw();
                }
            }
            while (Interlocked.CompareExchange(ref _nextCommandOffset, commandOffset + commandSize, commandOffset) != commandOffset);

            int* nextCommandP = (int*)(memory + commandOffset);
            *nextCommandP++ = commandSize;
            byte* commandTypeP = (byte*)nextCommandP;
            *commandTypeP++ = (byte)commandType;

            return commandTypeP;
        }

        private byte* ReserveNextCommand(byte* memory, CommandType commandType, int extraSize = 0) => ReserveNextCommand(memory, commandType, out _, extraSize);

        private byte* ReserveNextCommand<T>(byte* memory, CommandType commandType, int extraSize = 0)
            where T : unmanaged
        {
            int* componentCommandIndexP = (int*)ReserveNextCommand(memory, commandType, out _, extraSize);
            *componentCommandIndexP++ = ComponentCommand<T>.Index;

            return (byte*)componentCommandIndexP;
        }

        internal void Enable(int entityOffset)
        {
            fixed (byte* memory = _memory)
            {
                *(int*)ReserveNextCommand(memory, CommandType.Enable) = entityOffset;
            }
        }

        internal void Disable(int entityOffset)
        {
            fixed (byte* memory = _memory)
            {
                *(int*)ReserveNextCommand(memory, CommandType.Disable) = entityOffset;
            }
        }

        internal void Enable<T>(int entityOffset)
            where T : unmanaged
        {
            fixed (byte* memory = _memory)
            {
                *(int*)ReserveNextCommand<T>(memory, CommandType.EnableT) = entityOffset;
            }
        }

        internal void Disable<T>(int entityOffset)
            where T : unmanaged
        {
            fixed (byte* memory = _memory)
            {
                *(int*)ReserveNextCommand<T>(memory, CommandType.DisableT) = entityOffset;
            }
        }

        internal void Set<T>(int entityOffset, in T component)
            where T : unmanaged
        {
            fixed (byte* memory = _memory)
            {
                int* entityP = (int*)ReserveNextCommand<T>(memory, CommandType.Set, sizeof(T));
                *entityP++ = entityOffset;
                *(T*)entityP = component;
            }
        }

        internal void SetSameAs<T>(int entityOffset, int referenceOffset)
            where T : unmanaged
        {
            fixed (byte* memory = _memory)
            {
                int* entityP = (int*)ReserveNextCommand<T>(memory, CommandType.SetSameAs);
                *entityP++ = entityOffset;
                *entityP = referenceOffset;
            }
        }

        internal void Remove<T>(int entityOffset)
            where T : unmanaged
        {
            fixed (byte* memory = _memory)
            {
                *(int*)ReserveNextCommand<T>(memory, CommandType.Remove) = entityOffset;
            }
        }

        internal void SetAsChildOf(int chidOffset, int parentOffset)
        {
            fixed (byte* memory = _memory)
            {
                int* entityP = (int*)ReserveNextCommand(memory, CommandType.SetAsChildOf);
                *entityP++ = chidOffset;
                *entityP = parentOffset;
            }
        }

        internal void RemoveFromChildrenOf(int chidOffset, int parentOffset)
        {
            fixed (byte* memory = _memory)
            {
                int* entityP = (int*)ReserveNextCommand(memory, CommandType.RemoveFromChildrenOf);
                *entityP++ = chidOffset;
                *entityP = parentOffset;
            }
        }

        internal void Dispose(int entityOffset)
        {
            fixed (byte* memory = _memory)
            {
                *(int*)ReserveNextCommand(memory, CommandType.Dispose) = entityOffset;
            }
        }

        public EntityRecord Record(in Entity entity)
        {
            fixed (byte* memory = _memory)
            {
                *(Entity*)ReserveNextCommand(memory, CommandType.Entity, out int offset) = entity;

                return new EntityRecord(this, offset + _baseCommandSize);
            }
        }

        public EntityRecord CreateEntity()
        {
            fixed (byte* memory = _memory)
            {
                ReserveNextCommand(memory, CommandType.CreateEntity, out int offset);

                return new EntityRecord(this, offset + _baseCommandSize);
            }
        }

        public void Execute(World world)
        {
            fixed (byte* memory = _memory)
            {
                byte* commands = memory;
                while (_nextCommandOffset > 0)
                {
                    int commandSize = *(int*)commands;
                    switch (*(CommandType*)(commands + sizeof(int)))
                    {
                        case CommandType.CreateEntity:
                            *(Entity*)(commands + _baseCommandSize) = world.CreateEntity();
                            break;

                        case CommandType.Enable:
                            (*(Entity*)(memory + *(int*)(commands + _baseCommandSize))).Enable();
                            break;

                        case CommandType.Disable:
                            (*(Entity*)(memory + *(int*)(commands + _baseCommandSize))).Disable();
                            break;

                        case CommandType.EnableT:
                            _componentCommands[*(int*)(commands + _baseCommandSize)].Enable(*(Entity*)(memory + *(int*)(commands + _baseComponentCommandSize)));
                            break;

                        case CommandType.DisableT:
                            _componentCommands[*(int*)(commands + _baseCommandSize)].Disable(*(Entity*)(memory + *(int*)(commands + _baseComponentCommandSize)));
                            break;

                        case CommandType.Set:
                            _componentCommands[*(int*)(commands + _baseCommandSize)].Set(memory, (int*)(commands + _baseComponentCommandSize));
                            break;

                        case CommandType.SetSameAs:
                            _componentCommands[*(int*)(commands + _baseCommandSize)].SetSameAs(memory, (int*)(commands + _baseComponentCommandSize));
                            break;

                        case CommandType.Remove:
                            _componentCommands[*(int*)(commands + _baseCommandSize)].Remove(*(Entity*)(memory + *(int*)(commands + _baseComponentCommandSize)));
                            break;

                        case CommandType.SetAsChildOf:
                            (*(Entity*)(memory + *(int*)(commands + _baseCommandSize))).SetAsChildOf(*(Entity*)(memory + *(int*)(commands + _baseCommandSize + sizeof(int))));
                            break;

                        case CommandType.RemoveFromChildrenOf:
                            (*(Entity*)(memory + *(int*)(commands + _baseCommandSize))).RemoveFromChildrenOf(*(Entity*)(memory + *(int*)(commands + _baseCommandSize + sizeof(int))));
                            break;

                        case CommandType.Dispose:
                            (*(Entity*)(memory + *(int*)(commands + _baseComponentCommandSize))).Dispose();
                            break;
                    }

                    commands += commandSize;
                    _nextCommandOffset -= commandSize;
                }
            }
        }
    }
}
