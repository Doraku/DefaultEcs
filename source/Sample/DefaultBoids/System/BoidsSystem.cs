using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    [With(typeof(DrawInfo), typeof(Acceleration), typeof(Velocity), typeof(GridId))]
    public sealed class BoidsSystem : AEntitySystem<float>
    {
        private readonly World _world;
        private readonly EntityMap<GridId> _grid;

        public BoidsSystem(World world, IParallelRunner runner)
            : base(world, runner)
        {
            _world = world;
            _grid = world.GetEntities().With<Behavior>().AsMap<GridId>();
        }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            Components<DrawInfo> drawInfos = _world.GetComponents<DrawInfo>();
            Components<Velocity> velocities = _world.GetComponents<Velocity>();
            Components<Acceleration> accelerations = _world.GetComponents<Acceleration>();
            Components<GridId> gridIds = _world.GetComponents<GridId>();
            Components<Behavior> behaviors = _world.GetComponents<Behavior>();

            foreach (ref readonly Entity entity in entities)
            {
                Vector2 position = drawInfos[entity].Position;
                Vector2 separation = Vector2.Zero;
                Vector2 alignment = Vector2.Zero;
                Vector2 cohesion = Vector2.Zero;
                int neighborCount = 0;

                foreach (GridId neighbor in gridIds[entity].GetNeighbors())
                {
                    Behavior behavior = behaviors[_grid[neighbor]];

                    if (behavior.Count > 0)
                    {
                        Vector2 offset = (position * behavior.Count) - behavior.Center;
                        if (offset != Vector2.Zero)
                        {
                            separation += Vector2.Normalize(offset);
                        }
                    }
                    alignment += behavior.Direction;
                    cohesion += behavior.Center;
                    neighborCount += behavior.Count;
                }

                if (neighborCount > 1)
                {
                    alignment = (alignment / neighborCount) - velocities[entity].Value;
                    cohesion = position - (cohesion / neighborCount);
                }

                accelerations[entity].Value =
                    (separation * DefaultGame.BehaviorSeparationWeight)
                    + (alignment * DefaultGame.BehaviorAlignmentWeight)
                    + (cohesion * DefaultGame.BehaviorCohesionWeight);
            }
        }
    }
}
