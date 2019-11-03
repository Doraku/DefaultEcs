#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.Update(TState, System.Span&lt;TComponent&gt;) Method
Update the given [TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') once.  
```C#
protected virtual void Update(TState state, System.Span<TComponent> components);
```
#### Parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_System-Span-TComponent-)-state'></a>
`state` [TState](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')  
The state to use.  
  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_System-Span-TComponent-)-components'></a>
`components` [System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
The [TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') to update.  
  
