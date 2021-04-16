#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilderExtension](EntityQueryBuilderExtension.md 'DefaultEcs.EntityQueryBuilderExtension')
## EntityQueryBuilderExtension.WhenAddedEither(EntityQueryBuilder, Type[]) Method
Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the given types is added.  
```csharp
public static DefaultEcs.EntityQueryBuilder WhenAddedEither(this DefaultEcs.EntityQueryBuilder builder, params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs_EntityQueryBuilderExtension_WhenAddedEither(DefaultEcs_EntityQueryBuilder_System_Type__)_builder'></a>
`builder` [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') on which to create the rule.
  
<a name='DefaultEcs_EntityQueryBuilderExtension_WhenAddedEither(DefaultEcs_EntityQueryBuilder_System_Type__)_componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.
  
#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').
