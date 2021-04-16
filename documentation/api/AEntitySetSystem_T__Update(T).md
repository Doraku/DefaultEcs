#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.Update(T) Method
Updates the system once.  
Does nothing if [IsEnabled](AEntitySetSystem_T__IsEnabled.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.IsEnabled') is false or if the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') is empty.  
```csharp
public void Update(T state);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__Update(T)_state'></a>
`state` [T](AEntitySetSystem_T_.md#DefaultEcs_System_AEntitySetSystem_T__T 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.T')  
The state to use.
  
