#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.With&lt;T&gt;(ComponentPredicate&lt;T&gt;) Method
Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_EitherBuilder_With_T_(ComponentPredicate_T_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_With_T_(DefaultEcs_ComponentPredicate_T_)_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;).T') validating the given [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  
```csharp
public DefaultEcs.EntityQueryBuilder With<T>(DefaultEcs.ComponentPredicate<T> predicate);
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_With_T_(DefaultEcs_ComponentPredicate_T_)_T'></a>
`T`  
The type of component.
  
#### Parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_With_T_(DefaultEcs_ComponentPredicate_T_)_predicate'></a>
`predicate` [DefaultEcs.ComponentPredicate&lt;](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)')[T](EntityQueryBuilder_EitherBuilder_With_T_(ComponentPredicate_T_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_With_T_(DefaultEcs_ComponentPredicate_T_)_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;).T')[&gt;](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)')  
The [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)') which needs to be validated.
  
#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').
