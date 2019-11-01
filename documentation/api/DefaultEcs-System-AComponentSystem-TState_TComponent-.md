#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AComponentSystem&lt;TState,TComponent&gt; Class
Represents a base class to process updates on a given [World](./DefaultEcs-World.md 'DefaultEcs.World') instance to all its components of type [TComponent](#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent').  
```C#
public abstract class AComponentSystem<TState,TComponent>
```
#### Type parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--TState'></a>
`TState`  
The type of the object used as state to update the system.  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent'></a>
`TComponent`  
The type of component to update.  
### Constructors
- [AComponentSystem(DefaultEcs.World)](./DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World)')
- [AComponentSystem(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;)](./DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-System-SystemRunner-TState-).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-AComponentSystem-TState_TComponent--IsEnabled.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AComponentSystem-TState_TComponent--Dispose().md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Dispose()')
- [Update(TState, TComponent)](./DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_TComponent).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState, TComponent)')
- [Update(TState, System.Span&lt;TComponent&gt;)](./DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_System-Span-TComponent-).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState, System.Span&lt;TComponent&gt;)')
