#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AComponentSystem&lt;TState,TComponent&gt; Class
Represents a base class to process updates on a given [World](./DefaultEcs-World.md 'DefaultEcs.World') instance to all its components of type [TComponent](#DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent').  
```csharp
public abstract class AComponentSystem<TState,TComponent> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AComponentSystem&lt;TState,TComponent&gt;  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[TState](#DefaultEcs-System-AComponentSystem-TState_TComponent--TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--TState'></a>
`TState`  
The type of the object used as state to update the system.  
  
<a name='DefaultEcs-System-AComponentSystem-TState_TComponent--TComponent'></a>
`TComponent`  
The type of component to update.  
  
### Constructors
- [AComponentSystem(DefaultEcs.World)](./DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World)')
- [AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')
- [AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AComponentSystem-TState_TComponent--AComponentSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')
### Properties
- [IsEnabled](./DefaultEcs-System-AComponentSystem-TState_TComponent--IsEnabled.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AComponentSystem-TState_TComponent--Dispose().md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Dispose()')
- [PostUpdate(TState)](./DefaultEcs-System-AComponentSystem-TState_TComponent--PostUpdate(TState).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.PostUpdate(TState)')
- [PreUpdate(TState)](./DefaultEcs-System-AComponentSystem-TState_TComponent--PreUpdate(TState).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.PreUpdate(TState)')
- [Update(TState)](./DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState)')
- [Update(TState, TComponent)](./DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_TComponent).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState, TComponent)')
- [Update(TState, System.Span&lt;TComponent&gt;)](./DefaultEcs-System-AComponentSystem-TState_TComponent--Update(TState_System-Span-TComponent-).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState, System.Span&lt;TComponent&gt;)')
