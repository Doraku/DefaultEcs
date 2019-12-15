#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## AEntitySystem&lt;T&gt;.Update(T) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-AEntitySystem-T--IsEnabled.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.IsEnabled') is false or if the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') is empty.  
```C#
public void Update(T state);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySystem-T--Update(T)-state'></a>
`state` [T](./DefaultEcs-System-AEntitySystem-T-.md#DefaultEcs-System-AEntitySystem-T--T 'DefaultEcs.System.AEntitySystem&lt;T&gt;.T')  
The state to use.  
  
