using DefaultEcs.System;
using DefaultSlap.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultSlap.System
{
    public sealed partial class DrawSystem : AEntitySetSystem<float>
    {
        [ConstructorParameter]
        private readonly SpriteBatch _batch;

        [ConstructorParameter]
        private readonly Texture2D _square;

        protected override void PreUpdate(float state) => _batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

        [Update]
        private void Update(in Position position, in DrawInfo drawInfo)
        {
            _batch.Draw(_square, new Rectangle(position.Value - (drawInfo.Size / new Point(2)), drawInfo.Size), null, drawInfo.Color, 0, Vector2.Zero, SpriteEffects.None, drawInfo.ZIndex ?? 0f);
        }

        protected override void PostUpdate(float state) => _batch.End();
    }
}
