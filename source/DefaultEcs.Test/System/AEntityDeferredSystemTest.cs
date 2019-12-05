using System;
using DefaultEcs.Command;
using DefaultEcs.System;
using DefaultEcs.Threading;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.System
{
    public sealed class AEntityDeferredSystemTest
    {
        [WhenAddedEither(typeof(bool), typeof(short))]
        [WhenChangedEither(typeof(bool), typeof(short))]
        [WithoutEither(typeof(int), typeof(double))]
        private sealed class System : AEntityDeferredSystem<int>
        {
            public System(World world, EntitySet set, IParallelRunner runner)
                : base(world, set, runner)
            { }

            public System(World world, IParallelRunner runner)
                : base(world, runner)
            { }

            protected override void Update(int state, in EntityRecord entity)
            {
                entity.Remove<bool>();
            }
        }

        [Fact]
        public void AEntitySystem_Should_throw_ArgumentNullException_When_World_is_null()
        {
            Check.ThatCode(() => new System(default, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void AEntitySystem_Should_throw_ArgumentNullException_When_EntitySet_is_null()
        {
            using World world = new World();

            Check.ThatCode(() => new System(world, default, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void Update_Should_call_update()
        {
            using IParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);
            using World world = new World();
            using EntitySet set = world.GetEntities().WithEither<bool>().Or<short>().AsSet();
            using System system = new System(world, runner);

            for (int i = 0; i < 100; ++i)
            {
                world.CreateEntity().Set(true);
            }

            Check.That(set.Count).IsEqualTo(100);

            system.Update(42);

            Check.That(set.Count).IsZero();
        }
    }
}
