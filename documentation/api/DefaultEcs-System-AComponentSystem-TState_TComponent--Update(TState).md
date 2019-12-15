#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.Update(TState) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-AComponentSystem-TState_TComponent--IsEnabled.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.IsEnabled') is false or if there is no component of type [TComponent](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') in the [World](./DefaultEcs-World.md 'DefaultEcs.World').  
```C#
public void Update(TState state);
```
#### Parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState)-state'></a>
`state` [TState](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md#DefaultEcs-System-AComponentSystem-TState_TComponent--TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')  
The state to use.  
  
