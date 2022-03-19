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
| [WhenAdded(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WhenAdded(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WhenAdded(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are added. |
| [WhenAddedEither(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WhenAddedEither(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WhenAddedEither(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is added. |
| [WhenChanged(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WhenChanged(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WhenChanged(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are changed. |
| [WhenChangedEither(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WhenChangedEither(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WhenChangedEither(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is changed. |
| [WhenRemoved(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WhenRemoved(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WhenRemoved(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are removed. |
| [WhenRemovedEither(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WhenRemovedEither(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WhenRemovedEither(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is removed. |
| [With(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.With(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.With(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with all component of the given types. |
| [WithEither(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WithEither(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WithEither(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the given types. |
| [Without(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.Without(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.Without(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to ignore [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the given types. |
| [WithoutEither(this EntityQueryBuilder, Type[])](EntityQueryBuilderExtension.WithoutEither(thisEntityQueryBuilder,Type[]).md 'DefaultEcs.EntityQueryBuilderExtension.WithoutEither(this DefaultEcs.EntityQueryBuilder, System.Type[])') | Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') without at least one component of the given types. |
