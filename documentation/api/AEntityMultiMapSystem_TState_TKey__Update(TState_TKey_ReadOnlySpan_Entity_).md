#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState, TKey, ReadOnlySpan&lt;Entity&gt;) Method
Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.  
```csharp
protected virtual void Update(TState state, in TKey key, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_System_ReadOnlySpan_DefaultEcs_Entity_)_state'></a>
`state` [TState](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')  
The state to use.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_System_ReadOnlySpan_DefaultEcs_Entity_)_key'></a>
`key` [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')  
The key of the current [Entity](Entity.md 'DefaultEcs.Entity') instances.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_System_ReadOnlySpan_DefaultEcs_Entity_)_entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](Entity.md 'DefaultEcs.Entity') instances to update.
  
