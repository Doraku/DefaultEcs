#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')
## EntityMap&lt;TKey&gt;.TryGetEntity(TKey, Entity) Method
Gets the [Entity](Entity.md 'DefaultEcs.Entity') associated with the specified key.  
```csharp
public bool TryGetEntity(TKey key, out DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs_EntityMap_TKey__TryGetEntity(TKey_DefaultEcs_Entity)_key'></a>
`key` [TKey](EntityMap_TKey_.md#DefaultEcs_EntityMap_TKey__TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey')  
The key of the [Entity](Entity.md 'DefaultEcs.Entity') to get.
  
<a name='DefaultEcs_EntityMap_TKey__TryGetEntity(TKey_DefaultEcs_Entity)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
When this method returns, contains the [Entity](Entity.md 'DefaultEcs.Entity') associated with the specified key, if the key is found; otherwise, an invalid [Entity](Entity.md 'DefaultEcs.Entity'). This parameter is passed uninitialized.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') contains an [Entity](Entity.md 'DefaultEcs.Entity') with the specified key; otherwise, false.
