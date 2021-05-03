#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.PostUpdate(TState, TKey) Method
Performs a post-update per [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey') treatment.  
```csharp
protected virtual void PostUpdate(TState state, TKey key);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__PostUpdate(TState_TKey)_state'></a>
`state` [TState](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')  
The state to use.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__PostUpdate(TState_TKey)_key'></a>
`key` [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')  
The key of the [Entity](Entity.md 'DefaultEcs.Entity') instances which have been updated.
  
