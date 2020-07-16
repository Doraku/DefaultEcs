using System;
using System.Threading;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    [With(typeof(Velocity), typeof(DrawInfo))]
    public sealed class SetBehaviorSystem : AEntitiesSystem<float, GridId>
    {
        private readonly World _world;
        private readonly EntityMap<GridId> _map;
        private readonly (Vector2 center, Vector2 direction, int count)[] _temp;

        private int _updateCount;

        public SetBehaviorSystem(World world, IParallelRunner runner)
            : base(world, runner, 1)
        {
            _world = world;
            _map = world.GetEntities().With<Behavior>().AsMap<GridId>();
            _temp = new (Vector2 center, Vector2 direction, int count)[runner?.DegreeOfParallelism ?? 1];
        }

        protected override void PreUpdate(float state, GridId key)
        {
            _updateCount = 0;
        }

        protected override void Update(float state, in GridId key, ReadOnlySpan<Entity> entities)
        {
            Components<Velocity> velocities = _world.GetComponents<Velocity>();
            Components<DrawInfo> drawInfos = _world.GetComponents<DrawInfo>();

            Vector2 center = Vector2.Zero;
            Vector2 direction = Vector2.Zero;

            foreach (ref readonly Entity entity in entities)
            {
                center += drawInfos[entity].Position;
                direction += velocities[entity].Value;
            }

            _temp[Interlocked.Increment(ref _updateCount) - 1] = (center, direction, entities.Length);
        }

        protected override void PostUpdate(float state, GridId key)
        {
            Vector2 center = Vector2.Zero;
            Vector2 direction = Vector2.Zero;
            int count = 0;

            for (int i = 0; i < _updateCount; ++i)
            {
                center += _temp[i].center;
                direction += _temp[i].direction;
                count += _temp[i].count;
            }

            _map[key].Get<Behavior>() = new Behavior(center, direction, count);
        }

        public override void Dispose()
        {
            _map.Dispose();

            base.Dispose();
        }
    }
}
