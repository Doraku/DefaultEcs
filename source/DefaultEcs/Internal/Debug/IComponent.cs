using System;

namespace DefaultEcs.Internal.Debug
{
    internal interface IComponent
    {
        Type Type { get; }
    }
}
