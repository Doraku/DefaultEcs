#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ISystem&lt;T&gt; Interface
Exposes a method to update a system.  
```csharp
public interface ISystem<in T> :
IDisposable
```
Derived  
&#8627; [AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')  
&#8627; [ActionSystem&lt;T&gt;](./DefaultEcs-System-ActionSystem-T-.md 'DefaultEcs.System.ActionSystem&lt;T&gt;')  
&#8627; [AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')  
&#8627; [AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;')  
&#8627; [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')  
&#8627; [ParallelSystem&lt;T&gt;](./DefaultEcs-System-ParallelSystem-T-.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')  
&#8627; [SequentialSystem&lt;T&gt;](./DefaultEcs-System-SequentialSystem-T-.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-ISystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Properties
- [IsEnabled](./DefaultEcs-System-ISystem-T--IsEnabled.md 'DefaultEcs.System.ISystem&lt;T&gt;.IsEnabled')
### Methods
- [Update(T)](./DefaultEcs-System-ISystem-T--Update(T).md 'DefaultEcs.System.ISystem&lt;T&gt;.Update(T)')
