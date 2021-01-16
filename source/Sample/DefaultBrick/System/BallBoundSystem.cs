using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;
using DefaultEcs.System;

namespace DefaultBrick.System
{
    [With(typeof(Ball))]
    public sealed partial class BallBoundSystem : AEntitySetSystem<float>
    {
        [Update(true)]
        private void Update(in Entity entity, ref Position position, ref Velocity velocity)
        {
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
