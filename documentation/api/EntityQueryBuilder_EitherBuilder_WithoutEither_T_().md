#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.WithoutEither&lt;T&gt;() Method
Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') without at least one component of the either group.  
```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WithoutEither<T>();
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_WithoutEither_T_()_T'></a>
`T`  
The type of component to add to the either group.
  
#### Returns
[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.
