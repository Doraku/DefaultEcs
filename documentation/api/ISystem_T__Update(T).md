#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')
## ISystem&lt;T&gt;.Update(T) Method
Updates the system once.  
Does nothing if [IsEnabled](ISystem_T__IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled') is false.  
```csharp
void Update(T state);
```
#### Parameters
<a name='DefaultEcs_System_ISystem_T__Update(T)_state'></a>
`state` [T](ISystem_T_.md#DefaultEcs_System_ISystem_T__T 'DefaultEcs.System.ISystem&lt;T&gt;.T')  
The state to use.
  
