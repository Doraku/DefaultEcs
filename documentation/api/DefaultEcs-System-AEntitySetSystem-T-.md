#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AEntitySetSystem&lt;T&gt; Class
Represents a base class to process updates on a given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') instance.  
Only [Get&lt;T&gt;()](./DefaultEcs-Entity-Get-T-().md 'DefaultEcs.Entity.Get&lt;T&gt;()'), [Set&lt;T&gt;(T)](./DefaultEcs-Entity-Set-T-(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') and [SetSameAs&lt;T&gt;(DefaultEcs.Entity)](./DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') operation on already present component type are safe.  
```csharp
public abstract class AEntitySetSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntitySetSystem&lt;T&gt;  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](#DefaultEcs-System-AEntitySetSystem-T--T 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Constructors
- [AEntitySetSystem(DefaultEcs.EntitySet)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet)')
- [AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner)')
- [AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntitySetSystem(DefaultEcs.EntitySet, bool)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_bool).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, bool)')
- [AEntitySetSystem(DefaultEcs.World)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World)')
- [AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')
- [AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntitySetSystem(DefaultEcs.World, bool)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_bool).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, bool)')
- [AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool)](./DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_bool).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntitySetSystem-T--IsEnabled.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.IsEnabled')
- [Set](./DefaultEcs-System-AEntitySetSystem-T--Set.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.Set')
- [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World')
### Methods
- [Dispose()](./DefaultEcs-System-AEntitySetSystem-T--Dispose().md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.Dispose()')
- [PostUpdate(T)](./DefaultEcs-System-AEntitySetSystem-T--PostUpdate(T).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.PostUpdate(T)')
- [PreUpdate(T)](./DefaultEcs-System-AEntitySetSystem-T--PreUpdate(T).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.PreUpdate(T)')
- [Update(T)](./DefaultEcs-System-AEntitySetSystem-T--Update(T).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.Update(T)')
- [Update(T, DefaultEcs.Entity)](./DefaultEcs-System-AEntitySetSystem-T--Update(T_DefaultEcs-Entity).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.Update(T, DefaultEcs.Entity)')
- [Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntitySetSystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
