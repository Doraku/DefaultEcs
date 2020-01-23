#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')
## EntitySetBuilder.WhenAddedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the either group is added.  
```csharp
public DefaultEcs.EntitySetBuilder.EitherBuilder WhenAddedEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntitySetBuilder-WhenAddedEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder')  
A [EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder') to create a either group.  
