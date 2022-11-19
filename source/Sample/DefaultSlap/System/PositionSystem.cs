using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    [With<PositionFloat>, With<Position>]
    public sealed class PositionSystem : AEntitySetSystem<float>
    {
        public PositionSystem(World world, IParallelRunner runner)
            : base(world, runner)
        { }

        protected override void Update(float state, in Entity entity)
        {
            PositionFloat positionFloat = entity.Get<PositionFloat>();
            ref Position position = ref entity.Get<Position>();

            position.Value = new Point((int)positionFloat.Value.X, (int)positionFloat.Value.Y);
        }
    }
}
