#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.WhenRemovedEither<T>() Method

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is removed.

```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WhenRemovedEither<T>();
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemovedEither_T_().T'></a>

`T`

The type of component to add to the either group.

#### Returns
[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.