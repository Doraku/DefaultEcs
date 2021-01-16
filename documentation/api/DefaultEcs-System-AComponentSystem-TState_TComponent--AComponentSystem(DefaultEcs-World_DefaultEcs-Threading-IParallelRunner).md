#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner) Constructor
Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](./DefaultEcs-System-AComponentSystem-TState_TComponent--World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') and [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AComponentSystem-TState_TComponent--World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') on which to process the update.  
  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner)-world 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner).world') is null.  
