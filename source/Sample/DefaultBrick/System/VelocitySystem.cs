using DefaultBrick.Component;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public sealed partial class VelocitySystem : AEntitySetSystem<float>
    {
        [Update]
        private static void Update(float elapsedTime, ref Velocity velocity, ref Position position)
        {
            Vector2 offset = velocity.Value * elapsedTime;

            position.Value.X += offset.X;
            position.Value.Y += offset.Y;
        }
    }
}
