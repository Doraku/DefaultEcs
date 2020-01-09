using System;
using System.Diagnostics;
using System.IO;
using DefaultBoids.Component;
using DefaultBoids.System;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultBoids
{
    public class DefaultGame : Game
    {
        #region Fields

        private readonly GraphicsDeviceManager _deviceManager;
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;
        private readonly World _world;
        private readonly DefaultParallelRunner _runner;
        private readonly ISystem<float> _system;
        private readonly Stopwatch _watch;

        private int _frameCount;

        #endregion

        #region Initialisation

        public DefaultGame()
        {
            _deviceManager = new GraphicsDeviceManager(this);
            IsFixedTimeStep = false;
            _deviceManager.GraphicsProfile = GraphicsProfile.HiDef;
            _deviceManager.IsFullScreen = false;
            _deviceManager.PreferredBackBufferWidth = 800;
            _deviceManager.PreferredBackBufferHeight = 600;
            _deviceManager.SynchronizeWithVerticalRetrace = false;
            _deviceManager.ApplyChanges();
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            Content.RootDirectory = "Content";

            _batch = new SpriteBatch(GraphicsDevice);
            using (Stream stream = File.OpenRead(@"Content\square.png"))
            {
                _square = Texture2D.FromStream(GraphicsDevice, stream);
            }

            _world = new World();

            _runner = new DefaultParallelRunner(Environment.ProcessorCount);
            _system = new SequentialSystem<float>(
                new BoidsSystem(_world, _runner),
                new MoveSystem(_world, _runner),
                new DrawSystem(_batch, _square, _world));

            Random random = new Random();

            for (int i = 0; i < 1000; ++i)
            {
                Entity entity = _world.CreateEntity();
                entity.Set(new DrawInfo
                {
                    Color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1f),
                    Position = new Vector2((float)random.NextDouble() * _deviceManager.PreferredBackBufferWidth, (float)random.NextDouble() * _deviceManager.PreferredBackBufferHeight),
                    Size = new Vector2(random.Next(5, 10), random.Next(20, 30)),
                });
                entity.Set(new Velocity { Value = new Vector2(100, 0) });
                entity.Set<Acceleration>();
            }

            _watch = Stopwatch.StartNew();
        }

        #endregion

        #region Game

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _system.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            if (++_frameCount >= 100)
            {
                Window.Title = (100d / _watch.Elapsed.TotalSeconds).ToString();
                _frameCount = 0;
                _watch.Restart();
            }
        }

        protected override void Draw(GameTime gameTime) { }

        protected override void Dispose(bool disposing)
        {
            _runner.Dispose();
            _world.Dispose();
            _system.Dispose();
            _square.Dispose();
            _batch.Dispose();
            _deviceManager.Dispose();

            base.Dispose(disposing);
        }

        #endregion
    }
}
