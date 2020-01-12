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
            (Component<DrawInfo> drawInfos, Component<Velocity> velocities, Component<Acceleration> accelerations) = _world.Prefetch<DrawInfo, Velocity, Acceleration>(entities);

            using (drawInfos)
            using (velocities)
            using (accelerations)
            {
                for (int i = 0; i < entities.Length; ++i)
                {
                    Vector2 position = drawInfos[i].Position;
                    Vector2 separation = Vector2.Zero;
                    Vector2 alignment = Vector2.Zero;
                    Vector2 cohesion = Vector2.Zero;
                    int neighborCount = 0;

                    foreach (List<Entity> neighbors in _grid.GetEnumerator(position))
                    {
                        foreach (Entity neighbor in neighbors)
                        {
                            if (entities[i] == neighbor)
                            {
                                continue;
                            }

                            Vector2 otherPosition = neighbor.Get<DrawInfo>().Position;

                            Vector2 offset = position - otherPosition;

                            if (offset.LengthSquared() < _maxDistanceSquared)
                            {
                                separation += Vector2.Normalize(offset);

                                alignment += neighbor.Get<Velocity>().Value;

                                cohesion += otherPosition;

                                ++neighborCount;
                            }
                        }
                    }

                    if (neighborCount > 0)
                    {
                        alignment = (alignment / neighborCount) - velocities[i].Value;

                        cohesion = position - (cohesion / neighborCount);
                    }

                    accelerations[i].Value =
                        (separation * DefaultGame.BehaviorSeparationWeight)
                        + (alignment * DefaultGame.BehaviorAlignmentWeight)
                        + (cohesion * DefaultGame.BehaviorCohesionWeight);
                }
            }
        }
    }
}
