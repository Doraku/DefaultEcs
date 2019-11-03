#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ParallelSystem&lt;T&gt; Class
Represents a collection of [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update in parallel.  
```C#
public sealed class ParallelSystem<T> : ASystem<T>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [DefaultEcs.System.ASystem&lt;](./DefaultEcs-System-ASystem-T-.md 'DefaultEcs.System.ASystem&lt;T&gt;')[T](#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ASystem-T-.md 'DefaultEcs.System.ASystem&lt;T&gt;') &gt; [ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')  
#### Type parameters
<a name='DefaultEcs-System-ParallelSystem-T--T'></a>
`T`  
The type of the object used as state to update the systems.  
  
### Constructors
- [ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.System.SystemRunner&lt;T&gt;, DefaultEcs.System.ISystem&lt;T&gt;[])](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-System-SystemRunner-T-_DefaultEcs-System-ISystem-T---).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.System.SystemRunner&lt;T&gt;, DefaultEcs.System.ISystem&lt;T&gt;[])')
- [ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.System.SystemRunner&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-System-SystemRunner-T-_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.System.SystemRunner&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)')
- [ParallelSystem(DefaultEcs.System.SystemRunner&lt;T&gt;, DefaultEcs.System.ISystem&lt;T&gt;[])](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-SystemRunner-T-_DefaultEcs-System-ISystem-T---).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.SystemRunner&lt;T&gt;, DefaultEcs.System.ISystem&lt;T&gt;[])')
- [ParallelSystem(DefaultEcs.System.SystemRunner&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)](./DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-SystemRunner-T-_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.SystemRunner&lt;T&gt;, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)')
### Methods
- [Dispose()](./DefaultEcs-System-ParallelSystem-T--Dispose().md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.Dispose()')
- [PreUpdate(T)](./DefaultEcs-System-ParallelSystem-T--PreUpdate(T).md 'DefaultEcs.System.ParallelSystem&lt;T&gt;.PreUpdate(T)')
