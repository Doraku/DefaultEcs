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
            (Component<Velocity> velocities, Component<Acceleration> accelerations, Component<DrawInfo> drawInfos) = _world.Prefetch<Velocity, Acceleration, DrawInfo>(entities);

            using (velocities)
            using (accelerations)
            using (drawInfos)
            {
                for (int i = 0; i < entities.Length; ++i)
                {
                    ref Vector2 velocity = ref velocities[i].Value;

                    velocity += accelerations[i].Value * state;

                    Vector2 direction = Vector2.Normalize(velocity);
                    float speed = velocity.Length();

                    velocity = Math.Clamp(speed, DefaultGame.MinVelocity, DefaultGame.MaxVelocity) * direction;

                    ref DrawInfo drawInfo = ref drawInfos[i];
                    Vector2 newPosition = drawInfo.Position + (velocity * state);
                    _grid.Update(entities[i], drawInfo.Position, newPosition);
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
}
