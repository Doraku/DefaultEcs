#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ActionSystem&lt;T&gt; Class
Represents a class to set up easily a custom action as a system update.  
```csharp
public sealed class ActionSystem<T> :
ISystem<T>,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [ActionSystem&lt;T&gt;](./DefaultEcs-System-ActionSystem-T-.md 'DefaultEcs.System.ActionSystem&lt;T&gt;')  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](#DefaultEcs-System-ActionSystem-T--T 'DefaultEcs.System.ActionSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-ActionSystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Constructors
- [ActionSystem(System.Action&lt;T&gt;)](./DefaultEcs-System-ActionSystem-T--ActionSystem(System-Action-T-).md 'DefaultEcs.System.ActionSystem&lt;T&gt;.ActionSystem(System.Action&lt;T&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-ActionSystem-T--IsEnabled.md 'DefaultEcs.System.ActionSystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-ActionSystem-T--Dispose().md 'DefaultEcs.System.ActionSystem&lt;T&gt;.Dispose()')
- [Update(T)](./DefaultEcs-System-ActionSystem-T--Update(T).md 'DefaultEcs.System.ActionSystem&lt;T&gt;.Update(T)')
