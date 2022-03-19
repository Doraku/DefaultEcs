#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>')

## ParallelSystem(ISystem<T>, IParallelRunner, ISystem<T>[]) Constructor

Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') class.

```csharp
public ParallelSystem(DefaultEcs.System.ISystem<T> mainSystem, DefaultEcs.Threading.IParallelRunner runner, params DefaultEcs.System.ISystem<T>[] systems);
```
#### Parameters

<a name='DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.System.ISystem_T_,DefaultEcs.Threading.IParallelRunner,DefaultEcs.System.ISystem_T_[]).mainSystem'></a>

`mainSystem` [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](ParallelSystem_T_.md#DefaultEcs.System.ParallelSystem_T_.T 'DefaultEcs.System.ParallelSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')

The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instance to be updated on the calling thread.

<a name='DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.System.ISystem_T_,DefaultEcs.Threading.IParallelRunner,DefaultEcs.System.ISystem_T_[]).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.System.ISystem_T_,DefaultEcs.Threading.IParallelRunner,DefaultEcs.System.ISystem_T_[]).systems'></a>

`systems` [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](ParallelSystem_T_.md#DefaultEcs.System.ParallelSystem_T_.T 'DefaultEcs.System.ParallelSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instances.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[runner](ParallelSystem_T_.ParallelSystem(ISystem_T_,IParallelRunner,ISystem_T_[]).md#DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.System.ISystem_T_,DefaultEcs.Threading.IParallelRunner,DefaultEcs.System.ISystem_T_[]).runner 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.System.ISystem<T>, DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem<T>[]).runner') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](ParallelSystem_T_.ParallelSystem(ISystem_T_,IParallelRunner,ISystem_T_[]).md#DefaultEcs.System.ParallelSystem_T_.ParallelSystem(DefaultEcs.System.ISystem_T_,DefaultEcs.Threading.IParallelRunner,DefaultEcs.System.ISystem_T_[]).systems 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.System.ISystem<T>, DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem<T>[]).systems') is null.