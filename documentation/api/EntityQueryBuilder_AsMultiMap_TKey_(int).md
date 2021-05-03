#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')
## EntityQueryBuilder.AsMultiMap&lt;TKey&gt;(int) Method
Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntityMultiMap<TKey> AsMultiMap<TKey>(int capacity);
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_AsMultiMap_TKey_(int)_TKey'></a>
`TKey`  
The component type to use as key.
  
#### Parameters
<a name='DefaultEcs_EntityQueryBuilder_AsMultiMap_TKey_(int)_capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The initial number of element the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') can contain.
  
#### Returns
[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](EntityQueryBuilder_AsMultiMap_TKey_(int).md#DefaultEcs_EntityQueryBuilder_AsMultiMap_TKey_(int)_TKey 'DefaultEcs.EntityQueryBuilder.AsMultiMap&lt;TKey&gt;(int).TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')  
The [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').
