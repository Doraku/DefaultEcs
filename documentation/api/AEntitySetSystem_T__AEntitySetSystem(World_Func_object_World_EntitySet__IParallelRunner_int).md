#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.AEntitySetSystem(World, Func&lt;object,World,EntitySet&gt;, IParallelRunner, int) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [World](AEntitySetSystem_T__World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') and factory.  
The current instance will be passed as the first parameter of the factory.  
```csharp
protected AEntitySetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet> factory, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AEntitySetSystem_T__World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[EntitySet](EntitySet.md 'DefaultEcs.EntitySet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntitySetSystem_T__AEntitySetSystem(World_Func_object_World_EntitySet__IParallelRunner_int).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_runner 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int).runner').
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySetSystem_T__AEntitySetSystem(World_Func_object_World_EntitySet__IParallelRunner_int).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_world 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int).world') is null.
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntitySetSystem_T__AEntitySetSystem(World_Func_object_World_EntitySet__IParallelRunner_int).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__DefaultEcs_Threading_IParallelRunner_int)_factory 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int).factory') is null.
