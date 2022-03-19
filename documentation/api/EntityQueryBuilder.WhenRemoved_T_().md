#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')

## EntityQueryBuilder.WhenRemoved<T>() Method

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder.WhenRemoved_T_().md#DefaultEcs.EntityQueryBuilder.WhenRemoved_T_().T 'DefaultEcs.EntityQueryBuilder.WhenRemoved<T>().T') is removed.

```csharp
public DefaultEcs.EntityQueryBuilder WhenRemoved<T>();
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.WhenRemoved_T_().T'></a>

`T`

The type of component.

#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').