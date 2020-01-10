using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    [With(typeof(DrawInfo), typeof(Acceleration), typeof(Velocity))]
    public sealed class BoidsSystem : AEntitySystem<float>
    {
        private readonly float _maxDistance;
        private readonly float _maxDistanceSquared;

        public BoidsSystem(World world, IParallelRunner runner)
            : base(world, runner)
        {
            _maxDistance = DefaultGame.NeighborRange;
            _maxDistanceSquared = MathF.Pow(_maxDistance, 2);
        }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            foreach (ref readonly Entity entity in entities)
            {
                Vector2 position = entity.Get<DrawInfo>().Position;
                Vector2 separation = Vector2.Zero;
                Vector2 alignment = Vector2.Zero;
                Vector2 cohesion = Vector2.Zero;
                int neighborCount = 0;

                foreach (ref readonly Entity other in entities)
                {
                    Vector2 otherPosition = other.Get<DrawInfo>().Position;

                    Vector2 offset = position - otherPosition;

                    if (offset.LengthSquared() < _maxDistanceSquared && entity != other)
                    {
                        separation += Vector2.Normalize(offset);

                        alignment += other.Get<Velocity>().Value;

                        cohesion += otherPosition;

                        ++neighborCount;
                    }
                }

                if (neighborCount > 0)
                {
                    separation /= neighborCount;

                    alignment /= neighborCount;
                    alignment -= entity.Get<Velocity>().Value;

                    cohesion /= neighborCount;
                    cohesion -= position;
                }

                entity.Get<Acceleration>().Value =
                    (separation * DefaultGame.BehaviorSeparationWeight)
                    + (alignment * DefaultGame.BehaviorAlignmentWeight)
                    + (cohesion * DefaultGame.BehaviorCohesionWeight);
            }
        }
    }
}
