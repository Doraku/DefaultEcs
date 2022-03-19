#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>')

## AEntitySortedSetSystem<TState,TComponent>.Update(TState, Entity) Method

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once.

```csharp
protected virtual void Update(TState state, in DefaultEcs.Entity entity);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.Update(TState,DefaultEcs.Entity).state'></a>

`state` [TState](AEntitySortedSetSystem_TState,TComponent_.md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TState 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.TState')

The state to use.

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.Update(TState,DefaultEcs.Entity).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') instance to update.