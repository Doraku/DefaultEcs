using System;
using System.Runtime.CompilerServices;

namespace DefaultEcs
{
    public sealed partial class World
    {
        private static class Publisher<T>
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
                Actions = new SubscribeAction<T>[0];

                _cleanWorld += Clear;
            }

            #endregion

            #region Methods

            private static void Clear(int worldId)
            {
                lock (typeof(Publisher<T>))
                {
                    if (worldId < Actions.Length)
                    {
                        Actions[worldId] = null;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IDisposable Subscribe(int worldId, SubscribeAction<T> action)
            {
                lock (typeof(Publisher<T>))
                {
                    if (worldId >= Actions.Length)
                    {
                        SubscribeAction<T>[] newActions = new SubscribeAction<T>[(worldId + 1) * 2];
                        Array.Copy(Actions, newActions, Actions.Length);
                        Actions = newActions;
                    }

                    Actions[worldId] += action;
                }

                return new Subscription(worldId, action);
            }

            #endregion
        }
    }
}
