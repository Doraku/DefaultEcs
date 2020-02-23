#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')
## EntitiesMap&lt;TKey&gt;.TryGetEntities(TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;) Method
Gets the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances associated with the specified key.  
```csharp
public bool TryGetEntities(TKey key, out System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-EntitiesMap-TKey--TryGetEntities(TKey_System-ReadOnlySpan-DefaultEcs-Entity-)-key'></a>
`key` [TKey](./DefaultEcs-EntitiesMap-TKey-.md#DefaultEcs-EntitiesMap-TKey--TKey 'DefaultEcs.EntitiesMap&lt;TKey&gt;.TKey')  
The key of the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to get.  
  
<a name='DefaultEcs-EntitiesMap-TKey--TryGetEntities(TKey_System-ReadOnlySpan-DefaultEcs-Entity-)-entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
When this method returns, contains the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances associated with the specified key, if the key is found; otherwise, the type default value. This parameter is passed uninitialized.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') contains [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with the specified key; otherwise, false.  
