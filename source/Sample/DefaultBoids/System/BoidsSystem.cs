using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    public sealed partial class BoidsSystem : AEntitySetSystem<float>
    {
        [ConstructorParameter]
        private readonly EntityMap<GridId> _grid;

        [Update]
        private void Update(in Components<Behavior> behaviors, in GridId gridId, in DrawInfo drawInfo, in Velocity velocity, ref Acceleration acceleration)
        {
            Vector2 position = drawInfo.Position;
            Vector2 separation = Vector2.Zero;
            Vector2 alignment = Vector2.Zero;
            Vector2 cohesion = Vector2.Zero;
            int neighborCount = 0;

            //foreach (GridId neighbor in gridIds[entity].GetNeighbors())
            {
                Behavior behavior = behaviors[_grid[gridId]];

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
                alignment = (alignment / neighborCount) - velocity.Value;
                cohesion = position - (cohesion / neighborCount);
            }

            acceleration.Value =
                (separation * DefaultGame.BehaviorSeparationWeight)
                + (alignment * DefaultGame.BehaviorAlignmentWeight)
                + (cohesion * DefaultGame.BehaviorCohesionWeight);
        }
    }
}
