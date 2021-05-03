#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')
## EntityQueryBuilder.WhenRemovedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is removed.  
```csharp
public DefaultEcs.EntityQueryBuilder.EitherBuilder WhenRemovedEither<T>();
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_WhenRemovedEither_T_()_T'></a>
`T`  
The type of component to add to the either group.
  
#### Returns
[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')  
A [EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') to create a either group.
