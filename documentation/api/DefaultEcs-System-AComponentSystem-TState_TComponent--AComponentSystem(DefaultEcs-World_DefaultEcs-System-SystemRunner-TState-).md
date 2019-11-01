#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;) Constructor
Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](./DefaultEcs-World.md 'DefaultEcs.World') and [SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;').  
```C#
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.System.SystemRunner<TState> runner);
```
#### Parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-System-SystemRunner-TState-)-world'></a>
world [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') on which to process the update.  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-System-SystemRunner-TState-)-runner'></a>
runner [SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;')  
The [SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;') used to process the update in parallel if not null.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-System-SystemRunner-TState-)-world 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;).world') is null.  
