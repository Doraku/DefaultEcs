#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.Update(T, ReadOnlySpan&lt;Entity&gt;) Method
Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.  
```csharp
protected virtual void Update(T state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__Update(T_System_ReadOnlySpan_DefaultEcs_Entity_)_state'></a>
`state` [T](AEntitySetSystem_T_.md#DefaultEcs_System_AEntitySetSystem_T__T 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.T')  
The state to use.
  
<a name='DefaultEcs_System_AEntitySetSystem_T__Update(T_System_ReadOnlySpan_DefaultEcs_Entity_)_entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](Entity.md 'DefaultEcs.Entity') instances to update.
  
