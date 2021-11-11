using System;

namespace DefaultEcs.Internal.Component
{
    internal interface IComponentPool<T> : IDisposable
    {
        ComponentMode Mode { get; }

        bool IsNotEmpty { get; }

        int Count { get; }

        bool Has(int entityId);

        bool Set(int entityId, in T component);

        bool SetSameAs(int entityId, int referenceEntityId);

        bool Remove(int entityId);

        ref T Get(int entityId);

        void TrimExcess();

        Components<T> AsComponents();

        void CopyTo(IComponentPool<T> newPool);
    }
}
