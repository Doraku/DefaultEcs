using System.Diagnostics.CodeAnalysis;
using DefaultEcs.Technical.Command;

namespace DefaultEcs
{
    /// <summary>
    /// Provides a set of methods to help the generation of generic code for AoT compilation.
    /// </summary>
    public static class AoTHelper
    {
        /// <summary>
        /// Registers the type <typeparamref name="T"/> so <see cref="SubscribeAttribute"/> can freely be used on method like the delegate <see cref="MessageHandler{T}"/> to automatically subscribe when using <see cref="IPublisherExtension"/> on a <see cref="World"/> instance.
        /// </summary>
        /// <typeparam name="T">The type of message.</typeparam>
        public static void RegisterMessage<T>()
        {
            using World world = new World();

            world.Subscribe(default(MessageHandler<T>));
        }

        /// <summary>
        /// Registers the type <typeparamref name="T"/> so it can freely be used in <see cref="System.ComponentAttribute"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void RegisterComponent<T>()
        {
            static bool Filter(in T _) => true;

            Filter(default);

            new EntityRuleBuilder(default, default)
                .With<T>().WithEither<T>().Or<T>().WithEither<T>().With<T>().With<T>(Filter).WithEither<T>().With<T>(Filter)
                .Without<T>().WithoutEither<T>().Or<T>().WithoutEither<T>().Without<T>()
                .WhenAdded<T>().WhenAddedEither<T>().Or<T>().WhenAddedEither<T>().WhenAdded<T>()
                .WhenChanged<T>().WhenChangedEither<T>().Or<T>().WhenChangedEither<T>().WhenChanged<T>()
                .WhenRemoved<T>().WhenRemovedEither<T>().Or<T>().WhenRemovedEither<T>().WhenRemoved<T>();
        }

        /// <summary>
        /// Registers the unmanaged type <typeparamref name="T"/> so it can freely be used in <see cref="System.ComponentAttribute"/> and by <see cref="Command.EntityRecord.Set{T}(in T)"/>.
        /// </summary>
        /// <typeparam name="T">The type of component.</typeparam>
        public static void RegisterUnmanagedComponent<T>()
            where T : unmanaged
        {
            RegisterComponent<T>();

            using World world = new World();

            Entity entity = world.CreateEntity();

            unsafe
            {
                T value;

                UnmanagedComponentCommand<T>.WriteComponent(default, (byte*)&value, default);
                UnmanagedComponentCommand<T>.SetComponent(entity, default, (byte*)&value);
            }
        }
    }
}
