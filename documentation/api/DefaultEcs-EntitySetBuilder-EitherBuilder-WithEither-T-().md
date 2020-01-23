#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').[EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder')
## EitherBuilder.WithEither&lt;T&gt;() Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with at least one component of the either group.  
```csharp
public DefaultEcs.EntitySetBuilder.EitherBuilder WithEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntitySetBuilder-EitherBuilder-WithEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder')  
A [EitherBuilder](./DefaultEcs-EntitySetBuilder-EitherBuilder.md 'DefaultEcs.EntitySetBuilder.EitherBuilder') to create a either group.  
