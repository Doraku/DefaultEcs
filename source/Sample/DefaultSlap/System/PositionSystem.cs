using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public sealed partial class PositionSystem : AEntitySetSystem<float>
    {
        [Update]
        private static void Update(in PositionFloat positionFloat, ref Position position)
        {
            position.Value = new Point((int)positionFloat.Value.X, (int)positionFloat.Value.Y);
        }
    }
}
