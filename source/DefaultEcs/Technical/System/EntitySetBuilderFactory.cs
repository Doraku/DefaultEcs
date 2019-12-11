using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using DefaultEcs.System;

namespace DefaultEcs.Technical.System
{
    internal static class EntitySetBuilderFactory
    {
        #region Fields

        private static readonly ConcurrentDictionary<Type, Func<World, EntitySetBuilder>> _entitySetBuilderFactories;
        private static readonly Dictionary<ComponentFilterType, Func<EntitySetBuilder, Type[], EntitySetBuilder>> _actions;

        #endregion

        #region Initialisation

        static EntitySetBuilderFactory()
        {
            _entitySetBuilderFactories = new ConcurrentDictionary<Type, Func<World, EntitySetBuilder>>();

            TypeInfo entitySetBuilder = typeof(EntitySetBuilder).GetTypeInfo();

            _actions = new Dictionary<ComponentFilterType, Func<EntitySetBuilder, Type[], EntitySetBuilder>>
            {
                [ComponentFilterType.With] = EntitySetBuilderExtension.With,
                [ComponentFilterType.WithEither] = EntitySetBuilderExtension.WithEither,
                [ComponentFilterType.Without] = EntitySetBuilderExtension.Without,
                [ComponentFilterType.WithoutEither] = EntitySetBuilderExtension.WithoutEither,
                [ComponentFilterType.WhenAdded] = EntitySetBuilderExtension.WhenAdded,
                [ComponentFilterType.WhenAddedEither] = EntitySetBuilderExtension.WhenAddedEither,
                [ComponentFilterType.WhenChanged] = EntitySetBuilderExtension.WhenChanged,
                [ComponentFilterType.WhenChangedEither] = EntitySetBuilderExtension.WhenChangedEither,
                [ComponentFilterType.WhenRemoved] = EntitySetBuilderExtension.WhenRemoved,
                [ComponentFilterType.WhenRemovedEither] = EntitySetBuilderExtension.WhenRemovedEither
            };
        }

        #endregion

        #region Methods

        private static Func<World, EntitySetBuilder> GetEntitySetBuilderFactory(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();

            Func<EntitySetBuilder, EntitySetBuilder> builderAction = b => b;

            foreach (ComponentAttribute attribute in typeInfo.GetCustomAttributes<ComponentAttribute>(true))
            {
                builderAction += b => _actions[attribute.FilterType](b, attribute.ComponentTypes);
            }

            bool enabled = typeInfo.GetCustomAttribute<DisabledAttribute>() is null;

            return w => builderAction(enabled ? w.GetEntities() : w.GetDisabledEntities());
        }

        public static Func<World, EntitySetBuilder> Create(Type type) => _entitySetBuilderFactories.GetOrAdd(type, GetEntitySetBuilderFactory);

        #endregion
    }
}
