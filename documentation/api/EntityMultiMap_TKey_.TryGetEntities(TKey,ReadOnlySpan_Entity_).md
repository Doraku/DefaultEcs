#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')

## EntityMultiMap<TKey>.TryGetEntities(TKey, ReadOnlySpan<Entity>) Method

Gets the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key.

```csharp
public bool TryGetEntities(TKey key, out System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters

<a name='DefaultEcs.EntityMultiMap_TKey_.TryGetEntities(TKey,System.ReadOnlySpan_DefaultEcs.Entity_).key'></a>

`key` [TKey](EntityMultiMap_TKey_.md#DefaultEcs.EntityMultiMap_TKey_.TKey 'DefaultEcs.EntityMultiMap<TKey>.TKey')

The key of the [Entity](Entity.md 'DefaultEcs.Entity') instances to get.

<a name='DefaultEcs.EntityMultiMap_TKey_.TryGetEntities(TKey,System.ReadOnlySpan_DefaultEcs.Entity_).entities'></a>

`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')

When this method returns, contains the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key, if the key is found; otherwise, the type default value. This parameter is passed uninitialized.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') contains [Entity](Entity.md 'DefaultEcs.Entity') instances with the specified key; otherwise, false.