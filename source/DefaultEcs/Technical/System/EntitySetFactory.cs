using System;
using System.Collections.Concurrent;
using System.Reflection;
using DefaultEcs.System;

namespace DefaultEcs.Technical.System
{
    internal static class EntitySetFactory
    {
        #region Fields

        private static readonly ConcurrentDictionary<Type, Func<World, EntitySet>> _entitySetFactories;

        #endregion

        #region Initialisation

        static EntitySetFactory()
        {
            _entitySetFactories = new ConcurrentDictionary<Type, Func<World, EntitySet>>();
        }

        #endregion

        #region Methods

        private static Func<World, EntitySet> GetEntitySetFactory(Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();

            Func<EntityRuleBuilder, EntityRuleBuilder> builderAction = b => b;

            foreach (ComponentAttribute attribute in typeInfo.GetCustomAttributes<ComponentAttribute>(true))
            {
                builderAction += attribute.FilterType switch
                {
                    ComponentFilterType.With => b => b.With(attribute.ComponentTypes),
                    ComponentFilterType.WithEither => b => b.WithEither(attribute.ComponentTypes),
                    ComponentFilterType.Without => b => b.Without(attribute.ComponentTypes),
                    ComponentFilterType.WithoutEither => b => b.WithoutEither(attribute.ComponentTypes),
                    ComponentFilterType.WhenAdded => b => b.WhenAdded(attribute.ComponentTypes),
                    ComponentFilterType.WhenAddedEither => b => b.WhenAddedEither(attribute.ComponentTypes),
                    ComponentFilterType.WhenChanged => b => b.WhenChanged(attribute.ComponentTypes),
                    ComponentFilterType.WhenChangedEither => b => b.WhenChangedEither(attribute.ComponentTypes),
                    ComponentFilterType.WhenRemoved => b => b.WhenRemoved(attribute.ComponentTypes),
                    ComponentFilterType.WhenRemovedEither => b => b.WhenRemovedEither(attribute.ComponentTypes),
                    _ => null
                };
            }

            bool enabled = typeInfo.GetCustomAttribute<DisabledAttribute>() is null;

            return w => builderAction(enabled ? w.GetEntities() : w.GetDisabledEntities()).AsSet();
        }

        public static Func<World, EntitySet> Create(Type type) => _entitySetFactories.GetOrAdd(type, GetEntitySetFactory);

        #endregion
    }
}
