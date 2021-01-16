using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using DefaultSlap.Message;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultSlap.System
{
    internal sealed partial class PlayerSystem : AEntitySetSystem<float>
    {
        [ConstructorParameter]
        private readonly GameWindow _window;

        private MouseState _mouseState;
        private bool _isSlaping;

        protected override void PreUpdate(float state)
        {
            _mouseState = Mouse.GetState(_window);
            _isSlaping = _mouseState.LeftButton == ButtonState.Pressed;
        }

        [Update]
        private void Update(ref PlayerState playerState, ref DrawInfo drawInfo)
        {
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
