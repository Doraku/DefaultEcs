#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.WhenAddedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the either group is added.  
```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WhenAddedEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntityQueryBuilder-EitherBuilder-WhenAddedEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.  
