using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
{
    internal static class Publisher<T>
    {
        #region Types

        private readonly struct Subscription : IDisposable
        {
            #region Fields

            private readonly int _worldId;
            private readonly SubscribeAction<T> _action;

            #endregion

            #region Initialisation

            public Subscription(int worldId, SubscribeAction<T> action)
            {
                _worldId = worldId;
                _action = action;
            }

            #endregion

            #region IDisposable

            public void Dispose()
            {
                lock (typeof(Publisher<T>))
                {
                    Actions[_worldId] -= _action;
                }
            }

            #endregion
        }

        #endregion

        #region Fields

        public static SubscribeAction<T>[] Actions;

        #endregion

        #region Initialisation

        static Publisher()
        {
            Actions = new SubscribeAction<T>[1];

            if (typeof(T) != typeof(WorldDisposedMessage))
            {
                Publisher<WorldDisposedMessage>.Subscribe(0, On);
            }
        }

        #endregion

        #region Callbacks

        private static void On(in WorldDisposedMessage message)
        {
            lock (typeof(Publisher<T>))
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
        public static IDisposable Subscribe(int worldId, SubscribeAction<T> action)
        {
            lock (typeof(Publisher<T>))
            {
                if (worldId >= Actions.Length)
                {
                    Array.Resize(ref Actions, worldId * 2);
                }

                Actions[worldId] += action;
            }

            return new Subscription(worldId, action);
        }

        #endregion
    }
}
