#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;')
## AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(EntitySortedSet&lt;TComponent&gt;, bool) Constructor
Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;').  
```csharp
protected AEntitySortedSetSystem(DefaultEcs.EntitySortedSet<TComponent> sortedSet, bool useBuffer=false);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_EntitySortedSet_TComponent__bool)_sortedSet'></a>
`sortedSet` [DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')[TComponent](AEntitySortedSetSystem_TState_TComponent_.md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TComponent 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')  
The [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.
  
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_EntitySortedSet_TComponent__bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[sortedSet](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(EntitySortedSet_TComponent__bool).md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_EntitySortedSet_TComponent__bool)_sortedSet 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet&lt;TComponent&gt;, bool).sortedSet') is null.
