#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')
## EntityRuleBuilder.WhenAddedEither&lt;T&gt;() Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the either group is added.  
```csharp
public DefaultEcs.EntityRuleBuilder.EitherBuilder WhenAddedEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-WhenAddedEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder')  
A [EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder') to create a either group.  
