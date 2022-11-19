using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using DefaultSlap.Message;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultSlap.System
{
    [With<PlayerState>, With<Position>, With<DrawInfo>]
    internal sealed class PlayerSystem : AEntitySetSystem<float>
    {
        private readonly GameWindow _window;

        private MouseState _mouseState;
        private bool _isSlaping;

        public PlayerSystem(World world, GameWindow window)
            : base(world)
        {
            _window = window;
        }

        protected override void PreUpdate(float state)
        {
            _mouseState = Mouse.GetState(_window);
            _isSlaping = _mouseState.LeftButton == ButtonState.Pressed;
        }

        protected override void Update(float state, in Entity entity)
        {
            ref PlayerState playerState = ref entity.Get<PlayerState>();
            ref Position position = ref entity.Get<Position>();
            ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

            position.Value = _mouseState.Position;

            if (_isSlaping
                && !playerState.IsSlaping)
            {
                Point size = drawInfo.Size;
                World.Publish(new SlapMessage(new Rectangle(_mouseState.Position - (size / new Point(2)), size)));
            }

            playerState.IsSlaping = _isSlaping;
            drawInfo.Color.A = _isSlaping ? (byte)0xFF : (byte)0x7F;
        }
    }
}
