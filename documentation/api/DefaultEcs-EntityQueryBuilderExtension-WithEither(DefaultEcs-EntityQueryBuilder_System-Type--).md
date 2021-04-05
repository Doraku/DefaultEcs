#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityQueryBuilderExtension](./DefaultEcs-EntityQueryBuilderExtension.md 'DefaultEcs.EntityQueryBuilderExtension')
## EntityQueryBuilderExtension.WithEither(DefaultEcs.EntityQueryBuilder, System.Type[]) Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with at least one component of the given types.  
```csharp
public static DefaultEcs.EntityQueryBuilder WithEither(this DefaultEcs.EntityQueryBuilder builder, params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntityQueryBuilderExtension-WithEither(DefaultEcs-EntityQueryBuilder_System-Type--)-builder'></a>
`builder` [EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The [EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') on which to create the rule.  
  
<a name='DefaultEcs-EntityQueryBuilderExtension-WithEither(DefaultEcs-EntityQueryBuilder_System-Type--)-componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.  
  
#### Returns
[EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').  
