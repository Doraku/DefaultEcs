using System;
using DefaultEcs;
using DefaultEcs.System;
using DefaultSlap.Component;
using DefaultSlap.Message;

namespace DefaultSlap.System
{
    public class HitSystem : ISystem<float>
    {
        private readonly World _world;

        public HitSystem(World world)
        {
            _world = world;
        }

        public void Update(float elaspedTime)
        {
            Span<HitDelay> hits = _world.GetAllComponents<HitDelay>();
            for (int i = 0; i < hits.Length; ++i)
            {
                ref HitDelay hit = ref hits[i];
                if ((hit.Current -= elaspedTime) <= 0f)
                {
                    hit.Current = hit.Delay;
                    _world.Publish(new PlayerHitMessage());
                }
            }
        }
    }
}
