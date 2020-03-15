using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DefaultEcs.Technical.Command
{
    internal sealed unsafe class ManagedComponentCommand<T>
    {
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void WriteComponent(List<object> objects, byte* data, in T component)
        {
            lock (objects)
            {
                *(int*)data = objects.Count;
                objects.Add(component);
            }
        }

        public static int Set(in Entity entity, List<object> objects, byte* memory)
        {
            entity.Set((T)objects[*(int*)memory]);

            return sizeof(int);
        }
    }
}
