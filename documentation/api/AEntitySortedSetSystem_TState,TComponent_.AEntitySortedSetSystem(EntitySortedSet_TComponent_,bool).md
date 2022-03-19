#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>')

## AEntitySortedSetSystem(EntitySortedSet<TComponent>, bool) Constructor

Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>') class with the given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>').

```csharp
protected AEntitySortedSetSystem(DefaultEcs.EntitySortedSet<TComponent> sortedSet, bool useBuffer=false);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet_TComponent_,bool).sortedSet'></a>

`sortedSet` [DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')[TComponent](AEntitySortedSetSystem_TState,TComponent_.md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')

The [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet_TComponent_,bool).useBuffer'></a>

`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the entities should be copied before being processed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[sortedSet](AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(EntitySortedSet_TComponent_,bool).md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet_TComponent_,bool).sortedSet 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet<TComponent>, bool).sortedSet') is null.