#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')
## ISystem&lt;T&gt;.Update(T) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-ISystem-T--IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled') is false.  
```C#
void Update(T state);
```
#### Parameters
<a name='DefaultEcs-System-ISystem-T--Update(T)-state'></a>
`state` [T](./DefaultEcs-System-ISystem-T-.md#DefaultEcs-System-ISystem-T--T 'DefaultEcs.System.ISystem&lt;T&gt;.T')  
The state to use.  
  
