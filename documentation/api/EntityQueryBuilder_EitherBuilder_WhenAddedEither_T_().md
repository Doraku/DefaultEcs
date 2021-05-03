#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.WhenAddedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is added.  
```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WhenAddedEither<T>();
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_WhenAddedEither_T_()_T'></a>
`T`  
The type of component to add to the either group.
  
#### Returns
[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.
