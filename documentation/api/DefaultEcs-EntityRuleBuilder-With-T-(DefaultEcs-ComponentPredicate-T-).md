#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')
## EntityRuleBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;) Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with a component of type [T](#DefaultEcs-EntityRuleBuilder-With-T-(DefaultEcs-ComponentPredicate-T-)-T 'DefaultEcs.EntityRuleBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;).T') validating the given [ComponentPredicate&lt;T&gt;(T)](./DefaultEcs-ComponentPredicate-T-(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  
```csharp
public DefaultEcs.EntityRuleBuilder With<T>(DefaultEcs.ComponentPredicate<T> predicate);
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-With-T-(DefaultEcs-ComponentPredicate-T-)-T'></a>
`T`  
The type of component.  
  
#### Parameters
<a name='DefaultEcs-EntityRuleBuilder-With-T-(DefaultEcs-ComponentPredicate-T-)-predicate'></a>
`predicate` [DefaultEcs.ComponentPredicate&lt;](./DefaultEcs-ComponentPredicate-T-(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)')[T](#DefaultEcs-EntityRuleBuilder-With-T-(DefaultEcs-ComponentPredicate-T-)-T 'DefaultEcs.EntityRuleBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;).T')[&gt;](./DefaultEcs-ComponentPredicate-T-(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)')  
The [ComponentPredicate&lt;T&gt;(T)](./DefaultEcs-ComponentPredicate-T-(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)') which needs to be validated.  
  
#### Returns
[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')  
The current [EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder').  
