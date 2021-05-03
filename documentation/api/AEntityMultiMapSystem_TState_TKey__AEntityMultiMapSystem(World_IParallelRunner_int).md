#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(World, IParallelRunner, int) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_runner 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).runner').
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_DefaultEcs_Threading_IParallelRunner_int)_world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).world') is null.
