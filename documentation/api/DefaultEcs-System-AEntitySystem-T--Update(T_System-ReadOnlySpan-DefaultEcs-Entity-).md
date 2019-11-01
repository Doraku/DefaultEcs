#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## AEntitySystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;) Method
Update the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances once.  
```C#
protected virtual void Update(T state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-state'></a>
state [T](./DefaultEcs-System-AEntitySystem-T-.md#DefaultEcs-System-AEntitySystem-T--T 'DefaultEcs.System.AEntitySystem&lt;T&gt;.T')  
The state to use.  
<a name='DefaultEcs-System-AEntitySystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-)-entities'></a>
entities [System.ReadOnlySpan](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan 'System.ReadOnlySpan')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to update.  
