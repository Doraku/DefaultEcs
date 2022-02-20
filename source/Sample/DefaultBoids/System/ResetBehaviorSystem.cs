using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultBoids.System
{
    internal sealed class ResetBehaviorSystem : AComponentSystem<float, Behavior>
    {
        public ResetBehaviorSystem(World world)
            : base(world, world.Get<IParallelRunner>())
        { }

        protected override void Update(float state, Span<Behavior> components) => components.Fill(default);
    }
}
