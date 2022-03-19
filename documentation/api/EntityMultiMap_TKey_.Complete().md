#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')

## EntityMultiMap<TKey>.Complete() Method

Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder.WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded<T>()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder.WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged<T>()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder.WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved<T>()')).  
Does nothing if it was created from a static filter.  
This method need to be called after current instance content has been processed in a update cycle.

```csharp
public void Complete();
```