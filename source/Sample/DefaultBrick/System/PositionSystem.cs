using DefaultEcs;
using DefaultBrick.Component;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public class PositionSystem : ISystem
    {
        private readonly EntitySet _set;

        public PositionSystem(World world)
        {
            _set = world.GetEntities().With<Position>().With<DrawInfo>().Build();
        }

        public void Update(float elaspedTime)
        {
            foreach (Entity entity in _set.GetEntities())
            {
                Vector2 position = entity.Get<Position>().Value;
                ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

                drawInfo.Destination.X = (int)position.X;
                drawInfo.Destination.Y = (int)position.Y;
            }
        }
    }
}
