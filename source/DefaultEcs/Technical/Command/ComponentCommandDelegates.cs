using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal unsafe delegate void ComponentCommandCreateSet<T>(List<object> objects, int* memory, in T component);

    internal unsafe delegate void ComponentCommandSet(List<object> objects, byte* memory, int* data);
}
