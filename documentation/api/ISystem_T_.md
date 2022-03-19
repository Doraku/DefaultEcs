#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## ISystem<T> Interface

Exposes a method to update a system.

```csharp
public interface ISystem<in T> :
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.ISystem_T_.T'></a>

`T`

The type of the object used as state to update the system.

Derived  
&#8627; [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')  
&#8627; [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem<T>')  
&#8627; [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')  
&#8627; [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')  
&#8627; [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>')  
&#8627; [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem<T>')  
&#8627; [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [IsEnabled](ISystem_T_.IsEnabled.md 'DefaultEcs.System.ISystem<T>.IsEnabled') | Gets or sets whether the current [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instance should update or not. |

| Methods | |
| :--- | :--- |
| [Update(T)](ISystem_T_.Update(T).md 'DefaultEcs.System.ISystem<T>.Update(T)') | Updates the system once.<br/>Does nothing if [IsEnabled](ISystem_T_.IsEnabled.md 'DefaultEcs.System.ISystem<T>.IsEnabled') is false. |
