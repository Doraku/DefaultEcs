using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    public sealed partial class MoveSystem : AEntitySetSystem<float>
    {
        private readonly SafeBuffer<Entity> _buffer = new(DefaultGame.BoidsCount);

        [Update]
        private void Update(in Entity entity, float elaspedTime, ref Velocity velocity, ref DrawInfo drawInfo, ref GridId gridId, in Acceleration acceleration)
        {
            velocity.Value += acceleration.Value * elaspedTime;

            Vector2 direction = Vector2.Normalize(velocity.Value);
            float speed = velocity.Value.Length();

            velocity.Value = Math.Clamp(speed, DefaultGame.MinVelocity, DefaultGame.MaxVelocity) * direction;

            Vector2 newPosition = drawInfo.Position + (velocity.Value * elaspedTime);

            GridId newId = newPosition.ToGridId();
            if (!newId.Equals(gridId))
            {
                gridId = newId;
                _buffer.Add(entity);
            }
            drawInfo.Position = newPosition;

            if ((drawInfo.Position.X < 0 && velocity.Value.X < 0)
                || (drawInfo.Position.X > DefaultGame.ResolutionWidth && velocity.Value.X > 0))
            {
                velocity.Value.X *= -1;
            }
            if ((drawInfo.Position.Y < 0 && velocity.Value.Y < 0)
                || (drawInfo.Position.Y > DefaultGame.ResolutionHeight && velocity.Value.Y > 0))
            {
                velocity.Value.Y *= -1;
            }

            drawInfo.Rotation = MathF.Atan2(velocity.Value.X, -velocity.Value.Y);
        }

        protected override void PostUpdate(float state)
        {
            foreach (ref readonly Entity entity in _buffer)
            {
                entity.NotifyChanged<GridId>();
            }
        }
    }
}
