#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;')
## AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(World, Func&lt;object,World,EntitySortedSet&lt;TComponent&gt;&gt;, bool) Constructor
Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [World](World.md 'DefaultEcs.World') and factory.  
To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntitySortedSetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySortedSet<TComponent>> factory, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySortedSet_TComponent___bool)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySortedSet_TComponent___bool)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')[TComponent](AEntitySortedSetSystem_TState_TComponent_.md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TComponent 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;').
  
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySortedSet_TComponent___bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(World_Func_object_World_EntitySortedSet_TComponent___bool).md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySortedSet_TComponent___bool)_world 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySortedSet&lt;TComponent&gt;&gt;, bool).world') is null.
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(World_Func_object_World_EntitySortedSet_TComponent___bool).md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySortedSet_TComponent___bool)_factory 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySortedSet&lt;TComponent&gt;&gt;, bool).factory') is null.
