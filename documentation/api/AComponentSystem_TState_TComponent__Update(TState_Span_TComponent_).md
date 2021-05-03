#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.Update(TState, Span&lt;TComponent&gt;) Method
Update the given [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') once.  
```csharp
protected virtual void Update(TState state, System.Span<TComponent> components);
```
#### Parameters
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__Update(TState_System_Span_TComponent_)_state'></a>
`state` [TState](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')  
The state to use.
  
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__Update(TState_System_Span_TComponent_)_components'></a>
`components` [System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
The [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') to update.
  
