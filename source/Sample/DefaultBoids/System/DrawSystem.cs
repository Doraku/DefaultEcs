using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultBoids.System
{
    public sealed class DrawSystem : AComponentSystem<float, DrawInfo>
    {
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;

        public DrawSystem(SpriteBatch batch, Texture2D square, World world)
            : base(world)
        {
            _batch = batch;
            _square = square;
        }

        protected override void PreUpdate(float state) => _batch.Begin();

        protected override void Update(float state, Span<DrawInfo> components)
        {
            foreach (ref DrawInfo component in components)
            {
                _batch.Draw(_square, component.Position, null, component.Color, component.Rotation, new Vector2(.5f), component.Size, SpriteEffects.None, 0f);
            }
        }

        protected override void PostUpdate(float state) => _batch.End();
    }
}
