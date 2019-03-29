using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal sealed unsafe class ManagedComponentCommand<T>
    {
        public static void CreateSet(List<object> objects, int* data, in T component)
        {
            lock (objects)
            {
                objects.Add(component);
                *data = objects.Count;
            }
        }

        public static void Set(List<object> objects, byte* memory, int* data)
        {
            (*(Entity*)(memory + *data++)).Set((T)objects[*data]);
        }
    }
}
