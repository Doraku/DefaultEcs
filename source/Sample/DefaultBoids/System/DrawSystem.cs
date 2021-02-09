using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultBoids.System
{
    public sealed class DrawSystem : AComponentSystem<SpriteBatch, DrawInfo>
    {
        private readonly Texture2D _square;
        private readonly World _world;
        private readonly IParallelRunner _runner;

        public DrawSystem(Texture2D square, World world, IParallelRunner runner)
            : base(world)
        {
            _square = square;
            _world = world;
            _runner = runner;
        }

        protected override void PreUpdate(SpriteBatch state) => state.Begin();

        protected override void Update(SpriteBatch state, Span<DrawInfo> components)
        {
            foreach (ref DrawInfo component in components)
            {
                state.Draw(_square, component.Position, null, component.Color, component.Rotation, new Vector2(.5f), component.Size, SpriteEffects.None, 0f);
            }
        }

        protected override void PostUpdate(SpriteBatch state) => _world.Optimize(_runner, state.End);
    }
}
