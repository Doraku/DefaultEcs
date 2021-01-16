using DefaultBrick.Component;
using DefaultEcs.System;

namespace DefaultBrick.System
{
    public sealed partial class PositionSystem : AEntitySetSystem<float>
    {
        [Update]
        private static void Update(in Position position, ref DrawInfo drawInfo)
        {
            drawInfo.Destination.X = (int)position.Value.X;
            drawInfo.Destination.Y = (int)position.Value.Y;
        }
    }
}
