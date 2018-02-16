using System;
using System.Runtime.CompilerServices;

namespace DefaultEcs
{
    public sealed partial class World
    {
        private static class InnerPublisher<T>
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
                    lock (_locker)
                    {
                        Actions[_worldId] -= _action;
                    }
                }

                #endregion
            }

            #endregion

            #region Fields

            private static readonly object _locker;

            public static SubscribeAction<T>[] Actions;

            #endregion

            #region Initialisation

            static InnerPublisher()
            {
                _locker = new object();

                Actions = new SubscribeAction<T>[_worldIdDispenser.LastInt + 1];

                _newWorld += Add;
                _cleanPublisher += Clear;
            }

            #endregion

            #region Methods

            private static void Add(int worldId)
            {
                lock (_locker)
                {
                    if (Actions.Length < worldId + 1)
                    {
                        SubscribeAction<T>[] newActions = new SubscribeAction<T>[(worldId + 1) * 2];
                        Array.Copy(Actions, newActions, Actions.Length);
                        Actions = newActions;
                    }
                }
            }

            private static void Clear(int worldId)
            {
                lock (_locker)
                {
                    Actions[worldId] = null;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IDisposable Subscribe(int worldId, SubscribeAction<T> action)
            {
                lock (_locker)
                {
                    Actions[worldId] += action;
                }

                return new Subscription(worldId, action);
            }

            #endregion
        }
    }
}
