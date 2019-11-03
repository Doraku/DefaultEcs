#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ISystem&lt;T&gt; Interface
Exposes a method to update a system.  
```C#
public interface ISystem<in T> :
IDisposable
```
Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-ISystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Properties
- [IsEnabled](./DefaultEcs-System-ISystem-T--IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled')
### Methods
- [Update(T)](./DefaultEcs-System-ISystem-T--Update(T).md 'DefaultEcs.System.ISystem&lt;T&gt;.Update(T)')
