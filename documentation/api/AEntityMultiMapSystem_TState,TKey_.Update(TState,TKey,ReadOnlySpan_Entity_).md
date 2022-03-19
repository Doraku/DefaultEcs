#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem<TState,TKey>.Update(TState, TKey, ReadOnlySpan<Entity>) Method

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.

```csharp
protected virtual void Update(TState state, in TKey key, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,System.ReadOnlySpan_DefaultEcs.Entity_).state'></a>

`state` [TState](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TState 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TState')

The state to use.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,System.ReadOnlySpan_DefaultEcs.Entity_).key'></a>

`key` [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey')

The key of the current [Entity](Entity.md 'DefaultEcs.Entity') instances.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,System.ReadOnlySpan_DefaultEcs.Entity_).entities'></a>

`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')

The [Entity](Entity.md 'DefaultEcs.Entity') instances to update.