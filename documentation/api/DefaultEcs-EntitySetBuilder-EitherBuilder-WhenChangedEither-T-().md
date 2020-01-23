#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').[EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder')
## EitherBuilder.WhenChangedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the either group is changed.  
```csharp
public DefaultEcs.EntitySetBuilder.EitherBuilder WhenChangedEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntitySetBuilder-EitherBuilder-WhenChangedEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder')  
A [EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder') to create a either group.  
