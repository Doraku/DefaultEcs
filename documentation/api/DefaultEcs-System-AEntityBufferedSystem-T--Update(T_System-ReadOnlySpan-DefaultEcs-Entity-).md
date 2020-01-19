#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;')
## AEntityBufferedSystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;) Method
Update the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances once.  
```C#
protected virtual void Update(T state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-System-AEntityBufferedSystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-state'></a>
`state` [T](./DefaultEcs-System-AEntityBufferedSystem-T-.md#DefaultEcs-System-AEntityBufferedSystem-T--T 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.T')  
The state to use.  
  
<a name='DefaultEcs-System-AEntityBufferedSystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to update.  
  
