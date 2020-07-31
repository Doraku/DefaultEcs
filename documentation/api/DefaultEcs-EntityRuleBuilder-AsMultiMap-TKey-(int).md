#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')
## EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(int) Method
Returns an [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntitiesMap<TKey> AsMultiMap<TKey>(int capacity);
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int)-TKey'></a>
`TKey`  
The component type to use as key.  
  
#### Parameters
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int)-capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The initial number of element the [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') can contain.  
  
#### Returns
[DefaultEcs.EntitiesMap&lt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')[TKey](#DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int)-TKey 'DefaultEcs.EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(int).TKey')[&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')  
The [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;').  
