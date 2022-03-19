#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>')

## ParallelSystem(IParallelRunner, IEnumerable<ISystem<T>>) Constructor

Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') class.

```csharp
public ParallelSystem(DefaultEcs.Threading.IParallelRunner runner, System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>> systems);
```
#### Parameters

<a name='DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.Threading.IParallelRunner,System.Collections.Generic.IEnumerable_DefaultEcs.System.ISystem_T__).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.Threading.IParallelRunner,System.Collections.Generic.IEnumerable_DefaultEcs.System.ISystem_T__).systems'></a>

`systems` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](ParallelSystem_T_.md#DefaultEcs.System.ParallelSystem_T_.T 'DefaultEcs.System.ParallelSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instances.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[runner](ParallelSystem_T_.ParallelSystem(IParallelRunner,IEnumerable_ISystem_T__).md#DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.Threading.IParallelRunner,System.Collections.Generic.IEnumerable_DefaultEcs.System.ISystem_T__).runner 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>>).runner') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](ParallelSystem_T_.ParallelSystem(IParallelRunner,IEnumerable_ISystem_T__).md#DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.Threading.IParallelRunner,System.Collections.Generic.IEnumerable_DefaultEcs.System.ISystem_T__).systems 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>>).systems') is null.