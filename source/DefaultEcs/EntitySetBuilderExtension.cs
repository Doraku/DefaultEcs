using System;
using System.Reflection;

namespace DefaultEcs
{
    /// <summary>
    /// Provides set of static methods to create more easily rules on a <see cref="EntitySetBuilder"/> instance.
    /// </summary>
    public static class EntitySetBuilderExtension
    {
        #region Fields

        private static readonly MethodInfo _with;
        private static readonly MethodInfo _without;
        private static readonly MethodInfo _whenAdded;
        private static readonly MethodInfo _whenChanged;
        private static readonly MethodInfo _whenRemoved;
        private static readonly MethodInfo _withEither;
        private static readonly MethodInfo _withoutEither;
        private static readonly MethodInfo _whenAddedEither;
        private static readonly MethodInfo _whenChangedEither;
        private static readonly MethodInfo _whenRemovedEither;
        private static readonly MethodInfo _or;
        private static readonly MethodInfo _commit;

        #endregion

        #region Initialisation

        static EntitySetBuilderExtension()
        {
            _with = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.With));
            _without = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.Without));
            _whenAdded = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WhenAdded));
            _whenChanged = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WhenChanged));
            _whenRemoved = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WhenRemoved));
            _withEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WithEither));
            _withoutEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WithoutEither));
            _whenAddedEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WhenAddedEither));
            _whenChangedEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WhenChangedEither));
            _whenRemovedEither = typeof(EntitySetBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.WhenRemovedEither));
            _or = typeof(EntitySetBuilder.EitherBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.EitherBuilder.Or));
            _commit = typeof(EntitySetBuilder.EitherBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntitySetBuilder.EitherBuilder.Commit));
        }

        #endregion

        #region Methods

        private static EntitySetBuilder Simple(EntitySetBuilder builder, Type[] componentTypes, MethodInfo method)
        {
            foreach (Type componentType in componentTypes)
            {
                method.MakeGenericMethod(componentType).Invoke(builder, null);
            }

            return builder;
        }

        private static EntitySetBuilder Either(EntitySetBuilder builder, Type[] componentTypes, MethodInfo method)
        {
            EntitySetBuilder.EitherBuilder eitherBuilder = null;

            foreach (Type componentType in componentTypes)
            {
                if (eitherBuilder is null)
                {
                    eitherBuilder = (EntitySetBuilder.EitherBuilder)method.MakeGenericMethod(componentType).Invoke(builder, null);
                }
                else
                {
                    _or.MakeGenericMethod(componentType).Invoke(eitherBuilder, null);
                }
            }

            if (eitherBuilder != null)
            {
                _commit.Invoke(eitherBuilder, null);
            }

            return builder;
        }

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with all component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder With(this EntitySetBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _with);

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder Without(this EntitySetBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _without);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are added.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenAdded(this EntitySetBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenAdded);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are changed.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenChanged(this EntitySetBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenChanged);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are removed.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenRemoved(this EntitySetBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenRemoved);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WithEither(this EntitySetBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _withEither);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> without at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WithoutEither(this EntitySetBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _withoutEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is added.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenAddedEither(this EntitySetBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenAddedEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is changed.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenChangedEither(this EntitySetBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenChangedEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is removed.
        /// </summary>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenRemovedEither(this EntitySetBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenRemovedEither);

        #endregion
    }
}
