using System;

namespace DefaultEcs.Technical.Debug
{
    internal interface IComponent
    {
        Type Type { get; }
    }
}
