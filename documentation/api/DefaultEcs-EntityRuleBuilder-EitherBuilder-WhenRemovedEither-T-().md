#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder').[EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder')
## EntityRuleBuilder.EitherBuilder.WhenRemovedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the either group is removed.  
```csharp
public DefaultEcs.EntityRuleBuilder.EitherBuilder WhenRemovedEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-EitherBuilder-WhenRemovedEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder')  
A [EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder') to create a either group.  
