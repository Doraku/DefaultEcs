using DefaultBoids.Component;
using DefaultEcs.System;

namespace DefaultBoids.System
{
    [With(typeof(GridId))]
    public sealed partial class ResetBehaviorSystem : AEntitySetSystem<float>
    {
        [Update]
        private static void Update(ref Behavior behavior)
        {
            behavior = new Behavior();
        }
    }
}
