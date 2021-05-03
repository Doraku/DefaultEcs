#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(World, bool) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_bool)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_bool).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_World_bool)_world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, bool).world') is null.
