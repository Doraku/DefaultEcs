using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    [With(typeof(DrawInfo), typeof(Velocity), typeof(Acceleration), typeof(Grid))]
    public sealed class MoveSystem : AEntitySystem<float>
    {
        public MoveSystem(World world, IParallelRunner runner)
            : base(world, runner)
        { }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                ref Vector2 velocity = ref entity.Get<Velocity>().Value;

                velocity += entity.Get<Acceleration>().Value * state;

                Vector2 direction = Vector2.Normalize(velocity);
                float speed = velocity.Length();

                velocity = Math.Clamp(speed, DefaultGame.MinVelocity, DefaultGame.MaxVelocity) * direction;

                ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();
                Vector2 newPosition = drawInfo.Position + velocity * state;
                entity.Get<Grid>().Update(entity, drawInfo.Position, newPosition);
                drawInfo.Position = newPosition;

                if ((drawInfo.Position.X < 0 && velocity.X < 0)
                    || (drawInfo.Position.X > DefaultGame.ResolutionWidth && velocity.X > 0))
                {
                    velocity.X *= -1;
                }
                if ((drawInfo.Position.Y < 0 && velocity.Y < 0)
                    || (drawInfo.Position.Y > DefaultGame.ResolutionHeight && velocity.Y > 0))
                {
                    velocity.Y *= -1;
                }

                drawInfo.Rotation = MathF.Atan2(velocity.X, -velocity.Y);
            }
        }
    }
}
