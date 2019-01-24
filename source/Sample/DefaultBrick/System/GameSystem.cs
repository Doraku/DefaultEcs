using System;
using DefaultBrick.Component;
using DefaultBrick.Level;
using DefaultBrick.Message;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public class GameSystem : ISystem<float>
    {
        private readonly Random _random;
        private readonly World _world;

        private int _ballCount;
        private int _brickCount;

        public GameSystem(World world)
        {
            _random = new Random();
            _world = world;

            _world.Subscribe(this);
        }

        [Subscribe]
        private void On(in BallDroppedMessage _)
        {
            --_ballCount;
        }

        [Subscribe]
        private void On(in BrickBrokenMessage _)
        {
            --_brickCount;
        }

        [Subscribe]
        private void On(in NewBrickMessage _)
        {
            ++_brickCount;
        }

        public void Update(float state)
        {
            if (_brickCount == 0)
            {
                Level1.Load(_world);
            }

            if (_ballCount == 0)
            {
                Entity ball = _world.CreateEntity();
                ball.Set<Ball>(default);
                ball.Set(new DrawInfo
                {
                    Color = Color.Yellow,
                    Destination = new Rectangle(0, 0, 10, 10)
                });
                ball.Set(new BallStart
                {
                    OffSet = _random.Next(10, 80)
                });

                ++_ballCount;
            }
        }

        public void Dispose() { }
    }
}
