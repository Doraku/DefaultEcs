using System;
using System.Collections.Generic;
using DefaultEcs.Serialization;
using DefaultEcs.Technical.Command;

namespace DefaultEcs.Command
{
    internal delegate void EntityRecordAction(in EntityRecord record);

    public sealed class EntityFactory
    {
        #region Types

        private sealed class ComponentReader : IComponentReader
        {
            private readonly List<EntityRecordAction> _actions;

            public ComponentReader(in Entity entity)
            {
                _actions = new List<EntityRecordAction>();

                entity.ReadAllComponents(this);
            }

            public void OnRead<T>(ref T component, in Entity componentOwner)
            {
                T value = component;
                _actions.Add((in EntityRecord r) => r.Set(value));
            }

            public EntityFactory ToFactory() => Create(_actions.ToArray());
        }

        #endregion

        #region Fields

        private readonly byte[] _memory;
        private readonly List<object> _objects;

        #endregion

        #region Initialisation

        internal EntityFactory(Span<byte> memory, List<object> objects)
        {
            _memory = memory.ToArray();
            _objects = objects.Count > 0 ? new List<object>(objects) : null;
        }

        #endregion

        #region Methods

        internal static EntityFactory Create(params EntityRecordAction[] actions)
        {
            using EntityCommandRecorder recorder = new EntityCommandRecorder();

            EntityRecord record = recorder.CreateEntity();

            foreach (EntityRecordAction action in actions)
            {
                action(record);
            }

            return recorder.ToFactory();
        }

        public static EntityFactory CreateFromEntity(in Entity entity) => new ComponentReader(entity).ToFactory();

        public unsafe Entity Execute(World world)
        {
            fixed (byte* memory = _memory)
            {
                *(EntityCommand*)memory = new EntityCommand(CommandType.CreateEntity, default);
            }

            return Executer.Execute(_memory, _memory.Length, _objects, world);
        }

        public unsafe void Execute(in Entity entity)
        {
            fixed (byte* memory = _memory)
            {
                *(EntityCommand*)memory = new EntityCommand(CommandType.Enable, entity);
            }

            Executer.Execute(_memory, _memory.Length, _objects, null);
        }

        #endregion
    }
}
