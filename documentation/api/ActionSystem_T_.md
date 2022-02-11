#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## ActionSystem&lt;T&gt; Class
Represents a class to set up easily a custom action as a system update.  
```csharp
public sealed class ActionSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_ActionSystem_T__T'></a>
`T`  
The type of the object used as state to update the system.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ActionSystem&lt;T&gt;  

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](ActionSystem_T_.md#DefaultEcs_System_ActionSystem_T__T 'DefaultEcs.System.ActionSystem&lt;T&gt;.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [ActionSystem(Action&lt;T&gt;)](ActionSystem_T__ActionSystem(Action_T_).md 'DefaultEcs.System.ActionSystem&lt;T&gt;.ActionSystem(System.Action&lt;T&gt;)') | Initialises a new instance of the [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem&lt;T&gt;') class with the given [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1').<br/> |

| Properties | |
| :--- | :--- |
| [IsEnabled](ActionSystem_T__IsEnabled.md 'DefaultEcs.System.ActionSystem&lt;T&gt;.IsEnabled') | Gets or sets whether the current [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') instance should update or not.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](ActionSystem_T__Dispose().md 'DefaultEcs.System.ActionSystem&lt;T&gt;.Dispose()') | Does nothing.<br/> |
| [Update(T)](ActionSystem_T__Update(T).md 'DefaultEcs.System.ActionSystem&lt;T&gt;.Update(T)') | Updates the system once.<br/>Does nothing if [IsEnabled](ISystem_T__IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled') is false.<br/> |
