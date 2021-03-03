using System;
using System.Threading;
using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public sealed partial class AISystem : AEntitySetSystem<float>
    {
        private readonly ThreadLocal<Random> _random = new(() => new Random());

        [Update]
        private void Update(float elapsedTime, ref TargetPosition target, ref PositionFloat position, in Speed speed)
        {
            Vector2 offset = new Vector2(target.Value.X, target.Value.Y) - position.Value;
            if (target.Value == Point.Zero
                || offset.Length() < 10f)
            {
                target.Value = new Point(_random.Value.Next(10, 790), _random.Value.Next(10, 590));
                offset = new Vector2(target.Value.X, target.Value.Y) - position.Value;
            }

            offset.Normalize();

            position.Value += offset * elapsedTime * speed.Value;
        }
    }
}
