using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DefaultEcs.System;

namespace DefaultEcs.Technical.System
{
    internal static class EntitySetBuilderFactory
    {
        #region Fields

        private static readonly ConcurrentDictionary<Type, Func<World, EntitySetBuilder>> _entitySetBuilderFactories;
        private static readonly Dictionary<ComponentFilterType, MethodInfo> _filters;

        #endregion

        #region Initialisation

        static EntitySetBuilderFactory()
        {
            _entitySetBuilderFactories = new ConcurrentDictionary<Type, Func<World, EntitySetBuilder>>();

            TypeInfo entitySetBuilder = typeof(EntitySetBuilder).GetTypeInfo();

            _filters = new Dictionary<ComponentFilterType, MethodInfo>
            {
                [ComponentFilterType.With] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.With)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WithEither] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WithEither)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.Without] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.Without)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WithoutEither] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WithoutEither)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WhenAdded] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WhenAdded)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WhenAddedEither] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WhenAddedEither)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WhenChanged] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WhenChanged)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WhenChangedEither] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WhenChangedEither)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WhenRemoved] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WhenRemoved)).First(m => !m.ContainsGenericParameters),
                [ComponentFilterType.WhenRemovedEither] = entitySetBuilder.GetDeclaredMethods(nameof(EntitySetBuilder.WhenRemovedEither)).First(m => !m.ContainsGenericParameters)
            };
        }

        #endregion

        #region Methods

        private static Func<World, EntitySetBuilder> GetEntitySetBuilderFactory(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();

            ParameterExpression world = Expression.Parameter(typeof(World));
            Expression expression = Expression.Call(world, typeof(World).GetTypeInfo().GetDeclaredMethod(typeInfo.GetCustomAttribute<DisabledAttribute>() == null ? nameof(World.GetEntities) : nameof(World.GetDisabledEntities)));

            foreach (ComponentAttribute attribute in typeInfo.GetCustomAttributes<ComponentAttribute>(true))
            {
                expression = Expression.Call(expression, _filters[attribute.FilterType], Expression.Constant(attribute.ComponentTypes));
            }

            return Expression.Lambda<Func<World, EntitySetBuilder>>(expression, world).Compile();
        }

        public static Func<World, EntitySetBuilder> Create(Type type) => _entitySetBuilderFactories.GetOrAdd(type, GetEntitySetBuilderFactory);

        #endregion
    }
}
