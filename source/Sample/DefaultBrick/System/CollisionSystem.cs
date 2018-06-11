using System;
using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public sealed class CollisionSystem : AEntitySetSystem<float>
    {
        private readonly World _world;
        private readonly EntitySet _solidSet;

        public CollisionSystem(World world)
            : base(world.GetEntities().With<Ball>().With<Position>().With<Velocity>().Build())
        {
            _world = world;
            _solidSet = _world.GetEntities().With<Solid>().With<DrawInfo>().Build();
        }

        protected override void Update(float elaspedTime, in Entity ball)
        {
            ref Position position = ref ball.Get<Position>();
            ref Velocity velocity = ref ball.Get<Velocity>();
            Rectangle ballXBound = new Rectangle((int)position.Value.X, (int)(position.Value.Y - velocity.Value.Y * elaspedTime), 10, 10);
            Rectangle ballYBound = new Rectangle((int)(position.Value.X - velocity.Value.X * elaspedTime), (int)position.Value.Y, 10, 10);

            Span<Entity> solids = stackalloc Entity[_solidSet.Count];
            _solidSet.CopyEntitiesTo(solids);

            int speedUp = 0;

            foreach (Entity solid in solids)
            {
                Rectangle bound = solid.Get<DrawInfo>().Destination;
                bool hasCollision = false;

                if (ballXBound.Intersects(bound))
                {
                    hasCollision = true;

                    if (ballYBound.X - velocity.Value.X * elaspedTime < bound.X + bound.Width)
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

                        if (ballXBound.Y - velocity.Value.Y * elaspedTime < bound.Y + bound.Height)
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

            velocity.Value += Vector2.Normalize(velocity.Value) * speedUp * 10f;
        }
    }
}
