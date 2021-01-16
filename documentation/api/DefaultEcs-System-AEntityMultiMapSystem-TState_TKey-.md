#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AEntityMultiMapSystem&lt;TState,TKey&gt; Class
Represents a base class to process updates on a given [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') instance.  
```csharp
public abstract class AEntityMultiMapSystem<TState,TKey> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntityMultiMapSystem&lt;TState,TKey&gt;  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[TState](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TState'></a>
`TState`  
The type of the object used as state to update the system.  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TKey'></a>
`TKey`  
The type of the component used as key.  
  
### Constructors
- [AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-EntityMultiMap-TKey-).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;)')
- [AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-EntityMultiMap-TKey-_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner)')
- [AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-EntityMultiMap-TKey-_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, bool)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-EntityMultiMap-TKey-_bool).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, bool)')
- [AEntityMultiMapSystem(DefaultEcs.World)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World)')
- [AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')
- [AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntityMultiMapSystem(DefaultEcs.World, bool)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_bool).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, bool)')
- [AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_bool).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.IsEnabled')
- [MultiMap](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--MultiMap.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.MultiMap')
- [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World')
### Methods
- [Dispose()](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--Dispose().md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Dispose()')
- [GetKeys()](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--GetKeys().md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.GetKeys()')
- [PostUpdate(TState)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--PostUpdate(TState).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PostUpdate(TState)')
- [PostUpdate(TState, TKey)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--PostUpdate(TState_TKey).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PostUpdate(TState, TKey)')
- [PreUpdate(TState)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--PreUpdate(TState).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PreUpdate(TState)')
- [PreUpdate(TState, TKey)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--PreUpdate(TState_TKey).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PreUpdate(TState, TKey)')
- [Update(TState)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--Update(TState).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState)')
- [Update(TState, TKey, DefaultEcs.Entity)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--Update(TState_TKey_DefaultEcs-Entity).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState, TKey, DefaultEcs.Entity)')
- [Update(TState, TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--Update(TState_TKey_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState, TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
