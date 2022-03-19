#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>')

## EntityMap<TKey>.TryGetEntity(TKey, Entity) Method

Gets the [Entity](Entity.md 'DefaultEcs.Entity') associated with the specified key.

```csharp
public bool TryGetEntity(TKey key, out DefaultEcs.Entity entity);
```
#### Parameters

<a name='DefaultEcs.EntityMap_TKey_.TryGetEntity(TKey,DefaultEcs.Entity).key'></a>

`key` [TKey](EntityMap_TKey_.md#DefaultEcs.EntityMap_TKey_.TKey 'DefaultEcs.EntityMap<TKey>.TKey')

The key of the [Entity](Entity.md 'DefaultEcs.Entity') to get.

<a name='DefaultEcs.EntityMap_TKey_.TryGetEntity(TKey,DefaultEcs.Entity).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

When this method returns, contains the [Entity](Entity.md 'DefaultEcs.Entity') associated with the specified key, if the key is found; otherwise, an invalid [Entity](Entity.md 'DefaultEcs.Entity'). This parameter is passed uninitialized.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>') contains an [Entity](Entity.md 'DefaultEcs.Entity') with the specified key; otherwise, false.