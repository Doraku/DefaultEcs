#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;')
## AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(EntitySortedSet&lt;TComponent&gt;) Constructor
Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;').  
```csharp
protected AEntitySortedSetSystem(DefaultEcs.EntitySortedSet<TComponent> sortedSet);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_EntitySortedSet_TComponent_)_sortedSet'></a>
`sortedSet` [DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')[TComponent](AEntitySortedSetSystem_TState_TComponent_.md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TComponent 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')  
The [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') on which to process the update.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[sortedSet](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(EntitySortedSet_TComponent_).md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(DefaultEcs_EntitySortedSet_TComponent_)_sortedSet 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet&lt;TComponent&gt;).sortedSet') is null.
