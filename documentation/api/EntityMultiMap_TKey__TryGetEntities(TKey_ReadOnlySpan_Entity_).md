#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')
## EntityMultiMap&lt;TKey&gt;.TryGetEntities(TKey, ReadOnlySpan&lt;Entity&gt;) Method
Gets the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key.  
```csharp
public bool TryGetEntities(TKey key, out System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs_EntityMultiMap_TKey__TryGetEntities(TKey_System_ReadOnlySpan_DefaultEcs_Entity_)_key'></a>
`key` [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey')  
The key of the [Entity](Entity.md 'DefaultEcs.Entity') instances to get.
  
<a name='DefaultEcs_EntityMultiMap_TKey__TryGetEntities(TKey_System_ReadOnlySpan_DefaultEcs_Entity_)_entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
When this method returns, contains the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key, if the key is found; otherwise, the type default value. This parameter is passed uninitialized.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') contains [Entity](Entity.md 'DefaultEcs.Entity') instances with the specified key; otherwise, false.
