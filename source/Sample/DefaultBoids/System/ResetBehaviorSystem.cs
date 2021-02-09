using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultBoids.System
{
    public sealed class ResetBehaviorSystem : AComponentSystem<float, Behavior>
    {
        public ResetBehaviorSystem(World world, IParallelRunner runner)
            : base(world, runner)
        { }

        protected override void Update(float state, Span<Behavior> components) => components.Fill(default);
    }
}
