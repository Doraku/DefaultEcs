using System;
using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public class AISystem : ASystem<float>
    {
        private readonly Random _random;

        public AISystem(World world)
            : base(world.GetEntities().With<PositionFloat>().With<TargetPosition>().With<Speed>().Build())
        {
            _random = new Random();
        }

        protected override void InternalUpdate(float elaspedTime, ReadOnlySpan<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                Point target = entity.Get<TargetPosition>().Value;
                ref Vector2 position = ref entity.Get<PositionFloat>().Value;
                Vector2 offset = new Vector2(target.X, target.Y) - position;
                if (target == Point.Zero
                    || offset.Length() < 10f)
                {
                    target = new Point(_random.Next(10, 790), _random.Next(10, 590));
                    entity.Get<TargetPosition>().Value = target;
                    offset = new Vector2(target.X, target.Y) - position;
                }

                offset.Normalize();

                position += offset * elaspedTime * entity.Get<Speed>().Value;
            }
        }
    }
}
