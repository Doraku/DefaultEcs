#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState) Method
Updates the system once.  
Does nothing if [IsEnabled](AEntityMultiMapSystem_TState_TKey__IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.IsEnabled') is false or if the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') is empty.  
```csharp
public void Update(TState state);
```
#### Parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__Update(TState)_state'></a>
`state` [TState](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')  
The state to use.
  

Implements [Update(T)](ISystem_T__Update(T).md 'DefaultEcs.System.ISystem&lt;T&gt;.Update(T)')  
