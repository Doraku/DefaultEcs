#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## AEntitySystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;) Method
Update the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances once.  
```csharp
protected virtual void Update(T state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-state'></a>
`state` [T](./DefaultEcs-System-AEntitySystem-T-.md#DefaultEcs-System-AEntitySystem-T--T 'DefaultEcs.System.AEntitySystem&lt;T&gt;.T')  
The state to use.  
  
<a name='DefaultEcs-System-AEntitySystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to update.  
  
