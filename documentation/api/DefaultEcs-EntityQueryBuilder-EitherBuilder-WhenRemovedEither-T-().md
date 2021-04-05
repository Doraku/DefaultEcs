#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.WhenRemovedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the either group is removed.  
```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WhenRemovedEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntityQueryBuilder-EitherBuilder-WhenRemovedEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EntityQueryBuilder.EitherBuilder](./DefaultEcs-EntityQueryBuilder-EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.  
