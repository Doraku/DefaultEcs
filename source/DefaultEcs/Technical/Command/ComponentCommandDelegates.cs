using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal unsafe delegate void WriteComponent<T>(List<object> objects, byte* memory, in T component);

    internal unsafe delegate int SetComponent(in Entity entity, List<object> objects, byte* memory);
}
