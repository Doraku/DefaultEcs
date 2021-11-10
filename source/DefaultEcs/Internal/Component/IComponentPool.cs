using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultEcs.Internal.Component
{
    internal interface IComponentPool<T>
    {
        ComponentMode Mode { get; }

        bool IsNotEmpty { get; }

        int Count { get; }

        bool Has(int entityId);

        bool Set(int entityId, in T component);

        bool Remove(int entityId);

        ref T Get(int entityId);

        void TrimExcess();
    }
}
