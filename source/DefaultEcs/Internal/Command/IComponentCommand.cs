using System.Collections.Generic;

namespace DefaultEcs.Internal.Command
{
    internal unsafe interface IComponentCommand
    {
        void Enable(in Entity entity);
        void Disable(in Entity entity);
        int Set(in Entity entity, List<object> objects, byte* memory);
        void SetSameAs(in Entity entity, in Entity reference);
        void SetSameAsWorld(in Entity entity);
        void Remove(in Entity entity);
        void NotifyChanged(in Entity entity);
    }
}
