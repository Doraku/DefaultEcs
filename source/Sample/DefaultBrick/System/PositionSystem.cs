using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace DefaultBrick.System
{
    internal sealed class PositionSystem : AEntitySetSystem<float>
    {
        public PositionSystem(World world, IParallelRunner runner)
            : base(world.GetEntities().With<Position>().With<DrawInfo>().AsSet(), runner)
        { }

        protected override void Update(float state, in Entity entity)
        {
            Position position = entity.Get<Position>();
            ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

            drawInfo.Destination.X = (int)position.Value.X;
            drawInfo.Destination.Y = (int)position.Value.Y;
        }
    }
}
