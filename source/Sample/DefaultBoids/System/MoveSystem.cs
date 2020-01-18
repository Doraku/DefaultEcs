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
        private readonly World _world;
        private readonly Grid _grid;

        public MoveSystem(World world, IParallelRunner runner, Grid grid)
            : base(world, runner)
        {
            _world = world;
            _grid = grid;
        }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            Components<DrawInfo> drawInfos = _world.GetComponents<DrawInfo>();
            Components<Velocity> velocities = _world.GetComponents<Velocity>();
            Components<Acceleration> accelerations = _world.GetComponents<Acceleration>();

            foreach (ref readonly Entity entity in entities)
            {
                ref Vector2 velocity = ref velocities[entity].Value;

                velocity += accelerations[entity].Value * state;

                Vector2 direction = Vector2.Normalize(velocity);
                float speed = velocity.Length();

                velocity = Math.Clamp(speed, DefaultGame.MinVelocity, DefaultGame.MaxVelocity) * direction;

                ref DrawInfo drawInfo = ref drawInfos[entity];
                Vector2 newPosition = drawInfo.Position + (velocity * state);
                _grid.Update(entity, drawInfo.Position, newPosition);
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
