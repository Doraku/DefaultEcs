#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')
## ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;) Constructor
Initialises a new instance of the [ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.  
```C#
public ParallelSystem(DefaultEcs.System.ISystem<T> mainSystem, DefaultEcs.Threading.IParallelRunner runner, System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>> systems);
```
#### Parameters
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-mainSystem'></a>
`mainSystem` [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-ParallelSystem-T-.md#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instance to be updated on the calling thread.  
  
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-systems'></a>
`systems` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-ParallelSystem-T-.md#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[runner](#DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-runner 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;).runner') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](#DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-Threading-IParallelRunner_System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-systems 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;).systems') is null.  
