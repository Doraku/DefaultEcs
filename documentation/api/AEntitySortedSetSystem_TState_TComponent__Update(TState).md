#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;')
## AEntitySortedSetSystem&lt;TState,TComponent&gt;.Update(TState) Method
Updates the system once.  
Does nothing if [IsEnabled](AEntitySortedSetSystem_TState_TComponent__IsEnabled.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.IsEnabled') is false or if the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') is empty.  
```csharp
public void Update(TState state);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__Update(TState)_state'></a>
`state` [TState](AEntitySortedSetSystem_TState_TComponent_.md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TState 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.TState')  
The state to use.
  

Implements [Update(T)](ISystem_T__Update(T).md 'DefaultEcs.System.ISystem&lt;T&gt;.Update(T)')  
