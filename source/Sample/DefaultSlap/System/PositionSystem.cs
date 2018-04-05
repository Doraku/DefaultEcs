using DefaultEcs;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;

namespace DefaultSlap.System
{
    public class PositionSystem : ISystem
    {
        private readonly EntitySet _set;

        public PositionSystem(World world)
        {
            _set = world.GetEntities().With<Position>().With<PositionFloat>().Build();
        }

        public void Update(float elaspedTime)
        {
            foreach (Entity entity in _set.GetEntities())
            {
                Vector2 positionFloat = entity.Get<PositionFloat>().Value;
                entity.Get<Position>().Value = new Point((int)positionFloat.X, (int)positionFloat.Y);
            }
        }
    }
}
