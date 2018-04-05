using System.IO;
using DefaultEcs;
using DefaultSlap.Component;
using DefaultSlap.Message;
using DefaultSlap.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace DefaultSlap
{
    public class DefaultGame : Game
    {
        #region Fields

        private readonly GraphicsDeviceManager _deviceManager;
        private readonly SpriteBatch _batch;
        private readonly Texture2D _square;
        private readonly SoundEffect _slapSound;
        private readonly SoundEffect _bounceSound;
        private readonly ISystem[] _systems;

        private World _world;

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
            _slapSound = Content.Load<SoundEffect>("Slap");
            _bounceSound = Content.Load<SoundEffect>("Jump");

            _world = new World(1000);

            _world.SetComponentTypeMaximumCount<PlayerState>(1);

            _systems = new ISystem[]
            {
                new PlayerSystem(Window, _world),
                new HitSystem(_world),
                new GameSystem(_world),
                new AISystem(_world),
                new PositionSystem(_world),
                new DrawSystem(_batch, _square, _world)
            };

            Entity player = _world.CreateEntity();
            player.Set<PlayerState>(default);
            player.Set<Position>(default);
            player.Set(new DrawInfo(new Point(100, 100), Color.Yellow, 1));

            _world.Subscribe<SlapMessage>(On);
            _world.Subscribe<PlayerHitMessage>(On);
        }

        #endregion

        #region Callbacks

        private void On(in SlapMessage message)
        {
            _slapSound.Play();
        }

        private void On(in PlayerHitMessage message)
        {
            _bounceSound.Play();
        }

        #endregion

        #region Game

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

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
            _slapSound.Dispose();
            _bounceSound.Dispose();
            _square.Dispose();
            _batch.Dispose();
            _deviceManager.Dispose();

            base.Dispose(disposing);
        }

        #endregion
    }
}
