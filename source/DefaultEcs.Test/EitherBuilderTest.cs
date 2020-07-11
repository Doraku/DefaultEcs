using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public sealed class EitherBuilderTest
    {
        [Fact]
        public void With_Should_return_EntitySetBuilder()
        {
            using World world = new World();

            EntityRuleBuilder builder = world.GetEntities();

            Check.That(builder.WithEither<bool>().With<int>()).IsEqualTo(builder);
        }

        [Fact]
        public void Without_Should_return_EntitySetBuilder()
        {
            using World world = new World();

            EntityRuleBuilder builder = world.GetEntities();

            Check.That(builder.WithEither<bool>().Without<int>()).IsEqualTo(builder);
        }

        [Fact]
        public void WhenAdded_Should_return_EntitySetBuilder()
        {
            using World world = new World();

            EntityRuleBuilder builder = world.GetEntities();

            Check.That(builder.WithEither<bool>().WhenAdded<int>()).IsEqualTo(builder);
        }

        [Fact]
        public void WhenChanged_Should_return_EntitySetBuilder()
        {
            using World world = new World();

            EntityRuleBuilder builder = world.GetEntities();

            Check.That(builder.WithEither<bool>().WhenChanged<int>()).IsEqualTo(builder);
        }

        [Fact]
        public void WhenRemoved_Should_return_EntitySetBuilder()
        {
            using World world = new World();

            EntityRuleBuilder builder = world.GetEntities();

            Check.That(builder.WithEither<bool>().WhenRemoved<int>()).IsEqualTo(builder);
        }

        [Fact]
        public void WithEither_Should_return_new_EitherBuilder()
        {
            using World world = new World();

            EntityRuleBuilder.EitherBuilder builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.WithEither<bool>()).IsNotEqualTo(builder);
        }

        [Fact]
        public void WithoutEither_Should_return_new_EitherBuilder()
        {
            using World world = new World();

            EntityRuleBuilder.EitherBuilder builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.WithoutEither<bool>()).IsNotEqualTo(builder);
        }

        [Fact]
        public void WhenAddedEither_Should_return_new_EitherBuilder()
        {
            using World world = new World();

            EntityRuleBuilder.EitherBuilder builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.WhenAddedEither<bool>()).IsNotEqualTo(builder);
        }

        [Fact]
        public void WhenChangedEither_Should_return_new_EitherBuilder()
        {
            using World world = new World();

            EntityRuleBuilder.EitherBuilder builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.WhenChangedEither<bool>()).IsNotEqualTo(builder);
        }

        [Fact]
        public void WhenRemovedEither_Should_return_new_EitherBuilder()
        {
            using World world = new World();

            EntityRuleBuilder.EitherBuilder builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.WhenRemovedEither<bool>()).IsNotEqualTo(builder);
        }

        [Fact]
        public void Or_Should_return_self()
        {
            using World world = new World();

            EntityRuleBuilder.EitherBuilder builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.Or<bool>()).IsEqualTo(builder);

            builder = world.GetEntities().WithEither<bool>();

            Check.That(builder.Or<bool>()).IsEqualTo(builder);

            builder = world.GetEntities().WithoutEither<bool>();

            Check.That(builder.Or<bool>()).IsEqualTo(builder);

            builder = world.GetEntities().WhenAddedEither<bool>();

            Check.That(builder.Or<bool>()).IsEqualTo(builder);

            builder = world.GetEntities().WhenChangedEither<bool>();

            Check.That(builder.Or<bool>()).IsEqualTo(builder);

            builder = world.GetEntities().WhenRemovedEither<bool>();

            Check.That(builder.Or<bool>()).IsEqualTo(builder);
        }

        [Fact]
        public void Copy_Should_return_different_instance()
        {
            using World world = new World();

            EntityRuleBuilder builder = world.GetEntities();
            EntityRuleBuilder copy = builder.WithEither<bool>().Copy();

            Check.That(copy).IsNotEqualTo(builder);
        }
    }
}
