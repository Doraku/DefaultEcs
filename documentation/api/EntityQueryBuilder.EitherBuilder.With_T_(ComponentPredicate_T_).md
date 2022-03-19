#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.With<T>(ComponentPredicate<T>) Method

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder.EitherBuilder.With_T_(ComponentPredicate_T_).md#DefaultEcs.EntityQueryBuilder.EitherBuilder.With_T_(DefaultEcs.ComponentPredicate_T_).T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With<T>(DefaultEcs.ComponentPredicate<T>).T') validating the given [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate<T>(T)').

```csharp
public DefaultEcs.EntityQueryBuilder With<T>(DefaultEcs.ComponentPredicate<T> predicate);
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.With_T_(DefaultEcs.ComponentPredicate_T_).T'></a>

`T`

The type of component.
#### Parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.With_T_(DefaultEcs.ComponentPredicate_T_).predicate'></a>

`predicate` [DefaultEcs.ComponentPredicate&lt;](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate<T>(T)')[T](EntityQueryBuilder.EitherBuilder.With_T_(ComponentPredicate_T_).md#DefaultEcs.EntityQueryBuilder.EitherBuilder.With_T_(DefaultEcs.ComponentPredicate_T_).T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With<T>(DefaultEcs.ComponentPredicate<T>).T')[&gt;](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate<T>(T)')

The [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate<T>(T)') which needs to be validated.

#### Returns
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')  
The current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').