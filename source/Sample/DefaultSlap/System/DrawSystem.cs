using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultSlap.System
{
    [With<Position>, With<DrawInfo>]
    public sealed class DrawSystem : AEntitySetSystem<float>
    {
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;

        public DrawSystem(World world, SpriteBatch batch, Texture2D square)
            : base(world)
        {
            _batch = batch;
            _square = square;
        }

        protected override void PreUpdate(float state) => _batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

        protected override void Update(float state, in Entity entity)
        {
            Position position = entity.Get<Position>();
            DrawInfo drawInfo = entity.Get<DrawInfo>();

            _batch.Draw(_square, new Rectangle(position.Value - (drawInfo.Size / new Point(2)), drawInfo.Size), null, drawInfo.Color, 0, Vector2.Zero, SpriteEffects.None, drawInfo.ZIndex ?? 0f);
        }

        protected override void PostUpdate(float state) => _batch.End();
    }
}
