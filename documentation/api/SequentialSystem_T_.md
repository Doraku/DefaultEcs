#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## SequentialSystem<T> Class

Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') to update sequentially.

```csharp
public sealed class SequentialSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.SequentialSystem_T_.T'></a>

`T`

The type of the object used as state to update the systems.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SequentialSystem<T>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](SequentialSystem_T_.md#DefaultEcs.System.SequentialSystem_T_.T 'DefaultEcs.System.SequentialSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [SequentialSystem(ISystem&lt;T&gt;[])](SequentialSystem_T_.SequentialSystem(ISystem_T_[]).md 'DefaultEcs.System.SequentialSystem<T>.SequentialSystem(DefaultEcs.System.ISystem<T>[])') | Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>') class. |
| [SequentialSystem(IEnumerable&lt;ISystem&lt;T&gt;&gt;)](SequentialSystem_T_.SequentialSystem(IEnumerable_ISystem_T__).md 'DefaultEcs.System.SequentialSystem<T>.SequentialSystem(System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>>)') | Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>') class. |

| Properties | |
| :--- | :--- |
| [IsEnabled](SequentialSystem_T_.IsEnabled.md 'DefaultEcs.System.SequentialSystem<T>.IsEnabled') | Gets or sets whether the current [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>') instance should update or not. |

| Methods | |
| :--- | :--- |
| [Dispose()](SequentialSystem_T_.Dispose().md 'DefaultEcs.System.SequentialSystem<T>.Dispose()') | Disposes all the inner [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instances. |
| [Update(T)](SequentialSystem_T_.Update(T).md 'DefaultEcs.System.SequentialSystem<T>.Update(T)') | Updates all the systems once sequentially. |
