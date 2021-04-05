#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.WithoutEither&lt;T&gt;() Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') without at least one component of the either group.  
```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WithoutEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntityQueryBuilder-EitherBuilder-WithoutEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.  
