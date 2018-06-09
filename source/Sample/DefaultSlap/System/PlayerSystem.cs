using System;
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

        public PlayerSystem(GameWindow window, World world)
            : base(world.GetEntities().With<PlayerState>().With<DrawInfo>().With<Position>().Build())
        {
            _window = window;
            _world = world;
        }

        protected override void Update(float elaspedTime, ReadOnlySpan<Entity> entities)
        {
            MouseState mouseState = Mouse.GetState(_window);
            bool isSlaping = mouseState.LeftButton == ButtonState.Pressed;

            foreach (Entity entity in entities)
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
