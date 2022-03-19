#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.WithoutEither<T>() Method

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') without at least one component of the either group.

```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WithoutEither<T>();
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.WithoutEither_T_().T'></a>

`T`

The type of component to add to the either group.

#### Returns
[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.