#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(World, Func&lt;object,World,EntityMultiMap&lt;TKey&gt;&gt;, bool) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](World.md 'DefaultEcs.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>> factory, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___bool)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___bool)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___bool).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___bool)_world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool).world') is null.
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___bool).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntityMultiMap_TKey___bool)_factory 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool).factory') is null.
