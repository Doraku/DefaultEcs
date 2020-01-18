using System;
using System.Collections.Generic;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    [With(typeof(DrawInfo), typeof(Acceleration), typeof(Velocity), typeof(Grid))]
    public sealed class BoidsSystem : AEntitySystem<float>
    {
        private readonly float _maxDistance;
        private readonly float _maxDistanceSquared;
        private readonly World _world;
        private readonly Grid _grid;

        public BoidsSystem(World world, IParallelRunner runner, Grid grid)
            : base(world, runner)
        {
            _maxDistance = DefaultGame.NeighborRange;
            _maxDistanceSquared = MathF.Pow(_maxDistance, 2);
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
                Vector2 position = drawInfos[entity].Position;
                Vector2 separation = Vector2.Zero;
                Vector2 alignment = Vector2.Zero;
                Vector2 cohesion = Vector2.Zero;
                int neighborCount = 0;

                foreach (List<Entity> neighbors in _grid.GetEnumerator(position))
                {
                    foreach (Entity neighbor in neighbors)
                    {
                        if (entity == neighbor)
                        {
                            continue;
                        }

                        Vector2 otherPosition = drawInfos[neighbor].Position;

                        Vector2 offset = position - otherPosition;

                        if (offset.LengthSquared() < _maxDistanceSquared)
                        {
                            separation += Vector2.Normalize(offset);

                            alignment += velocities[neighbor].Value;

                            cohesion += otherPosition;

                            ++neighborCount;
                        }
                    }
                }

                if (neighborCount > 0)
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
