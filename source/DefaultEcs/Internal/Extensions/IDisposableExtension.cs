using System.Collections.Generic;
using System.Linq;

namespace System
{
    internal static class IDisposableExtension
    {
        #region Types

        private sealed class DisposableGroup : IDisposable
        {
            #region Fields

            private readonly IDisposable[] _disposables;

            #endregion

            #region Initialisation

            public DisposableGroup(IEnumerable<IDisposable> disposables)
            {
                _disposables = GetDisposables(disposables).ToArray();
            }

            #endregion

            #region Methods

            private static IEnumerable<IDisposable> GetDisposables(IEnumerable<IDisposable> disposables)
            {
                foreach (IDisposable disposable in disposables)
                {
                    if (disposable is DisposableGroup group)
                    {
                        foreach (IDisposable child in group._disposables)
                        {
                            yield return child;
                        }
                    }
                    else
                    {
                        yield return disposable;
                    }
                }
            }

            #endregion

            #region IDisposable

            void IDisposable.Dispose()
            {
                for (int i = _disposables.Length - 1; i >= 0; --i)
                {
                    _disposables[i].Dispose();
                }

                GC.SuppressFinalize(this);
            }

            #endregion
        }

        #endregion

        #region Methods

        public static IDisposable Merge(this IEnumerable<IDisposable> disposables) => new DisposableGroup(disposables);

        #endregion
    }
}
