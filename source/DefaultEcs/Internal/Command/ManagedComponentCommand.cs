using System.Collections.Generic;

namespace DefaultEcs.Internal.Command
{
    internal sealed unsafe class ManagedComponentCommand<T>
    {
        public static void WriteComponent(List<object> objects, byte* data, in T component)
        {
            lock (objects)
            {
                *(int*)data = objects.Count;
                objects.Add(component);
            }
        }

        public static int Set(World world, List<object> objects, byte* memory)
        {
            world.Set((T)objects[*(int*)memory]);

            return sizeof(int);
        }

        public static int Set(in Entity entity, List<object> objects, byte* memory)
        {
            entity.Set((T)objects[*(int*)memory]);

            return sizeof(int);
        }
    }
}
