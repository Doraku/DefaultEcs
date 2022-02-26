using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    internal sealed class BallToBarSystem : AEntitySetSystem<float>
    {
        private readonly GameWindow _window;

        private MouseState _state;

        public BallToBarSystem(World world, GameWindow window)
            : base(world.GetEntities().With<BallStart>().With<DrawInfo>().AsSet(), true)
        {
            _window = window;
        }

        protected override void PreUpdate(float state)
        {
            _state = Mouse.GetState(_window);
        }

        protected override void Update(float state, in Entity entity)
        {
            ref BallStart ballStart = ref entity.Get<BallStart>();
            DrawInfo drawInfo = entity.Get<DrawInfo>();

            int offset = ballStart.OffSet;

            drawInfo.Destination.X = MathHelper.Clamp(_state.X - 50 + offset, offset, _window.ClientBounds.Width - 100 + offset);
            drawInfo.Destination.Y = 540;

            if (_state.LeftButton == ButtonState.Pressed)
            {
                Vector2 velocity = new(offset - 45, -offset);
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