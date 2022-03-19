#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')

## EntityQueryBuilder.WithEither<T>() Method

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the either group.

```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WithEither<T>();
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.WithEither_T_().T'></a>

`T`

The type of component to add to the either group.

#### Returns
[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.