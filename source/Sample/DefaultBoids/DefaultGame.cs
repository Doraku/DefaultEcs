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

        public const int BoidsCount = 1000;

        public const int ResolutionWidth = 800;
        public const int ResolutionHeight = 600;

        public const float BehaviorSeparationWeight = 210;
        public const float BehaviorAlignmentWeight = 2;
        public const float BehaviorCohesionWeight = 3;

        public const float NeighborRange = 100;

        public const float MinVelocity = 80;
        public const float MaxVelocity = 100;

        private readonly GraphicsDeviceManager _deviceManager;
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;
        private readonly World _world;
        private readonly DefaultParallelRunner _runner;
        private readonly ISystem<float> _system;
        private readonly ISystem<float> _drawSystem;
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
            _deviceManager.PreferredBackBufferWidth = ResolutionWidth;
            _deviceManager.PreferredBackBufferHeight = ResolutionHeight;
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
                new MoveSystem(_world, _runner));

            _drawSystem = new DrawSystem(_batch, _square, _world);

            Random random = new Random();

            for (int i = 0; i < BoidsCount; ++i)
            {
                Entity entity = _world.CreateEntity();
                entity.Set(new DrawInfo
                {
                    Color = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1f),
                    Position = new Vector2((float)random.NextDouble() * _deviceManager.PreferredBackBufferWidth, (float)random.NextDouble() * _deviceManager.PreferredBackBufferHeight),
                    Size = new Vector2(random.Next(3, 6), random.Next(10, 15)),
                });
                entity.Set(new Velocity { Value = new Vector2(MinVelocity, 0) });
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

        protected override void Draw(GameTime gameTime) => _drawSystem.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

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
