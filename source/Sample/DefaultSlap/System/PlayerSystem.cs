using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using DefaultSlap.Message;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultSlap.System
{
    sealed class PlayerSystem : AEntitySetSystem<float>
    {
        private readonly GameWindow _window;
        private readonly World _world;

        private MouseState _mouseState;
        private bool _isSlaping;

        public PlayerSystem(GameWindow window, World world)
            : base(world.GetEntities().With<PlayerState>().With<DrawInfo>().With<Position>().Build())
        {
            _window = window;
            _world = world;
        }

        protected override void PreUpdate(float state)
        {
            _mouseState = Mouse.GetState(_window);
            _isSlaping = _mouseState.LeftButton == ButtonState.Pressed;
        }

        protected override void Update(float elaspedTime, in Entity entity)
        {
            entity.Get<Position>().Value = _mouseState.Position;
            ref PlayerState playerState = ref entity.Get<PlayerState>();
            if (_isSlaping
                && !playerState.IsSlaping)
            {
                Point size = entity.Get<DrawInfo>().Size;
                _world.Publish(new SlapMessage(new Rectangle(_mouseState.Position - size / new Point(2), size)));
            }

            playerState.IsSlaping = _isSlaping;
            entity.Get<DrawInfo>().Color.A = _isSlaping ? (byte)0xFF : (byte)0x7F;
        }
    }
}
