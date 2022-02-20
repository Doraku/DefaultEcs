using System;

namespace DefaultEcs.Internal.Diagnostics
{
    internal interface IComponent
    {
        Type Type { get; }
    }
}
