#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>')

## AEntitySortedSetSystem<TState,TComponent>.Update(TState) Method

Updates the system once.  
Does nothing if [IsEnabled](AEntitySortedSetSystem_TState,TComponent_.IsEnabled.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.IsEnabled') is false or if the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') is empty.

```csharp
public void Update(TState state);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.Update(TState).state'></a>

`state` [TState](AEntitySortedSetSystem_TState,TComponent_.md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TState 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.TState')

The state to use.

Implements [Update(T)](ISystem_T_.Update(T).md 'DefaultEcs.System.ISystem<T>.Update(T)')