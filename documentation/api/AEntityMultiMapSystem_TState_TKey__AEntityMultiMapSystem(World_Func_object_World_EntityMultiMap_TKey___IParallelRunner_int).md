#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(World, Func&lt;object,World,EntityMultiMap&lt;TKey&gt;&gt;, IParallelRunner, int) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') and factory.  
The current instance will be passed as the first parameter of the factory.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>> factory, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_runner 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int).runner').
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int).world') is null.
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___IParallelRunner_int).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___DefaultEcs_Threading_IParallelRunner_int)_factory 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int).factory') is null.
