using System.Collections.Generic;

namespace DefaultEcs.Internal.Command
{
    internal sealed unsafe class UnmanagedComponentCommand<T>
        where T : unmanaged
    {
        public static int SizeOfT = sizeof(T);

        public static void WriteComponent(List<object> _, byte* data, in T component) => *(T*)data = component;

        public static int SetWorldComponent(World world, List<object> _, byte* memory)
        {
            world.Set(*(T*)memory);

            return SizeOfT;
        }

        public static int SetEntityComponent(in Entity entity, List<object> _, byte* memory)
        {
            entity.Set(*(T*)memory);

            return SizeOfT;
        }
    }
}
