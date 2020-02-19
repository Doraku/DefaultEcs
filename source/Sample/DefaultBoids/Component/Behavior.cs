using Microsoft.Xna.Framework;

namespace DefaultBoids.Component
{
    public readonly struct Behavior
    {
        public readonly Vector2 Center;
        public readonly Vector2 Direction;
        public readonly int Count;

        public Behavior(Vector2 center, Vector2 direction, int count)
        {
            Center = center;
            Direction = direction;
            Count = count;
        }
    }
}
