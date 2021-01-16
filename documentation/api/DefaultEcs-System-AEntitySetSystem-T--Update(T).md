#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.Update(T) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-AEntitySetSystem-T--IsEnabled.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.IsEnabled') is false or if the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') is empty.  
```csharp
public void Update(T state);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--Update(T)-state'></a>
`state` [T](./DefaultEcs-System-AEntitySetSystem-T-.md#DefaultEcs-System-AEntitySetSystem-T--T 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.T')  
The state to use.  
  
