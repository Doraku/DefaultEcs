#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')
## EntityRuleBuilder.WithoutEither&lt;T&gt;() Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') without at least one component of the either group.  
```csharp
public DefaultEcs.EntityRuleBuilder.EitherBuilder WithoutEither<T>();
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-WithoutEither-T-()-T'></a>
`T`  
The type of component to add to the either group.  
  
#### Returns
[EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder')  
A [EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder') to create a either group.  
