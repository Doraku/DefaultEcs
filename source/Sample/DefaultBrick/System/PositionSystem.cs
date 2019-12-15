using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public sealed class PositionSystem : AEntitySystem<float>
    {
        public PositionSystem(World world, IParallelRunner runner)
            : base(world.GetEntities().WhenAdded<Position>().WhenChanged<Position>().With<DrawInfo>().AsSet(), runner)
        {
        }

        protected override void Update(float state, in Entity entity)
        {
            Vector2 position = entity.Get<Position>().Value;
            ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

            drawInfo.Destination.X = (int)position.X;
            drawInfo.Destination.Y = (int)position.Y;
        }
    }
}
