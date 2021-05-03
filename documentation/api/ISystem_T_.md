#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## ISystem&lt;T&gt; Interface
Exposes a method to update a system.  
```csharp
public interface ISystem<in T> :
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_ISystem_T__T'></a>
`T`  
The type of the object used as state to update the system.
  

Derived  
&#8627; [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')  
&#8627; [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem&lt;T&gt;')  
&#8627; [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')  
&#8627; [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')  
&#8627; [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')  
&#8627; [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Properties

***
[IsEnabled](ISystem_T__IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled')

Gets or sets whether the current [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') instance should update or not.  
### Methods

***
[Update(T)](ISystem_T__Update(T).md 'DefaultEcs.System.ISystem&lt;T&gt;.Update(T)')

Updates the system once.  
Does nothing if [IsEnabled](ISystem_T__IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled') is false.  
