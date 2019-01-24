using System.Collections.Generic;
using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;
using DefaultEcs.System;

namespace DefaultBrick.System
{
    public sealed class BallBoundSystem : AEntitySystem<float>
    {
        private readonly World _world;
        private readonly List<Entity> _toRemove;

        public BallBoundSystem(World world)
            : base(world.GetEntities().With<Velocity>().With<Position>().With<Ball>().Build())
        {
            _world = world;
            _toRemove = new List<Entity>();
        }

        protected override void Update(float state, in Entity entity)
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
                _toRemove.Add(entity);
                _world.Publish<BallDroppedMessage>(default);
            }
        }

        protected override void PostUpdate(float state)
        {
            while (_toRemove.Count > 0)
            {
                _toRemove[0].Dispose();
                _toRemove.RemoveAt(0);
            }
        }
    }
}
