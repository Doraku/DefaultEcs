using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    public sealed class PlayerSystem : AEntitySetSystem<float>
    {
        private readonly GameWindow _window;

        private MouseState _state;

        public PlayerSystem(GameWindow window, World world)
            : base(world.GetEntities().With<PlayerInput>().With<DrawInfo>().AsSet())
        {
            _window = window;
        }

        protected override void PreUpdate(float state)
        {
            _state = Mouse.GetState(_window);
        }

        protected override void Update(float state, in Entity entity)
        {
            ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

            drawInfo.Destination.X = MathHelper.Clamp(_state.X - (drawInfo.Destination.Width / 2), 0, _window.ClientBounds.Width - drawInfo.Destination.Width);
        }
    }
}
