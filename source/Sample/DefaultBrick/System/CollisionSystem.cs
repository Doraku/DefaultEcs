using System;
using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    [With(typeof(Solid), typeof(DrawInfo))]
    public sealed class CollisionSystem : AEntityBufferedSystem<float>
    {
        private readonly World _world;
        private readonly EntitySet _balls;

        public CollisionSystem(World world)
            : base(world)
        {
            _world = world;
            _balls = _world.GetEntities().With<Ball>().With<Position>().With<Velocity>().AsSet();
        }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity ball in _balls.GetEntities())
            {
                ref Position position = ref ball.Get<Position>();
                ref Velocity velocity = ref ball.Get<Velocity>();
                Rectangle ballXBound = new Rectangle((int)position.Value.X, (int)(position.Value.Y - (velocity.Value.Y * state)), 10, 10);
                Rectangle ballYBound = new Rectangle((int)(position.Value.X - (velocity.Value.X * state)), (int)position.Value.Y, 10, 10);

                Span<Entity> solids = stackalloc Entity[_balls.Count];
                _balls.GetEntities().CopyTo(solids);

                int speedUp = 0;

                foreach (ref readonly Entity solid in entities)
                {
                    Rectangle bound = solid.Get<DrawInfo>().Destination;
                    bool hasCollision = false;

                    if (ballXBound.Intersects(bound))
                    {
                        hasCollision = true;

                        if (ballYBound.X - (velocity.Value.X * state) < bound.X + bound.Width)
                        {
                            position.Value.X -= (position.Value.X + 10 - bound.X) * 2;
                        }
                        else
                        {
                            position.Value.X -= (position.Value.X - bound.X - bound.Width) * 2;
                        }

                        velocity.Value.X *= -1;
                    }
                    else if (ballYBound.Intersects(bound))
                    {
                        if (solid.Has<Bar>())
                        {
                            position.Value.Y = bound.Y - 10;

                            int offset = (int)position.Value.X - bound.X;
                            Vector2 newVelocity = new Vector2(offset - 45, -offset);
                            newVelocity.Normalize();

                            velocity.Value = newVelocity * velocity.Value.Length();
                            _world.Publish<BarBounceMessage>(default);
                        }
                        else
                        {
                            hasCollision = true;

                            if (ballXBound.Y - (velocity.Value.Y * state) < bound.Y + bound.Height)
                            {
                                position.Value.Y -= (position.Value.Y + 10 - bound.Y) * 2;
                            }
                            else
                            {
                                position.Value.Y -= (position.Value.Y - bound.Y - bound.Height) * 2;
                            }

                            velocity.Value.Y *= -1;
                        }
                    }

                    if (hasCollision
                        && solid.Has<Breakable>())
                    {
                        ++speedUp;
                        solid.Dispose();
                        _world.Publish<BrickBrokenMessage>(default);
                    }
                }

                ball.Set(position);
                velocity.Value += Vector2.Normalize(velocity.Value) * speedUp * 10f;
            }
        }
    }
}
