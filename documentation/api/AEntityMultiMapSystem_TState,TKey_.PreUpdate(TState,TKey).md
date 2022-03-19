#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem<TState,TKey>.PreUpdate(TState, TKey) Method

Performs a pre-update per [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey') treatment.

```csharp
protected virtual void PreUpdate(TState state, TKey key);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.PreUpdate(TState,TKey).state'></a>

`state` [TState](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TState 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TState')

The state to use.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.PreUpdate(TState,TKey).key'></a>

`key` [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey')

The key of the [Entity](Entity.md 'DefaultEcs.Entity') instances about to be updated.