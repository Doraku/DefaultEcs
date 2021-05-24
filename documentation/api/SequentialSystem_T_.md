#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## SequentialSystem&lt;T&gt; Class
Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update sequentially.  
```csharp
public sealed class SequentialSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_SequentialSystem_T__T'></a>
`T`  
The type of the object used as state to update the systems.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SequentialSystem&lt;T&gt;  

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](SequentialSystem_T_.md#DefaultEcs_System_SequentialSystem_T__T 'DefaultEcs.System.SequentialSystem&lt;T&gt;.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [SequentialSystem(ISystem&lt;T&gt;[])](SequentialSystem_T__SequentialSystem(ISystem_T___).md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(DefaultEcs.System.ISystem&lt;T&gt;[])') | Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') class.<br/> |
| [SequentialSystem(IEnumerable&lt;ISystem&lt;T&gt;&gt;)](SequentialSystem_T__SequentialSystem(IEnumerable_ISystem_T__).md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)') | Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') class.<br/> |

| Properties | |
| :--- | :--- |
| [IsEnabled](SequentialSystem_T__IsEnabled.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.IsEnabled') | Gets or sets whether the current [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') instance should update or not.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](SequentialSystem_T__Dispose().md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.Dispose()') | Disposes all the inner [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.<br/> |
| [Update(T)](SequentialSystem_T__Update(T).md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.Update(T)') | Updates all the systems once sequentially.<br/> |
