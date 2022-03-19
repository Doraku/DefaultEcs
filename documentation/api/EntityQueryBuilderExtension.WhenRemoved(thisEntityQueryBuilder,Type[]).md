#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilderExtension](EntityQueryBuilderExtension.md 'DefaultEcs.EntityQueryBuilderExtension')

## EntityQueryBuilderExtension.WhenRemoved(this EntityQueryBuilder, Type[]) Method

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') when all component of the given types are removed.

```csharp
public static DefaultEcs.EntityQueryBuilder WhenRemoved(this DefaultEcs.EntityQueryBuilder builder, params System.Type[] componentTypes);
```
#### Parameters

<a name='DefaultEcs.EntityQueryBuilderExtension.WhenRemoved(thisDefaultEcs.EntityQueryBuilder,System.Type[]).builder'></a>

`builder` [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')

The [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') on which to create the rule.

<a name='DefaultEcs.EntityQueryBuilderExtension.WhenRemoved(thisDefaultEcs.EntityQueryBuilder,System.Type[]).componentTypes'></a>

`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The types of component.

#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').