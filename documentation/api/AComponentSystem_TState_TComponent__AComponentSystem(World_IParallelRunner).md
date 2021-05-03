#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(World, IParallelRunner) Constructor
Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') on which to process the update.
  
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AComponentSystem_TState_TComponent__AComponentSystem(World_IParallelRunner).md#DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner)_world 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner).world') is null.
