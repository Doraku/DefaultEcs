#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ASystem&lt;T&gt; Class
Represents a base class to process updates, supporting a [SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;'). Do not inherit from this class directly.  
```C#
public abstract class ASystem<T>
```
#### Type parameters
<a name='DefaultEcs-System-ASystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
### Constructors
- [ASystem(DefaultEcs.System.SystemRunner&lt;T&gt;)](./DefaultEcs-System-ASystem-T--ASystem(DefaultEcs-System-SystemRunner-T-).md 'DefaultEcs.System.ASystem&lt;T&gt;.ASystem(DefaultEcs.System.SystemRunner&lt;T&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-ASystem-T--IsEnabled.md 'DefaultEcs.System.ASystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-ASystem-T--Dispose().md 'DefaultEcs.System.ASystem&lt;T&gt;.Dispose()')
- [PostUpdate(T)](./DefaultEcs-System-ASystem-T--PostUpdate(T).md 'DefaultEcs.System.ASystem&lt;T&gt;.PostUpdate(T)')
- [PreUpdate(T)](./DefaultEcs-System-ASystem-T--PreUpdate(T).md 'DefaultEcs.System.ASystem&lt;T&gt;.PreUpdate(T)')
- [Update(T)](./DefaultEcs-System-ASystem-T--Update(T).md 'DefaultEcs.System.ASystem&lt;T&gt;.Update(T)')
