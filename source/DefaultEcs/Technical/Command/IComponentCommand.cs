using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal unsafe interface IComponentCommand
    {
        void Enable(in Entity entity);
        void Disable(in Entity entity);
        int Set(List<object> objects, byte* memory, int* data);
        void SetSameAs(byte* memory, int* data);
        void Remove(in Entity entity);
    }
}
