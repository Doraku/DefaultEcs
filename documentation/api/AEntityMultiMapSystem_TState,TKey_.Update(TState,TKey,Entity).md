#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem<TState,TKey>.Update(TState, TKey, Entity) Method

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once.

```csharp
protected virtual void Update(TState state, in TKey key, in DefaultEcs.Entity entity);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,DefaultEcs.Entity).state'></a>

`state` [TState](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TState 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TState')

The state to use.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,DefaultEcs.Entity).key'></a>

`key` [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey')

The key of the current [Entity](Entity.md 'DefaultEcs.Entity').

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,DefaultEcs.Entity).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') instance to update.