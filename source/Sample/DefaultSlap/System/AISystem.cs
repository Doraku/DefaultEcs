using System;
using System.Threading;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public sealed class AISystem : AEntitySystem<float>
    {
        private readonly ThreadLocal<Random> _random;

        public AISystem(World world, IRunner runner)
            : base(world.GetEntities().With<PositionFloat>().With<TargetPosition>().With<Speed>().Build(), runner)
        {
            _random = new ThreadLocal<Random>(() => new Random());
        }

        protected override void Update(float state, in Entity entity)
        {
            Point target = entity.Get<TargetPosition>().Value;
            ref Vector2 position = ref entity.Get<PositionFloat>().Value;
            Vector2 offset = new Vector2(target.X, target.Y) - position;
            if (target == Point.Zero
                || offset.Length() < 10f)
            {
                target = new Point(_random.Value.Next(10, 790), _random.Value.Next(10, 590));
                entity.Get<TargetPosition>().Value = target;
                offset = new Vector2(target.X, target.Y) - position;
            }

            offset.Normalize();

            position += offset * state * entity.Get<Speed>().Value;
        }
    }
}
