using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public sealed class PositionSystem : AEntitySystem<float>
    {
        public PositionSystem(World world, SystemRunner<float> runner)
            : base(world.GetEntities().With<Position>().With<PositionFloat>().Build(), runner)
        { }

        protected override void Update(float elaspedTime, in Entity entity)
        {
            Vector2 positionFloat = entity.Get<PositionFloat>().Value;
            entity.Get<Position>().Value = new Point((int)positionFloat.X, (int)positionFloat.Y);
        }
    }
}
