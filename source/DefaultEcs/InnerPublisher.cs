using System;
using System.Runtime.CompilerServices;

namespace DefaultEcs
{
    public sealed partial class World
    {
        private static class InnerPublisher<T>
        {
            #region Fields

            private static readonly object _locker;

            public static Action<T>[] Actions;

            #endregion

            #region Initialisation

            static InnerPublisher()
            {
                _locker = new object();

                Actions = new Action<T>[_worldIdDispenser.LastInt + 1];

                _newWorld += Add;
                _cleanPublisher += Clear;
            }

            #endregion

            #region Methods

            private static void Add(int id)
            {
                lock (_locker)
                {
                    if (Actions.Length < id + 1)
                    {
                        Action<T>[] newActions = new Action<T>[(id + 1) * 2];
                        Array.Copy(Actions, newActions, Actions.Length);
                        Actions = newActions;
                    }
                }
            }

            private static void Clear(int id)
            {
                lock (_locker)
                {
                    Actions[id] = null;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void Subscribe(int id, Action<T> action)
            {
                lock (_locker)
                {
                    Actions[id] += action;
                }
            }

            #endregion
        }
    }
}
