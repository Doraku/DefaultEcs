#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityMap&lt;TKey&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;')
## EntityMap&lt;TKey&gt;.Complete() Method
Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](./DefaultEcs-EntityRuleBuilder-WhenAdded-T-().md 'DefaultEcs.EntityRuleBuilder.WhenAdded&lt;T&gt;()'), [WhenChanged&lt;T&gt;()](./DefaultEcs-EntityRuleBuilder-WhenChanged-T-().md 'DefaultEcs.EntityRuleBuilder.WhenChanged&lt;T&gt;()') or [WhenRemoved&lt;T&gt;()](./DefaultEcs-EntityRuleBuilder-WhenRemoved-T-().md 'DefaultEcs.EntityRuleBuilder.WhenRemoved&lt;T&gt;()')).  
Does nothing if it was created from a static filter.  
This method need to be called after current instance content has been processed in a update cycle.  
```csharp
public void Complete();
```
