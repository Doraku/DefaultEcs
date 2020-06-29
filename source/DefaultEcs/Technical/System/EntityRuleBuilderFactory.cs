using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using DefaultEcs.System;

namespace DefaultEcs.Technical.System
{
    internal static class EntityRuleBuilderFactory
    {
        #region Fields

        private static readonly MethodInfo _withPredicate;
        private static readonly ConcurrentDictionary<Type, Func<object, World, EntityRuleBuilder>> _entityRuleBuilderFactories;

        #endregion

        #region Initialisation

        static EntityRuleBuilderFactory()
        {
            _withPredicate = typeof(EntityRuleBuilder).GetTypeInfo().GetDeclaredMethods(nameof(EntityRuleBuilder.With)).Single(m => m.GetParameters().Length == 1);
            _entityRuleBuilderFactories = new ConcurrentDictionary<Type, Func<object, World, EntityRuleBuilder>>();
        }

        #endregion

        #region Methods

        private static Func<object, World, EntityRuleBuilder> GetEntityRuleBuilderFactory(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();

            Func<object, EntityRuleBuilder, EntityRuleBuilder> builderAction = (_, b) => b;

            foreach (ComponentAttribute attribute in typeInfo.GetCustomAttributes<ComponentAttribute>(true))
            {
                builderAction += attribute.FilterType switch
                {
                    ComponentFilterType.With => (_, b) => b.With(attribute.ComponentTypes),
                    ComponentFilterType.WithEither => (_, b) => b.WithEither(attribute.ComponentTypes),
                    ComponentFilterType.Without => (_, b) => b.Without(attribute.ComponentTypes),
                    ComponentFilterType.WithoutEither => (_, b) => b.WithoutEither(attribute.ComponentTypes),
                    ComponentFilterType.WhenAdded => (_, b) => b.WhenAdded(attribute.ComponentTypes),
                    ComponentFilterType.WhenAddedEither => (_, b) => b.WhenAddedEither(attribute.ComponentTypes),
                    ComponentFilterType.WhenChanged => (_, b) => b.WhenChanged(attribute.ComponentTypes),
                    ComponentFilterType.WhenChangedEither => (_, b) => b.WhenChangedEither(attribute.ComponentTypes),
                    ComponentFilterType.WhenRemoved => (_, b) => b.WhenRemoved(attribute.ComponentTypes),
                    ComponentFilterType.WhenRemovedEither => (_, b) => b.WhenRemovedEither(attribute.ComponentTypes),
                    _ => null
                };
            }

            while (type != null)
            {
                foreach (MethodInfo method in type.GetTypeInfo().DeclaredMethods.Where(m => m.GetCustomAttribute<WithPredicateAttribute>(false) != null))
                {
                    ParameterInfo[] parameters = method.GetParameters();

                    if (parameters.Length != 1
                        || !parameters[0].ParameterType.IsByRef
                        || method.ReturnType != typeof(bool))
                    {
                        throw new NotSupportedException($"Can't apply {nameof(WithPredicateAttribute)} to \"{method.Name}\": method is not of type {nameof(ComponentPredicate<object>)}.");
                    }

                    Type argType = parameters[0].ParameterType.GetElementType();

                    builderAction += (o, b) => (EntityRuleBuilder)_withPredicate.MakeGenericMethod(argType).Invoke(
                        b,
                        new object[]
                        {
                            method.IsStatic
                                ? method.CreateDelegate(typeof(ComponentPredicate<>).MakeGenericType(argType))
                                : method.CreateDelegate(typeof(ComponentPredicate<>).MakeGenericType(argType), o)
                        });
                }

                type = type.GetTypeInfo().BaseType;
            }

            bool enabled = typeInfo.GetCustomAttribute<DisabledAttribute>() is null;

            return (o, w) => builderAction(o, enabled ? w.GetEntities() : w.GetDisabledEntities());
        }

        public static Func<object, World, EntityRuleBuilder> Create(Type type) => _entityRuleBuilderFactories.GetOrAdd(type, GetEntityRuleBuilderFactory);

        #endregion
    }
}
