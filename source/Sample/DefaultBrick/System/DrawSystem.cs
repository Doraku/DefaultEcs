using System;
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

        protected override void Update(float elaspedTime, Span<DrawInfo> components)
        {
            _batch.Begin();

            for (int i = 0; i < components.Length; ++i)
            {
                _batch.Draw(_square, components[i].Destination, components[i].Color);
            }

            _batch.End();
        }
    }
}
