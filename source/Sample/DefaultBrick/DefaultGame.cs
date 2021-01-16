using System;
using System.IO;
using DefaultBrick.Level;
using DefaultBrick.Message;
using DefaultBrick.System;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultBrick
{
    public class DefaultGame : Game
    {
        #region Fields

        private readonly GraphicsDeviceManager _deviceManager;
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;
        private readonly SoundEffect _breakSound;
        private readonly SoundEffect _bounceSound;
        private readonly World _world;
        private readonly DefaultParallelRunner _runner;
        private readonly ISystem<float> _system;

        #endregion

        #region Initialisation

        public DefaultGame()
        {
            _deviceManager = new GraphicsDeviceManager(this);
            IsFixedTimeStep = true;
            _deviceManager.GraphicsProfile = GraphicsProfile.HiDef;
            _deviceManager.IsFullScreen = false;
            _deviceManager.PreferredBackBufferWidth = 800;
            _deviceManager.PreferredBackBufferHeight = 600;
            _deviceManager.ApplyChanges();
            GraphicsDevice.RasterizerState = RasterizerState.CullCounterClockwise;
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            Content.RootDirectory = "Content";

            _batch = new SpriteBatch(GraphicsDevice);
            using (Stream stream = File.OpenRead(@"Content\square.png"))
            {
                _square = Texture2D.FromStream(GraphicsDevice, stream);
            }
            _breakSound = Content.Load<SoundEffect>("Slap");
            _bounceSound = Content.Load<SoundEffect>("Jump");

            _world = new World(1000);

            _runner = new DefaultParallelRunner(Environment.ProcessorCount);
            _system = new SequentialSystem<float>(
                new GameSystem(_world),
                new PlayerSystem(_world, Window),
                new BallToBarSystem(_world, Window),
                new VelocitySystem(_world, _runner),
                new CollisionSystem(_world),
                new BallBoundSystem(_world),
                new PositionSystem(_world, _runner),
                new DrawSystem(_batch, _square, _world));

            _world.Subscribe(this);

            Level1.CreatePlayer(_world);
        }

        #endregion

        #region Callbacks

        [Subscribe]
        private void On(in BrickBrokenMessage _) => _breakSound.Play();

        [Subscribe]
        private void On(in BarBounceMessage _) => _bounceSound.Play();

        #endregion

        #region Game

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _system.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw(GameTime gameTime) { }

        protected override void Dispose(bool disposing)
        {
            _runner.Dispose();
            _world.Dispose();
            _system.Dispose();
            _breakSound.Dispose();
            _bounceSound.Dispose();
            _square.Dispose();
            _batch.Dispose();
            _deviceManager.Dispose();

            base.Dispose(disposing);
        }

        #endregion
    }
}
