using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    public sealed partial class BallToBarSystem : AEntitySetSystem<float>
    {
        [ConstructorParameter]
        private readonly GameWindow _window;

        private MouseState _state;

        protected override void PreUpdate(float state)
        {
            _state = Mouse.GetState(_window);
        }

        [Update(true)]
        private void Update(in Entity entity, in BallStart ballStart, ref DrawInfo drawInfo)
        {
            int offset = ballStart.OffSet;

            drawInfo.Destination.X = MathHelper.Clamp(_state.X - 50 + offset, offset, _window.ClientBounds.Width - 100 + offset);
            drawInfo.Destination.Y = 540;

            if (_state.LeftButton == ButtonState.Pressed)
            {
                Vector2 velocity = new Vector2(offset - 45, -offset);
                velocity.Normalize();

                entity.Remove<BallStart>();
                entity.Set(new Velocity
                {
                    Value = velocity * 500f
                });
                entity.Set(new Position
                {
                    Value = new Vector2(
                        drawInfo.Destination.X,
                        drawInfo.Destination.Y)
                });
            }
        }
    }
}