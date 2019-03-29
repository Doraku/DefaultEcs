using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal sealed unsafe class UnmanagedComponentCommand<T>
        where T : unmanaged
    {
#pragma warning disable RCS1158 // Static member in generic type should use a type parameter.
        public static int SizeOfT = sizeof(T);
#pragma warning restore RCS1158 // Static member in generic type should use a type parameter.

        public static void CreateSet(List<object> _, int* data, in T component) => *(T*)data = component;

        public static void Set(List<object> _, byte* memory, int* data) => (*(Entity*)(memory + *data++)).Set(*(T*)data);
    }
}
