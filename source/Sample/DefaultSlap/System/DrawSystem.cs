using DefaultEcs;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultSlap.System
{
    public class DrawSystem : ISystem
    {
        private readonly EntitySet _set;
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;

        public DrawSystem(SpriteBatch batch, Texture2D square, World world)
        {
            _batch = batch;
            _square = square;
            _set = world.GetEntities().With<Position>().With<DrawInfo>().Build();
        }

        public void Update(float elaspedTime)
        {
            _batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            foreach (Entity entity in _set.GetEntities())
            {
                Point position = entity.Get<Position>().Value;
                DrawInfo drawInfo = entity.Get<DrawInfo>();

                _batch.Draw(_square, new Rectangle(position - drawInfo.Size / new Point(2), drawInfo.Size), null, drawInfo.Color, 0, Vector2.Zero, SpriteEffects.None, drawInfo.ZIndex ?? 0f);
            }

            _batch.End();
        }
    }
}
