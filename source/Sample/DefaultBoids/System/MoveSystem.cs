using System;
using DefaultBoids.Component;
using DefaultEcs;
using DefaultEcs.Command;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace DefaultBoids.System
{
    [With(typeof(DrawInfo), typeof(Velocity), typeof(Acceleration), typeof(GridId))]
    public sealed class MoveSystem : AEntitySystem<float>
    {
        private readonly World _world;
        private readonly EntityCommandRecorder _recorder;

        public MoveSystem(World world, IParallelRunner runner)
            : base(world, runner)
        {
            _world = world;
            _recorder = new EntityCommandRecorder();
        }

        protected override void Update(float state, ReadOnlySpan<Entity> entities)
        {
            Components<DrawInfo> drawInfos = _world.GetComponents<DrawInfo>();
            Components<Velocity> velocities = _world.GetComponents<Velocity>();
            Components<Acceleration> accelerations = _world.GetComponents<Acceleration>();
            Components<GridId> gridIds = _world.GetComponents<GridId>();

            foreach (ref readonly Entity entity in entities)
            {
                ref Vector2 velocity = ref velocities[entity].Value;

                velocity += accelerations[entity].Value * state;

                Vector2 direction = Vector2.Normalize(velocity);
                float speed = velocity.Length();

                velocity = Math.Clamp(speed, DefaultGame.MinVelocity, DefaultGame.MaxVelocity) * direction;

                ref DrawInfo drawInfo = ref drawInfos[entity];
                Vector2 newPosition = drawInfo.Position + (velocity * state);

                GridId newId = newPosition.ToGridId();
                if (!newId.Equals(gridIds[entity]))
                {
                    entity.Get<GridId>() = newId;
                    _recorder.Record(entity).NotifyChanged<GridId>();
                }
                drawInfo.Position = newPosition;

                if ((drawInfo.Position.X < 0 && velocity.X < 0)
                    || (drawInfo.Position.X > DefaultGame.ResolutionWidth && velocity.X > 0))
                {
                    velocity.X *= -1;
                }
                if ((drawInfo.Position.Y < 0 && velocity.Y < 0)
                    || (drawInfo.Position.Y > DefaultGame.ResolutionHeight && velocity.Y > 0))
                {
                    velocity.Y *= -1;
                }

                drawInfo.Rotation = MathF.Atan2(velocity.X, -velocity.Y);
            }
        }

        protected override void PostUpdate(float state) => _recorder.Execute(_world);

        public override void Dispose()
        {
            _recorder.Dispose();

            base.Dispose();
        }
    }
}
