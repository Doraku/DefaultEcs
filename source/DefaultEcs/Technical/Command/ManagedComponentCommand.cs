using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal sealed unsafe class ManagedComponentCommand<T>
    {
        public static void CreateSet(List<object> objects, int* data, in T component)
        {
            lock (objects)
            {
                *data = objects.Count;
                objects.Add(component);
            }
        }

        public static int Set(List<object> objects, byte* memory, int* data)
        {
            (*(Entity*)(memory + *data++)).Set((T)objects[*data]);

            return sizeof(int);
        }
    }
}
