using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    [With(typeof(Position), typeof(PositionFloat))]
    public sealed class PositionSystem : AEntitySystem<float>
    {
        public PositionSystem(World world, SystemRunner<float> runner)
            : base(world, runner)
        { }

        protected override void Update(float state, in Entity entity)
        {
            Vector2 positionFloat = entity.Get<PositionFloat>().Value;
            entity.Get<Position>().Value = new Point((int)positionFloat.X, (int)positionFloat.Y);
        }
    }
}
