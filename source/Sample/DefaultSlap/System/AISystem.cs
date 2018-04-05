using System;
using DefaultEcs;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public class AISystem : ISystem
    {
        private readonly Random _random;
        private readonly EntitySet _set;

        public AISystem(World world)
        {
            _random = new Random();
            _set = world.GetEntities().With<PositionFloat>().With<TargetPosition>().With<Speed>().Build();
        }

        public void Update(float elaspedTime)
        {
            foreach (Entity entity in _set.GetEntities())
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
