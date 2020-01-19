#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AEntitySystem&lt;T&gt; Class
Represents a base class to process updates on a given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') instance.  
Only [Get&lt;T&gt;()](./DefaultEcs-Entity-Get-T-().md 'DefaultEcs.Entity.Get&lt;T&gt;()'), [Set&lt;T&gt;(T)](./DefaultEcs-Entity-Set-T-(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') and [SetSameAs&lt;T&gt;(DefaultEcs.Entity)](./DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') operation on already present component type are safe.  
```C#
public abstract class AEntitySystem<T> :
ISystem<T>,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](#DefaultEcs-System-AEntitySystem-T--T 'DefaultEcs.System.AEntitySystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-AEntitySystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Constructors
- [AEntitySystem(DefaultEcs.EntitySet)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet)')
- [AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner)')
- [AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int)')
- [AEntitySystem(DefaultEcs.World)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.World)')
- [AEntitySystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')
- [AEntitySystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner_int).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntitySystem-T--IsEnabled.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AEntitySystem-T--Dispose().md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Dispose()')
- [PostUpdate(T)](./DefaultEcs-System-AEntitySystem-T--PostUpdate(T).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.PostUpdate(T)')
- [PreUpdate(T)](./DefaultEcs-System-AEntitySystem-T--PreUpdate(T).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.PreUpdate(T)')
- [Update(T)](./DefaultEcs-System-AEntitySystem-T--Update(T).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T)')
- [Update(T, DefaultEcs.Entity)](./DefaultEcs-System-AEntitySystem-T--Update(T_DefaultEcs-Entity).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T, DefaultEcs.Entity)')
- [Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntitySystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
### Events
- [EntityAdded](./DefaultEcs-System-AEntitySystem-T--EntityAdded.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.EntityAdded')
- [EntityRemoved](./DefaultEcs-System-AEntitySystem-T--EntityRemoved.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.EntityRemoved')
