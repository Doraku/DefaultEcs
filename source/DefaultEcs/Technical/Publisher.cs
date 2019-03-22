﻿using System;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical.Helper;
using DefaultEcs.Technical.Message;

namespace DefaultEcs.Technical
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
            private readonly ActionIn<T> _action;

            #endregion

            #region Initialisation

            public Subscription(int worldId, ActionIn<T> action)
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

        public static ActionIn<T>[] Actions;

        #endregion

        #region Initialisation

        static Publisher()
        {
            _lockObject = new object();

            Actions = new ActionIn<T>[2];

            if (typeof(T) != typeof(WorldDisposedMessage))
            {
                Publisher<WorldDisposedMessage>.Subscribe(0, On);
            }
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
        public static IDisposable Subscribe(int worldId, ActionIn<T> action)
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
