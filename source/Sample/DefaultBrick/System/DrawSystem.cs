using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultBrick.System
{
    public class DrawSystem : AComponentSystem<float, DrawInfo>
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

        protected override void Update(float state, ref DrawInfo component) => _batch.Draw(_square, component.Destination, component.Color);

        protected override void PostUpdate(float state) => _batch.End();
    }
}
