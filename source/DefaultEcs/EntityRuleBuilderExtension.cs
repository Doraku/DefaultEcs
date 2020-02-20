using System;
using System.Linq;
using System.Reflection;

namespace DefaultEcs
{
    /// <summary>
    /// Provides set of static methods to create more easily rules on a <see cref="EntityRuleBuilder"/> instance.
    /// </summary>
    public static class EntityRuleBuilderExtension
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

        static EntityRuleBuilderExtension()
        {
            _with = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethods(nameof(EntityRuleBuilder.With)).Single(m => m.GetParameters().Length == 0);
            _without = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.Without));
            _whenAdded = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WhenAdded));
            _whenChanged = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WhenChanged));
            _whenRemoved = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WhenRemoved));
            _withEither = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WithEither));
            _withoutEither = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WithoutEither));
            _whenAddedEither = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WhenAddedEither));
            _whenChangedEither = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WhenChangedEither));
            _whenRemovedEither = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.WhenRemovedEither));
            _or = typeof(EntityRuleBuilder.EitherBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.EitherBuilder.Or));
            _commit = typeof(EntityRuleBuilder.EitherBuilder).GetTypeInfo().GetDeclaredMethod(nameof(EntityRuleBuilder.EitherBuilder.Commit));
        }

        #endregion

        #region Methods

        private static EntityRuleBuilder Simple(EntityRuleBuilder builder, Type[] componentTypes, MethodInfo method)
        {
            foreach (Type componentType in componentTypes)
            {
                method.MakeGenericMethod(componentType).Invoke(builder, null);
            }

            return builder;
        }

        private static EntityRuleBuilder Either(EntityRuleBuilder builder, Type[] componentTypes, MethodInfo method)
        {
            EntityRuleBuilder.EitherBuilder eitherBuilder = null;

            foreach (Type componentType in componentTypes)
            {
                if (eitherBuilder is null)
                {
                    eitherBuilder = (EntityRuleBuilder.EitherBuilder)method.MakeGenericMethod(componentType).Invoke(builder, null);
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
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder With(this EntityRuleBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _with);

        /// <summary>
        /// Makes a rule to ignore <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder Without(this EntityRuleBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _without);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are added.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WhenAdded(this EntityRuleBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenAdded);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are changed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WhenChanged(this EntityRuleBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenChanged);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when all component of the given types are removed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WhenRemoved(this EntityRuleBuilder builder, params Type[] componentTypes) => Simple(builder, componentTypes, _whenRemoved);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WithEither(this EntityRuleBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _withEither);

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> without at least one component of the given types.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WithoutEither(this EntityRuleBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _withoutEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is added.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WhenAddedEither(this EntityRuleBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenAddedEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is changed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WhenChangedEither(this EntityRuleBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenChangedEither);

        /// <summary>
        /// Makes a rule to observe <see cref="Entity"/> when one component of the given types is removed.
        /// </summary>
        /// <param name="builder">The <see cref="EntityRuleBuilder"/> on which to create the rule.</param>
        /// <param name="componentTypes">The types of component.</param>
        /// <returns>The current <see cref="EntityRuleBuilder"/>.</returns>
        public static EntityRuleBuilder WhenRemovedEither(this EntityRuleBuilder builder, params Type[] componentTypes) => Either(builder, componentTypes, _whenRemovedEither);

        #endregion
    }
}
