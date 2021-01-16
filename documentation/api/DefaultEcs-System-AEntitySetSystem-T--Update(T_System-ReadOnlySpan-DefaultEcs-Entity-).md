#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;) Method
Update the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances once.  
```csharp
protected virtual void Update(T state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-state'></a>
`state` [T](./DefaultEcs-System-AEntitySetSystem-T-.md#DefaultEcs-System-AEntitySetSystem-T--T 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.T')  
The state to use.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to update.  
  
