#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## ActionSystem<T> Class

Represents a class to set up easily a custom action as a system update.

```csharp
public sealed class ActionSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.ActionSystem_T_.T'></a>

`T`

The type of the object used as state to update the system.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ActionSystem<T>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](ActionSystem_T_.md#DefaultEcs.System.ActionSystem_T_.T 'DefaultEcs.System.ActionSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [ActionSystem(Action&lt;T&gt;)](ActionSystem_T_.ActionSystem(Action_T_).md 'DefaultEcs.System.ActionSystem<T>.ActionSystem(System.Action<T>)') | Initialises a new instance of the [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem<T>') class with the given [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1'). |

| Properties | |
| :--- | :--- |
| [IsEnabled](ActionSystem_T_.IsEnabled.md 'DefaultEcs.System.ActionSystem<T>.IsEnabled') | Gets or sets whether the current [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instance should update or not. |

| Methods | |
| :--- | :--- |
| [Dispose()](ActionSystem_T_.Dispose().md 'DefaultEcs.System.ActionSystem<T>.Dispose()') | Does nothing. |
| [Update(T)](ActionSystem_T_.Update(T).md 'DefaultEcs.System.ActionSystem<T>.Update(T)') | Updates the system once.<br/>Does nothing if [IsEnabled](ISystem_T_.IsEnabled.md 'DefaultEcs.System.ISystem<T>.IsEnabled') is false. |
