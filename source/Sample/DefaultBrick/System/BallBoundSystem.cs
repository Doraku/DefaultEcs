using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;
using DefaultEcs.System;

namespace DefaultBrick.System
{
    internal sealed class BallBoundSystem : AEntitySetSystem<float>
    {
        public BallBoundSystem(World world)
            : base(world.GetEntities().With<Ball>().With<Position>().With<Velocity>().AsSet(), true)
        { }

        protected override void Update(float state, in Entity entity)
        {
            ref Position position = ref entity.Get<Position>();
            ref Velocity velocity = ref entity.Get<Velocity>();

            if (position.Value.X < 0)
            {
                position.Value.X *= -1;
                velocity.Value.X *= -1;
            }
            else if (position.Value.X > 790)
            {
                position.Value.X = 1580 - position.Value.X;
                velocity.Value.X *= -1;
            }

            if (position.Value.Y < 0)
            {
                position.Value.Y *= -1;
                velocity.Value.Y *= -1;
            }
            else if (position.Value.Y > 600)
            {
                entity.Dispose();
                World.Publish<BallDroppedMessage>(default);
            }
        }
    }
}
