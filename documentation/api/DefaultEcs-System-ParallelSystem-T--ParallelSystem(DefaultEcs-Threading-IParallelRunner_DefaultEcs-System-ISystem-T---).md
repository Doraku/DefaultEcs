#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')
## ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[]) Constructor
Initialises a new instance of the [ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') class.  
```csharp
public ParallelSystem(DefaultEcs.Threading.IParallelRunner runner, params DefaultEcs.System.ISystem<T>[] systems);
```
#### Parameters
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-Threading-IParallelRunner_DefaultEcs-System-ISystem-T---)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-Threading-IParallelRunner_DefaultEcs-System-ISystem-T---)-systems'></a>
`systems` [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-ParallelSystem-T-.md#DefaultEcs-System-ParallelSystem-T--T 'DefaultEcs.System.ParallelSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[runner](#DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-Threading-IParallelRunner_DefaultEcs-System-ISystem-T---)-runner 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[]).runner') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](#DefaultEcs-System-ParallelSystem-T--ParallelSystem(DefaultEcs-Threading-IParallelRunner_DefaultEcs-System-ISystem-T---)-systems 'DefaultEcs.System.ParallelSystem&lt;T&gt;.ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem&lt;T&gt;[]).systems') is null.  
