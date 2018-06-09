using System;
using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public sealed class VelocitySystem : AEntitySetSystem<float>
    {
        public VelocitySystem(World world, SystemRunner<float> runner)
            : base(world.GetEntities().With<Velocity>().With<Position>().Build(), runner)
        {
        }

        protected override void Update(float elaspedTime, ReadOnlySpan<Entity> entities)
        {
            foreach (Entity entity in entities)
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
