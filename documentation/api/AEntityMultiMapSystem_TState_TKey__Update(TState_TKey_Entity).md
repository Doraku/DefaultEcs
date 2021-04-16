#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState, TKey, Entity) Method
Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once.  
```csharp
protected virtual void Update(TState state, in TKey key, in DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_DefaultEcs_Entity)_state'></a>
`state` [TState](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')  
The state to use.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_DefaultEcs_Entity)_key'></a>
`key` [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')  
The key of the current [Entity](Entity.md 'DefaultEcs.Entity').
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_DefaultEcs_Entity)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The [Entity](Entity.md 'DefaultEcs.Entity') instance to update.
  
