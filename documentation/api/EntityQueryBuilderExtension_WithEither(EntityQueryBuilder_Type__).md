#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilderExtension](EntityQueryBuilderExtension.md 'DefaultEcs.EntityQueryBuilderExtension')
## EntityQueryBuilderExtension.WithEither(EntityQueryBuilder, Type[]) Method
Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the given types.  
```csharp
public static DefaultEcs.EntityQueryBuilder WithEither(this DefaultEcs.EntityQueryBuilder builder, params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs_EntityQueryBuilderExtension_WithEither(DefaultEcs_EntityQueryBuilder_System_Type__)_builder'></a>
`builder` [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') on which to create the rule.
  
<a name='DefaultEcs_EntityQueryBuilderExtension_WithEither(DefaultEcs_EntityQueryBuilder_System_Type__)_componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.
  
#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').
