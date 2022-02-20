using System;

namespace DefaultEcs.Internal.Serialization
{
    internal readonly struct MarshallerDisposedMessage
    {
        public readonly int ContextId;

        public MarshallerDisposedMessage(int contextId)
        {
            ContextId = contextId;
        }
    }

    internal struct SerializationActions
    {
        public Delegate WorldWrite;
        public Delegate EntityWrite;
        public Delegate ValueWrite;
        public object ComponentRead;
        public Delegate ValueRead;
    }

    internal static class SerializationContext
    {
        private static readonly IntDispenser _idDispenser;

        static SerializationContext()
        {
            _idDispenser = new IntDispenser(-1);
        }

        public static int GetId() => _idDispenser.GetFreeInt();

        public static void ReleaseId(int id)
        {
            Publisher.Publish(0, new MarshallerDisposedMessage(id));
            _idDispenser.ReleaseInt(id);
        }
    }

    internal static class SerializationContext<T>
    {
        private static readonly object _lockObject;

        public static SerializationActions[] Actions;

        static SerializationContext()
        {
            _lockObject = new object();

            Actions = EmptyArray<SerializationActions>.Value;

            Publisher<MarshallerDisposedMessage>.Subscribe(0, On);
        }

        private static void On(in MarshallerDisposedMessage message)
        {
            lock (_lockObject)
            {
                if (message.ContextId < Actions.Length)
                {
                    Actions[message.ContextId] = default;
                }
            }
        }

        public static void SetWriteActions(int contextId, Delegate world, Delegate entity, Delegate value)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Actions, contextId);

                Actions[contextId].WorldWrite = world;
                Actions[contextId].EntityWrite = entity;
                Actions[contextId].ValueWrite = value;
            }
        }

        public static void SetReadActions(int contextId, object component, Delegate value)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Actions, contextId);

                Actions[contextId].ComponentRead = component;
                Actions[contextId].ValueRead = value;
            }
        }
    }
}
