using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultBoids.System
{
    [With(typeof(GridId), typeof(Behavior))]
    public sealed class ResetBehaviorSystem : AEntitySystem<float>
    {
        public ResetBehaviorSystem(World world, IParallelRunner runner)
            : base(world, runner)
        { }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                entity.Get<Behavior>() = new Behavior();
            }
        }
    }
}
