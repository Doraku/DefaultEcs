#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')
## EntitySet.Complete() Method
Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](./DefaultEcs-EntitySetBuilder-WhenAdded-T-().md 'DefaultEcs.EntitySetBuilder.WhenAdded&lt;T&gt;()'), [WhenChanged&lt;T&gt;()](./DefaultEcs-EntitySetBuilder-WhenChanged-T-().md 'DefaultEcs.EntitySetBuilder.WhenChanged&lt;T&gt;()') or [WhenRemoved&lt;T&gt;()](./DefaultEcs-EntitySetBuilder-WhenRemoved-T-().md 'DefaultEcs.EntitySetBuilder.WhenRemoved&lt;T&gt;()')).  
Does nothing if it was created from a static filter.  
This method need to be called after current instance content has been processed in a update cycle.  
```C#
public void Complete();
```
