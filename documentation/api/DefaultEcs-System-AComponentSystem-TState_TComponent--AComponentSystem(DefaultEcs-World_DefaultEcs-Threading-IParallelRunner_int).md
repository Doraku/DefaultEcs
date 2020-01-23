#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int) Constructor
Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](./DefaultEcs-World.md 'DefaultEcs.World') and [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner, int minComponentCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') on which to process the update.  
  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int)-minComponentCountByRunnerIndex'></a>
`minComponentCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of component per runner index to use the given [runner](#DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int)-runner 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).runner').  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int)-world 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).world') is null.  
