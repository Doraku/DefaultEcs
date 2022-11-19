using System;
using System.Linq;
using System.Reflection;

namespace DefaultEcs
{
    /// <summary>
    /// Provides set of static methods to create more easily rules on a <see cref="EntityQueryBuilder"/> instance.
    /// </summary>
    public static class EntityQueryBuilderExtension
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

        static EntityQueryBuilderExtension()
        {
            _with = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethods(nameof(EntityQueryBuilder.With)).Single(m => m.GetParameters().Length == 0);
            _without = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.Without));
            _whenAdded = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WhenAdded));
            _whenChanged = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WhenChanged));
            _whenRemoved = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WhenRemoved));
            _withEither = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WithEither));
            _withoutEither = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WithoutEither));
            _whenAddedEither = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WhenAddedEither));
            _whenChangedEither = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WhenChangedEither));
            _whenRemovedEither = typeof(EntityQueryBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.WhenRemovedEither));
            _or = typeof(EntityQueryBuilder.EitherBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.EitherBuilder.Or));
            _commit = typeof(EntityQueryBuilder.EitherBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityQueryBuilder.EitherBuilder.Commit));
        }

        #endregion

        #region Methods

        private static EntityQueryBuilder Simple(EntityQueryBuilder builder, Type[] componentTypes, MethodInfo method)
        {
            foreach (Type componentType in componentTypes.ThrowIfNull())
            {
                method.MakeGenericMethod(componentType).Invoke(builder, null);
            }

            return builder;
        }

        private static EntityQueryBuilder Either(EntityQueryBuilder builder, Type[] componentTypes, MethodInfo method)
        {
            EntityQueryBuilder.EitherBuilder eitherBuilder = null;

            foreach (Type componentType in componentTypes.ThrowIfNull())
            {
                if (eitherBuilder is null)
                {
                    eitherBuilder = (EntityQueryBuilder.EitherBuilder)method.MakeGenericMethod(componentType).Invoke(builder, null);
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
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder With(this EntityQueryBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _with);

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder Without(this EntityQueryBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _without);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are added.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WhenAdded(this EntityQueryBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenAdded);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are changed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WhenChanged(this EntityQueryBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenChanged);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are removed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WhenRemoved(this EntityQueryBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenRemoved);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WithEither(this EntityQueryBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _withEither);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> without at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WithoutEither(this EntityQueryBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _withoutEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is added.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WhenAddedEither(this EntityQueryBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenAddedEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is changed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WhenChangedEither(this EntityQueryBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenChangedEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is removed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityQueryBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityQueryBuilder"/>.</returns>
        public static EntityQueryBuilder WhenRemovedEither(this EntityQueryBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenRemovedEither);

        #endregion
    }
}
