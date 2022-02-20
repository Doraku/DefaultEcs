using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Internal.Messages;

namespace DefaultEcs.Internal
{
    internal static class Publisher
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Publish<T>(int worldId, in T message) => Publisher<T>.Publish(worldId, message);
    }

    internal static class Publisher<T>
    {
        #region Types

        private readonly struct Subscription : IDisposable
        {
            #region Fields

            private readonly int _worldId;
            private readonly MessageHandler<T> _action;

            #endregion

            #region Initialisation

            public Subscription(int worldId, MessageHandler<T> action)
            {
                _worldId = worldId;
                _action = action;
            }

            #endregion

            #region IDisposable

            public void Dispose()
            {
                lock (_lockObject)
                {
                    Actions[_worldId] -= _action;
                }
            }

            #endregion
        }

        #endregion

        #region Fields

        private static readonly object _lockObject;

        public static MessageHandler<T>[] Actions;

        #endregion

        #region Initialisation

        static Publisher()
        {
            _lockObject = new object();

            Actions = new MessageHandler<T>[2];

            Publisher<WorldDisposedMessage>.Subscribe(0, On);
        }

        #endregion

        #region Callbacks

        private static void On(in WorldDisposedMessage message)
        {
            lock (_lockObject)
            {
                if (message.WorldId < Actions.Length)
                {
                    Actions[message.WorldId] = null;
                }
            }
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IDisposable Subscribe(int worldId, MessageHandler<T> action)
        {
            lock (_lockObject)
            {
                ArrayExtension.EnsureLength(ref Actions, worldId);

                Actions[worldId] += action;
            }

            return new Subscription(worldId, action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Publish(int worldId, in T message)
        {
            if (worldId < Actions.Length)
            {
                Actions[worldId]?.Invoke(message);
            }
        }

        #endregion
    }
}
