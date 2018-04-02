using System;
using DefaultBrick.Component;
using DefaultEcs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DefaultBrick.System
{
    public class BallToBarSystem : ISystem
    {
        private readonly GameWindow _window;
        private readonly EntitySet _set;

        public BallToBarSystem(GameWindow window, World world)
        {
            _window = window;
            _set = world.GetEntities().With<BallStart>().With<DrawInfo>().Build();
        }

        public void Update(float elaspedTime)
        {
            if (_set.Count > 0)
            {
                MouseState state = Mouse.GetState(_window);

                Span<Entity> entities = stackalloc Entity[_set.Count];
                _set.CopyEntitiesTo(entities);

                foreach (Entity entity in entities)
                {
                    int offset = entity.Get<BallStart>().OffSet;
                    ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

                    drawInfo.Destination.X = MathHelper.Clamp(state.X - 50 + offset, offset, _window.ClientBounds.Width - 100 + offset);
                    drawInfo.Destination.Y = 540;

                    if (state.LeftButton == ButtonState.Pressed)
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
    }
}
