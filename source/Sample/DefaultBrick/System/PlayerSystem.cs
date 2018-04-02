using DefaultEcs;
using DefaultBrick.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    public class PlayerSystem : ISystem
    {
        private readonly GameWindow _window;
        private readonly EntitySet _set;

        public PlayerSystem(GameWindow window, World world)
        {
            _window = window;
            _set = world.GetEntities().With<PlayerInput>().With<DrawInfo>().Build();
        }

        public void Update(float elaspedTime)
        {
            MouseState state = Mouse.GetState(_window);

            foreach (Entity entity in _set.GetEntities())
            {
                ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

                drawInfo.Destination.X = MathHelper.Clamp(state.X - (drawInfo.Destination.Width / 2), 0, _window.ClientBounds.Width - drawInfo.Destination.Width);
            }
        }
    }
}
