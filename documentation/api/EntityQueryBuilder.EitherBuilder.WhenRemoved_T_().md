#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.WhenRemoved<T>() Method

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder.EitherBuilder.WhenRemoved_T_().md#DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemoved_T_().T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemoved<T>().T') is removed.

```csharp
public DefaultEcs.EntityQueryBuilder WhenRemoved<T>();
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemoved_T_().T'></a>

`T`

The type of component.

#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').