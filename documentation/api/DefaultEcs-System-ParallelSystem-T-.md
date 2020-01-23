#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ParallelSystem&lt;T&gt; Class
Represents a collection of [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update in parallel.  
```csharp
public sealed class ParallelSystem<T> :
ISystem<T>,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-ParallelSystem-T--T'></a>
`T`  
The type of the object used as state to update the systems.  
  
### Constructors
- [ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[])](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_DefaultEcs-System-ISystem-T---).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[])')
- [ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)')
- [ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[])](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-Threading-IParallelRunner_DefaultEcs-System-ISystem-T---).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[])')
- [ParallelSystem(DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-ParallelSystem-T--IsEnabled.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-ParallelSystem-T--Dispose().md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.Dispose()')
- [Update(T)](./DefaultEcs-System-ParallelSystem-T--Update(T).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.Update(T)')
