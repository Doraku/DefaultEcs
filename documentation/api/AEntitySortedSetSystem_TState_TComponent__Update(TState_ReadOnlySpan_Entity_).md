#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;')
## AEntitySortedSetSystem&lt;TState,TComponent&gt;.Update(TState, ReadOnlySpan&lt;Entity&gt;) Method
Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.  
```csharp
protected virtual void Update(TState state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__Update(TState_System_ReadOnlySpan_DefaultEcs_Entity_)_state'></a>
`state` [TState](AEntitySortedSetSystem_TState_TComponent_.md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TState 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.TState')  
The state to use.
  
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__Update(TState_System_ReadOnlySpan_DefaultEcs_Entity_)_entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](Entity.md 'DefaultEcs.Entity') instances to update.
  
