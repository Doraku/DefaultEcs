using System;
using System.IO;
using DefaultEcs;
using DefaultEcs.System;
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
        private readonly World _world;
        private readonly ISystem<float> _system;
        private readonly SystemRunner<float> _runner;

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

            _world.SetMaximumComponentCount<PlayerState>(1);

            _runner = new SystemRunner<float>(Environment.ProcessorCount);
            _system = new SequentialSystem<float>(
                new PlayerSystem(Window, _world),
                new HitSystem(_world),
                new GameSystem(_world),
                new AISystem(_world, _runner),
                new PositionSystem(_world, _runner),
                new DrawSystem(_batch, _square, _world));

            Entity player = _world.CreateEntity();
            player.Set<PlayerState>(default);
            player.Set<Position>(default);
            player.Set(new DrawInfo(new Point(100, 100), Color.Yellow, 1));

            _world.Subscribe(this);
        }

        #endregion

        #region Callbacks
#pragma warning disable IDE0051 // Remove unused private members

        [Subscribe]
        private void On(in SlapMessage _) => _slapSound.Play();

        [Subscribe]
        private void On(in PlayerHitMessage _) => _bounceSound.Play();

#pragma warning restore IDE0051 // Remove unused private members
        #endregion

        #region Game

        protected override void Update(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _system.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw(GameTime gameTime) { }

        protected override void Dispose(bool disposing)
        {
            _runner.Dispose();
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
