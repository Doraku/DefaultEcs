using System;
using System.Threading;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    [With<TargetPosition>, With<PositionFloat>, With<Speed>]
    public sealed class AISystem : AEntitySetSystem<float>
    {
        private readonly ThreadLocal<Random> _random = new(() => new Random());

        public AISystem(World world, IParallelRunner runner)
            : base(world, runner)
        { }

        protected override void Update(float state, in Entity entity)
        {
            ref TargetPosition target = ref entity.Get<TargetPosition>();
            ref PositionFloat position = ref entity.Get<PositionFloat>();
            Speed speed = entity.Get<Speed>();

            Vector2 offset = new Vector2(target.Value.X, target.Value.Y) - position.Value;
            if (target.Value == Point.Zero
                || offset.Length() < 10f)
            {
                target.Value = new Point(_random.Value.Next(10, 790), _random.Value.Next(10, 590));
                offset = new Vector2(target.Value.X, target.Value.Y) - position.Value;
            }

            offset.Normalize();

            position.Value += offset * state * speed.Value;
        }
    }
}
