#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AEntitiesSystem&lt;TState,TKey&gt; Class
Represents a base class to process updates on a given [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') instance.  
```csharp
public abstract class AEntitiesSystem<TState,TKey> :
ISystem<TState>,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntitiesSystem&lt;TState,TKey&gt;  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[TState](#DefaultEcs-System-AEntitiesSystem-TState_TKey--TState 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TState')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--TState'></a>
`TState`  
The type of the object used as state to update the system.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey'></a>
`TKey`  
The type of the component used as key.  
  
### Constructors
- [AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;)')
- [AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner)')
- [AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntitiesSystem(DefaultEcs.World)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-World).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.World)')
- [AEntitiesSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')
- [AEntitiesSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntitiesSystem-TState_TKey--IsEnabled.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AEntitiesSystem-TState_TKey--Dispose().md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.Dispose()')
- [GetKeys()](./DefaultEcs-System-AEntitiesSystem-TState_TKey--GetKeys().md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.GetKeys()')
- [PostUpdate(TState)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--PostUpdate(TState).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.PostUpdate(TState)')
- [PostUpdate(TState, TKey)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--PostUpdate(TState_TKey).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.PostUpdate(TState, TKey)')
- [PreUpdate(TState)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--PreUpdate(TState).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.PreUpdate(TState)')
- [PreUpdate(TState, TKey)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--PreUpdate(TState_TKey).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.PreUpdate(TState, TKey)')
- [Update(TState)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.Update(TState)')
- [Update(TState, TKey, DefaultEcs.Entity)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_DefaultEcs-Entity).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.Update(TState, TKey, DefaultEcs.Entity)')
- [Update(TState, TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.Update(TState, TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
