#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.Update(TState, TComponent) Method
Update the given [TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') once.  
```C#
protected virtual void Update(TState state, ref TComponent component);
```
#### Parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_TComponent)-state'></a>
state [TState](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')  
The state to use.  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_TComponent)-component'></a>
component [TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent')  
The [TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') to update.  
