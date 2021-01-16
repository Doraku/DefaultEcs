using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    [With(typeof(PlayerInput))]
    public sealed partial class PlayerSystem : AEntitySetSystem<float>
    {
        [ConstructorParameter]
        private readonly GameWindow _window;

        private MouseState _state;

        protected override void PreUpdate(float state)
        {
            _state = Mouse.GetState(_window);
        }

        [Update]
        private void Update(ref DrawInfo drawInfo)
        {
            drawInfo.Destination.X = MathHelper.Clamp(_state.X - (drawInfo.Destination.Width / 2), 0, _window.ClientBounds.Width - drawInfo.Destination.Width);
        }
    }
}
