using Microsoft.Xna.Framework;

namespace DefaultBoids.Component
{
    public readonly record struct Behavior(
        Vector2 Center,
        Vector2 Direction,
        int Count);
}
