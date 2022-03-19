#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## ParallelSystem<T> Class

Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') to update in parallel.

```csharp
public sealed class ParallelSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.ParallelSystem_T_.T'></a>

`T`

The type of the object used as state to update the systems.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ParallelSystem<T>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](ParallelSystem_T_.md#DefaultEcs.System.ParallelSystem_T_.T 'DefaultEcs.System.ParallelSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [ParallelSystem(ISystem&lt;T&gt;, IParallelRunner, ISystem&lt;T&gt;[])](ParallelSystem_T_.ParallelSystem(ISystem_T_,IParallelRunner,ISystem_T_[]).md 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.System.ISystem<T>, DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem<T>[])') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') class. |
| [ParallelSystem(ISystem&lt;T&gt;, IParallelRunner, IEnumerable&lt;ISystem&lt;T&gt;&gt;)](ParallelSystem_T_.ParallelSystem(ISystem_T_,IParallelRunner,IEnumerable_ISystem_T__).md 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.System.ISystem<T>, DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>>)') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') class. |
| [ParallelSystem(IParallelRunner, ISystem&lt;T&gt;[])](ParallelSystem_T_.ParallelSystem(IParallelRunner,ISystem_T_[]).md 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.Threading.IParallelRunner, DefaultEcs.System.ISystem<T>[])') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') class. |
| [ParallelSystem(IParallelRunner, IEnumerable&lt;ISystem&lt;T&gt;&gt;)](ParallelSystem_T_.ParallelSystem(IParallelRunner,IEnumerable_ISystem_T__).md 'DefaultEcs.System.ParallelSystem<T>.ParallelSystem(DefaultEcs.Threading.IParallelRunner, System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>>)') | Initialises a new instance of the [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') class. |

| Properties | |
| :--- | :--- |
| [IsEnabled](ParallelSystem_T_.IsEnabled.md 'DefaultEcs.System.ParallelSystem<T>.IsEnabled') | Gets or sets whether the current [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>') instance should update or not. |

| Methods | |
| :--- | :--- |
| [Dispose()](ParallelSystem_T_.Dispose().md 'DefaultEcs.System.ParallelSystem<T>.Dispose()') | Disposes all the inner [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instances. |
| [Update(T)](ParallelSystem_T_.Update(T).md 'DefaultEcs.System.ParallelSystem<T>.Update(T)') | Updates the system once. |
