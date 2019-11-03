#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')
## ParallelSystem(DefaultEcs.System.ISystem&lt;T&gt;, DefaultEcs.System.SystemRunner&lt;T&gt;, DefaultEcs.System.ISystem&lt;T&gt;[]) Constructor
Initialises a new instance of the [ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.  
```C#
public ParallelSystem(DefaultEcs.System.ISystem<T> mainSystem, DefaultEcs.System.SystemRunner<T> runner, params DefaultEcs.System.ISystem<T>[] systems);
```
#### Parameters
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-System-SystemRunner-T-_DefaultEcs-System-ISystem-T---)-mainSystem'></a>
`mainSystem` [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-ParallelSystem-T-.md#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instance to be updated on the calling thread.  
  
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-System-SystemRunner-T-_DefaultEcs-System-ISystem-T---)-runner'></a>
`runner` [DefaultEcs.System.SystemRunner&lt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;')[T](./DefaultEcs-System-ParallelSystem-T-.md#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;')  
The [SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-System-ISystem-T-_DefaultEcs-System-SystemRunner-T-_DefaultEcs-System-ISystem-T---)-systems'></a>
`systems` [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-ParallelSystem-T-.md#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.  
  
