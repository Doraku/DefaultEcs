#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.Update(TState) Method
Updates the system once.  
Does nothing if [IsEnabled](AComponentSystem_TState_TComponent__IsEnabled.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.IsEnabled') is false or if there is no component of type [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') in the [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World').  
```csharp
public void Update(TState state);
```
#### Parameters
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__Update(TState)_state'></a>
`state` [TState](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')  
The state to use.
  

Implements [Update(T)](ISystem_T__Update(T).md 'DefaultEcs.System.ISystem&lt;T&gt;.Update(T)')  
