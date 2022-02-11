#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, bool) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey> map, bool useBuffer=false);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__bool)_map'></a>
`map` [DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')  
The [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') on which to process the update.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey__bool).md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(DefaultEcs_EntityMultiMap_TKey__bool)_map 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, bool).map') is null.
