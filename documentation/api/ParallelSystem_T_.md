#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## ParallelSystem&lt;T&gt; Class
Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update in parallel.  
```csharp
public sealed class ParallelSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_ParallelSystem_T__T'></a>
`T`  
The type of the object used as state to update the systems.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ParallelSystem&lt;T&gt;  

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](ParallelSystem_T_.md#DefaultEcs_System_ParallelSystem_T__T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [ParallelSystem(ISystem&lt;T&gt;, IParallelRunner, ISystem&lt;T&gt;[])](ParallelSystem_T__ParallelSystem(ISystem_T__IParallelRunner_ISystem_T___).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[])') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.<br/> |
| [ParallelSystem(ISystem&lt;T&gt;, IParallelRunner, IEnumerable&lt;ISystem&lt;T&gt;&gt;)](ParallelSystem_T__ParallelSystem(ISystem_T__IParallelRunner_IEnumerable_ISystem_T__).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.<br/> |
| [ParallelSystem(IParallelRunner, ISystem&lt;T&gt;[])](ParallelSystem_T__ParallelSystem(IParallelRunner_ISystem_T___).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[])') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.<br/> |
| [ParallelSystem(IParallelRunner, IEnumerable&lt;ISystem&lt;T&gt;&gt;)](ParallelSystem_T__ParallelSystem(IParallelRunner_IEnumerable_ISystem_T__).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.<br/> |

| Properties | |
| :--- | :--- |
| [IsEnabled](ParallelSystem_T__IsEnabled.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.IsEnabled') | Gets or sets whether the current [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') instance should update or not.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](ParallelSystem_T__Dispose().md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.Dispose()') | Disposes all the inner [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.<br/> |
| [Update(T)](ParallelSystem_T__Update(T).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.Update(T)') | Updates the system once.<br/> |
