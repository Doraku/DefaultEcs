using System;
using DefaultEcs;
using DefaultBrick.Component;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultBrick.System
{
    public class DrawSystem : ISystem
    {
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;
        private readonly World _world;

        public DrawSystem(SpriteBatch batch, Texture2D square, World world)
        {
            _batch = batch;
            _square = square;
            _world = world;
        }

        public void Update(float elaspedTime)
        {
            _batch.Begin();

            Span<DrawInfo> drawInfos = _world.GetAllComponents<DrawInfo>();
            for (int i = 0; i < drawInfos.Length; ++i)
            {
                _batch.Draw(_square, drawInfos[i].Destination, drawInfos[i].Color);
            }

            _batch.End();
        }
    }
}
