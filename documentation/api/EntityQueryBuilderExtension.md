#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## EntityQueryBuilderExtension Class
Provides set of static methods to create more easily rules on a [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') instance.  
```csharp
public static class EntityQueryBuilderExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityQueryBuilderExtension  

| Methods | |
| :--- | :--- |
| [WhenAdded(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WhenAdded(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WhenAdded(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are added.<br/> |
| [WhenAddedEither(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WhenAddedEither(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WhenAddedEither(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is added.<br/> |
| [WhenChanged(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WhenChanged(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WhenChanged(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are changed.<br/> |
| [WhenChangedEither(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WhenChangedEither(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WhenChangedEither(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is changed.<br/> |
| [WhenRemoved(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WhenRemoved(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WhenRemoved(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are removed.<br/> |
| [WhenRemovedEither(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WhenRemovedEither(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WhenRemovedEither(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is removed.<br/> |
| [With(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_With(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.With(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with all component of the given types.<br/> |
| [WithEither(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WithEither(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WithEither(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the given types.<br/> |
| [Without(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_Without(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.Without(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to ignore [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the given types.<br/> |
| [WithoutEither(EntityQueryBuilder, Type[])](EntityQueryBuilderExtension_WithoutEither(EntityQueryBuilder_Type__).md 'DefaultEcs.EntityQueryBuilderExtension.WithoutEither(DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') without at least one component of the given types.<br/> |
