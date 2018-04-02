using System.IO;
using DefaultBrick.Level;
using DefaultBrick.Message;
using DefaultBrick.System;
using DefaultEcs;
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
        private readonly ISystem[] _systems;

        private World _world;

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

            _systems = new ISystem[]
            {
                new GameSystem(_world),
                new PlayerSystem(Window, _world),
                new BallToBarSystem(Window, _world),
                new VelocitySystem(_world),
                new CollisionSystem(_world),
                new BallBoundSystem(_world),
                new PositionSystem(_world),
                new DrawSystem(_batch, _square, _world)
            };

            _world.Subscribe<BrickBrokenMessage>(On);
            _world.Subscribe<BarBounceMessage>(On);

            Level1.CreatePlayer(_world);
        }

        #endregion

        #region Callbacks

        private void On(in BrickBrokenMessage message)
        {
            _breakSound.Play();
        }

        private void On(in BarBounceMessage message)
        {
            _bounceSound.Play();
        }

        #endregion

        #region Game

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            float elaspedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (ISystem system in _systems)
            {
                system.Update(elaspedTime);
            }
        }

        protected override void Draw(GameTime gameTime) { }

        protected override void Dispose(bool disposing)
        {
            _world.Dispose();
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
