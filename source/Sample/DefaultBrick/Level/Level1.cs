using DefaultBrick.Component;
using DefaultBrick.Message;
using DefaultEcs;
using Microsoft.Xna.Framework;

namespace DefaultBrick.Level
{
    public static class Level1
    {
        private static void CreateBrick(World world, int x, int y)
        {
            Entity brick = world.CreateEntity();
            brick.Set(new DrawInfo
            {
                Color = Color.Red,
                Destination = new Rectangle(x, y, 40, 20)
            });
            brick.Set<Solid>(default);
            brick.Set<Breakable>(default);

            world.Publish<NewBrickMessage>(default);
        }

        public static void CreatePlayer(World world)
        {
            Entity player = world.CreateEntity();
            player.Set<PlayerInput>(default);
            player.Set<Solid>(default);
            player.Set<Bar>(default);
            player.Set(new DrawInfo
            {
                Color = Color.White,
                Destination = new Rectangle(0, 550, 100, 10)
            });
        }

        public static void Load(World world)
        {
            for (int i = 0; i < 19; ++i)
            {
                CreateBrick(world, 1 + i * 41, 1);
            }
            for (int i = 0; i < 19; ++i)
            {
                CreateBrick(world, 759 - i * 41, 22);
            }
            for (int i = 0; i < 19; ++i)
            {
                CreateBrick(world, 1 + i * 41, 43);
            }
            for (int i = 0; i < 19; ++i)
            {
                CreateBrick(world, 759 - i * 41, 64);
            }
        }
    }
}
