#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;')
## AEntityBufferedSystem&lt;T&gt;.Update(T) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-AEntityBufferedSystem-T--IsEnabled.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.IsEnabled') is false or if the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') is empty.  
```C#
public void Update(T state);
```
#### Parameters
<a name='DefaultEcs-System-AEntityBufferedSystem-T--Update(T)-state'></a>
`state` [T](./DefaultEcs-System-AEntityBufferedSystem-T-.md#DefaultEcs-System-AEntityBufferedSystem-T--T 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.T')  
The state to use.  
  
