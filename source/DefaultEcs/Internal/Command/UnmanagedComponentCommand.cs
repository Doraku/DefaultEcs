using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DefaultEcs.Internal.Command
{
    internal sealed unsafe class UnmanagedComponentCommand<T>
        where T : unmanaged
    {
        [SuppressMessage("Design", "RCS1158:Static member in generic type should use a type parameter.")]
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
