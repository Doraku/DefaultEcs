#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(World, IParallelRunner, int) Constructor
Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner, int minComponentCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') on which to process the update.
  
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_minComponentCountByRunnerIndex'></a>
`minComponentCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of component per runner index to use the given [runner](AComponentSystem_TState_TComponent__AComponentSystem(World_IParallelRunner_int).md#DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_runner 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).runner').
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AComponentSystem_TState_TComponent__AComponentSystem(World_IParallelRunner_int).md#DefaultEcs_System_AComponentSystem_TState_TComponent__AComponentSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_world 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).world') is null.
