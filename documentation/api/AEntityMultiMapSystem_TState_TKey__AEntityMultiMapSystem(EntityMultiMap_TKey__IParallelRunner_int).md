#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, IParallelRunner, int) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey> map, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex=0);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__DefaultEcs_Threading_IParallelRunner_int)_map'></a>
`map` [DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')  
The [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') on which to process the update.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__DefaultEcs_Threading_IParallelRunner_int)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__DefaultEcs_Threading_IParallelRunner_int)_minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey__IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__DefaultEcs_Threading_IParallelRunner_int)_runner 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int).runner').
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey__IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__DefaultEcs_Threading_IParallelRunner_int)_map 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int).map') is null.
