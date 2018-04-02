using DefaultEcs;
using DefaultBrick.Component;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public class VelocitySystem : ISystem
    {
        private readonly EntitySet _set;

        public VelocitySystem(World world)
        {
            _set = world.GetEntities().With<Velocity>().With<Position>().Build();
        }

        public void Update(float elaspedTime)
        {
            foreach (Entity entity in _set.GetEntities())
            {
                ref Velocity velocity = ref entity.Get<Velocity>();
                ref Position position = ref entity.Get<Position>();

                Vector2 offset = velocity.Value * elaspedTime;

                position.Value.X += offset.X;
                position.Value.Y += offset.Y;
            }
        }
    }
}
