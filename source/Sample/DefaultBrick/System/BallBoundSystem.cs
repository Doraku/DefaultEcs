using System;
using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;

namespace DefaultBrick.System
{
    public class BallBoundSystem : ISystem
    {
        private readonly World _world;
        private readonly EntitySet _set;

        public BallBoundSystem(World world)
        {
            _world = world;
            _set = _world.GetEntities().With<Velocity>().With<Position>().With<Ball>().Build();
        }

        public void Update(float elaspedTime)
        {
            Span<Entity> entities = stackalloc Entity[_set.Count];
            _set.CopyEntitiesTo(entities);

            foreach (Entity entity in entities)
            {
                ref Position position = ref entity.Get<Position>();
                ref Velocity velocity = ref entity.Get<Velocity>();

                if (position.Value.X < 0)
                {
                    position.Value.X *= -1;
                    velocity.Value.X *= -1;
                }
                else if (position.Value.X > 790)
                {
                    position.Value.X = 1580 - position.Value.X;
                    velocity.Value.X *= -1;
                }

                if (position.Value.Y < 0)
                {
                    position.Value.Y *= -1;
                    velocity.Value.Y *= -1;
                }
                else if (position.Value.Y > 600)
                {
                    entity.Dispose();
                    _world.Publish<BallDroppedMessage>(default);
                }
            }
        }
    }
}
