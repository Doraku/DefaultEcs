using DefaultEcs;
using DefaultSlap.Component;
using DefaultSlap.Message;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultSlap.System
{
    class PlayerSystem : ISystem
    {
        private readonly GameWindow _window;
        private readonly World _world;
        private readonly EntitySet _set;

        public PlayerSystem(GameWindow window, World world)
        {
            _window = window;
            _world = world;
            _set = _world.GetEntities().With<PlayerState>().With<DrawInfo>().With<Position>().Build();
        }

        public void Update(float elaspedTime)
        {
            MouseState mouseState = Mouse.GetState(_window);
            bool isSlaping = mouseState.LeftButton == ButtonState.Pressed;

            foreach (Entity entity in _set.GetEntities())
            {
                entity.Get<Position>().Value = mouseState.Position;
                ref PlayerState playerState = ref entity.Get<PlayerState>();
                if (isSlaping
                    && !playerState.IsSlaping)
                {
                    Point size = entity.Get<DrawInfo>().Size;
                    _world.Publish(new SlapMessage(new Rectangle(mouseState.Position - size / new Point(2), size)));
                }

                playerState.IsSlaping = isSlaping;
                entity.Get<DrawInfo>().Color.A = isSlaping ? (byte)0xFF : (byte)0x7F;
            }
        }
    }
}
