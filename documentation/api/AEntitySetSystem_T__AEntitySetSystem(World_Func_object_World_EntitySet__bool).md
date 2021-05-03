#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.AEntitySetSystem(World, Func&lt;object,World,EntitySet&gt;, bool) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [World](AEntitySetSystem_T__World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World').  
To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntitySetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet> factory, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__bool)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AEntitySetSystem_T__World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__bool)_factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[EntitySet](EntitySet.md 'DefaultEcs.EntitySet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySetSystem_T__AEntitySetSystem(World_Func_object_World_EntitySet__bool).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__bool)_world 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool).world') is null.
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntitySetSystem_T__AEntitySetSystem(World_Func_object_World_EntitySet__bool).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World_System_Func_object_DefaultEcs_World_DefaultEcs_EntitySet__bool)_factory 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool).factory') is null.
